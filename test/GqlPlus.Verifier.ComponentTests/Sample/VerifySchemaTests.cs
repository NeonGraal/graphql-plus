using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema;
using GqlPlus.Parsing;
using GqlPlus.Result;
using GqlPlus.Token;
using GqlPlus.Verifying;

namespace GqlPlus.Sample;

public class VerifySchemaTests(
    ISchemaParseChecks checks,
    IVerify<IGqlpSchema> schemaVerifier
) : TestSchemaResult(checks)

{
  [Theory]
  [ClassData(typeof(SamplesSchemaGlobalsInvalidData))]
  public async Task Verify_GlobalsInvalid(string global)
    => await VerifyFile_Invalid("Globals/Invalid", global);

  [Theory]
  [ClassData(typeof(SamplesSchemaSimpleInvalidData))]
  public async Task Verify_SimpleInvalid(string simple)
    => await VerifyFile_Invalid("Simple/Invalid", simple);

  [Theory]
  [ClassData(typeof(SamplesSchemaObjectsInvalidData))]
  public async Task Verify_ObjectsInvalid(string obj)
    => await ReplaceFileAsync("Objects/Invalid", obj, VerifyInput_Invalid);

  private async Task VerifyFile_Invalid(string testDirectory, string testName)
  {
    string schema = await ReadSchema(testName, testDirectory);

    await VerifyInput_Invalid(schema, testDirectory, testName);
  }

  private async Task VerifyInput_Invalid(string input, string testDirectory, string test)
  {
    IResult<IGqlpSchema> parse = checks.Parse(input, "Schema");

    TokenMessages result = [];
    if (parse.IsOk()) {
      schemaVerifier.Verify(parse.Required(), result);
    } else {
      parse.IsError(e => result.Add(e with { Message = "Parse Error: " + e.Message }));
    }

    await CheckErrors(["Schema", testDirectory], test, result, true);
  }

  protected override async Task Result_Valid(IResult<IGqlpSchema> result, string test, string label, string[] dirs, string section, string input = "")
  {
    if (result is IResultError<SchemaAst> error) {
      error.Message.ShouldBeNull(section.Prefixed(" ") + test);
    }

    TokenMessages errors = [];

    schemaVerifier.Verify(result.Required(), errors);

    if (!string.IsNullOrWhiteSpace(section)) {
      errors.ShouldBeEmpty(test);
    } else {
      await CheckErrors(dirs, test, errors, true);
    }
  }
}
