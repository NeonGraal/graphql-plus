using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema;
using GqlPlus.Result;

namespace GqlPlus.Sample;

public class ParseSchemaTests(
  ISchemaParseChecks checks
) : TestSchemaResult(checks)
{

  protected override async Task Result_Valid(IResult<IGqlpSchema> result, string test, string label, string[] dirs, string section, string input = "")
  {
    if (string.IsNullOrWhiteSpace(section)) {
      IGqlpSchema ast = result.Required();

      await CheckErrors(dirs, test, ast.Errors);

      string target = ast.Show();
      TestContext.Current.AddAttachment("Result " + test, target);
      await Verify(target, CustomSettings(label, "Parse", test));
    } else {
      string testName = section + " " + test;

      if (result is IResultError<SchemaAst> error) {
        error.Message.ShouldBeNull(testName);
      }

      result.IsOk().ShouldBeTrue(testName);
    }
  }

  protected override async Task Result_Invalid(IResult<IGqlpSchema> result, string test, string label, string[] dirs, string section, string input = "")
  {
    Messages errors = [];
    if (!result.IsOk()) {
      result.IsError(e => errors.Add(e with { Message = "Parse Error: " + e.Message }));
    }

    await CheckErrors(dirs, test, errors);
  }
}
