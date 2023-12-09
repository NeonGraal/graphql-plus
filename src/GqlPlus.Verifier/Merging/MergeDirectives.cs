﻿using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeDirectives(IMerge<ParameterAst> parameters)
  : DescribedMerger<DirectiveDeclAst>
{
  protected override string ItemGroupKey(DirectiveDeclAst item)
    => item.Option.ToString();

  public override bool CanMerge(DirectiveDeclAst[] items)
    => base.CanMerge(items)
      && parameters.CanMerge(items.SelectMany(item => item.Parameters).ToArray());
}
