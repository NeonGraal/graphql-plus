using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema;

internal class SimpleName
  : ISimpleName
{
  public bool ParseName(ITokenizer tokens, [NotNullWhen(true)] out string? name, out TokenAt at)
  {
    at = tokens.At;
    return tokens.Identifier(out name);
  }

  internal static SimpleName Factory(IParserRepository _) => new();
}

internal interface ISimpleName : INameParser;
