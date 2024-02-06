using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class AstObjectsMerger<TObject, TField, TReference>(
  IMerge<TField> fields,
  IMerge<TypeParameterAst> typeParameters,
  IMerge<AstAlternate<TReference>> alternates
) : AstTypeMerger<AstType, TObject, TReference, TField>(fields)
  where TObject : AstObject<TField, TReference>
  where TField : AstField<TReference>, IAstDescribed
  where TReference : AstReference<TReference>
{
  protected override string ItemMatchKey(TObject item)
    => item.Parent?.Name ?? "";

  protected override bool CanMergeGroup(IGrouping<string, TObject> group)
  {
    var baseCanMerge = base.CanMergeGroup(group);
    var typeParametersCanMerge = group.ManyCanMerge(item => item.TypeParameters, typeParameters);
    var alternatesCanMerge = group.ManyGroupCanMerge(item => item.Alternates, a => a.Type.FullType, alternates);

    return baseCanMerge && typeParametersCanMerge && alternatesCanMerge;
  }

  protected override TObject MergeGroup(IEnumerable<TObject> group)
  {
    var typeParametersAsts = group.ManyMerge(item => item.TypeParameters, typeParameters);
    var alternateAsts = group.ManyMerge(item => item.Alternates, alternates);

    return base.MergeGroup(group) with {
      TypeParameters = [.. typeParametersAsts],
      Alternates = [.. alternateAsts],
    };
  }

  internal override IEnumerable<TField> GetItems(TObject type)
    => type.Fields;
  internal override TObject SetItems(TObject input, IEnumerable<TField> items)
    => input with { Fields = [.. items] };
}
