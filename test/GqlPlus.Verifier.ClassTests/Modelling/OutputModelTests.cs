using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Modelling;

public class OutputModelTests
  : ObjectModelTests<OutputDeclAst, OutputFieldAst, OutputReferenceAst>
{
  internal override IObjectModelChecks<OutputDeclAst, OutputFieldAst, OutputReferenceAst> ObjectChecks => _checks;

  private readonly OutputModelChecks _checks = new();
}

internal sealed class OutputModelChecks
  : ObjectModelChecks<OutputDeclAst, OutputFieldAst, OutputReferenceAst>
{
  public OutputModelChecks()
    : base(TypeKindModel.Output, new OutputModeller())
  { }

  protected override string[] ExpectedParent(string? parent)
    => parent is null ? []
    : ["parent: !_Described(_OutputBase)", "  output: " + parent];

  protected override OutputDeclAst NewObjectAst(
    string name,
    OutputReferenceAst? parent,
    string description,
    FieldInput[] fields,
    string[] alternates)
    => new(AstNulls.At, name, description) { Parent = parent };

  internal override OutputReferenceAst NewParentAst(string input)
    => new(AstNulls.At, input);
}
