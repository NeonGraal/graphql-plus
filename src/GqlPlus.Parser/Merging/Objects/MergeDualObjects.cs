using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Merging.Objects;

internal class MergeDualObjects(
  ILoggerFactory logger,
  IMerge<IGqlpDualField> fields,
  IMerge<IGqlpTypeParameter> typeParameters,
  IMerge<IGqlpDualAlternate> alternates
) : AstObjectsMerger<IGqlpDualObject, IGqlpDualBase, IGqlpDualField, IGqlpDualAlternate>(logger, fields, typeParameters, alternates)
{
  protected override IGqlpDualObject SetAlternates(IGqlpDualObject obj, IEnumerable<IGqlpTypeParameter> typeParameters, IEnumerable<IGqlpDualAlternate> alternates)
    => (DualDeclAst)obj with {
      TypeParameters = typeParameters.ArrayOf<TypeParameterAst>(),
      ObjAlternates = [.. alternates],
    };

  internal override IGqlpDualObject SetItems(IGqlpDualObject input, IEnumerable<IGqlpDualField> items)
    => (DualDeclAst)input with {
      ObjFields = [.. items],
    };
}
