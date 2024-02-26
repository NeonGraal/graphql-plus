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
    : base(TypeKindModel.Output, new OutputModeller(new ModifierModeller()))
  { }

  protected override OutputDeclAst NewObjectAst(
    string name,
    OutputReferenceAst? parent,
    string description,
    FieldInput[] fields,
    string[] alternates)
    => new(AstNulls.At, name, description) {
      Parent = parent,
      Fields = fields.OutputFields(),
      Alternates = alternates.Alternates(NewReferenceAst),
    };

  internal override OutputReferenceAst NewReferenceAst(string input)
    => new(AstNulls.At, input);
}
