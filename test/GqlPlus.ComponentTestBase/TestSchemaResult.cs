using GqlPlus.Abstractions.Schema;
using GqlPlus.Result;
using Microsoft.Extensions.Logging;
using Parlot.Fluent;

namespace GqlPlus;

public abstract class TestSchemaResult(
  ILoggerFactory logger,
  ISchemaParseChecks checks
) : TestSchemaInputs
{
  [Theory]
  [ClassData(typeof(SamplesSchemaMergesInvalidData))]
  public async Task Test_MergesInvalid(string model)
    => await ReplaceFileAsync("Merges/Invalid", model, SampleInvalid_Input);

  [Theory]
  [ClassData(typeof(SamplesSchemaObjectsInvalidData))]
  public async Task Test_ObjectsInvalid(string model)
    => await ReplaceFileAsync("Objects/Invalid", model, SampleInvalid_Input);

  [Theory]
  [ClassData(typeof(SamplesSchemaGlobalsInvalidData))]
  public async Task Test_GlobalsInvalid(string global)
    => await ReplaceFileAsync("Globals/Invalid", global, SampleInvalid_Input);

  [Theory]
  [ClassData(typeof(SamplesSchemaSimpleInvalidData))]
  public async Task Test_SimpleInvalid(string simple)
    => await ReplaceFileAsync("Simple/Invalid", simple, SampleInvalid_Input);

  private readonly ILogger _logger = logger.CreateTypedLogger<TestSchemaAsts>();

  protected virtual async Task SampleInvalid_Input(string input, string section, string test)
  {
    _logger.ParsingLabelledInput("Sample", input);

    IResult<IGqlpSchema> parse = checks.Parse(input, "Schema");
    if (parse.Required(s => s.Errors.ShouldBeEmpty())) {
      await Result_Invalid(parse, test, "Sample", ["Schema", section], test, section);
    } else {
      true.ShouldBeFalse("Expected valid parse result with no errors");
    }
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
