using System.Diagnostics.CodeAnalysis;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Resolving;
using VerifyTests;
using Xunit;

namespace GqlPlus;

public abstract class TestSchemaVerify(
  ISchemaVerifyChecks checks
) : TestSchemaAsts(checks)
{

  protected override async Task Test_Asts(IEnumerable<IGqlpSchema> asts, string test, string label, string[] dirs, string section, string input = "")
  {
    (SchemaModel model, IModelsContext context) = checks.Model_Asts(asts, !SchemaValidData.ExcludeSpecsForBuiltIn(test));

    await EncodeModel(model, context, test, TestLabel, dirs, section);

    await CheckResultErrors(dirs, test, context.Errors);
  }

  protected virtual async Task EncodeModel([NotNull] SchemaModel model, IModelsContext context, string test, string label, string[] dirs, string section)
  {
    Structured result = checks.Encode_Model(model, context);
    VerifySettings settings = CustomSettings(TestLabel, ResultGroup, test, section);
    string target = EncodeResult(result, section);
    TestContext.Current.AddAttachment("Output " + test, target);
    await VerifyResult(target, settings);
  }

  protected virtual Task CheckResultErrors(string[] dirs, string test, IMessages errors, bool includeVerify = false)
    => Task.CompletedTask;

  protected abstract Task VerifyResult(string target, VerifySettings settings);
  public abstract string ResultGroup { get; }
  public abstract string EncodeResult(Structured result, string section);
}
