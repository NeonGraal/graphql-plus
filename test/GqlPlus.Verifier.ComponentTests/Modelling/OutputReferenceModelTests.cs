using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Modelling;

public class OutputReferenceModelTests(
  IModeller<OutputReferenceAst, OutputBaseModel> modeller
) : TestReferenceModel<OutputReferenceAst>
{
  internal override ICheckReferenceModel<OutputReferenceAst> ReferenceChecks => _checks;

  private readonly OutputReferenceModelChecks _checks = new(modeller);
}

internal sealed class OutputReferenceModelChecks(
  IModeller<OutputReferenceAst, OutputBaseModel> modeller
) : CheckReferenceModel<OutputReferenceAst, OutputBaseModel>(modeller, TypeKindModel.Output)
{
  protected override OutputReferenceAst NewReferenceAst(string name)
    => new(AstNulls.At, name);
}
