﻿using GqlPlus.Verifier.Ast.Schema.Objects;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Merging.Objects;

internal class MergeTypeParameters
  : GroupsMerger<TypeParameterAst>
{
  protected override string ItemGroupKey(TypeParameterAst item) => item.Name;

  protected override ITokenMessages CanMergeGroup(IGrouping<string, TypeParameterAst> group)
    => group.CanMerge(item => item.Description);

  protected override TypeParameterAst MergeGroup(IEnumerable<TypeParameterAst> group)
    => group.First() with { Description = group.MergeDescriptions() };
}
