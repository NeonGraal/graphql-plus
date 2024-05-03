namespace GqlPlus.Verification;

public interface IVerify<TItem>
{
  void Verify(TItem item, ITokenMessages errors);
}
