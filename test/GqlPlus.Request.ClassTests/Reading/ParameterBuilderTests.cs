using GqlPlus.Structures;

namespace GqlPlus.Request.Reading;

public class ParameterBuilderTests
{
  [Fact]
  public void Build_Empty_ReturnsEmptyStructured()
  {
    Structured result = ParameterBuilder.Build([]);

    result.IsEmpty.ShouldBeTrue();
  }

  [Fact]
  public void Build_SingleValue_ReturnsSingleEntry()
  {
    Structured result = ParameterBuilder.Build([("kinds", "Enum")]);

    result.Map.ShouldContainKey(new StructureValue("kinds"));
    result.Map[new StructureValue("kinds")].Value?.Text.ShouldBe("Enum");
  }

  [Fact]
  public void Build_MultipleValuesForPath_ReturnsList()
  {
    Structured result = ParameterBuilder.Build([("names", "*Dual*"), ("names", "*Input*")]);

    result.Map.ShouldContainKey(new StructureValue("names"));
    Structured names = result.Map[new StructureValue("names")];
    names.List.Count.ShouldBe(2);
    names.List[0].Value?.Text.ShouldBe("*Dual*");
    names.List[1].Value?.Text.ShouldBe("*Input*");
  }

  [Fact]
  public void Build_NestedPath_ReturnsNestedMap()
  {
    Structured result = ParameterBuilder.Build([("filter.kinds", "Enum")]);

    result.Map.ShouldContainKey(new StructureValue("filter"));
    Structured filter = result.Map[new StructureValue("filter")];
    filter.Map.ShouldContainKey(new StructureValue("kinds"));
    filter.Map[new StructureValue("kinds")].Value?.Text.ShouldBe("Enum");
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
