using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Merging.Objects;

internal class MergeDualObjects(
  ILoggerFactory logger,
  IMerge<IGqlpDualField> fields,
  IMerge<IGqlpTypeParameter> typeParameters,
  IMerge<IGqlpDualAlternate> alternates
) : AstObjectsMerger<IGqlpDualObject, IGqlpDualField, IGqlpDualAlternate, IGqlpDualBase>(logger, fields, typeParameters, alternates)
{
  protected override IGqlpDualObject SetAlternates(IGqlpDualObject obj, IEnumerable<IGqlpTypeParameter> typeParameters, IEnumerable<IGqlpDualAlternate> alternates)
    => (DualDeclAst)obj with {
      TypeParameters = typeParameters.ArrayOf<TypeParameterAst>(),
      Alternates = [.. alternates],
    };

  internal override IGqlpDualObject SetItems(IGqlpDualObject input, IEnumerable<IGqlpDualField> items)
    => (DualDeclAst)input with {
      Fields = [.. items],
    };
}
