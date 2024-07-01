using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Modelling.Objects;

public class OutputModelTests(
  IModeller<IGqlpOutputObject, TypeOutputModel> modeller,
  IRenderer<TypeOutputModel> rendering
) : TestObjectModel<IGqlpOutputObject, IGqlpOutputBase, IGqlpOutputField, IGqlpOutputAlternate>
{
  internal override ICheckObjectModel<IGqlpOutputObject, IGqlpOutputBase, IGqlpOutputField, IGqlpOutputAlternate> ObjectChecks => _checks;

  private readonly OutputModelChecks _checks = new(modeller, rendering);
}

internal sealed class OutputModelChecks(
  IModeller<IGqlpOutputObject, TypeOutputModel> modeller,
  IRenderer<TypeOutputModel> rendering
) : CheckObjectModel<IGqlpOutputObject, OutputDeclAst, IGqlpOutputField, OutputFieldAst, IGqlpOutputAlternate, OutputAlternateAst, IGqlpOutputBase, TypeOutputModel>(modeller, rendering, TypeKindModel.Output)
{
  protected override OutputDeclAst NewObjectAst(ExpectedObjectInput input, IGqlpObjBase? parent = null)
    => new(AstNulls.At, input.Name, input.Description) {
      Aliases = input.Aliases,
      Parent = parent ?? (input.Parent is not null ? NewParentAst(input.Parent) : null),
      TypeParameters = input.TypeParameters.TypeParameters(),
      ObjFields = input.Fields.OutputFields(),
      ObjAlternates = input.Alternates.OutputAlternates(),
    };

  internal override IGqlpOutputBase NewParentAst(string input)
    => new OutputBaseAst(AstNulls.At, input);
}
