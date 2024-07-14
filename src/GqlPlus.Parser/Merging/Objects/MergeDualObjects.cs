using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Merging.Objects;

internal class MergeDualObjects(
  ILoggerFactory logger,
  IMerge<IGqlpDualField> fields,
  IMerge<IGqlpTypeParam> typeParams,
  IMerge<IGqlpDualAlternate> alternates
) : AstObjectsMerger<IGqlpDualObject, IGqlpDualBase, IGqlpDualField, IGqlpDualAlternate>(logger, fields, typeParams, alternates)
{
  protected override IGqlpDualObject SetAlternates(IGqlpDualObject obj, IEnumerable<IGqlpTypeParam> typeParams, IEnumerable<IGqlpDualAlternate> alternates)
    => (DualDeclAst)obj with {
      TypeParams = typeParams.ArrayOf<TypeParamAst>(),
      ObjAlternates = [.. alternates],
    };

  internal override IGqlpDualObject SetItems(IGqlpDualObject input, IEnumerable<IGqlpDualField> items)
    => (DualDeclAst)input with {
      ObjFields = [.. items],
    };
}
