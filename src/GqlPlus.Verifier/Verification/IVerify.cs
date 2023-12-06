using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification;

public interface IVerify<TTarget>
{
  ITokenMessages Verify(TTarget target);
}
