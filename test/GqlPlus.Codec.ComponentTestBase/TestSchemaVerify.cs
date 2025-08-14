using System.Diagnostics.CodeAnalysis;
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
    (SchemaModel model, IModelsContext context) = checks.Model_Asts(asts, !SchemaValidData.ExcludeSpecsForBuiltIn(test));

    await EncodeModel(model, context, test, label, dirs, section);

    await CheckResultErrors(dirs, test, context.Errors);
  }

  protected virtual async Task EncodeModel([NotNull] SchemaModel model, IModelsContext context, string test, string label, string[] dirs, string section)
  {
    Structured result = checks.Encode_Model(model, context);

    await VerifyResult(result, label, test, section);
  }

  protected virtual Task CheckResultErrors(string[] dirs, string test, IMessages errors, bool includeVerify = false)
    => Task.CompletedTask;

  protected abstract Task VerifyResult(Structured result, string label, string test, string section);
}
