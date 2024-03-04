using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Modelling;

public class InputModelTests(
  IModeller<InputDeclAst, TypeInputModel> modeller
) : ObjectModelTests<InputDeclAst, InputFieldAst, InputReferenceAst>
{
  internal override IObjectModelChecks<InputDeclAst, InputFieldAst, InputReferenceAst> ObjectChecks => _checks;

  private readonly InputModelChecks _checks = new(modeller);
}

internal sealed class InputModelChecks(
  IModeller<InputDeclAst, TypeInputModel> modeller
) : ObjectModelChecks<InputDeclAst, InputFieldAst, InputReferenceAst, TypeInputModel>(modeller, TypeKindModel.Input)
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
