using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification;

public interface IVerify<TTarget>
{
  IEnumerable<TokenMessage> Verify(TTarget target);
}
