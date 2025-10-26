using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Merging.Objects;

internal class MergeInputObjects(
  ILoggerFactory logger,
  IMerge<IGqlpInputField> fields,
  IMerge<IGqlpTypeParam> typeParams,
  IMerge<IGqlpAlternate> alternates
) : AstObjectsMerger<IGqlpInputObject, IGqlpInputField>(logger, fields, typeParams, alternates)
{
  protected override IGqlpInputObject SetAlternates(IGqlpInputObject obj, IEnumerable<IGqlpTypeParam> typeParams, IEnumerable<IGqlpAlternate> alternates)
    => (InputDeclAst)obj with {
      TypeParams = typeParams.ArrayOf<TypeParamAst>(),
      Alternates = [.. alternates],
    };

  internal override IGqlpInputObject SetItems(IGqlpInputObject input, IEnumerable<IGqlpInputField> items)
    => (InputDeclAst)input with {
      ObjFields = [.. items],
    };
}
