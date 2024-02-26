using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Modelling;

public class InputModelTests
  : ObjectModelTests<InputDeclAst, InputFieldAst, InputReferenceAst>
{
  internal override IObjectModelChecks<InputDeclAst, InputFieldAst, InputReferenceAst> ObjectChecks => _checks;

  private readonly InputModelChecks _checks = new();
}

internal sealed class InputModelChecks
  : ObjectModelChecks<InputDeclAst, InputFieldAst, InputReferenceAst>
{
  public InputModelChecks()
    : base(TypeKindModel.Input, new InputModeller(new ModifierModeller()))
  { }

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
