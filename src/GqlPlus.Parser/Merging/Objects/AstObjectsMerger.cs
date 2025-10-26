using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Merging.Objects;

internal abstract class AstObjectsMerger<TObject, TObjField>(
  ILoggerFactory logger,
  IMerge<TObjField> fields,
  IMerge<IGqlpTypeParam> typeParams,
  IMerge<IGqlpAlternate> alternates
) : AstTypeMerger<IGqlpType, TObject, IGqlpObjBase, TObjField>(logger, fields)
  where TObject : IGqlpObject<TObjField>
  where TObjField : IGqlpObjField
{
  protected override string ItemMatchName => "Parent";
  protected override string ItemMatchKey(TObject item)
    => (item.Parent?.FullType).IfWhiteSpace();

  protected override IMessages CanMergeGroup(IGrouping<string, TObject> group)
  {
    IMessages baseCanMerge = base.CanMergeGroup(group);
    IMessages typeParamsCanMerge = group.ManyCanMerge(item => item.TypeParams, typeParams);
    IMessages alternatesCanMerge = group.ManyGroupCanMerge(item => item.Alternates, a => a.FullType, alternates);

    return baseCanMerge.Add(typeParamsCanMerge).Add(alternatesCanMerge);
  }

  protected override TObject MergeGroup(IEnumerable<TObject> group)
  {
    IEnumerable<IGqlpTypeParam> typeParamsAsts = group.ManyMerge(item => item.TypeParams, typeParams);
    IEnumerable<IGqlpAlternate> alternateAsts = group.ManyMerge(item => item.Alternates, alternates);

    return SetAlternates(base.MergeGroup(group), typeParamsAsts, alternateAsts);
  }

  internal override IEnumerable<TObjField> GetItems(TObject type)
    => type.ObjFields;

  protected abstract TObject SetAlternates(TObject obj, IEnumerable<IGqlpTypeParam> typeParams, IEnumerable<IGqlpAlternate> alternates);
}
