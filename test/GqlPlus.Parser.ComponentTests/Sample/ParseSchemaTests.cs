using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Sample;

public class ParseSchemaTests(
    ISchemaParseChecks checks
) : TestSchemaInputs

{
  [Theory]
  [ClassData(typeof(SamplesSchemaGlobalsInvalidData))]
  public async Task Parse_GlobalsInvalid(string global)
    => await ParseFile_Invalid("Globals/Invalid", global);

  [Theory]
  [ClassData(typeof(SamplesSchemaSimpleInvalidData))]
  public async Task Parse_SimpleInvalid(string simple)
    => await ParseFile_Invalid("Simple/Invalid", simple);

  [Theory]
  [ClassData(typeof(SamplesSchemaObjectsInvalidData))]
  public async Task Parse_ObjectsInvalid(string obj)
    => await ReplaceFileAsync("Objects/Invalid", obj, ParseInput_Invalid);

  private async Task ParseFile_Invalid(string testDirectory, string testName)
  {
    string schema = await ReadSchema(testName, testDirectory);

    await ParseInput_Invalid(schema, testDirectory, testName);
  }

  private async Task ParseInput_Invalid(string input, string testDirectory, string test)
  {
    IResult<IGqlpSchema> parse = checks.Parse(input, "Schema");

    TokenMessages result = [];
    if (!parse.IsOk()) {
      parse.IsError(e => result.Add(e with { Message = "Parse Error: " + e.Message }));
    }

    await CheckErrors(["Schema", testDirectory], test, result);
  }

  protected override async Task Label_Input(string label, string input, string[] dirs, string test, string section = "")
  {
    IGqlpSchema ast = checks.ParseInput(input, label);

    await CheckErrors(dirs, test, ast.Errors);

    await Verify(ast.Show(), CustomSettings(label, "Parse", test, section));
  }

  protected override Task Sample_Input(string input, string section, string test)
  {
    IResult<IGqlpSchema> parse = checks.Parse(input, "Schema");

    if (parse is IResultError<SchemaAst> error) {
      error.Message.ShouldBeNull(test);
    }

    parse.IsOk().ShouldBeTrue(test);

    return Task.CompletedTask;
  }
}
