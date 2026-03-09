using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Merging.Objects;

internal class AstObjectsMerger<TObjField>(
  IMergerRepository mergers
) : AstTypeMerger<IGqlpType, IGqlpObject<TObjField>, IGqlpObjBase, TObjField>(mergers.LoggerFactory, mergers.MergerFor<TObjField>())
  where TObjField : IGqlpObjField
{
  private readonly IMerge<IGqlpTypeParam> _typeParams = mergers.MergerFor<IGqlpTypeParam>();
  private readonly IMerge<IGqlpAlternate> _alternates = mergers.MergerFor<IGqlpAlternate>();

  protected override string ItemMatchName => "Parent";
  protected override string ItemMatchKey(IGqlpObject<TObjField> item)
    => (item.Parent?.FullType).IfWhiteSpace();

  protected override IMessages CanMergeGroup(IGrouping<string, IGqlpObject<TObjField>> group)
  {
    IMessages baseCanMerge = base.CanMergeGroup(group);
    IMessages typeParamsCanMerge = group.ManyCanMerge(item => item.TypeParams, _typeParams);
    IMessages alternatesCanMerge = group.ManyGroupCanMerge(item => item.Alternates, a => a.FullType, _alternates);

    return baseCanMerge.Add(typeParamsCanMerge).Add(alternatesCanMerge);
  }

  protected override IGqlpObject<TObjField> MergeGroup(IEnumerable<IGqlpObject<TObjField>> group)
  {
    IEnumerable<IGqlpTypeParam> typeParamsAsts = group.ManyMerge(item => item.TypeParams, _typeParams);
    IEnumerable<IGqlpAlternate> alternateAsts = group.ManyMerge(item => item.Alternates, _alternates);

    return SetAlternates(base.MergeGroup(group), typeParamsAsts, alternateAsts);
  }

  [SuppressMessage("Performance", "CA1822:Mark members as static")]
  protected AstObject<TObjField> SetAlternates(IGqlpObject<TObjField> obj, IEnumerable<IGqlpTypeParam> typeParams, IEnumerable<IGqlpAlternate> alternates)
    => (AstObject<TObjField>)obj with {
      TypeParams = typeParams.ArrayOf<TypeParamAst>(),
      Alternates = [.. alternates],
    };

  internal override IEnumerable<TObjField> GetItems(IGqlpObject<TObjField> type)
    => type.ObjFields;

  internal override IGqlpObject<TObjField> SetItems(IGqlpObject<TObjField> input, IEnumerable<TObjField> items)
    => (AstObject<TObjField>)input with {
      ObjFields = [.. items],
    };
}
