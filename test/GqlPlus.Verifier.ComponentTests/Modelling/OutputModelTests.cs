using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Modelling;

public class OutputModelTests(
  IModeller<OutputDeclAst, TypeOutputModel> modeller
) : ObjectModelTests<OutputDeclAst, OutputFieldAst, OutputReferenceAst>
{
  internal override IObjectModelChecks<OutputDeclAst, OutputFieldAst, OutputReferenceAst> ObjectChecks => _checks;

  private readonly OutputModelChecks _checks = new(modeller);
}

internal sealed class OutputModelChecks(
  IModeller<OutputDeclAst, TypeOutputModel> modeller
) : ObjectModelChecks<OutputDeclAst, OutputFieldAst, OutputReferenceAst, TypeOutputModel>(modeller, TypeKindModel.Output)
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
