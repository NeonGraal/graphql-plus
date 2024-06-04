using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Merging.Objects;

internal class MergeInputObjects(
  ILoggerFactory logger,
  IMerge<IGqlpInputField> fields,
  IMerge<IGqlpTypeParameter> typeParameters,
  IMerge<IGqlpAlternate<IGqlpInputBase>> alternates
) : AstObjectsMerger<IGqlpInputObject, IGqlpInputField, IGqlpInputBase>(logger, fields, typeParameters, alternates)
{
  protected override IGqlpInputObject SetAlternates(IGqlpInputObject obj, IEnumerable<IGqlpTypeParameter> typeParameters, IEnumerable<IGqlpAlternate<IGqlpInputBase>> alternates)
    => (InputDeclAst)obj with {
      TypeParameters = typeParameters.ArrayOf<TypeParameterAst>(),
      Alternates = alternates.ArrayOf<AstAlternate<IGqlpInputBase>>(),
    };

  internal override IGqlpInputObject SetItems(IGqlpInputObject input, IEnumerable<IGqlpInputField> items)
    => (InputDeclAst)input with {
      Fields = items.ArrayOf<InputFieldAst>(),
    };
}
