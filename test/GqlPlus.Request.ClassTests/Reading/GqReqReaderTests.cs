namespace GqlPlus.Request.Reading;

public class GqReqReaderTests
{
  [Fact]
  public void Read_PlainOperation_ReturnsDefinition()
  {
    string input = "_Schema { categories { name } }";

    GqReqInput result = GqReqReader.Read(input);

    result.ShouldSatisfyAllConditions(
      () => result.Definition.ShouldBe(input),
      () => result.Category.ShouldBeNull(),
      () => result.Operation.ShouldBeNull(),
      () => result.Parameters.ShouldBeEmpty());
  }

  [Fact]
  public void Read_MultiKey_ExtractsAllFields()
  {
    string input = """
      category = _Schema
      definition = ($filter) { types($filter) { name } }
      """;

    GqReqInput result = GqReqReader.Read(input);

    result.ShouldSatisfyAllConditions(
      () => result.Category.ShouldBe("_Schema"),
      () => result.Definition.ShouldBe("($filter) { types($filter) { name } }"),
      () => result.Operation.ShouldBeNull(),
      () => result.Parameters.ShouldBeEmpty());
  }

  [Fact]
  public void Read_Parameters_ParsesDotsAsPath()
  {
    string input = """
      definition = ($filter) { types($filter) { name } }
      parameters.filter.kinds = Enum
      """;

    GqReqInput result = GqReqReader.Read(input);

    result.Parameters.ShouldHaveSingleItem()
      .ShouldBe(("filter.kinds", "Enum"));
  }

  [Fact]
  public void Read_MultipleValuesForSamePath_AllPresent()
  {
    string input = """
      definition = ($names[]) { types($names) { name } }
      parameters.names = *Dual*
      parameters.names = *Input*
      """;

    GqReqInput result = GqReqReader.Read(input);

    result.Parameters.Count.ShouldBe(2);
    result.Parameters[0].ShouldBe(("names", "*Dual*"));
    result.Parameters[1].ShouldBe(("names", "*Input*"));
  }

  [Fact]
  public void Read_WithOperation_ExtractsOperationField()
  {
    string input = """
      category = _Schema
      operation = myOp
      definition = { categories { name } }
      """;

    GqReqInput result = GqReqReader.Read(input);

    result.ShouldSatisfyAllConditions(
      () => result.Category.ShouldBe("_Schema"),
      () => result.Operation.ShouldBe("myOp"),
      () => result.Definition.ShouldBe("{ categories { name } }"));
  }

  [Fact]
  public void Read_Empty_ReturnsEmptyDefinition()
  {
    GqReqInput result = GqReqReader.Read("");

    result.ShouldSatisfyAllConditions(
      () => result.Definition.ShouldBe(""),
      () => result.Category.ShouldBeNull(),
      () => result.Parameters.ShouldBeEmpty());
  }
}
