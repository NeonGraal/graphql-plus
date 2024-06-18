using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Modelling.Objects;

public class InputModelTests(
  IModeller<IGqlpInputObject, TypeInputModel> modeller,
  IRenderer<TypeInputModel> rendering
) : TestObjectModel<InputDeclAst, IGqlpInputField, InputFieldAst, IGqlpInputAlternate, InputAlternateAst, IGqlpInputBase, InputBaseAst>
{
  internal override ICheckObjectModel<InputDeclAst, IGqlpInputField, IGqlpInputAlternate, IGqlpInputBase> ObjectChecks => _checks;

  private readonly InputModelChecks _checks = new(modeller, rendering);
}

internal sealed class InputModelChecks(
  IModeller<IGqlpInputObject, TypeInputModel> modeller,
  IRenderer<TypeInputModel> rendering
) : CheckObjectModel<IGqlpInputObject, InputDeclAst, IGqlpInputField, InputFieldAst, IGqlpInputAlternate, InputAlternateAst, IGqlpInputBase, TypeInputModel>(modeller, rendering, TypeKindModel.Input)
{
  protected override InputDeclAst NewObjectAst(
    string name,
    IGqlpInputBase? parent,
    string? description,
    string[]? aliases,
    FieldInput[] fields,
    AlternateInput[] alternates)
    => new(AstNulls.At, name, description ?? "") {
      Aliases = aliases ?? [],
      Parent = (InputBaseAst?)parent,
      Fields = fields.InputFields(),
      Alternates = alternates.InputAlternates(),
    };

  internal override IGqlpInputBase NewParentAst(string input)
    => new InputBaseAst(AstNulls.At, input);
}
