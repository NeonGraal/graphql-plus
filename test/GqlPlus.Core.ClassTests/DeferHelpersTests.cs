namespace GqlPlus;

public class DeferHelpersTests
{
  [Theory, RepeatData]
  public void ToMap_WithKeySelector_ReturnsCorrectKeys(string[] values)
  {
    string[] distinct = [.. values.Distinct()];
    DeferList<string>.D factory = () => distinct;

    DeferMap<string> result = factory.ToMap(v => v);

    result.Keys.ShouldBe(distinct.Order(), ignoreOrder: true);
  }

  [Theory, RepeatData]
  public void ToMap_WithKeySelectorAndValueSelector_ReturnsCorrectValues(string[] values)
  {
    string[] distinct = [.. values.Distinct()];
    DeferList<string>.D factory = () => distinct;

    DeferMap<string> result = factory.ToMap(v => v, v => v.ToUpperInvariant());

    result.Values.ShouldBe(distinct.Select(v => v.ToUpperInvariant()), ignoreOrder: true);
  }

  [Theory, RepeatData]
  public void ToDictionary_WithKeySelector_ReturnsCorrectKeys(string[] values)
  {
    string[] distinct = [.. values.Distinct()];
    DeferList<string>.D factory = () => distinct;

    DeferDict<string, string> result = factory.ToDictionary<string, string>(v => v);

    result.Keys.ShouldBe(distinct.Order(), ignoreOrder: true);
  }

  [Theory, RepeatData]
  public void ToDictionary_WithKeySelectorAndValueSelector_ReturnsCorrectValues(string[] values)
  {
    string[] distinct = [.. values.Distinct()];
    DeferList<string>.D factory = () => distinct;

    DeferDict<string, string> result = factory.ToDictionary<string, string, string>(v => v, v => v.ToUpperInvariant());

    result.Values.ShouldBe(distinct.Select(v => v.ToUpperInvariant()), ignoreOrder: true);
  }
}
