using GqlPlus.Ast.Schema;

namespace GqlPlus;

public abstract class TestSchemaAsts(
  ISchemaParseChecks checks
) : TestSchemaInputs
{

  protected override async Task Label_Input(string label, string input, string[] dirs, string test, string section)
  {
    IAstSchema asts = checks.ParseInput(input, label);

    await Test_Asts([asts], test, label, dirs, section, input);
  }

  protected override async Task Label_Inputs(string label, IEnumerable<string> inputs, string test)
  {
    inputs.Joined(Environment.NewLine).AttachAs("Inputs " + test);

    IEnumerable<IAstSchema> asts = inputs.Select(input => checks.ParseInput(input, label));

    await Test_Asts(asts, test, label, [label], "");
  }

  protected abstract Task Test_Asts(IEnumerable<IAstSchema> asts, string test, string label, string[] dirs, string section, string input = "");
}
