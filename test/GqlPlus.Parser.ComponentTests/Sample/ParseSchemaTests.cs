using GqlPlus.Abstractions.Schema;
using GqlPlus.Result;

namespace GqlPlus.Sample;

public class ParseSchemaTests(
  ISchemaParseChecks checks
) : TestSchemaResult(checks)
{

  protected override async Task Result_Valid(IResult<IAstSchema> result, string test, string label, string[] dirs, string section, string input = "")
  {
    IAstSchema ast = result.Required();

    await CheckErrors(dirs, test, ast.Errors, "parse");

    await ast.Show().AttachAndVerify("Result " + test, CustomSettings(label, "Parse", test, section));
  }

  protected override async Task Result_Invalid(IResult<IAstSchema> result, string test, string label, string[] dirs, string section, string input = "")
  {
    IMessages errors = Messages.New;
    if (!result.IsOk()) {
      result.IsError(e => errors.Add(e with { Message = "Parse Error: " + e.Message }));
    }

    await CheckErrors(dirs, test, errors, "parse");
  }
}
