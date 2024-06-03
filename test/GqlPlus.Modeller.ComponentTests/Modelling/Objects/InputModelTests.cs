using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Modelling.Objects;

public class InputModelTests(
  IModeller<IGqlpInputObject, TypeInputModel> modeller
) : TestObjectModel<InputDeclAst, InputFieldAst, IGqlpInputBase, InputBaseAst>
{
  internal override ICheckObjectModel<InputDeclAst, InputFieldAst, IGqlpInputBase> ObjectChecks => _checks;

  private readonly InputModelChecks _checks = new(modeller);
}

internal sealed class InputModelChecks(
  IModeller<IGqlpInputObject, TypeInputModel> modeller
) : CheckObjectModel<IGqlpInputObject, InputDeclAst, IGqlpInputField, InputFieldAst, IGqlpInputBase, TypeInputModel>(modeller, TypeKindModel.Input)
{
  protected override InputDeclAst NewObjectAst(
    string name,
    IGqlpInputBase? parent,
    string? description,
    string[]? aliases,
    FieldInput[] fields,
    string[] alternates)
    => new(AstNulls.At, name, description ?? "")
    {
      Aliases = aliases ?? [],
      Parent = (InputBaseAst?)parent,
      Fields = fields.InputFields(),
      Alternates = alternates.Alternates(NewParentAst),
    };

  internal override IGqlpInputBase NewParentAst(string input)
    => new InputBaseAst(AstNulls.At, input);
}
