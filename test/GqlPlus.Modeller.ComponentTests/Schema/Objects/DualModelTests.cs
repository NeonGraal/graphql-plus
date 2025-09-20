using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Schema.Objects;

public class DualModelTests(
  IDualModelChecks checks
) : TestObjectModel<IGqlpDualObject, IGqlpDualField, TypeDualModel>(checks)
{ }

internal sealed class DualModelChecks(
  CheckTypeInputs<IGqlpDualObject, TypeDualModel> inputs
) : CheckObjectModel<IGqlpDualObject, DualDeclAst, IGqlpDualField, DualFieldAst, DualAlternateAst, TypeDualModel>(inputs, TypeKindModel.Dual)
  , IDualModelChecks
{
  protected override DualDeclAst NewObjectAst(ExpectedObjectInput input, IGqlpObjBase? parent = null)
    => new(AstNulls.At, input.Name, input.Description) {
      Aliases = input.Aliases,
      Parent = parent ?? NewParentAst(input.Parent),
      TypeParams = input.TypeParams.TypeParams(),
      ObjFields = input.Fields.DualFields(),
      Alternates = input.Alternates.DualAlternates(),
    };

  internal override IGqlpObjBase? NewParentAst(string? input)
    => string.IsNullOrWhiteSpace(input) ? null : new DualBaseAst(AstNulls.At, input);
}

public interface IDualModelChecks
  : ICheckObjectModel<IGqlpDualObject, IGqlpDualField, TypeDualModel>
{ }
