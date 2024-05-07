using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Merging.Objects;

internal class AstObjectsMerger<TObject, TObjField, TObjBase>(
  ILoggerFactory logger,
  IMerge<TObjField> fields,
  IMerge<IGqlpTypeParameter> typeParameters,
  IMerge<AstAlternate<TObjBase>> alternates
) : AstTypeMerger<IGqlpType, TObject, TObjBase, TObjField>(logger, fields)
  where TObject : AstObject<TObjField, TObjBase>
  where TObjField : AstObjectField<TObjBase>, IGqlpDescribed
  where TObjBase : AstObjectBase<TObjBase>
{
  protected override string ItemMatchName => "Parent";
  protected override string ItemMatchKey(TObject item)
    => item.Parent?.Name ?? "";

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
    IEnumerable<AstAlternate<TObjBase>> alternateAsts = group.ManyMerge(item => item.Alternates, alternates);

    return base.MergeGroup(group) with {
      TypeParameters = typeParametersAsts.ArrayOf<TypeParameterAst>(),
      Alternates = [.. alternateAsts],
    };
  }

  internal override IEnumerable<TObjField> GetItems(TObject type)
    => type.Fields;
  internal override TObject SetItems(TObject input, IEnumerable<TObjField> items)
    => input with { Fields = [.. items] };
}
