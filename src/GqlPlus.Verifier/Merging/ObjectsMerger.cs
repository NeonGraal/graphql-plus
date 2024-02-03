using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class ObjectsMerger<TObject, TField, TReference>(
  IMerge<TypeParameterAst> typeParameters,
  IMerge<AlternateAst<TReference>> alternates,
  IMerge<TField> fields
) : TypedMerger<AstType, TObject, TReference, TypeParameterAst>(typeParameters)
  where TObject : AstObject<TField, TReference>
  where TField : AstField<TReference>, IAstDescribed
  where TReference : AstReference<TReference>
{
  protected override string ItemMatchKey(TObject item)
    => item.Parent?.Name ?? "";

  protected override bool CanMergeGroup(IGrouping<string, TObject> group)
  {
    var baseCanMerge = base.CanMergeGroup(group);
    var fieldsCanMerge = group.ManyGroupCanMerge(item => item.Fields, f => f.Name, fields);
    var alternatesCanMerge = group.ManyGroupCanMerge(item => item.Alternates, a => a.Type.FullType, alternates);

    return baseCanMerge && fieldsCanMerge && alternatesCanMerge;
  }

  protected override TObject MergeGroup(IEnumerable<TObject> group)
  {
    var fieldAsts = group.ManyMerge(item => item.Fields, fields);
    var alternateAsts = group.ManyMerge(item => item.Alternates, alternates);

    return base.MergeGroup(group) with {
      Fields = [.. fieldAsts],
      Alternates = [.. alternateAsts],
    };
  }

  internal override IEnumerable<TypeParameterAst> GetItems(TObject type)
    => type.TypeParameters;
  internal override TObject SetItems(TObject input, IEnumerable<TypeParameterAst> items)
    => input with { TypeParameters = [.. items] };
}
