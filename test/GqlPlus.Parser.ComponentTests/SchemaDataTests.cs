using GqlPlus.Result;

namespace GqlPlus;

public class SchemaDataTests
{
  [Fact]
  public void VerifySchemaDataKeys()
  {
    IEnumerable<string> duplicateKeys = SchemaValidMergesData.Source.Keys
      .Concat(SchemaValidObjectsData.Source.Keys)
      .Concat(SchemaValidGlobalsData.Source.Keys)
      .Concat(SchemaValidSimpleData.Source.Keys)
      .GroupBy(k => k)
      .Where(g => g.Count() > 1)
      .Select(g => g.Key);

    duplicateKeys.Should().BeEmpty();
  }
}
