using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Merging.Objects;

internal class MergeOutputObjects(
  ILoggerFactory logger,
  IMerge<IGqlpOutputField> fields,
  IMerge<IGqlpTypeParam> typeParams,
  IMerge<IGqlpOutputAlternate> alternates
) : AstObjectsMerger<IGqlpOutputObject, IGqlpOutputBase, IGqlpOutputField, IGqlpOutputAlternate>(logger, fields, typeParams, alternates)
{
  protected override IGqlpOutputObject SetAlternates(IGqlpOutputObject obj, IEnumerable<IGqlpTypeParam> typeParams, IEnumerable<IGqlpOutputAlternate> alternates)
    => (OutputDeclAst)obj with {
      TypeParams = typeParams.ArrayOf<TypeParamAst>(),
      ObjAlternates = [.. alternates],
    };

  internal override IGqlpOutputObject SetItems(IGqlpOutputObject input, IEnumerable<IGqlpOutputField> items)
    => (OutputDeclAst)input with {
      ObjFields = [.. items],
    };
}
