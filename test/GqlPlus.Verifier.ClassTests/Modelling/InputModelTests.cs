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
    : base(TypeKindModel.Input, new InputModeller())
  { }

  protected override string[] ExpectedParent(string? parent)
    => parent is null ? []
    : ["parent: !_Described(_InputBase)", "  input: " + parent];

  protected override InputDeclAst NewObjectAst(
    string name,
    InputReferenceAst? parent,
    string description,
    FieldInput[] fields,
    string[] alternates)
    => new(AstNulls.At, name, description) { Parent = parent };

  internal override InputReferenceAst NewParentAst(string input)
    => new(AstNulls.At, input);
}
