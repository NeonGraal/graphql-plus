using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Schema.Objects;

public class InputModelTests(
  IInputModelChecks checks
) : TestObjectModel<IGqlpInputObject, IGqlpInputField, TypeInputModel>(checks)
{ }

internal sealed class InputModelChecks(
  CheckTypeInputs<IGqlpInputObject, TypeInputModel> inputs
) : CheckObjectModel<IGqlpInputObject, InputDeclAst, IGqlpInputField, InputFieldAst, TypeInputModel>(inputs, TypeKindModel.Input)
  , IInputModelChecks
{
  protected override InputDeclAst NewObjectAst(ExpectedObjectInput input, IGqlpObjBase? parent = null)
    => new(AstNulls.At, input.Name, input.Description) {
      Aliases = input.Aliases,
      Parent = parent ?? NewParentAst(input.Parent),
      TypeParams = input.TypeParams.TypeParams(),
      ObjFields = input.Fields.InputFields(),
      Alternates = input.Alternates.Alternates(),
    };

  internal override IGqlpObjBase? NewParentAst(string? input)
    => string.IsNullOrWhiteSpace(input) ? null : new ObjBaseAst(AstNulls.At, input, "");
}

public interface IInputModelChecks
  : ICheckObjectModel<IGqlpInputObject, IGqlpInputField, TypeInputModel>
{ }
