using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Merging.Objects;

internal class MergeOutputObjects(
  ILoggerFactory logger,
  IMerge<IGqlpOutputField> fields,
  IMerge<IGqlpTypeParam> typeParams,
  IMerge<IGqlpObjAlternate> alternates
) : AstObjectsMerger<IGqlpOutputObject, IGqlpOutputField>(logger, fields, typeParams, alternates)
{
  protected override IGqlpOutputObject SetAlternates(IGqlpOutputObject obj, IEnumerable<IGqlpTypeParam> typeParams, IEnumerable<IGqlpObjAlternate> alternates)
    => (OutputDeclAst)obj with {
      TypeParams = typeParams.ArrayOf<TypeParamAst>(),
      Alternates = [.. alternates],
    };

  internal override IGqlpOutputObject SetItems(IGqlpOutputObject input, IEnumerable<IGqlpOutputField> items)
    => (OutputDeclAst)input with {
      ObjFields = [.. items],
    };
}
