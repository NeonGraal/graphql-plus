using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Modelling.Objects;

public class InputModelTests(
  IInputModelChecks checks
) : TestObjectModel<IGqlpInputObject, IGqlpInputBase, IGqlpInputField, IGqlpInputAlternate, TypeInputModel>(checks)
{ }

internal sealed class InputModelChecks(
  IModeller<IGqlpInputObject, TypeInputModel> modeller,
  IRenderer<TypeInputModel> rendering
) : CheckObjectModel<IGqlpInputObject, InputDeclAst, IGqlpInputField, InputFieldAst, IGqlpInputAlternate, InputAlternateAst, IGqlpInputBase, TypeInputModel>(modeller, rendering, TypeKindModel.Input)
  , IInputModelChecks
{
  protected override InputDeclAst NewObjectAst(ExpectedObjectInput input, IGqlpObjBase? parent = null)
    => new(AstNulls.At, input.Name, input.Description) {
      Aliases = input.Aliases,
      Parent = parent ?? (input.Parent is not null ? NewParentAst(input.Parent) : null),
      TypeParameters = input.TypeParameters.TypeParameters(),
      ObjFields = input.Fields.InputFields(),
      ObjAlternates = input.Alternates.InputAlternates(),
    };

  internal override IGqlpInputBase NewParentAst(string input)
    => new InputBaseAst(AstNulls.At, input);
}

public interface IInputModelChecks
  : ICheckObjectModel<IGqlpInputObject, IGqlpInputBase, IGqlpInputField, IGqlpInputAlternate, TypeInputModel>
{ }
