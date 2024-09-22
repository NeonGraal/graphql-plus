using GqlPlus.Result;

namespace GqlPlus;

public class SchemaDataTests
{
  [Fact]
  public void VerifySchemaDataKeys()
  {
    IEnumerable<string> duplicateKeys = SchemaValidMergesData.Keys
      .Concat(SchemaValidObjectsData.Keys)
      .Concat(SchemaValidGlobalsData.Keys)
      .Concat(SchemaValidSimpleData.Keys)
      .GroupBy(k => k)
      .Where(g => g.Count() > 1)
      .Select(g => g.Key);

    duplicateKeys.Should().BeEmpty();
  }
}
