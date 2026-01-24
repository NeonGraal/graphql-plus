using GqlPlus.Convert;

namespace GqlPlus.Sample;

[Trait("Generate", "Plain")]
public class PlainSchemaTests(
  ISchemaVerifyChecks checks
) : TestSchemaVerify(checks)
{
  public override string ResultGroup => "Plain";
  protected override Task CheckResultErrors(string[] dirs, string test, IMessages errors, bool includeVerify = false)
    => CheckErrors(dirs, test, errors, includeVerify);
  protected override Task VerifyResult(string target, VerifySettings settings)
    => Verify(target, settings);
  public override string EncodeResult(Structured result, string section)
    => result.ToPlain(true).Joined(Environment.NewLine);
}
