using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Modelling.Objects;

public class OutputModelTests(
  IModeller<IGqlpOutputObject, TypeOutputModel> modeller
) : TestObjectModel<OutputDeclAst, OutputFieldAst, IGqlpOutputBase, OutputBaseAst>
{
  internal override ICheckObjectModel<OutputDeclAst, OutputFieldAst, IGqlpOutputBase> ObjectChecks => _checks;

  private readonly OutputModelChecks _checks = new(modeller);
}

internal sealed class OutputModelChecks(
  IModeller<IGqlpOutputObject, TypeOutputModel> modeller
) : CheckObjectModel<IGqlpOutputObject, OutputDeclAst, IGqlpOutputField, OutputFieldAst, IGqlpOutputBase, TypeOutputModel>(modeller, TypeKindModel.Output)
{
  protected override OutputDeclAst NewObjectAst(
    string name,
    IGqlpOutputBase? parent,
    string? description,
    string[]? aliases,
    FieldInput[] fields,
    string[] alternates)
    => new(AstNulls.At, name, description ?? "")
    {
      Aliases = aliases ?? [],
      Parent = (OutputBaseAst?)parent,
      Fields = fields.OutputFields(),
      Alternates = alternates.Alternates(NewParentAst),
    };

  internal override IGqlpOutputBase NewParentAst(string input)
    => new OutputBaseAst(AstNulls.At, input);
}
