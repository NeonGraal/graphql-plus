﻿using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeTypeParameters
  : GroupsMerger<TypeParameterAst>
{
  protected override string ItemGroupKey(TypeParameterAst item) => item.Name;

  protected override bool CanMergeGroup(IGrouping<string, TypeParameterAst> group)
    => group.CanMerge(item => item.Description);

  protected override TypeParameterAst MergeGroup(TypeParameterAst[] items)
    => items.First() with { Description = items.MergeDescriptions() };
}
