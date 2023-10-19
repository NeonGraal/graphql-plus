using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier;

internal class SchemaParser : CommonParser
{
  public SchemaParser(Tokenizer tokens)
    : base(tokens) { }

  internal bool ParseCategory(out CategoryAst result)
  {
    var at = _tokens.At;
    result = new(at, "");

    if (_tokens.Take("category")) {
      at = _tokens.At;
      if (!_tokens.Identifier(out var name)) {
        return Error("Invalid Category. Name not found.");
      }

      result = new(at, name);

      if (_tokens.Take('(')) {
        if (_tokens.Identifier(out var option)) {
          if (Enum.TryParse<CategoryOption>(option, true, out var opt)) {
            result.Option = opt;
          } else {
            return Error("Invalid Category. Unknown option.");
          }

          if (!_tokens.Take(')')) {
            return Error("Invalid Category. Expected ')' after option.");
          }
        } else {
          return Error("Invalid Category. Expected option after ')'.");
        }
      }

      var aliases = new List<string>();
      while (_tokens.Identifier(out var alias)) {
        aliases.Add(alias);
      }

      result.Aliases = aliases.ToArray();

      return true;
    }

    return false;
  }
}
