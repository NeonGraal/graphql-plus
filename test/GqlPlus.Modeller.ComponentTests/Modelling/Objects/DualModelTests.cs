using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Modelling.Objects;

public class DualModelTests(
  IModeller<IGqlpDualObject, TypeDualModel> modeller,
  IRenderer<TypeDualModel> rendering
) : TestObjectModel<DualDeclAst, IGqlpDualField, DualFieldAst, IGqlpDualAlternate, DualAlternateAst, IGqlpDualBase, DualBaseAst>
{
  internal override ICheckObjectModel<DualDeclAst, IGqlpDualField, IGqlpDualAlternate, IGqlpDualBase> ObjectChecks => _checks;

  private readonly DualModelChecks _checks = new(modeller, rendering);
}

internal sealed class DualModelChecks(
  IModeller<IGqlpDualObject, TypeDualModel> modeller,
  IRenderer<TypeDualModel> rendering
) : CheckObjectModel<IGqlpDualObject, DualDeclAst, IGqlpDualField, DualFieldAst, IGqlpDualAlternate, DualAlternateAst, IGqlpDualBase, TypeDualModel>(modeller, rendering, TypeKindModel.Dual)
{
  protected override DualDeclAst NewObjectAst(
    string name,
    IGqlpDualBase? parent,
    string? description,
    string[]? aliases,
    FieldInput[] fields,
    AlternateInput[] alternates)
    => new(AstNulls.At, name, description ?? "") {
      Aliases = aliases ?? [],
      Parent = (DualBaseAst?)parent,
      Fields = fields.DualFields(),
      Alternates = alternates.DualAlternates(),
    };
  internal override IGqlpDualBase NewParentAst(string input)
    => new DualBaseAst(AstNulls.At, input);
}
