using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification;

public interface IVerify<TItem>
{
  ITokenMessages Verify(TItem item);
}
