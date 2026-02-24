using GqlPlus.Convert;

namespace GqlPlus.Sample;

[Trait("Generate", "Plain")]
public class PlainSchemaTests(
  ISchemaVerifyChecks checks
) : TestSchemaVerify(checks)
{
  public override string ResultGroup => "Plain";
  protected override Task CheckResultErrors(string[] dirs, string test, IMessages errors, params string[] additionalCategories)
    => CheckErrors(dirs, test, errors, additionalCategories);
  protected override Task VerifyResult(string target, VerifySettings settings)
    => Verify(target, settings);
  public override string EncodeResult(Structured result, string section)
    => result.ToPlain(true).Joined(Environment.NewLine);
}
