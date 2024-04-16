using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Modelling.Objects;

public class InputReferenceModelTests(
  IModeller<InputReferenceAst, InputBaseModel> modeller
) : TestReferenceModel<InputReferenceAst>
{
  internal override ICheckReferenceModel<InputReferenceAst> ReferenceChecks => _checks;

  private readonly InputReferenceModelChecks _checks = new(modeller);
}

internal sealed class InputReferenceModelChecks(
  IModeller<InputReferenceAst, InputBaseModel> modeller
) : CheckReferenceModel<InputReferenceAst, InputBaseModel>(modeller, TypeKindModel.Input)
{
  protected override InputReferenceAst NewReferenceAst(string name)
    => new(AstNulls.At, name);
}
