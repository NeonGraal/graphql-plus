namespace GqlPlus.Verifying;

public interface IVerify<TItem>
{
  void Verify(TItem item, ITokenMessages errors);
}
