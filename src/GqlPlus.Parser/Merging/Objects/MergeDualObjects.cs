using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Merging.Objects;

internal class MergeDualObjects(
  ILoggerFactory logger,
  IMerge<IGqlpDualField> fields,
  IMerge<IGqlpTypeParameter> typeParameters,
  IMerge<IGqlpAlternate<IGqlpDualBase>> alternates
) : AstObjectsMerger<IGqlpDualObject, IGqlpDualField, IGqlpDualBase>(logger, fields, typeParameters, alternates)
{
  protected override IGqlpDualObject SetAlternates(IGqlpDualObject obj, IEnumerable<IGqlpTypeParameter> typeParameters, IEnumerable<IGqlpAlternate<IGqlpDualBase>> alternates)
    => (DualDeclAst)obj with {
      TypeParameters = typeParameters.ArrayOf<TypeParameterAst>(),
      Alternates = alternates.ArrayOf<AstAlternate<IGqlpDualBase>>(),
    };

  internal override IGqlpDualObject SetItems(IGqlpDualObject input, IEnumerable<IGqlpDualField> items)
    => (DualDeclAst)input with {
      Fields = items.ArrayOf<DualFieldAst>(),
    };
}
