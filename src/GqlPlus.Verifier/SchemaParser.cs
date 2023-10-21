using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier;

internal class SchemaParser : CommonParser
{
  public SchemaParser(Tokenizer tokens)
    : base(tokens) { }

  internal bool ParseCategory(out CategoryAst result, string description)
  {
    var at = _tokens.At;
    result = new(at, description, "");

    at = _tokens.At;
    _tokens.Identifier(out var name);

    var aliases = new List<string>();
    if (_tokens.Take('[')) {
      while (_tokens.Identifier(out var alias)) {
        aliases.Add(alias);
      }

      if (!_tokens.Take("]")) {
        return Error("Invalid Category. Expected ']' to end aliases.");
      }

      if (aliases.Count == 0) {
        return Error("Invalid Category. Expected at least one alias after '['.");
      }
    }

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
}
