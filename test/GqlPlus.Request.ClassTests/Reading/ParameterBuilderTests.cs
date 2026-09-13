namespace GqlPlus.Reading;

public class ParameterBuilderTests
{
  [Fact]
  public void Build_Empty_ReturnsEmptyStructured()
  {
    Structured result = ParameterBuilder.Build([]);

    result.IsEmpty.ShouldBeTrue();
  }

  [Theory, RepeatData]
  public void Build_SingleValue_ReturnsSingleEntry(string key, string value)
  {
    StructureValue theKey = new(key);
    Structured theValue = value.Encode();

    Structured result = ParameterBuilder.Build([(key, value)]);

    result.Map.ShouldSatisfyAllConditions(
      m => m.ShouldContainKey(theKey),
      m => m[theKey].ShouldBe(theValue));
  }

  [Theory, RepeatData]
  public void Build_MultipleValuesForPath_ReturnsList(string key, string[] list)
  {
    this.SkipShortArray(list);

    StructureValue theKey = new(key);
    Structured theValue = list.Encode();

    Structured result = ParameterBuilder.Build([.. list.Select(v => (key, v))]);

    result.Map.ShouldSatisfyAllConditions(
      m => m.ShouldContainKey(theKey),
      m => m[theKey].ShouldBe(theValue));
  }

  [Theory, RepeatData]
  public void Build_NestedPath_ReturnsNestedMap(string top, string key, string value)
  {
    StructureValue theTop = new(top);
    StructureValue theKey = new(key);
    Structured theValue = new(theKey.DictWith(value.Encode()));

    Structured result = ParameterBuilder.Build([(top + "." + key, value)]);

    result.Map.ShouldSatisfyAllConditions(
      m => m.ShouldContainKey(theTop),
      m => m[theTop].ShouldBe(theValue));
  }

  [Fact]
  public void Build_MixedPaths_ReturnsCorrectTree()
  {
    Structured result = ParameterBuilder.Build([("filter.kinds", "Enum"), ("filter.names", "Foo")]);

    result.Map.ShouldContainKey(new StructureValue("filter"));
    Structured filter = result.Map[new StructureValue("filter")];
    filter.Map.ShouldContainKey(new StructureValue("kinds"));
    filter.Map.ShouldContainKey(new StructureValue("names"));
  }
}
