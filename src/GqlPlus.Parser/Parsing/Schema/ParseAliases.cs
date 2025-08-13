using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema;

internal class ParseAliases
  : Parser<string>.IA
{
  public IResultArray<string> Parse(ITokenizer tokens, string label)

  {
    List<string> aliases = [];
    if (tokens.Take('[')) {
      while (ParseAlias(tokens, out string? alias)) {
        aliases.Add(alias);
      }

      if (!tokens.Take(']')) {
        return tokens.PartialArray(label, "']' to end aliases", () => aliases);
      } else if (aliases.Count == 0) {
        return tokens.ErrorArray(label, "at least one alias after '['", aliases);
      }
    }

    return aliases.OkArray();
  }

  public static bool ParseAlias(ITokenizer tokens, [NotNullWhen(true)] out string? alias)
  {
    if (tokens.Identifier(out alias)) {
      return true;
    }

    if (tokens.TakeZero()) {
      alias = "0";
      return true;
    } else if (tokens.TakeAny(out char simple, '^', '*', '_', '%')) {
      alias = $"{simple}";    
      return true;
    }

    alias = null;
    return false;
  }
}
