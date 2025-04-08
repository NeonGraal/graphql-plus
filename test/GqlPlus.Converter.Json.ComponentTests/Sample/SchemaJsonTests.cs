using GqlPlus.Convert;

namespace GqlPlus.Sample;

public class SchemaJsonTests(
    ISchemaVerifyChecks checks
) : TestSchemaVerify(checks)
{
  protected override Task VerifyResult(Structured result, string label, string test, string testDirectory)
    => Verify(result.ToJson(), "json", CustomSettings(label, "Json", test, testDirectory));
}
