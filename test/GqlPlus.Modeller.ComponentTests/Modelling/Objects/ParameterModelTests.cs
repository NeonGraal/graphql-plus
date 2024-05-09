using GqlPlus.Ast.Schema;

namespace GqlPlus.Modelling.Objects;

public class ParameterModelTests(
  IModeller<InputParameterAst, InputParameterModel> modeller
) : TestDescribedModel<string>
{
  internal override ICheckDescribedModel<string> DescribedChecks => _checks;

  internal ParameterModelChecks _checks = new(modeller);
}

internal sealed class ParameterModelChecks(
  IModeller<InputParameterAst, InputParameterModel> modeller
) : CheckDescribedModel<string, InputParameterAst, InputParameterModel>(modeller)
{
  protected override string[] ExpectedDescription(ExpectedDescriptionInput<string> input)
  {
    IEnumerable<string> description = input.Description.Indent();
    return description.Any()
      ? ["!_InputParameter",
        "type: !_BaseDescribed(_ObjRef(_InputBase))",
        "  base: !_InputBase " + input.Name,
        .. description]
        : ["!_InputParameter", "type: !_InputBase " + input.Name];
  }

  protected override InputParameterAst NewDescribedAst(string input, string description)
    => new(AstNulls.At, input, description);
}
