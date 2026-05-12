using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Logging;

namespace GqlPlus.Factories;

public class BaseFactoryTests
{
  private readonly TestableFactory _sut = new();

  [Fact]
  public void FactoryDict_Default_IsEmpty()
  {
    BaseFactory<IRepository>.FactoryDict result = [];

    result.ShouldBeEmpty();
  }

  [Fact]
  public void FactoryList_Default_IsEmpty()
  {
    BaseFactory<IRepository>.FactoryList result = [];

    result.ShouldBeEmpty();
  }

  [Theory, RepeatData]
  public void FactoryFor_TypedFactory_ReturnsTypedFactory(string value)
  {
    string typed(IRepository _) => value;
    Factory<object, IRepository> asObject = (Factory<string, IRepository>)typed;

    Factory<string, IRepository> result = _sut.ExposedFactoryFor<string>(asObject);

    result.ShouldBe(typed);
  }

  [Fact]
  public void FactoryFor_WrongType_ThrowsInvalidOperationException()
  {
    object wrong(IRepository _) => new object();

    Action result = () => _sut.ExposedFactoryFor<string>(wrong);

    result.ShouldThrow<InvalidOperationException>();
  }

  [Theory, RepeatData]
  public void FactoriesFor_TypedFactories_ReturnsAllFactories([NotNull] string[] values)
  {
    BaseFactory<IRepository>.FactoryList list = [.. values.Select(TypedAsObject)];

    IEnumerable<Factory<string, IRepository>> result = _sut.ExposedFactoriesFor<string>(list);

    result.Count().ShouldBe(values.Length);
  }

  [Fact]
  public void FactoriesFor_WrongType_ThrowsInvalidOperationException()
  {
    object wrong(IRepository _) => new object();
    BaseFactory<IRepository>.FactoryList list = [wrong];

    Action result = () => {
      foreach (Factory<string, IRepository> _ in _sut.ExposedFactoriesFor<string>(list)) { }
    };

    result.ShouldThrow<InvalidOperationException>();
  }

  [Theory, RepeatData]
  public void FactoryKeyValue_GivenFactory_KeyIsTypeOf(string value)
  {
    Factory<object, IRepository> asObject = TypedAsObject(value);

    KeyValuePair<Type, Factory<object, IRepository>> result = _sut.ExposedFactoryKeyValue<string>(asObject);

    result.Key.ShouldBe(typeof(string));
  }

  [Theory, RepeatData]
  public void FactoryKeyValue_GivenFactory_ValueIsFactory(string value)
  {
    Factory<object, IRepository> asObject = TypedAsObject(value);

    KeyValuePair<Type, Factory<object, IRepository>> result = _sut.ExposedFactoryKeyValue<string>(asObject);

    result.Value.ShouldBe(asObject);
  }

  [Theory, RepeatData]
  public void FactoriesKeyValue_GivenFactories_KeyIsTypeOf([NotNull] string[] values)
  {
    IEnumerable<Factory<string, IRepository>> factories = values.Select<string, Factory<string, IRepository>>(v => _ => v);

    KeyValuePair<Type, BaseFactory<IRepository>.FactoryList> result = _sut.ExposedFactoriesKeyValue<string>(factories);

    result.Key.ShouldBe(typeof(string));
  }

  [Theory, RepeatData]
  public void FactoriesKeyValue_GivenFactories_ValueCountMatchesInput([NotNull] string[] values)
  {
    IEnumerable<Factory<string, IRepository>> factories = values.Select<string, Factory<string, IRepository>>(v => _ => v);

    KeyValuePair<Type, BaseFactory<IRepository>.FactoryList> result = _sut.ExposedFactoriesKeyValue<string>(factories);

    result.Value.Count.ShouldBe(values.Length);
  }

  private static Factory<object, IRepository> TypedAsObject(string value)
  {
    string typed(IRepository _) => value;
    return (Factory<string, IRepository>)typed;
  }

  private sealed class TestableFactory : BaseFactory<IRepository>
  {
    public Factory<T, IRepository> ExposedFactoryFor<T>(Factory<object, IRepository> factory)
      where T : class
      => FactoryFor<T>(factory);

    public IEnumerable<Factory<T, IRepository>> ExposedFactoriesFor<T>(FactoryList factories)
      where T : class
      => FactoriesFor<T>(factories);

    public KeyValuePair<Type, Factory<object, IRepository>> ExposedFactoryKeyValue<T>(Factory<object, IRepository> factory)
      => FactoryKeyValue<T>(factory);

    public KeyValuePair<Type, FactoryList> ExposedFactoriesKeyValue<T>(IEnumerable<Factory<T, IRepository>> factories)
      where T : class
      => FactoriesKeyValue<T>(factories);
  }
}
