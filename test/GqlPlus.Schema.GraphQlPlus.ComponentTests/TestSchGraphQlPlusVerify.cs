using GqlPlus.Ast.Schema;
using GqlPlus.Resolving;
using GqlPlus.Schema;

namespace GqlPlus;

public abstract class TestSchGraphQlPlusVerify(
  ISchGraphQlPlusVerifyChecks checks
) : TestSchemaAsts(checks)
{
  protected override async Task Test_Asts(IEnumerable<IAstSchema> asts, string test, string label, string[] dirs, string section, string input = "")
  {
    (ISch_SchemaObject adapted, IModelsContext context) = checks.Adapt_Asts(asts, !SchemaValidData.ExcludeSpecsForBuiltIn(test), section == "Introspection");

    Structured result = checks.Encode_Schema(adapted);
    VerifySettings settings = CustomSettings(label, ResultGroup, test, section);
    string target = EncodeResult(result, section);
    TestContext.Current.AddAttachment("Output " + test, target);
    await VerifyResult(target, settings);
  }

  protected abstract Task VerifyResult(string target, VerifySettings settings);
  public abstract string ResultGroup { get; }
  public abstract string EncodeResult(Structured result, string section);
}
