using GqlPlus.Convert;

namespace GqlPlus.Sample;

public class SchemaYamlTests(
    ISchemaVerifyChecks checks
) : TestSchemaVerify(checks)
{
  protected override Task VerifyResult(Structured result, string label, string test, string testDirectory)
    => Verify(result.ToYaml(true), CustomSettings(label, "Yaml", test, testDirectory));
}
