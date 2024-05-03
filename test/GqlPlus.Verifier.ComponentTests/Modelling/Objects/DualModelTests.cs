using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Modelling.Objects;

public class DualModelTests(
  IModeller<DualDeclAst, TypeDualModel> modeller
) : TestObjectModel<DualDeclAst, DualFieldAst, DualBaseAst>
{
  internal override ICheckObjectModel<DualDeclAst, DualFieldAst, DualBaseAst> ObjectChecks => _checks;

  private readonly DualModelChecks _checks = new(modeller);
}

internal sealed class DualModelChecks(
  IModeller<DualDeclAst, TypeDualModel> modeller
) : CheckObjectModel<DualDeclAst, DualFieldAst, DualBaseAst, TypeDualModel>(modeller, TypeKindModel.Dual)
{
  protected override DualDeclAst NewObjectAst(
    string name,
    DualBaseAst? parent,
    string description,
    FieldInput[] fields,
    string[] alternates)
    => new(AstNulls.At, name, description) {
      Parent = parent,
      Fields = fields.DualFields(),
      Alternates = alternates.Alternates(NewParentAst),
    };
  internal override DualBaseAst NewParentAst(string input)
    => new(AstNulls.At, input);
}
