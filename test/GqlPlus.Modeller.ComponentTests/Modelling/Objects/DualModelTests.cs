using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Modelling.Objects;

public class DualModelTests(
  IDualModelChecks checks
) : TestObjectModel<IGqlpDualObject, IGqlpDualBase, IGqlpDualField, IGqlpDualAlternate, TypeDualModel>(checks)
{ }

internal sealed class DualModelChecks(
  IModeller<IGqlpDualObject, TypeDualModel> modeller,
  IRenderer<TypeDualModel> rendering
) : CheckObjectModel<IGqlpDualObject, DualDeclAst, IGqlpDualField, DualFieldAst, IGqlpDualAlternate, DualAlternateAst, IGqlpDualBase, TypeDualModel>(modeller, rendering, TypeKindModel.Dual)
  , IDualModelChecks
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

public interface IDualModelChecks
  : ICheckObjectModel<IGqlpDualObject, IGqlpDualBase, IGqlpDualField, IGqlpDualAlternate, TypeDualModel>
{ }
