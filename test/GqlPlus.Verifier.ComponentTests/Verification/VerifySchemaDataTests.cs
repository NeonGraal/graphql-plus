using GqlPlus.Abstractions.Schema;
using GqlPlus.Parse;

namespace GqlPlus.Verification;

public class VerifySchemaDataTests(
    Parser<IGqlpSchema>.D parser
) : SchemaBase(parser)
{
  [Fact]
  public void CheckVerifySchemaDataKeys()
  {
    IEnumerable<string> duplicateKeys = VerifySchemaValidMergesData.Source.Keys
      .Concat(VerifySchemaValidObjectsData.Source.Keys)
      .Concat(VerifySchemaValidGlobalsData.Source.Keys)
      .Concat(VerifySchemaValidSimpleData.Source.Keys)
      .GroupBy(k => k)
      .Where(g => g.Count() > 1)
      .Select(g => g.Key);

    duplicateKeys.Should().BeEmpty();
  }
}
