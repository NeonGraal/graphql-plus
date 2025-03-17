using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema;
using GqlPlus.Parsing;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Sample;

public class SchemaParserTests(
    Parser<IGqlpSchema>.D schemaParser
) : SampleSchemaChecks(schemaParser)
{
  [Theory]
  [ClassData(typeof(SamplesSchemaData))]
  public async Task ParseSchema(string sample)
  {
    IGqlpSchema ast = await ParseSample("Schema", sample);

    await CheckErrors("Schema", "", sample, ast.Errors);

    await Verify(ast.Show(), CustomSettings("Sample", "Schema", sample));
  }

  [Theory]
  [ClassData(typeof(SamplesSchemaSpecificationData))]
  public async Task ParseSpec(string sample)
  {
    IGqlpSchema ast = await ParseSample("Schema", sample, "Specification");

    await CheckErrors("Schema", "Specification", sample, ast.Errors);

    await Verify(ast.Show(), CustomSettings("Sample", "Specification", sample));
  }

  [Fact]
  public async Task Verify_All()
    => ParseInputs_Valid(await SchemaValidDataAll(), "!ALL");

  [Theory]
  [ClassData(typeof(SchemaValidData))]
  public async Task Verify_Groups(string group)
    => ParseInputs_Valid(await SchemaValidDataGroup(group), "!" + group);

  [Theory]
  [ClassData(typeof(SamplesSchemaGlobalsData))]
  public async Task Verify_Globals(string global)
    => await VerifyFile_Valid("Globals", global);

  [Theory]
  [ClassData(typeof(SamplesSchemaGlobalsInvalidData))]
  public async Task Verify_GlobalsInvalid(string global)
    => await ParseFile_Invalid("Globals/Invalid", global);

  [Theory]
  [ClassData(typeof(SamplesSchemaMergesData))]
  public async Task Verify_Merges(string merge)
    => await ReplaceFile("Merges", merge, ParseInput_Valid);

  [Theory]
  [ClassData(typeof(SamplesSchemaSimpleData))]
  public async Task Verify_Simple(string simple)
    => await VerifyFile_Valid("Simple", simple);

  [Theory]
  [ClassData(typeof(SamplesSchemaSimpleInvalidData))]
  public async Task Verify_SimpleInvalid(string simple)
    => await ParseFile_Invalid("Simple/Invalid", simple);

  [Theory]
  [ClassData(typeof(SamplesSchemaObjectsData))]
  public async Task Verify_Objects(string obj)
    => await ReplaceFile("Objects", obj, ParseInput_Valid);

  [Theory]
  [ClassData(typeof(SamplesSchemaObjectsInvalidData))]
  public async Task Verify_ObjectsInvalid(string obj)
    => await ReplaceFileAsync("Objects/Invalid", obj, ParseInput_Invalid);

  private async Task VerifyFile_Valid(string testDirectory, string testName)
  {
    string schema = await ReadSchema(testName, testDirectory);

    ParseInput_Valid(schema, testDirectory, testName);
  }

  private async Task ParseFile_Invalid(string testDirectory, string testName)
  {
    string schema = await ReadSchema(testName, testDirectory);

    await ParseInput_Invalid(schema, testDirectory, testName);
  }

  private void ParseInputs_Valid(IEnumerable<string> inputs, string testName)
  {
    string schema = inputs.Joined(Environment.NewLine);

    ParseInput_Valid(schema, "", testName);
  }

  private void ParseInput_Valid(string input, string _, string testName)
  {
    IResult<IGqlpSchema> parse = Parse(input);

    if (parse is IResultError<SchemaAst> error) {
      error.Message.ShouldBeNull(testName);
    }

    parse.IsOk().ShouldBeTrue(testName);
  }

  private async Task ParseInput_Invalid(string input, string testDirectory, string test)
  {
    IResult<IGqlpSchema> parse = Parse(input);

    TokenMessages result = [];
    if (!parse.IsOk()) {
      parse.IsError(e => result.Add(e with { Message = "Parse Error: " + e.Message }));
    }

    await CheckErrors("Schema", testDirectory, test, result);
  }
}
