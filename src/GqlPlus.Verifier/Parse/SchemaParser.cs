using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse;

internal class SchemaParser : CommonParser
{
  public SchemaParser(Tokenizer tokens)
    : base(tokens) { }

  private delegate bool Parser<T>(SchemaParser parser, string description, out T declaration);

  private readonly Dictionary<string, Parser<AstDescribed>> _parsers = new() {
    ["category"] = ParserFor((SchemaParser parser, string description, out CategoryAst result)
      => parser.ParseCategory(out result, description)),
    ["directive"] = ParserFor((SchemaParser parser, string description, out DirectiveAst result)
      => parser.ParseDirective(out result, description)),
    ["enum"] = ParserFor((SchemaParser parser, string description, out EnumAst result)
      => parser.ParseEnum(out result, description)),
    ["output"] = ParserFor((SchemaParser parser, string description, out OutputAst result)
      => parser.ParseOutput(out result, description)),
    ["input"] = ParserFor((SchemaParser parser, string description, out InputAst result)
      => parser.ParseInput(out result, description)),
    ["scalar"] = ParserFor((SchemaParser parser, string description, out ScalarAst result)
      => parser.ParseScalar(out result, description)),
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
    if (!ParseOption("Category", out CategoryOption option)) {
      return false;
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

  private bool ParseOption<O>(string label, out O result)
    where O : struct
  {
    result = default;
    if (!_tokens.Take('(')) {
      return true;
    }

    if (!_tokens.Identifier(out var option)) {
      return Error($"Invalid {label}. Expected option after '('.");
    }

    if (!Enum.TryParse(option, true, out result)) {
      return Error($"Invalid {label}. Unknown option.");
    }

    return Error($"Invalid {label}. Expected ')' after option.", _tokens.Take(')'));
  }

  internal bool ParseDirective(out DirectiveAst result, string description)
  {
    var hasName = _tokens.Prefix('@', out var name, out var at);
    result = new(at, name, description);

    if (!hasName) {
      return Error("Invalid Directive. Expected '@' name");
    }

    var aliases = ParseAliases("Directive");
    if (!ParseOption("Directive", out DirectiveOption option)) {
      return false;
    }

    return true;
  }

  internal bool ParseEnum(out EnumAst result, string description) => throw new NotImplementedException();

  private bool ParseObject<O, F, R>(out O result, string description, IObjectParser<O, F, R> factories)
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
        } else {
          Error($"Invalid {factories.Label}. Expected more fields or '}}'.");
          break;
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

    return Error($"Invalid {parser.Label}. Expected field details.", parser.FieldEnumLabel(field));
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
        return factories.TypeEnumLabel(reference);
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

  internal bool ParseOutputFieldLabel(OutputFieldAst field)
  {
    if (_tokens.Take('=')) {
      var at = _tokens.At;

      if (!_tokens.Identifier(out var label)) {
        return Error("Invalid Output. Expected label after '='.");
      }

      if (!_tokens.Take('.')) {
        field.Label = label;
        return true;
      }

      if (_tokens.Identifier(out var value)) {
        field.Type = new OutputReferenceAst(at, label);
        field.Label = value;
        return true;
      }

      return Error("Invalid Output. Expected label after '.'.");
    }

    return Error("Invalid Output. Expected ':' or '='.");
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

    return Error("Invalid Parameter. Expected ')' at end.", _tokens.Take(')'));
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

  internal bool ParseScalar(out ScalarAst result, string description) => throw new NotImplementedException();
}
