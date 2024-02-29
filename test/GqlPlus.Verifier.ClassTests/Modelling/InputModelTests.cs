using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Modelling;

public class InputModelTests
  : ObjectModelTests<InputDeclAst, InputFieldAst, InputReferenceAst>
{
  internal override IObjectModelChecks<InputDeclAst, InputFieldAst, InputReferenceAst> ObjectChecks => _checks;

  private readonly InputModelChecks _checks;

  public InputModelTests()
  {
    InputReferenceModeller reference = new();
    ModifierModeller modifier = new();
    AlternateModeller<InputReferenceAst, InputBaseModel> alternate = new(reference, modifier);
    InputModeller input = new(alternate, modifier, reference);

    _checks = new(input);
  }
}

internal sealed class InputModelChecks(
  IModeller<InputDeclAst> modeller
) : ObjectModelChecks<InputDeclAst, InputFieldAst, InputReferenceAst, InputModel>(modeller, TypeKindModel.Input)
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
