using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

public class ObjectsMerger<TObject, TField, TReference>(
  IMerge<TypeParameterAst> typeParameters,
  IMerge<AlternateAst<TReference>> alternates,
  IMerge<TField> fields
) : NamedMerger<TObject>
  where TObject : AstObject<TField, TReference>
  where TField : AstField<TReference>, IAstDescribed
  where TReference : AstReference<TReference>
{
  protected override string ItemMatchKey(TObject item)
    => item.Extends?.Name ?? "";

  public override bool CanMerge(TObject[] items)
  {
    var baseCanMerge = base.CanMerge(items);
    var descriptionsCanMerge = items.CanMerge(item => item.Description);
    var typeParametersCanMerge = items.ManyCanMerge(item => item.TypeParameters, typeParameters);
    var fieldsCanMerge = items.ManyGroupCanMerge(item => item.Fields, f => f.Name, fields);
    var alternatesCanMerge = items.ManyGroupCanMerge(item => item.Alternates, a => a.Type.FullType, alternates);

    return baseCanMerge && descriptionsCanMerge && typeParametersCanMerge && fieldsCanMerge && alternatesCanMerge;
  }

  protected override TObject MergeGroup(TObject[] group)
    => group.First() with { Description = group.MergeDescriptions() };
}
