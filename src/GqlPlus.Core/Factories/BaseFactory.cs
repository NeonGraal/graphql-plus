namespace GqlPlus.Factories;

#pragma warning disable CA1052 // Static holder types should be Static or NotInheritable
public class BaseFactory<TRepo>
  where TRepo : IRepository
#pragma warning restore CA1052 // Static holder types should be Static or NotInheritable
{
#pragma warning disable CA1034 // Nested types should not be visible
  public class FactoryDict : Dictionary<Type, Factory<object, TRepo>>;
  public class FactoryList : List<Factory<object, TRepo>>;
#pragma warning restore CA1034 // Nested types should not be visible

  protected IEnumerable<T> InstancesFor<T>(IEnumerable<Factory<object, TRepo>> factories, TRepo repo)
    where T : class
    => factories.Select(f => (T)f.Invoke(repo));
  protected IEnumerable<Factory<T, TRepo>> FactoriesFor<T>(IEnumerable<Factory<object, TRepo>> factories)
    where T : class
    => factories.Select(FactoryFor<T>);

  protected Factory<T, TRepo> FactoryFor<T>(Factory<object, TRepo> factory)
    where T : class
    => factory is Factory<T, TRepo> typedFactory
      ? typedFactory
      : throw new InvalidOperationException($"Factory registration for type '{typeof(T).ExpandTypeName()}' is not of the expected type '{typeof(Factory<T, TRepo>).ExpandTypeName()}'.");

  protected KeyValuePair<Type, Factory<object, TRepo>> FactoryKeyValue<T>(Factory<object, TRepo> factory)
    => factory.ToKeyValue(typeof(T));
  protected KeyValuePair<Type, FactoryList> FactoriesKeyValue<T>(IEnumerable<Factory<T, TRepo>> factories)
    where T : class
  {
    FactoryList list = [.. factories];
    return list.ToKeyValue(typeof(T));
  }
}
