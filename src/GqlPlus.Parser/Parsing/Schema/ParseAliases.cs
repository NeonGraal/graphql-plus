using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema;

internal class ParseAliases
  : Parser<string>.IA
{
  public IResultArray<string> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    List<string> aliases = [];
    if (tokens.Take('[')) {
      while (tokens.Identifier(out string? alias)) {
        aliases.Add(alias);
      }

      if (!tokens.Take("]")) {
        return tokens.PartialArray(label, "']' to end aliases", () => aliases);
      } else if (aliases.Count == 0) {
        return tokens.ErrorArray(label, "at least one alias after '['", aliases);
      }
    }

    return aliases.OkArray();
  }
}
