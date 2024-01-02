using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema;

internal class SimpleName : ISimpleName
{
  public bool ParseName(Tokenizer tokens, out string? name, out TokenAt at)
  {
    at = tokens.At;
    return tokens.Identifier(out name);
  }
}

internal interface ISimpleName : INameParser { }
