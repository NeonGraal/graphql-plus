namespace GqlPlus.Verifying;

public interface IVerify<TItem>
{
  void Verify(TItem item, IMessages errors);
}

public class Verifier<T>(
  Verifier<T>.D factory
) : DeferOne<IVerify<T>>(factory)
  , IVerify<T>
{
  public void Verify(T item, IMessages errors)
    => Value.Verify(item, errors);

  //public static implicit operator Verifier<T>(D factory)
  //  => new(factory.ThrowIfNull());
}
