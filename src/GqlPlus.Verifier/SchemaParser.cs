using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier;

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

  internal bool ParseOutput(out OutputAst output, string description)
  {
    var at = _tokens.At;
    if (!_tokens.Identifier(out var name)) {
      output = new(at, "", description);
      return Error("Invalid Output. Expected name");
    }

    var parameters = ParseParameters("Output");
    var aliases = ParseAliases("Output");

    output = new(at, name, description) {
      Parameters = parameters,
      Aliases = aliases
    };

    if (!_tokens.Take('=')) {
      return Error("Invalid Output. Expected '=' before definition.");
    }

    var hasBase = ParseOutputReference(out var outputReference);

    if (_tokens.Take('{')) {
      var fields = new List<OutputFieldAst>();
      while (!_tokens.Take('}')) {
        if (ParseOutputField(out var field)) {
          fields.Add(field);
        }
      }

      if (hasBase) {
        output.Extends = outputReference;
      }

      output.Fields = fields.ToArray();
      output.Alternates = ParseOutputAlternates();
    } else if (hasBase) {
      output.Alternates = ParseOutputAlternates(outputReference);
    }

    return true;
  }

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

  private OutputReferenceAst[] ParseOutputAlternates(params OutputReferenceAst[] initial)
  {
    var alternates = new List<OutputReferenceAst>(initial);
    while (_tokens.Take('|')) {
      if (ParseOutputReference(out var alternate)) {
        alternates.Add(alternate);
      }
    }

    return alternates.ToArray();
  }

  private bool ParseOutputField(out OutputFieldAst outputField)
  {
    var at = _tokens.At;
    outputField = new(at, "", new(at, ""));

    return false;
  }

  private bool ParseOutputReference(out OutputReferenceAst outputReference)
  {
    outputReference = new(_tokens.At, "");

    return false;
  }

  private TypeParameterAst[] ParseParameters(string label)
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
