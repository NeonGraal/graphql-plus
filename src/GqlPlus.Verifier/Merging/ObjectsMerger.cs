﻿using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class ObjectsMerger<TObject, TField, TReference>(
  IMerge<TypeParameterAst> typeParameters,
  IMerge<AlternateAst<TReference>> alternates,
  IMerge<TField> fields
) : AliasedAllMerger<AstType, TObject>
  where TObject : AstObject<TField, TReference>
  where TField : AstField<TReference>, IAstDescribed
  where TReference : AstReference<TReference>
{
  protected override string ItemMatchKey(TObject item)
    => item.Parent?.Name ?? "";

  public override bool CanMerge(IEnumerable<TObject> items)
  {
    var baseCanMerge = base.CanMerge(items);
    var typeParametersCanMerge = items.ManyCanMerge(item => item.TypeParameters, typeParameters);
    var fieldsCanMerge = items.ManyGroupCanMerge(item => item.Fields, f => f.Name, fields);
    var alternatesCanMerge = items.ManyGroupCanMerge(item => item.Alternates, a => a.Type.FullType, alternates);

    return baseCanMerge && typeParametersCanMerge && fieldsCanMerge && alternatesCanMerge;
  }

  protected override TObject MergeGroup(IEnumerable<TObject> group)
  {
    var typeParameterAsts = group.ManyMerge(item => item.TypeParameters, typeParameters);
    var fieldAsts = group.ManyMerge(item => item.Fields, fields);
    var alternateAsts = group.ManyMerge(item => item.Alternates, alternates);

    return base.MergeGroup(group) with {
      TypeParameters = [.. typeParameterAsts],
      Fields = [.. fieldAsts],
      Alternates = [.. alternateAsts],
    };
  }
}
