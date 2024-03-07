using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Modelling;

public class ParameterModelTests(
  IModeller<ParameterAst, ParameterModel> modeller
) : TestDescribedModel<string>
{
  internal override ICheckDescribedModel<string> DescribedChecks => _checks;

  protected override string[] ExpectedDescription(string input, string description)
    => string.IsNullOrWhiteSpace(description)
    ? ["!_Parameter", "type: !_Described(_ObjRef(_InputBase)) " + input]
    : ["!_Parameter", "type: !_Described(_ObjRef(_InputBase))", "  " + description, "  input: " + input];

  internal ParameterModelChecks _checks = new(modeller);
}

internal sealed class ParameterModelChecks(
  IModeller<ParameterAst, ParameterModel> modeller
) : CheckDescribedModel<string, ParameterAst, ParameterModel>(modeller)
{
  protected override ParameterAst NewDescribedAst(string input, string description)
    => new(AstNulls.At, input, description);
}
