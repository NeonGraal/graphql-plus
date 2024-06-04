using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Merging.Objects;

internal abstract class AstObjectsMerger<TObject, TObjField, TObjBase>(
  ILoggerFactory logger,
  IMerge<TObjField> fields,
  IMerge<IGqlpTypeParameter> typeParameters,
  IMerge<IGqlpAlternate<TObjBase>> alternates
) : AstTypeMerger<IGqlpType, TObject, TObjBase, TObjField>(logger, fields)
  where TObject : IGqlpObject<TObjField, TObjBase>
  where TObjField : IGqlpObjectField<TObjBase>, IGqlpDescribed
  where TObjBase : IGqlpObjectBase<TObjBase>, IEquatable<TObjBase>
{
  protected override string ItemMatchName => "Parent";
  protected override string ItemMatchKey(TObject item)
    => item.Parent?.TypeName ?? "";

  protected override ITokenMessages CanMergeGroup(IGrouping<string, TObject> group)
  {
    ITokenMessages baseCanMerge = base.CanMergeGroup(group);
    ITokenMessages typeParametersCanMerge = group.ManyCanMerge(item => item.TypeParameters, typeParameters);
    ITokenMessages alternatesCanMerge = group.ManyGroupCanMerge(item => item.Alternates, a => a.Type.FullType, alternates);

    return baseCanMerge.Add(typeParametersCanMerge).Add(alternatesCanMerge);
  }

  protected override TObject MergeGroup(IEnumerable<TObject> group)
  {
    IEnumerable<IGqlpTypeParameter> typeParametersAsts = group.ManyMerge(item => item.TypeParameters, typeParameters);
    IEnumerable<IGqlpAlternate<TObjBase>> alternateAsts = group.ManyMerge(item => item.Alternates, alternates);

    return SetAlternates(base.MergeGroup(group), typeParametersAsts, alternateAsts);
  }

  internal override IEnumerable<TObjField> GetItems(TObject type)
    => type.Fields;

  protected abstract TObject SetAlternates(TObject obj, IEnumerable<IGqlpTypeParameter> typeParameters, IEnumerable<IGqlpAlternate<TObjBase>> alternates);
}
