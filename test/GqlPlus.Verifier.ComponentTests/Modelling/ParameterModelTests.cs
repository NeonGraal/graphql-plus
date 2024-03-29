using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Modelling;

public class ParameterModelTests(
  IModeller<ParameterAst, ParameterModel> modeller
) : TestDescribedModel<string>
{
  internal override ICheckDescribedModel<string> DescribedChecks => _checks;

  internal ParameterModelChecks _checks = new(modeller);
}

internal sealed class ParameterModelChecks(
  IModeller<ParameterAst, ParameterModel> modeller
) : CheckDescribedModel<string, ParameterAst, ParameterModel>(modeller)
{
  protected override string[] ExpectedDescription(ExpectedDescriptionInput<string> input)
  {
    string[] description = [.. input.Description?.Select(d => "  " + d) ?? []];
    return description.Length == 0
      ? ["!_Parameter", "type: !_InputBase " + input.Name]
      : ["!_Parameter",
        "type: !_InputBase",
        .. description,
        "  input: " + input.Name];
  }

  protected override ParameterAst NewDescribedAst(string input, string description)
    => new(AstNulls.At, input, description);
}
