using System.Diagnostics.CodeAnalysis;
using GqlPlus.Convert;
using GqlPlus.Resolving;
using Microsoft.Extensions.Logging;

namespace GqlPlus.Sample;

public class LinesSchemaTests(
  ILoggerFactory logger,
  ISchemaVerifyChecks checks
) : TestSchemaVerify(logger, checks)
{

  protected override Task VerifyResult(Structured result, string label, string test, string section)
    => Verify(result.ToLines(true).Joined(Environment.NewLine), CustomSettings(label, "Lines", test, section));

  protected override void CheckNoErrors([NotNull] IModelsContext context, string test)
    => context.Errors.ShouldBeEmpty(test);

  protected override Task CheckResultErrors(string[] dirs, string test, IMessages errors, bool includeVerify = false)
    => CheckErrors(dirs, test, errors, includeVerify);
}
