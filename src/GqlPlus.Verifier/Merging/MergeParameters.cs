﻿using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeParameters
  : AlternatesMerger<ParameterAst, InputReferenceAst>
{
  protected override string ItemGroupKey(ParameterAst item)
    => item.Modifiers.AsString().Joined();
  public override bool CanMerge(ParameterAst[] items)
    => base.CanMerge(items)
    && items.CanMerge(item => item.Default);
}
