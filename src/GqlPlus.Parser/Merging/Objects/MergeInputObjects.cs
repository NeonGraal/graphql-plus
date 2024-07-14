using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Merging.Objects;

internal class MergeInputObjects(
  ILoggerFactory logger,
  IMerge<IGqlpInputField> fields,
  IMerge<IGqlpTypeParam> typeParams,
  IMerge<IGqlpInputAlternate> alternates
) : AstObjectsMerger<IGqlpInputObject, IGqlpInputBase, IGqlpInputField, IGqlpInputAlternate>(logger, fields, typeParams, alternates)
{
  protected override IGqlpInputObject SetAlternates(IGqlpInputObject obj, IEnumerable<IGqlpTypeParam> typeParams, IEnumerable<IGqlpInputAlternate> alternates)
    => (InputDeclAst)obj with {
      TypeParams = typeParams.ArrayOf<TypeParamAst>(),
      ObjAlternates = [.. alternates],
    };

  internal override IGqlpInputObject SetItems(IGqlpInputObject input, IEnumerable<IGqlpInputField> items)
    => (InputDeclAst)input with {
      ObjFields = [.. items],
    };
}
