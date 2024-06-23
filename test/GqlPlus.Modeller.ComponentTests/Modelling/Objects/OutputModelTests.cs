using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Modelling.Objects;

public class OutputModelTests(
  IModeller<IGqlpOutputObject, TypeOutputModel> modeller,
  IRenderer<TypeOutputModel> rendering
) : TestObjectModel<OutputDeclAst, IGqlpOutputField, OutputFieldAst, IGqlpOutputAlternate, OutputAlternateAst, IGqlpOutputBase, OutputBaseAst>
{
  internal override ICheckObjectModel<OutputDeclAst, IGqlpOutputBase, IGqlpOutputField, IGqlpOutputAlternate> ObjectChecks => _checks;

  private readonly OutputModelChecks _checks = new(modeller, rendering);
}

internal sealed class OutputModelChecks(
  IModeller<IGqlpOutputObject, TypeOutputModel> modeller,
  IRenderer<TypeOutputModel> rendering
) : CheckObjectModel<IGqlpOutputObject, OutputDeclAst, IGqlpOutputField, OutputFieldAst, IGqlpOutputAlternate, OutputAlternateAst, IGqlpOutputBase, TypeOutputModel>(modeller, rendering, TypeKindModel.Output)
{
  protected override OutputDeclAst NewObjectAst(
    string name,
    IGqlpObjBase? parent,
    string? description,
    string[]? aliases,
    FieldInput[] fields,
    AlternateInput[] alternates)
    => new(AstNulls.At, name, description ?? "") {
      Aliases = aliases ?? [],
      Parent = (OutputBaseAst?)parent,
      ObjFields = fields.OutputFields(),
      ObjAlternates = alternates.OutputAlternates(),
    };

  internal override IGqlpOutputBase NewParentAst(string input)
    => new OutputBaseAst(AstNulls.At, input);
}
