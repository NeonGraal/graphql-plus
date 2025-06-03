using GqlPlus.Convert;
using Microsoft.Extensions.Logging;

namespace GqlPlus.Sample;

public class JsonSchemaTests(
  ILoggerFactory logger,
  ISchemaVerifyChecks checks
) : TestSchemaVerify(logger, checks)
{
  protected override Task VerifyResult(Structured result, string label, string test, string section)
    => Verify(result.ToJson(), "json", CustomSettings(label, "Json", test, section));
}
