using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Modelling.Objects;

public class DualModelTests(
  IDualModelChecks checks
) : TestObjectModel<IGqlpDualObject, IGqlpDualBase, IGqlpDualField, IGqlpDualAlternate, TypeDualModel>(checks)
{ }

internal sealed class DualModelChecks(
  CheckTypeInputs<IGqlpDualObject, TypeDualModel> inputs
) : CheckObjectModel<IGqlpDualObject, DualDeclAst, IGqlpDualField, DualFieldAst, IGqlpDualAlternate, DualAlternateAst, IGqlpDualBase, TypeDualModel>(inputs, TypeKindModel.Dual)
  , IDualModelChecks
{
  protected override DualDeclAst NewObjectAst(ExpectedObjectInput input, IGqlpObjBase? parent = null)
    => new(AstNulls.At, input.Name, input.Description) {
      Aliases = input.Aliases,
      Parent = parent ?? (input.Parent is not null ? NewParentAst(input.Parent) : null),
      TypeParams = input.TypeParams.TypeParams(),
      ObjFields = input.Fields.DualFields(),
      ObjAlternates = input.Alternates.DualAlternates(),
    };

  internal override IGqlpDualBase NewParentAst(string input)
    => new DualBaseAst(AstNulls.At, input);
}

public interface IDualModelChecks
  : ICheckObjectModel<IGqlpDualObject, IGqlpDualBase, IGqlpDualField, IGqlpDualAlternate, TypeDualModel>
{ }
