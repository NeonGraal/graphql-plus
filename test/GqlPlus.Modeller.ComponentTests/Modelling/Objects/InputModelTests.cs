using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Modelling.Objects;

public class InputModelTests(
  IModeller<IGqlpInputObject, TypeInputModel> modeller,
  IRenderer<TypeInputModel> rendering
) : TestObjectModel<IGqlpInputObject, IGqlpInputField, IGqlpInputAlternate, IGqlpInputBase>
{
  internal override ICheckObjectModel<IGqlpInputObject, IGqlpInputBase, IGqlpInputField, IGqlpInputAlternate> ObjectChecks => _checks;

  private readonly InputModelChecks _checks = new(modeller, rendering);
}

internal sealed class InputModelChecks(
  IModeller<IGqlpInputObject, TypeInputModel> modeller,
  IRenderer<TypeInputModel> rendering
) : CheckObjectModel<IGqlpInputObject, InputDeclAst, IGqlpInputField, InputFieldAst, IGqlpInputAlternate, InputAlternateAst, IGqlpInputBase, TypeInputModel>(modeller, rendering, TypeKindModel.Input)
{
  protected override InputDeclAst NewObjectAst(ExpectedObjectInput input, IGqlpObjBase? parent = null)
    => new(AstNulls.At, input.Name, input.Description.FirstOrDefault() ?? "") {
      Aliases = input.Aliases,
      Parent = parent ?? (input.Parent is not null ? NewParentAst(input.Parent) : null),
      ObjFields = input.Fields.InputFields(),
      ObjAlternates = input.Alternates.InputAlternates(),
    };

  internal override IGqlpInputBase NewParentAst(string input)
    => new InputBaseAst(AstNulls.At, input);
}
