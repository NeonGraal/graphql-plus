using GqlPlus.Ast.Schema;

namespace GqlPlus.Modelling.Objects;

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
    IEnumerable<string> description = input.Description.Indent();
    return description.Any()
      ? ["!_Parameter",
        "type: !_BaseDescribed(_ObjRef(_InputBase))",
        "  base: !_InputBase " + input.Name,
        .. description]
        : ["!_Parameter", "type: !_InputBase " + input.Name];
  }

  protected override ParameterAst NewDescribedAst(string input, string description)
    => new(AstNulls.At, input, description);
}
