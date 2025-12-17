using GqlPlus.Convert;

namespace GqlPlus.Sample;

[Trait("Generate", "Yaml")]
[Trait("Generate", "Plain")]
public class PlainSchemaTests(
  ISchemaVerifyChecks checks
) : TestSchemaVerify(checks)
{
  protected override Task VerifyResult(Structured result, string label, string test, string section)
    => Verify(result.ToPlain(true).Joined(Environment.NewLine), CustomSettings(label, "Plain", test, section));

  protected override Task CheckResultErrors(string[] dirs, string test, IMessages errors, bool includeVerify = false)
    => CheckErrors(dirs, test, errors, includeVerify);
}
