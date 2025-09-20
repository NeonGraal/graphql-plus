using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Schema.Objects;

public class OutputModelTests(
  IOutputModelChecks checks
) : TestObjectModel<IGqlpOutputObject, IGqlpOutputField, TypeOutputModel>(checks)
{ }

internal sealed class OutputModelChecks(
  CheckTypeInputs<IGqlpOutputObject, TypeOutputModel> inputs
) : CheckObjectModel<IGqlpOutputObject, OutputDeclAst, IGqlpOutputField, OutputFieldAst, TypeOutputModel>(inputs, TypeKindModel.Output)
  , IOutputModelChecks
{
  protected override OutputDeclAst NewObjectAst(ExpectedObjectInput input, IGqlpObjBase? parent = null)
    => new(AstNulls.At, input.Name, input.Description) {
      Aliases = input.Aliases,
      Parent = parent ?? NewParentAst(input.Parent),
      TypeParams = input.TypeParams.TypeParams(),
      ObjFields = input.Fields.OutputFields(),
      Alternates = input.Alternates.ObjAlternates(),
    };

  internal override IGqlpObjBase? NewParentAst(string? input)
    => string.IsNullOrWhiteSpace(input) ? null : new ObjBaseAst(AstNulls.At, input, "");
}

public interface IOutputModelChecks
  : ICheckObjectModel<IGqlpOutputObject, IGqlpOutputField, TypeOutputModel>
{ }
