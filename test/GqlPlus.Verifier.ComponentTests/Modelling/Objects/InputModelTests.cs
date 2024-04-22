using GqlPlus.Verifier.Ast.Schema.Objects;

namespace GqlPlus.Verifier.Modelling.Objects;

public class InputModelTests(
  IModeller<InputDeclAst, TypeInputModel> modeller
) : TestObjectModel<InputDeclAst, InputFieldAst, InputReferenceAst>
{
  internal override ICheckObjectModel<InputDeclAst, InputFieldAst, InputReferenceAst> ObjectChecks => _checks;

  private readonly InputModelChecks _checks = new(modeller);
}

internal sealed class InputModelChecks(
  IModeller<InputDeclAst, TypeInputModel> modeller
) : CheckObjectModel<InputDeclAst, InputFieldAst, InputReferenceAst, TypeInputModel>(modeller, TypeKindModel.Input)
{
  protected override InputDeclAst NewObjectAst(
    string name,
    InputReferenceAst? parent,
    string description,
    FieldInput[] fields,
    string[] alternates)
    => new(AstNulls.At, name, description) {
      Parent = parent,
      Fields = fields.InputFields(),
      Alternates = alternates.Alternates(NewReferenceAst),
    };

  internal override InputReferenceAst NewReferenceAst(string input)
    => new(AstNulls.At, input);
}
