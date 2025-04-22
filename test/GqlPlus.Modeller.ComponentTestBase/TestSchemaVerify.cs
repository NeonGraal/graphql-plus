using GqlPlus.Abstractions;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Resolving;
using Microsoft.Extensions.Logging;

namespace GqlPlus;

public abstract class TestSchemaVerify(
  ILoggerFactory logger,
  ISchemaVerifyChecks checks
) : TestSchemaAsts(logger, checks)
{
  protected override async Task Test_Asts(IEnumerable<IGqlpSchema> asts, string test, string label, string[] dirs, string section, string input = "")
  {
    (Structured result, ITypesContext context) = checks.Verify_Asts(asts);

    await VerifyResult(result, label, test, section);

    if (string.IsNullOrWhiteSpace(section)) {
      await CheckResultErrors(dirs, test, context.Errors);
    } else {
      CheckNoErrors(context, test);
    }
  }

  protected virtual void CheckNoErrors(ITypesContext context, string test)
  { }

  protected virtual Task CheckResultErrors(string[] dirs, string test, ITokenMessages errors, bool includeVerify = false)
    => Task.CompletedTask;

  protected abstract Task VerifyResult(Structured result, string label, string test, string section);
}
