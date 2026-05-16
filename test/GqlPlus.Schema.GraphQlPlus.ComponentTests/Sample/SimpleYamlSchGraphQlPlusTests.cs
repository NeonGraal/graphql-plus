namespace GqlPlus.Sample;

[Trait("Generate", "Yaml")]
[Trait("Generate", "SimpleYaml")]
public class SimpleYamlSchGraphQlPlusTests(
  ISchGraphQlPlusVerifyChecks checks
) : TestSchGraphQlPlusVerify(checks)
{
  public override string ResultGroup => "SimpleYaml";
  protected override Task VerifyResult(string target, VerifySettings settings)
    => Verify(target, settings);
  public override string EncodeResult(Structured result, string section)
    => result.ToSimpleYaml(true).Joined(Environment.NewLine);
}
