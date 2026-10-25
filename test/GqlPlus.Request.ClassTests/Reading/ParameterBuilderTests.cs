namespace GqlPlus.Reading;

public class ParameterBuilderTests
{
  [Fact]
  public void Build_Empty_ReturnsEmptyUnit()
  {
    IGqlpValue result = ParameterBuilder.Build([]);

    result.ShouldBeOfType<GqlpUnit>();
  }

  [Theory, RepeatData]
  public void Build_SingleValue_ReturnsSingleEntry(string key, string value)
  {
    IGqlpValue expected = value.Encode();

    IGqlpValue result = ParameterBuilder.Build([(key, value)]);

    result.ShouldBe(new GqlpMap([Field(key, expected)]));
  }

  [Theory, RepeatData]
  public void Build_MultipleValuesForPath_ReturnsList(string key, string[] list)
  {
    this.SkipShortArray(list);

    IGqlpValue result = ParameterBuilder.Build([.. list.Select(v => (key, v))]);

    result.ShouldBe(new GqlpMap([Field(key, list.Encode())]));
  }

  [Theory, RepeatData]
  public void Build_NestedPath_ReturnsNestedMap(string top, string key, string value)
  {
    IGqlpValue result = ParameterBuilder.Build([(top + "." + key, value)]);

    result.ShouldBe(new GqlpMap([
      Field(top, new GqlpMap([Field(key, value.Encode())])),
    ]));
  }

  [Fact]
  public void Build_MixedPaths_ReturnsCorrectTree()
  {
    GqlpMap result = (GqlpMap)ParameterBuilder.Build([("filter.kinds", "Enum"), ("filter.names", "Foo")]);

    result.Entries.Count.ShouldBe(1);
    GqlpMap filter = result.Entries[new GqlpScalar("filter", isIdentifier: true)] as GqlpMap
      ?? throw new InvalidOperationException("Expected filter map.");
    filter.Entries.Keys.Select(k => k.Text).ShouldBe(["kinds", "names"]);
  }

  private static KeyValuePair<IGqlpScalar, IGqlpValue> Field(string key, IGqlpValue value)
    => new(new GqlpScalar(key, isIdentifier: key.IsIdentifier()), value);
}
