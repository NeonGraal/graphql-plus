namespace GqlPlus;

public static class Defer<T>
  where T : class
{
  public delegate T D();
  public delegate IEnumerable<T> DA();

#pragma warning disable CA1034 // Nested types should not be visible
  public class L(D factory)
    : Lazy<T>(() => factory())
  {
    public static implicit operator L(D factory)
      => new(factory.ThrowIfNull());

    public T I => Value;
  }

  public class LA(DA factory)
    : Lazy<IEnumerable<T>>(() => factory())
  {
    public static implicit operator LA(DA factory)
      => new(factory.ThrowIfNull());

    public IEnumerable<T> IA => Value;
  }
}
