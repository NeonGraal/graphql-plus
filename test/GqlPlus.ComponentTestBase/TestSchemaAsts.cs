using GqlPlus.Abstractions.Schema;
using Microsoft.Extensions.Logging;

namespace GqlPlus;

public abstract class TestSchemaAsts(
  ILoggerFactory logger,
  ISchemaParseChecks checks
) : TestSchemaInputs
{
  private readonly ILogger _logger = logger.CreateLogger(nameof(TestSchemaAsts));

  protected override async Task Label_Input(string label, string input, string[] dirs, string test, string section)
  {
    _logger.ParsingLabelledInput(label, input);

    IGqlpSchema asts = checks.ParseInput(input, label);

    await Test_Asts([asts], test, label, dirs, section, input);
  }

  protected override async Task Label_Inputs(string label, IEnumerable<string> inputs, string test)
  {
    _logger.ParsingLabelledInput(label, inputs.Joined(Environment.NewLine));

    IEnumerable<IGqlpSchema> asts = inputs.Select(input => checks.ParseInput(input, label));

    await Test_Asts(asts, test, label, [label], "");
  }

  protected abstract Task Test_Asts(IEnumerable<IGqlpSchema> asts, string test, string label, string[] dirs, string section, string input = "");
}
