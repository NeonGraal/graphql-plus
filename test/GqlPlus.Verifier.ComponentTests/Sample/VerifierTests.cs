using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema;
using GqlPlus.Parsing;
using GqlPlus.Result;
using GqlPlus.Token;
using GqlPlus.Verifying;

namespace GqlPlus.Sample;

public class VerifierTests(
    Parser<IGqlpSchema>.D schemaParser,
    IVerify<IGqlpSchema> schemaVerifier
) : SchemaDataBase(schemaParser)
{
  [Theory]
  [ClassData(typeof(SampleSchemaData))]
  public async Task VerifySampleSchema(string sample)
  {
    IGqlpSchema ast = await ParseSampleSchema(sample);
    TokenMessages errors = [];

    schemaVerifier.Verify(ast, errors);

    await CheckErrors("Schema", "", sample, errors, true);
  }

  [Fact]
  public async Task Verify_All()
    => VerifyInputs_Valid(await SchemaValidAll(), "!ALL");

  [Theory]
  [ClassData(typeof(SchemaValidData))]
  public async Task Verify_Groups(string group)
    => VerifyInputs_Valid(await SchemaValidGroup(group), "!" + group);

  [Theory]
  [ClassData(typeof(SchemaValidGlobalsData))]
  public async Task Verify_Globals(string global)
    => await VerifyFile_Valid("ValidGlobals", global);

  [Theory]
  [ClassData(typeof(SchemaInvalidGlobalsData))]
  public async Task Verify_GlobalsInvalid(string global)
    => await VerifyFile_Invalid("InvalidGlobals", global);

  [Theory]
  [ClassData(typeof(SchemaValidMergesData))]
  public async Task Verify_Merges(string merge)
    => await ReplaceFile("ValidMerges", merge, VerifyInput_Valid);

  [Theory]
  [ClassData(typeof(SchemaValidSimpleData))]
  public async Task Verify_Simple(string simple)
    => await VerifyFile_Valid("ValidSimple", simple);

  [Theory]
  [ClassData(typeof(SchemaInvalidSimpleData))]
  public async Task Verify_SimpleInvalid(string simple)
    => await VerifyFile_Invalid("InvalidSimple", simple);

  [Theory]
  [ClassData(typeof(SchemaValidObjectsData))]
  public async Task Verify_Objects(string obj)
    => await ReplaceFile("ValidObjects", obj, VerifyInput_Valid);

  [Theory]
  [ClassData(typeof(SchemaInvalidObjectsData))]
  public async Task Verify_ObjectsInvalid(string obj)
    => await ReplaceFileAsync("InvalidObjects", obj, VerifyInput_Invalid);

  private async Task VerifyFile_Valid(string testDirectory, string testName)
  {
    string schema = await ReadSchema(testName, testDirectory);

    VerifyInput_Valid(schema, testDirectory, testName);
  }

  private async Task VerifyFile_Invalid(string testDirectory, string testName)
  {
    string schema = await ReadSchema(testName, testDirectory);

    await VerifyInput_Invalid(schema, testDirectory, testName);
  }

  private void VerifyInputs_Valid(IEnumerable<string> inputs, string testName)
  {
    string schema = inputs.Joined(Environment.NewLine);

    VerifyInput_Valid(schema, "", testName);
  }

  private void VerifyInput_Valid(string input, string testDirectory, string testName)
  {
    IResult<IGqlpSchema> parse = Parse(input);

    if (parse is IResultError<SchemaAst> error) {
      error.Message.ShouldBeNull(testName);
    }

    TokenMessages result = [];

    schemaVerifier.Verify(parse.Required(), result);

    result.ShouldBeEmpty(testName);
  }

  private async Task VerifyInput_Invalid(string input, string testDirectory, string test)
  {
    IResult<IGqlpSchema> parse = Parse(input);

    TokenMessages result = [];
    if (parse.IsOk()) {
      schemaVerifier.Verify(parse.Required(), result);
    } else {
      parse.IsError(e => result.Add(e with { Message = "Parse Error: " + e.Message }));
    }

    await CheckErrors("Schema", testDirectory, test, result, true);
  }
}
