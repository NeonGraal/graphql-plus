using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema;
using GqlPlus.Parsing;
using GqlPlus.Result;
using GqlPlus.Token;
using GqlPlus.Verifying;

namespace GqlPlus.Schema;

public class VerifierTests(
    Parser<IGqlpSchema>.D parser,
    IVerify<IGqlpSchema> verifier
) : SchemaDataBase(parser)
{
  [Theory]
  [ClassData(typeof(SchemaValidGlobalsData))]
  public async Task Verify_ValidGlobals(string global)
    => await VerifyFile_Valid("ValidGlobals", global);

  [Theory]
  [ClassData(typeof(SchemaInvalidGlobalsData))]
  public async Task Verify_InvalidGlobals(string global)
    => await VerifyFile_Invalid("InvalidGlobals", global);

  [Theory]
  [ClassData(typeof(SchemaValidMergesData))]
  public async Task Verify_ValidMerges(string merge)
    => await ReplaceFile("ValidMerges", merge, VerifyInput_Valid);

  [Theory]
  [ClassData(typeof(SchemaValidSimpleData))]
  public async Task Verify_ValidSimple(string simple)
    => await VerifyFile_Valid("ValidSimple", simple);

  [Theory]
  [ClassData(typeof(SchemaInvalidSimpleData))]
  public async Task Verify_InvalidSimple(string simple)
    => await VerifyFile_Invalid("InvalidSimple", simple);

  [Theory]
  [ClassData(typeof(SchemaValidObjectsData))]
  public async Task Verify_ValidObjects(string obj)
    => await ReplaceFile("ValidObjects", obj, VerifyInput_Valid);

  [Theory]
  [ClassData(typeof(SchemaInvalidObjectsData))]
  public async Task Verify_InvalidObjects(string obj)
    => await ReplaceFileAsync("InvalidObjects", obj, VerifyInput_Invalid);

  private async Task VerifyFile_Valid(string testDirectory, string testName)
  {
    string schema = await ReadSchema(testName, testDirectory);

    VerifyInput_Valid(schema, testName);
  }

  private async Task VerifyFile_Invalid(string testDirectory, string testName)
  {
    string schema = await ReadSchema(testName, testDirectory);

    await VerifyInput_Invalid(schema, $"{testDirectory}/{testName}");
  }

  private void VerifyInput_Valid(string input, string testName)
  {
    IResult<IGqlpSchema> parse = Parse(input);

    if (parse is IResultError<SchemaAst> error) {
      error.Message.Should().BeNull(testName);
    }

    TokenMessages result = [];

    verifier.Verify(parse.Required(), result);

    result.Should().BeNullOrEmpty(testName);
  }

  private async Task VerifyInput_Invalid(string input, string test)
  {
    IResult<IGqlpSchema> parse = Parse(input);

    TokenMessages result = [];
    if (parse.IsOk()) {
      verifier.Verify(parse.Required(), result);
    } else {
      parse.IsError(e => result.Add(e with { Message = "Parse Error: " + e.Message }));
    }

    await CheckErrors("Schema", test, result, true);
  }
}
