using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse;

internal class SchemaParser : CommonParser
{
  public SchemaParser(Tokenizer tokens)
    : base(tokens) { }

  private delegate bool Parser<T>(SchemaParser parser, string description, out T declaration);

  private readonly Dictionary<string, Parser<AstDescribed>> _parsers = new() {
    ["category"] = ParserFor((SchemaParser parser, string description, out CategoryAst category)
      => parser.ParseCategory(out category, description)),
    ["output"] = ParserFor((SchemaParser parser, string description, out OutputAst output)
      => parser.ParseOutput(out output, description)),
    ["input"] = ParserFor((SchemaParser parser, string description, out InputAst input)
      => parser.ParseInput(out input, description)),
  };

  private static Parser<AstDescribed> ParserFor<T>(Parser<T> parser)
      where T : AstDescribed
    => (SchemaParser parent, string description, out AstDescribed declaration) => {
      var result = parser(parent, description, out T declared);
      declaration = declared;
      return result;
    };

  internal SchemaAst Parse()
  {
    if (_tokens.AtStart) {
      if (!_tokens.Read()) {
        return new(_tokens.At) { Errors = new[] { _tokens.Error("Unexpected") } };
      }
    }

    var at = _tokens.At;
    SchemaAst ast = new(at);

    var declarations = new List<AstDescribed>();

    while (_tokens.Identifier(out var selector)) {
      if (_parsers.TryGetValue(selector, out var parser)) {
        if (parser(this, "", out var declaration)) {
          declarations.Add(declaration);
        }
      }
    }

    if (_tokens.AtEnd) {
      ast.Result = ParseResult.Success;
    } else {
      Error("Text beyond end of Schema.");
    }

    return ast with {
      Declarations = declarations.ToArray(),
      Errors = Errors.ToArray(),
    };
  }

  internal bool ParseCategory(out CategoryAst result, string description)
  {
    var at = _tokens.At;
    result = new(at, "") { Description = description };

    at = _tokens.At;
    _tokens.Identifier(out var name);

    var aliases = ParseAliases("Category");
    var option = CategoryOption.Parallel;

    if (_tokens.Take('(')) {
      if (_tokens.Identifier(out var opt)) {
        if (!Enum.TryParse(opt, true, out option)) {
          return Error("Invalid Category. Unknown option.");
        }

        if (!_tokens.Take(')')) {
          return Error("Invalid Category. Expected ')' after option.");
        }
      } else {
        return Error("Invalid Category. Expected option after ')'.");
      }
    }

    if (_tokens.Take('=') && _tokens.Identifier(out var output)) {
      if (string.IsNullOrEmpty(name)) {
        name = output.Camelize();
      }

      result = new(at, name!, output) {
        Aliases = aliases.ToArray(),
        Option = option
      };
      return true;
    }

    return Error("Invalid Category. Expected output type after '='.");
  }

  internal bool ParseObject<O, F, R>(out O result, string description, IObjectParser<O, F, R> factories)
    where O : AstObject<F, R> where F : AstField<R> where R : AstReference<R>
  {
    var at = _tokens.At;
    var getName = _tokens.Identifier(out var name);

    result = factories.Object(at, name, description);
    if (!getName) {
      return Error($"Invalid {factories.Label}. Expected name.");
    }

    result.Parameters = ParseTypeParameters(factories.Label);
    result.Aliases = ParseAliases(factories.Label);

    if (!_tokens.Take('=')) {
      return Error($"Invalid {factories.Label}. Expected '=' before definition.");
    }

    var hasBase = ParseReference(out var reference, factories);

    if (_tokens.Take('{')) {
      var fields = new List<F>();
      while (!_tokens.Take('}')) {
        if (ParseField(out var field, factories)) {
          fields.Add(field);
        }
      }

      if (hasBase) {
        result.Extends = reference;
      }

      result.Fields = fields.ToArray();
      result.Alternates = ParseAlternates(factories);
    } else if (hasBase) {
      result.Alternates = ParseAlternates(factories, reference);
    }

    return true;
  }

  private R[] ParseAlternates<R>(IReferenceParser<R> factories, params R[] initial)
    where R : AstReference<R>
  {
    var alternates = new List<R>(initial);
    while (_tokens.Take('|')) {
      if (ParseReference(out var alternate, factories)) {
        alternates.Add(alternate);
      }
    }

    return alternates.ToArray();
  }

