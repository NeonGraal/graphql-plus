using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging;
using GqlPlus.Result;
using GqlPlus.Verifying;

namespace GqlPlus.Sample;

public class VerifySchemaTests(
  ISchemaParseChecks checks,
  IMerge<IGqlpSchema> schemaMerger,
  IVerify<IGqlpSchema> schemaVerifier
) : TestSchemaResult(checks)

{

  protected override async Task Result_Valid(IResult<IGqlpSchema> result, string test, string label, string[] dirs, string section, string input = "")
  {
    this.SkipIf(SchemaValidData.ExcludeSpecsForBuiltIn(test));

    if (result is IResultError error) {
      error.Message.ShouldBeNull(section.Prefixed(" ") + test);
    }

    IEnumerable<IGqlpSchema> merged = schemaMerger.Merge([result.Required()]);

    Messages errors = [];

    schemaVerifier.Verify(merged.First(), errors);

    await CheckErrors(dirs, test, errors, "verify", "parse");
  }

  protected override async Task Result_Invalid(IResult<IGqlpSchema> result, string test, string label, string[] dirs, string section, string input = "")
  {
    Messages errors = [];
    if (result.IsOk()) {
      schemaVerifier.Verify(result.Required(), errors);
    } else {
      result.IsError(e => errors.Add(e with { Message = "Parse Error: " + e.Message }));
    }

    await CheckErrors(dirs, test, errors, "verify", "parse");
  }
}
