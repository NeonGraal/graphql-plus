using GqlPlus.Abstractions.Schema;
using GqlPlus.Result;
using Microsoft.Extensions.Logging;

namespace GqlPlus;

public abstract class TestSchemaResult(
  ILoggerFactory logger,
  ISchemaParseChecks checks
) : TestSchemaInputs
{
  [Theory]
  [ClassData(typeof(SamplesSchemaMergeInvalidData))]
  public async Task Test_MergesInvalid(string model)
    => await ReplaceFileAsync("Merge/Invalid", model, SampleInvalid_Input);

  [Theory]
  [ClassData(typeof(SamplesSchemaObjectInvalidData))]
  public async Task Test_ObjectsInvalid(string model)
    => await ReplaceFileAsync("Object/Invalid", model, SampleInvalid_Input);

  [Theory]
  [ClassData(typeof(SamplesSchemaGlobalInvalidData))]
  public async Task Test_GlobalsInvalid(string global)
    => await ReplaceFileAsync("Global/Invalid", global, SampleInvalid_Input);

  [Theory]
  [ClassData(typeof(SamplesSchemaSimpleInvalidData))]
  public async Task Test_SimpleInvalid(string simple)
    => await ReplaceFileAsync("Simple/Invalid", simple, SampleInvalid_Input);

  private readonly ILogger _logger = logger.CreateTypedLogger<TestSchemaAsts>();

  protected virtual async Task SampleInvalid_Input(string input, string section, string test)
  {
    _logger.ParsingLabelledInput("Sample", input);

    IResult<IGqlpSchema> parse = checks.Parse(input, "Schema");

    await Result_Invalid(parse, test, "Sample", ["Schema", section], test, section);
  }

  protected override async Task Label_Input(string label, string input, string[] dirs, string test, string section)
  {
    _logger.ParsingLabelledInput(label, input);

    IResult<IGqlpSchema> result = checks.Parse(input, label);

    await Result_Valid(result, test, label, dirs, section, input);
  }

  protected override Task Label_Inputs(string label, IEnumerable<string> inputs, string test)
    => base.Label_Inputs(label, inputs, test);

  protected abstract Task Result_Valid(IResult<IGqlpSchema> result, string test, string label, string[] dirs, string section, string input = "");
  protected abstract Task Result_Invalid(IResult<IGqlpSchema> result, string test, string label, string[] dirs, string section, string input = "");
}
