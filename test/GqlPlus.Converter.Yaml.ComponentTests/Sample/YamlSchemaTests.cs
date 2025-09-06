using GqlPlus.Convert;
using Microsoft.Extensions.Logging;

namespace GqlPlus.Sample;

[Trait("Generate", "Yaml")]
public class YamlSchemaTests(
  ILoggerFactory logger,
  ISchemaVerifyChecks checks
) : TestSchemaVerify(logger, checks)
{
  protected override Task VerifyResult(Structured result, string label, string test, string section)
    => Verify(result.ToYaml(string.IsNullOrWhiteSpace(section)), CustomSettings(label, "Yaml", test, section));
}
