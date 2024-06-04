using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Merging.Objects;

internal class MergeOutputObjects(
  ILoggerFactory logger,
  IMerge<IGqlpOutputField> fields,
  IMerge<IGqlpTypeParameter> typeParameters,
  IMerge<IGqlpAlternate<IGqlpOutputBase>> alternates
) : AstObjectsMerger<IGqlpOutputObject, IGqlpOutputField, IGqlpOutputBase>(logger, fields, typeParameters, alternates)
{
  protected override IGqlpOutputObject SetAlternates(IGqlpOutputObject obj, IEnumerable<IGqlpTypeParameter> typeParameters, IEnumerable<IGqlpAlternate<IGqlpOutputBase>> alternates)
    => (OutputDeclAst)obj with
    {
      TypeParameters = typeParameters.ArrayOf<TypeParameterAst>(),
      Alternates = alternates.ArrayOf<AstAlternate<IGqlpOutputBase>>(),
    };

  internal override IGqlpOutputObject SetItems(IGqlpOutputObject input, IEnumerable<IGqlpOutputField> items)
    => (OutputDeclAst)input with
    {
      Fields = items.ArrayOf<OutputFieldAst>(),
    };
}
