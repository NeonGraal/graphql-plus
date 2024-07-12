using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Modelling.Objects;

public class OutputModelTests(
  IOutputModelChecks checks
) : TestObjectModel<IGqlpOutputObject, IGqlpOutputBase, IGqlpOutputField, IGqlpOutputAlternate, TypeOutputModel>(checks)
{ }

internal sealed class OutputModelChecks(
  IModeller<IGqlpOutputObject, TypeOutputModel> modeller,
  IRenderer<TypeOutputModel> rendering
) : CheckObjectModel<IGqlpOutputObject, OutputDeclAst, IGqlpOutputField, OutputFieldAst, IGqlpOutputAlternate, OutputAlternateAst, IGqlpOutputBase, TypeOutputModel>(modeller, rendering, TypeKindModel.Output)
  , IOutputModelChecks
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

public interface IOutputModelChecks
  : ICheckObjectModel<IGqlpOutputObject, IGqlpOutputBase, IGqlpOutputField, IGqlpOutputAlternate, TypeOutputModel>
{ }
