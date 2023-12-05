using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification;
internal class NullVerifier<T> : IVerify<T> where T : AstBase
{
  public IEnumerable<TokenMessage> Verify(T target) => [];
}
