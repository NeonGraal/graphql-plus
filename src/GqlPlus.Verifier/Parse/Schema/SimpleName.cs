using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema;

internal class SimpleName : INameParser
{
  public bool ParseName(Tokenizer tokens, out string? name, out TokenAt at)
  {
    at = tokens.At;
    return tokens.Identifier(out name);
  }
}
