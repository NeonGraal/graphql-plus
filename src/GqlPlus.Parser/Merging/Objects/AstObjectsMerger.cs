using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Merging.Objects;

internal abstract class AstObjectsMerger<TObject, TObjBase, TObjField, TObjAlt>(
  ILoggerFactory logger,
  IMerge<TObjField> fields,
  IMerge<IGqlpTypeParam> typeParams,
  IMerge<TObjAlt> alternates
) : AstTypeMerger<IGqlpType, TObject, IGqlpObjBase, TObjField>(logger, fields)
  where TObject : IGqlpObject<TObjBase, TObjField, TObjAlt>
  where TObjField : IGqlpObjField
  where TObjAlt : IGqlpObjAlternate
  where TObjBase : IGqlpObjBase
{
  protected override string ItemMatchName => "Parent";
  protected override string ItemMatchKey(TObject item)
    => item.Parent?.FullType ?? "";

  protected override ITokenMessages CanMergeGroup(IGrouping<string, TObject> group)
  {
    ITokenMessages baseCanMerge = base.CanMergeGroup(group);
    ITokenMessages typeParamsCanMerge = group.ManyCanMerge(item => item.TypeParams, typeParams);
    ITokenMessages alternatesCanMerge = group.ManyGroupCanMerge(item => item.ObjAlternates, a => a.FullType, alternates);

    return baseCanMerge.Add(typeParamsCanMerge).Add(alternatesCanMerge);
  }

  protected override TObject MergeGroup(IEnumerable<TObject> group)
  {
    IEnumerable<IGqlpTypeParam> typeParamsAsts = group.ManyMerge(item => item.TypeParams, typeParams);
    IEnumerable<TObjAlt> alternateAsts = group.ManyMerge(item => item.ObjAlternates, alternates);

    return SetAlternates(base.MergeGroup(group), typeParamsAsts, alternateAsts);
  }

  internal override IEnumerable<TObjField> GetItems(TObject type)
    => type.ObjFields;

  protected abstract TObject SetAlternates(TObject obj, IEnumerable<IGqlpTypeParam> typeParams, IEnumerable<TObjAlt> alternates);
}
