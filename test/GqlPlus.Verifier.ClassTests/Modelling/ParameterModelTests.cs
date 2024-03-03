using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Modelling;

public class ParameterModelTests
  : DescribedModelTests<string>
{
  internal override IDescribedModelChecks<string> DescribedChecks => _checks;

  protected override string[] ExpectedDescription(string input, string description)
    => string.IsNullOrWhiteSpace(description)
    ? ["!_Parameter", "type: !_Described(_ObjRef(_InputBase)) " + input]
    : ["!_Parameter", "type: !_Described(_ObjRef(_InputBase))", "  " + description, "  input: " + input];

  internal ParameterModelChecks _checks;

  public ParameterModelTests()
  {
    InputReferenceModeller reference = new();
    ModifierModeller modifier = new();
    AlternateModeller<InputReferenceAst, InputBaseModel> alternate = new(reference, modifier);
    SimpleModeller simple = new();
    ConstantModeller constant = new(simple);

    _checks = new(new ParameterModeller(alternate, constant));
  }
}

internal sealed class ParameterModelChecks(
  IModeller<ParameterAst> modeller
) : DescribedModelChecks<string, ParameterAst, ParameterModel>(modeller)
{
  protected override ParameterAst NewDescribedAst(string input, string description)
    => new(AstNulls.At, input, description);
}
