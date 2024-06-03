using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Modelling.Objects;

public class InputParameterModelTests(
  IModeller<IGqlpInputParameter, InputParameterModel> modeller
) : TestDescribedModel<string>
{
  internal override ICheckDescribedModel<string> DescribedChecks => _checks;

  internal ParameterModelChecks _checks = new(modeller);
}

internal sealed class ParameterModelChecks(
  IModeller<IGqlpInputParameter, InputParameterModel> modeller
) : CheckDescribedModel<string, IGqlpInputParameter, InputParameterModel>(modeller)
{
  protected override string[] ExpectedDescription(ExpectedDescriptionInput<string> input)
  {
    IEnumerable<string> description = input.Description;
    return description.Any()
      ? ["!_InputParameter",
        "base: !_InputBase",
        "  input: " + input.Name,
        .. description]
        : ["!_InputParameter", "input: " + input.Name];
  }

  protected override InputParameterAst NewDescribedAst(string input, string description)
    => new(AstNulls.At, input, description);
}
