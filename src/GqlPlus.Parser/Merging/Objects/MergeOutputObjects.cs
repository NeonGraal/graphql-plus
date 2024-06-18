using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Merging.Objects;

internal class MergeOutputObjects(
  ILoggerFactory logger,
  IMerge<IGqlpOutputField> fields,
  IMerge<IGqlpTypeParameter> typeParameters,
  IMerge<IGqlpOutputAlternate> alternates
) : AstObjectsMerger<IGqlpOutputObject, IGqlpOutputField, IGqlpOutputAlternate, IGqlpOutputBase>(logger, fields, typeParameters, alternates)
{
  protected override IGqlpOutputObject SetAlternates(IGqlpOutputObject obj, IEnumerable<IGqlpTypeParameter> typeParameters, IEnumerable<IGqlpOutputAlternate> alternates)
    => (OutputDeclAst)obj with {
      TypeParameters = typeParameters.ArrayOf<TypeParameterAst>(),
      Alternates = [.. alternates],
    };

  internal override IGqlpOutputObject SetItems(IGqlpOutputObject input, IEnumerable<IGqlpOutputField> items)
    => (OutputDeclAst)input with {
      Fields = [.. items],
    };
}
