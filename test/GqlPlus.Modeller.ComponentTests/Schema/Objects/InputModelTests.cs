using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Schema;

namespace GqlPlus.Schema.Objects;

public class InputModelTests(
  IInputModelChecks checks
) : TestObjectModel<IGqlpInputObject, IGqlpInputBase, IGqlpInputField, IGqlpInputAlternate, TypeInputModel>(checks)
{ }

internal sealed class InputModelChecks(
  CheckTypeInputs<IGqlpInputObject, TypeInputModel> inputs
) : CheckObjectModel<IGqlpInputObject, InputDeclAst, IGqlpInputField, InputFieldAst, IGqlpInputAlternate, InputAlternateAst, IGqlpInputBase, TypeInputModel>(inputs, TypeKindModel.Input)
  , IInputModelChecks
{
  protected override InputDeclAst NewObjectAst(ExpectedObjectInput input, IGqlpObjBase? parent = null)
    => new(AstNulls.At, input.Name, input.Description) {
      Aliases = input.Aliases,
      Parent = parent ?? (input.Parent is not null ? NewParentAst(input.Parent) : null),
      TypeParams = input.TypeParams.TypeParams(),
      ObjFields = input.Fields.InputFields(),
      ObjAlternates = input.Alternates.InputAlternates(),
    };

  internal override IGqlpInputBase NewParentAst(string input)
    => new InputBaseAst(AstNulls.At, input);
}

public interface IInputModelChecks
  : ICheckObjectModel<IGqlpInputObject, IGqlpInputBase, IGqlpInputField, IGqlpInputAlternate, TypeInputModel>
{ }
