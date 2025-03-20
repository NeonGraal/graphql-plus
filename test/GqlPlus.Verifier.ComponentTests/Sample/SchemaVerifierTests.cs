using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema;
using GqlPlus.Parsing;
using GqlPlus.Result;
using GqlPlus.Token;
using GqlPlus.Verifying;

namespace GqlPlus.Sample;

public class SchemaVerifierTests(
    Parser<IGqlpSchema>.D schemaParser,
    IVerify<IGqlpSchema> schemaVerifier
) : SchemaDataBase(schemaParser)
{
  [Theory]
  [ClassData(typeof(SamplesSchemaData))]
  public async Task VerifySchema(string sample)
  {
    IGqlpSchema ast = await ParseSample("Schema", sample);
    TokenMessages errors = [];

    schemaVerifier.Verify(ast, errors);

    await CheckErrors("Schema", "", sample, errors, true);
  }

  [Theory]
  [ClassData(typeof(SamplesSchemaSpecificationData))]
  public async Task VerifySpec(string sample)
  {
    IGqlpSchema ast = await ParseSample("Spec", sample, "Specification");
    TokenMessages errors = [];

    schemaVerifier.Verify(ast, errors);

    await CheckErrors("Schema", "Specification", sample, errors, true);
  }

  [Fact]
  public async Task Verify_All()
    => VerifyInputs_Valid(await SchemaValidDataAll(), "!ALL");

  [Theory]
  [ClassData(typeof(SchemaValidData))]
  public async Task Verify_Groups(string group)
    => VerifyInputs_Valid(await SchemaValidDataGroup(group), "!" + group);

  [Theory]
  [ClassData(typeof(SamplesSchemaGlobalsData))]
  public async Task Verify_Globals(string global)
    => await VerifyFile_Valid("Globals", global);

  [Theory]
  [ClassData(typeof(SamplesSchemaGlobalsInvalidData))]
  public async Task Verify_GlobalsInvalid(string global)
    => await VerifyFile_Invalid("Globals/Invalid", global);

  [Theory]
  [ClassData(typeof(SamplesSchemaMergesData))]
  public async Task Verify_Merges(string merge)
    => await ReplaceFile("Merges", merge, VerifyInput_Valid);

  [Theory]
  [ClassData(typeof(SamplesSchemaSimpleData))]
  public async Task Verify_Simple(string simple)
    => await VerifyFile_Valid("Simple", simple);

  [Theory]
  [ClassData(typeof(SamplesSchemaSimpleInvalidData))]
  public async Task Verify_SimpleInvalid(string simple)
    => await VerifyFile_Invalid("Simple/Invalid", simple);

  [Theory]
  [ClassData(typeof(SamplesSchemaObjectsData))]
  public async Task Verify_Objects(string obj)
    => await ReplaceFile("Objects", obj, VerifyInput_Valid);

  [Theory]
  [ClassData(typeof(SamplesSchemaObjectsInvalidData))]
  public async Task Verify_ObjectsInvalid(string obj)
    => await ReplaceFileAsync("Objects/Invalid", obj, VerifyInput_Invalid);

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
