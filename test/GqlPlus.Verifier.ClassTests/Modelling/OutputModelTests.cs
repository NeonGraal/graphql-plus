using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Modelling;

public class OutputModelTests
  : ObjectModelTests<OutputDeclAst, OutputFieldAst, OutputReferenceAst>
{
  internal override IObjectModelChecks<OutputDeclAst, OutputFieldAst, OutputReferenceAst> ObjectChecks => _checks;

  private readonly OutputModelChecks _checks;

  public OutputModelTests()
  {
    OutputReferenceModeller reference = new();
    ModifierModeller modifier = new();
    AlternateModeller<OutputReferenceAst, OutputBaseModel> alternate = new(reference, modifier);
    OutputModeller output = new(alternate, modifier, reference);

    _checks = new(output);
  }
}

internal sealed class OutputModelChecks(
  IModeller<OutputDeclAst> modeller
) : ObjectModelChecks<OutputDeclAst, OutputFieldAst, OutputReferenceAst, OutputModel>(modeller, TypeKindModel.Output)
{
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
