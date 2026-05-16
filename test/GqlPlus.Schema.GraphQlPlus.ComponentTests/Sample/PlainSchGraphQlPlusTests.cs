namespace GqlPlus.Sample;

[Trait("Generate", "Plain")]
public class PlainSchGraphQlPlusTests(
  ISchGraphQlPlusVerifyChecks checks
) : TestSchGraphQlPlusVerify(checks)
{
  public override string ResultGroup => "Plain";
  protected override Task VerifyResult(string target, VerifySettings settings)
    => Verify(target, settings);
  public override string EncodeResult(Structured result, string section)
    => result.ToPlain(true).Joined(Environment.NewLine);
}