  private bool ParseField<F, R>(out F field, IFieldParser<F, R> parser)
    where F : AstField<R> where R : AstReference<R>
  {
    var at = _tokens.At;
    _tokens.String(out var description);
    if (!_tokens.Identifier(out var name)) {
      field = parser.Field(at, "", description, parser.Reference(at, ""));
      return Error($"Invalid {parser.Label}. Expected field name");
    }

    var hasParameter = parser.FieldParameter(out var parameter);
    var aliases = ParseAliases(parser.Label);

    field = parser.Field(at, name, description, parser.Reference(at, ""));

    if (_tokens.Take(':')) {
      if (ParseReference(out var fieldType, parser)) {
        field = parser.Field(at, name, description, fieldType);
        field.Aliases = aliases;
        if (hasParameter) {
          parser.ApplyParameter(field, parameter);
        }

        field.Modifiers = ParseModifiers();
        return parser.FieldDefault(field);
      }

      return Error($"Invalid {parser.Label}. Expected field type.");
    }

    return parser.FieldEnumLabel(field) || Error($"Invalid {parser.Label}. Expected field details.");
  }

  private bool ParseReference<R>(out R reference, IReferenceParser<R> factories, bool isTypeArgument = false)
    where R : AstReference<R>
  {
    if (_tokens.Prefix('$', out var param, out var at)) {
      reference = factories.Reference(at, param);
      reference.IsTypeParameter = true;
      return true;
    }

    at = _tokens.At;

    if (_tokens.Identifier(out var name)) {
      reference = factories.Reference(at, name);
      if (_tokens.Take('<')) {
        var arguments = new List<R>();
        while (ParseReference(out var argument, factories, true)) {
          arguments.Add(argument);
        }

        reference.Arguments = arguments.ToArray();

        if (!_tokens.Take('>')) {
          return Error($"Invalid {factories.Label}. Expected '>' after arguments.");
        }
      } else if (isTypeArgument) {
        return factories.ParseEnumLabel(reference);
      }

      return true;
    }

    reference = factories.Reference(at, "");
    return false;
  }

  internal bool ParseOutput(out OutputAst output, string description)
   => ParseObject(out output, description, new OutputParserFactories(this));

  internal bool ParseOutputEnumLabel(OutputReferenceAst reference)
  {
    if (_tokens.Take('.')) {
      if (_tokens.Identifier(out var label)) {
        reference.Label = label;
        return true;
      }

      return Error("Invalid Output. Expected label after '.'.");
    }

    return true;
  }

  internal bool ParseParameter(out ParameterAst? parameter)
  {
    parameter = default;
    if (!_tokens.Take('(')) {
      return true;
    }

    var at = _tokens.At;
    if (!ParseReference(out var reference, new InputParserFactories(this))) {
      return Error("Invalid Parameter. Expected input reference after '('.");
    }

    parameter = new(at, reference) {
      Modifiers = ParseModifiers()
    };
    if (ParseDefault(out var constant)) {
      parameter.Default = constant;
    }

    return _tokens.Take(')') || Error("Invalid Parameter. Expected ')' at end.");
  }

  internal bool ParseInput(out InputAst output, string description)
   => ParseObject(out output, description, new InputParserFactories(this));

  private string[] ParseAliases(string label)
  {
    var aliases = new List<string>();
    if (_tokens.Take('[')) {
      while (_tokens.Identifier(out var alias)) {
        aliases.Add(alias);
      }

      if (!_tokens.Take("]")) {
        Error($"Invalid {label}. Expected ']' to end aliases.");
      } else if (aliases.Count == 0) {
        Error($"Invalid {label}. Expected at least one alias after '['.");
      }
    }

    return aliases.ToArray();
  }

  private TypeParameterAst[] ParseTypeParameters(string label)
  {
    var parameters = new List<TypeParameterAst>();

    if (_tokens.Take('<')) {
      while (!_tokens.Take('>')) {
        _tokens.String(out var description);
        if (_tokens.Prefix('$', out var name, out var at)) {
          parameters.Add(new(at, name, description));
        } else {
          Error($"Invalid {label}. Expected type parameter.");
          break;
        }
      }

      if (parameters.Count == 0) {
        Error($"Invalid {label}. Expected at least one type parameter after '<'.");
      }
    }

    return parameters.ToArray();
  }
}
