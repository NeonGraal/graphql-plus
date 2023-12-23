using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

public class ObjectsMerger<TObject, TField, TReference>(
  IMerge<TypeParameterAst> typeParameters,
  IMerge<AlternateAst<TReference>> alternates,
  IMerge<TField> fields
) : AliasedMerger<TObject>
  where TObject : AstObject<TField, TReference>
  where TField : AstField<TReference>, IAstDescribed
  where TReference : AstReference<TReference>
{
  protected override string ItemMatchKey(TObject item)
    => item.Extends?.Name ?? "";

  public override bool CanMerge(TObject[] items)
  {
    var baseCanMerge = base.CanMerge(items);
    var typeParametersCanMerge = items.ManyCanMerge(item => item.TypeParameters, typeParameters);
    var fieldsCanMerge = items.ManyGroupCanMerge(item => item.Fields, f => f.Name, fields);
    var alternatesCanMerge = items.ManyGroupCanMerge(item => item.Alternates, a => a.Type.FullType, alternates);

    return baseCanMerge && typeParametersCanMerge && fieldsCanMerge && alternatesCanMerge;
  }

  protected override TObject MergeGroup(TObject[] group)
    => base.MergeGroup(group) with {
      TypeParameters = group.ManyMerge(item => item.TypeParameters, typeParameters),
      Fields = group.ManyMerge(item => item.Fields, fields),
      Alternates = group.ManyMerge(item => item.Alternates, alternates),
    };
}
