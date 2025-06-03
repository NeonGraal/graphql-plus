using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema;
using GqlPlus.Result;
using GqlPlus.Token;
using Microsoft.Extensions.Logging;

namespace GqlPlus.Sample;

public class ParseSchemaTests(
  ILoggerFactory logger,
  ISchemaParseChecks checks
) : TestSchemaResult(logger, checks)
{
  protected override async Task Result_Valid(IResult<IGqlpSchema> result, string test, string label, string[] dirs, string section, string input = "")
  {
    if (string.IsNullOrWhiteSpace(section)) {
      IGqlpSchema ast = result.Required();

      await CheckErrors(dirs, test, ast.Errors);

      await Verify(ast.Show(), CustomSettings(label, "Parse", test));
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
    TokenMessages errors = [];
    if (!result.IsOk()) {
      result.IsError(e => errors.Add(e with { Message = "Parse Error: " + e.Message }));
    }

    await CheckErrors(dirs, test, errors);
  }
}
