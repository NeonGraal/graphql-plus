using GqlPlus.Abstractions.Schema;
using GqlPlus.Result;
using GqlPlus.Verifying;
using Microsoft.Extensions.Logging;

namespace GqlPlus.Sample;

public class VerifySchemaTests(
  ILoggerFactory logger,
  ISchemaParseChecks checks,
  IVerify<IGqlpSchema> schemaVerifier
) : TestSchemaResult(logger, checks)

{
  protected override async Task Result_Valid(IResult<IGqlpSchema> result, string test, string label, string[] dirs, string section, string input = "")
  {
    this.SkipIf(test == SchemaValidData.SpecDefinition);
    if (result is IResultError error) {
      error.Message.ShouldBeNull(section.Prefixed(" ") + test);
    }

    Messages errors = [];

    schemaVerifier.Verify(result.Required(), errors);

    await CheckErrors(dirs, test, errors, true);
  }

  protected override async Task Result_Invalid(IResult<IGqlpSchema> result, string test, string label, string[] dirs, string section, string input = "")
  {
    Messages errors = [];
    if (result.IsOk()) {
      schemaVerifier.Verify(result.Required(), errors);
    } else {
      result.IsError(e => errors.Add(e with { Message = "Parse Error: " + e.Message }));
    }

    await CheckErrors(dirs, test, errors, true);
  }
}
