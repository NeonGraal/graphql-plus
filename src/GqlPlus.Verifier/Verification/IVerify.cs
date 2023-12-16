using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification;

public interface IVerify<TItem>
{
  void Verify(TItem item, ITokenMessages errors);
}
