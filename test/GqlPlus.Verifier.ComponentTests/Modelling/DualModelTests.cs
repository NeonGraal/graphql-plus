using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Modelling;

public class DualModelTests(
  IModeller<DualDeclAst, TypeDualModel> modeller
) : TestObjectModel<DualDeclAst, DualFieldAst, DualReferenceAst>
{
  internal override ICheckObjectModel<DualDeclAst, DualFieldAst, DualReferenceAst> ObjectChecks => _checks;

  private readonly DualModelChecks _checks = new(modeller);
}

internal sealed class DualModelChecks(
  IModeller<DualDeclAst, TypeDualModel> modeller
) : CheckObjectModel<DualDeclAst, DualFieldAst, DualReferenceAst, TypeDualModel>(modeller, TypeKindModel.Dual)
{
  protected override DualDeclAst NewObjectAst(
    string name,
    DualReferenceAst? parent,
    string description,
    FieldInput[] fields,
    string[] alternates)
    => new(AstNulls.At, name, description) {
      Parent = parent,
      Fields = fields.DualFields(),
      Alternates = alternates.Alternates(NewReferenceAst),
    };
  internal override DualReferenceAst NewReferenceAst(string input)
    => new(AstNulls.At, input);
}
