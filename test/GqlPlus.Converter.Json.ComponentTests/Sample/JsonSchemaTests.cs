using GqlPlus.Convert;

namespace GqlPlus.Sample;

[Trait("Generate", "Json")]
public class JsonSchemaTests(
  ISchemaVerifyChecks checks
) : TestSchemaVerify(checks)
{
  protected override Task VerifyResult(Structured result, string label, string test, string section)
    => Verify(result.ToJson() + Environment.NewLine, "json", CustomSettings(label, "Json", test, section));
}
