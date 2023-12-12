using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

public class ObjectsMerger<TObject, TField, TReference>(
  IMerge<TypeParameterAst> typeParameters,
  IMerge<AlternateAst<TReference>> alternates,
  IMerge<TField> fields
) : NamedsMerger<TObject>
  where TObject : AstObject<TField, TReference>
  where TField : AstField<TReference>, IAstDescribed
  where TReference : AstReference<TReference>
{
  protected override string ItemMatchKey(TObject item)
    => item.Extends?.Name ?? "";
  public override bool CanMerge(TObject[] items)
    => base.CanMerge(items)
      && typeParameters.CanMerge([.. items.SelectMany(item => item.TypeParameters)])
      && fields.CanMerge([.. items.SelectMany(item => item.Fields)])
      && alternates.CanMerge([.. items.SelectMany(item => item.Alternates)]);
}
