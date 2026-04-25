using GqlPlus.Convert;

namespace GqlPlus.Sample;

[Trait("Generate", "Yaml")]
[Trait("Generate", "SimpleYaml")]
public class SimpleYamlSchemaTests(
  ISchemaVerifyChecks checks
) : TestSchemaVerify(checks)
{
  public override string ResultGroup => "SimpleYaml";
  protected override Task CheckResultErrors(string[] dirs, string test, IMessages errors)
    => CheckErrors(dirs, test, errors, ["encode", "parse"]);
  protected override Task VerifyResult(string target, VerifySettings settings)
    => Verify(target, settings);
  public override string EncodeResult(Structured result, string section)
    => result.ToSimpleYaml(true).Joined(Environment.NewLine);
}
