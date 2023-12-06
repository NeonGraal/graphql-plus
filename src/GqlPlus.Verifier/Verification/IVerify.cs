using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification;

public interface IVerify<TItem>
{
  ITokenMessages Verify(TItem item);
}

public interface IMerge<TItem>
{
  bool CanMerge(TItem[] items);
}
