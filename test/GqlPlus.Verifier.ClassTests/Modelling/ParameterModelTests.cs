using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Modelling;

public class ParameterModelTests
// Todo: : ModelDescribedTests<string>
{

  //internal override IModelDescribedChecks<string> DescribedChecks => _checks;
  //protected override string[] ExpectedDescription(string input, string description)
  //  => [];
}

internal sealed class ParameterModelChecks
  : DescribedModelChecks<string, ParameterAst, ParameterModel>
{
  public ParameterModelChecks()
    : base(new ParameterModeller(
      TestModeller<ConstantAst>.For(),
      TestModeller<ModifierAst>.For<ModifierModel>(
        m => new(m.Kind))))
  { }

  protected override ParameterAst NewDescribedAst(string input, string description)
    => new(AstNulls.At, input, description);
}
