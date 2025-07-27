using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Schema.Objects;

public class OutputModelTests(
  IOutputModelChecks checks
) : TestObjectModel<IGqlpOutputObject, IGqlpOutputBase, IGqlpOutputField, IGqlpOutputAlternate, TypeOutputModel>(checks)
{ }

internal sealed class OutputModelChecks(
  CheckTypeInputs<IGqlpOutputObject, TypeOutputModel> inputs
) : CheckObjectModel<IGqlpOutputObject, OutputDeclAst, IGqlpOutputField, OutputFieldAst, IGqlpOutputAlternate, OutputAlternateAst, IGqlpOutputBase, IGqlpOutputArg, TypeOutputModel>(inputs, TypeKindModel.Output)
  , IOutputModelChecks
{
  protected override OutputDeclAst NewObjectAst(ExpectedObjectInput input, IGqlpObjBase? parent = null)
    => new(AstNulls.At, input.Name, input.Description) {
      Aliases = input.Aliases,
      Parent = parent ?? NewParentAst(input.Parent),
      TypeParams = input.TypeParams.TypeParams(),
      ObjFields = input.Fields.OutputFields(),
      ObjAlternates = input.Alternates.OutputAlternates(),
    };

  internal override IGqlpOutputBase? NewParentAst(string? input)
    => input.IsWhiteSpace() ? null : new OutputBaseAst(AstNulls.At, input!);
}

public interface IOutputModelChecks
  : ICheckObjectModel<IGqlpOutputObject, IGqlpOutputBase, IGqlpOutputField, IGqlpOutputAlternate, TypeOutputModel>
{ }
