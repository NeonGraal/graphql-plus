using GqlPlus.Convert;

namespace GqlPlus.Sample;

[Trait("Generate", "Json")]
public class JsonSchemaTests(
  ISchemaVerifyChecks checks
) : TestSchemaVerify(checks)
{
  public override string ResultGroup => "Json";
  public override string EncodeResult(Structured result, string section)
    => result.ToJson() + Environment.NewLine;
  protected override Task VerifyResult(string target, VerifySettings settings)
    => Verify(target, "json", settings);
}
