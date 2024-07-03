using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Modelling.Objects;

public class DualModelTests(
  IModeller<IGqlpDualObject, TypeDualModel> modeller,
  IRenderer<TypeDualModel> rendering
) : TestObjectModel<IGqlpDualObject, IGqlpDualBase, IGqlpDualField, IGqlpDualAlternate>
{
  internal override ICheckObjectModel<IGqlpDualObject, IGqlpDualBase, IGqlpDualField, IGqlpDualAlternate> ObjectChecks => _checks;

  private readonly DualModelChecks _checks = new(modeller, rendering);
}

internal sealed class DualModelChecks(
  IModeller<IGqlpDualObject, TypeDualModel> modeller,
  IRenderer<TypeDualModel> rendering
) : CheckObjectModel<IGqlpDualObject, DualDeclAst, IGqlpDualField, DualFieldAst, IGqlpDualAlternate, DualAlternateAst, IGqlpDualBase, TypeDualModel>(modeller, rendering, TypeKindModel.Dual)
{
  protected override DualDeclAst NewObjectAst(ExpectedObjectInput input, IGqlpObjBase? parent = null)
    => new(AstNulls.At, input.Name, input.Description) {
      Aliases = input.Aliases,
      Parent = parent ?? (input.Parent is not null ? NewParentAst(input.Parent) : null),
      TypeParameters = input.TypeParameters.TypeParameters(),
      ObjFields = input.Fields.DualFields(),
      ObjAlternates = input.Alternates.DualAlternates(),
    };

  internal override IGqlpDualBase NewParentAst(string input)
    => new DualBaseAst(AstNulls.At, input);
}
