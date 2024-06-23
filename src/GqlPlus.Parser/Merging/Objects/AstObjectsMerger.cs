using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Merging.Objects;

internal abstract class AstObjectsMerger<TObject, TObjBase, TObjField, TObjAlt>(
  ILoggerFactory logger,
  IMerge<TObjField> fields,
  IMerge<IGqlpTypeParameter> typeParameters,
  IMerge<TObjAlt> alternates
) : AstTypeMerger<IGqlpType, TObject, IGqlpObjBase, TObjField>(logger, fields)
  where TObject : IGqlpObject<TObjBase, TObjField, TObjAlt>
  where TObjField : IGqlpObjField
  where TObjAlt : IGqlpObjAlternate
  where TObjBase : IGqlpObjBase
{
  protected override string ItemMatchName => "Parent";
  protected override string ItemMatchKey(TObject item)
    => item.Parent?.TypeName ?? "";

  protected override ITokenMessages CanMergeGroup(IGrouping<string, TObject> group)
  {
    ITokenMessages baseCanMerge = base.CanMergeGroup(group);
    ITokenMessages typeParametersCanMerge = group.ManyCanMerge(item => item.TypeParameters, typeParameters);
    ITokenMessages alternatesCanMerge = group.ManyGroupCanMerge(item => item.ObjAlternates, a => a.Type.FullType, alternates);

    return baseCanMerge.Add(typeParametersCanMerge).Add(alternatesCanMerge);
  }

  protected override TObject MergeGroup(IEnumerable<TObject> group)
  {
    IEnumerable<IGqlpTypeParameter> typeParametersAsts = group.ManyMerge(item => item.TypeParameters, typeParameters);
    IEnumerable<TObjAlt> alternateAsts = group.ManyMerge(item => item.ObjAlternates, alternates);

    return SetAlternates(base.MergeGroup(group), typeParametersAsts, alternateAsts);
  }

  internal override IEnumerable<TObjField> GetItems(TObject type)
    => type.ObjFields;

  protected abstract TObject SetAlternates(TObject obj, IEnumerable<IGqlpTypeParameter> typeParameters, IEnumerable<TObjAlt> alternates);
}
