using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Modelling.Objects;

public class OutputModelTests(
  IModeller<OutputDeclAst, TypeOutputModel> modeller
) : TestObjectModel<OutputDeclAst, OutputFieldAst, OutputBaseAst>
{
  internal override ICheckObjectModel<OutputDeclAst, OutputFieldAst, OutputBaseAst> ObjectChecks => _checks;

  private readonly OutputModelChecks _checks = new(modeller);
}

internal sealed class OutputModelChecks(
  IModeller<OutputDeclAst, TypeOutputModel> modeller
) : CheckObjectModel<OutputDeclAst, OutputFieldAst, OutputBaseAst, TypeOutputModel>(modeller, TypeKindModel.Output)
{
  protected override OutputDeclAst NewObjectAst(
    string name,
    OutputBaseAst? parent,
    string? description,
    string[]? aliases,
    FieldInput[] fields,
    string[] alternates)
    => new(AstNulls.At, name, description ?? "") {
      Aliases = aliases ?? [],
      Parent = parent,
      Fields = fields.OutputFields(),
      Alternates = alternates.Alternates(NewParentAst),
    };

  internal override OutputBaseAst NewParentAst(string input)
    => new(AstNulls.At, input);
}
