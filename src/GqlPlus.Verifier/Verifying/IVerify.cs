namespace GqlPlus.Verifying;

public interface IVerify<TItem>
{
  void Verify(TItem item, IMessages errors);
}
