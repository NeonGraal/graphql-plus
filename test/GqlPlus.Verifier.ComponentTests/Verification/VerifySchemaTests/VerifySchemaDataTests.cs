using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Parse;

namespace GqlPlus.Verifier.Verification;

public class VerifySchemaDataTests(
    Parser<SchemaAst>.D parser
) : SchemaBase(parser)
{
  [Fact]
  public void CheckVerifySchemaDataKeys()
  {
    var duplicateKeys = VerifySchemaValidMergesData.Source.Keys
      .Concat(VerifySchemaValidObjectsData.Source.Keys)
      .Concat(VerifySchemaValidGlobalsData.Source.Keys)
      .Concat(VerifySchemaValidSimpleData.Source.Keys)
      .GroupBy(k => k)
      .Where(g => g.Count() > 1)
      .Select(g => g.Key);

    duplicateKeys.Should().BeEmpty();
  }
}
