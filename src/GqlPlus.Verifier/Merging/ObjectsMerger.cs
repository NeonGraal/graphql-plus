using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

public class ObjectsMerger<TObject, TField, TReference>(
  IMerge<TypeParameterAst> typeParameters,
  IMerge<AlternateAst<TReference>> alternates,
  IMerge<TField> fields
) : DescribedsMerger<TObject>
  where TObject : AstObject<TField, TReference>
  where TField : AstField<TReference>, IAstDescribed
  where TReference : AstReference<TReference>
{
  protected override string ItemMatchKey(TObject item)
    => item.Extends?.Name ?? "";
  public override bool CanMerge(TObject[] items)
    => base.CanMerge(items)
      && items.ManyMerge(item => item.TypeParameters, typeParameters)
      && items.ManyGroupMerge(item => item.Fields, f => f.Name, fields)
      && items.ManyGroupMerge(item => item.Alternates, a => a.Type.FullType, alternates);
}
