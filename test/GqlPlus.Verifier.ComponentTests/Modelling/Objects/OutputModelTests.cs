using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Modelling.Objects;

public class OutputModelTests(
  IModeller<OutputDeclAst, TypeOutputModel> modeller
) : TestObjectModel<OutputDeclAst, OutputFieldAst, OutputReferenceAst>
{
  internal override ICheckObjectModel<OutputDeclAst, OutputFieldAst, OutputReferenceAst> ObjectChecks => _checks;

  private readonly OutputModelChecks _checks = new(modeller);
}

internal sealed class OutputModelChecks(
  IModeller<OutputDeclAst, TypeOutputModel> modeller
) : CheckObjectModel<OutputDeclAst, OutputFieldAst, OutputReferenceAst, TypeOutputModel>(modeller, TypeKindModel.Output)
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
