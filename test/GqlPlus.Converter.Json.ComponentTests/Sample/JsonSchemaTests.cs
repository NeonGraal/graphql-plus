using GqlPlus.Convert;
using Microsoft.Extensions.Logging;

namespace GqlPlus.Sample;

[Trait("Generate", "Json")]
public class JsonSchemaTests(
  ILoggerFactory logger,
  ISchemaVerifyChecks checks
) : TestSchemaVerify(logger, checks)
{
  protected override Task VerifyResult(Structured result, string label, string test, string section)
    => Verify(result.ToJson() + Environment.NewLine, "json", CustomSettings(label, "Json", test, section));
}
