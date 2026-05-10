namespace GqlPlus;

public class DeferListTests
{
  [Theory, RepeatData]
  public void GetEnumerator_WhenIterated_ReturnsFactoryValues(string[] values)
  {
    DeferList<string> defer = new(() => values);

    IEnumerable<string> result = defer;

    result.ShouldBe(values, ignoreOrder: true);
  }

  [Theory, RepeatData]
  public void GetEnumerator_NonGeneric_WhenIterated_ReturnsFactoryValues(string[] values)
  {
    DeferList<string> defer = new(() => values);

    System.Collections.IEnumerable enumerable = defer;

    foreach (object item in enumerable) {
      item.ShouldBeOfType<string>()
        .ShouldBeOneOf(values);
    }
  }

  [Theory, RepeatData]
  public void ImplicitConvert_FromDelegate_ReturnsFactoryValues(string[] values)
  {
    DeferList<string>.D factory = () => values;

    DeferList<string> result = factory;

    result.ShouldBe(values, ignoreOrder: true);
  }

  [Fact]
  public void ImplicitConvert_NullFactory_ThrowsArgumentNullException()
  {
    DeferList<string>.D? factory = null;

    Action result = () => _ = (DeferList<string>)factory!;

    result.ShouldThrow<ArgumentNullException>();
  }

  [Theory, RepeatData]
  public void ToMap_WithKeySelector_ReturnsCorrectKeys(string[] values)
  {
    string[] distinct = [.. values.Distinct()];
    DeferList<string> defer = new(() => distinct);

    DeferMap<string> result = defer.ToMap(v => v);

    result.Keys.ShouldBe(distinct.Order(), ignoreOrder: true);
  }

  [Theory, RepeatData]
  public void ToMap_WithKeySelectorAndValueSelector_ReturnsCorrectValues(string[] values)
  {
    string[] distinct = [.. values.Distinct()];
    DeferList<string> defer = new(() => distinct);

    DeferMap<string> result = defer.ToMap(v => v, v => v.ToUpperInvariant());

    result.Values.ShouldBe(distinct.Select(v => v.ToUpperInvariant()), ignoreOrder: true);
  }

  [Theory, RepeatData]
  public void ToDictionary_WithKeySelector_ReturnsCorrectKeys(string[] values)
  {
    string[] distinct = [.. values.Distinct()];
    DeferList<string> defer = new(() => distinct);

    DeferDict<string, string> result = defer.ToDictionary(v => v);

    result.Keys.ShouldBe(distinct.Order(), ignoreOrder: true);
  }

  [Theory, RepeatData]
  public void ToDictionary_WithKeySelectorAndValueSelector_ReturnsCorrectValues(string[] values)
  {
    string[] distinct = [.. values.Distinct()];
    DeferList<string> defer = new(() => distinct);

    DeferDict<string, string> result = defer.ToDictionary<string, string>(v => v, v => v.ToUpperInvariant());

    result.Values.ShouldBe(distinct.Select(v => v.ToUpperInvariant()), ignoreOrder: true);
  }
}
