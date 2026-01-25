using GqlPlus.Abstractions.Schema;

namespace GqlPlus;

public abstract class TestSchemaAsts(
  ISchemaParseChecks checks
) : TestSchemaInputs
{
  private const string TestLabel = "testLabel";

  protected override async Task Label_Input(string label, string input, string[] dirs, string test, string section)
  {
    TestContext.Current.AddAttachment("Input " + test, input);

    IGqlpSchema asts = checks.ParseInput(input, TestLabel);

    await Test_Asts([asts], test, TestLabel, dirs, section, input);
  }

  protected override async Task Label_Inputs(string label, IEnumerable<string> inputs, string test)
  {
    TestContext.Current.AddAttachment("Inputs " + test, inputs.Joined(Environment.NewLine));

    IEnumerable<IGqlpSchema> asts = inputs.Select(input => checks.ParseInput(input, TestLabel));

    await Test_Asts(asts, test, TestLabel, [TestLabel], "");
  }

  protected abstract Task Test_Asts(IEnumerable<IGqlpSchema> asts, string test, string label, string[] dirs, string section, string input = "");
}
