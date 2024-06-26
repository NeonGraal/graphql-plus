using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Merging.Objects;

internal class MergeOutputObjects(
  ILoggerFactory logger,
  IMerge<IGqlpOutputField> fields,
  IMerge<IGqlpTypeParameter> typeParameters,
  IMerge<IGqlpOutputAlternate> alternates
) : AstObjectsMerger<IGqlpOutputObject, IGqlpOutputBase, IGqlpOutputField, IGqlpOutputAlternate>(logger, fields, typeParameters, alternates)
{
  protected override IGqlpOutputObject SetAlternates(IGqlpOutputObject obj, IEnumerable<IGqlpTypeParameter> typeParameters, IEnumerable<IGqlpOutputAlternate> alternates)
    => (OutputDeclAst)obj with {
      TypeParameters = typeParameters.ArrayOf<TypeParameterAst>(),
      ObjAlternates = [.. alternates],
    };

  internal override IGqlpOutputObject SetItems(IGqlpOutputObject input, IEnumerable<IGqlpOutputField> items)
    => (OutputDeclAst)input with {
      ObjFields = [.. items],
    };
}
