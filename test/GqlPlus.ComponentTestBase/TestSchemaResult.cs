using GqlPlus.Abstractions.Schema;
using GqlPlus.Result;

namespace GqlPlus;

public abstract class TestSchemaResult(
    ISchemaParseChecks checks
) : TestSchemaInputs
{
  protected override async Task Label_Input(string label, string input, string[] dirs, string test, string section)
  {
    IResult<IGqlpSchema> result = checks.Parse(input, label);

    await Result_Valid(result, test, label, dirs, section, input);
  }

  protected override Task Label_Inputs(string label, IEnumerable<string> inputs, string test)
    => base.Label_Inputs(label, inputs, test);


  protected abstract Task Result_Valid(IResult<IGqlpSchema> result, string test, string label, string[] dirs, string section, string input = "");
}
