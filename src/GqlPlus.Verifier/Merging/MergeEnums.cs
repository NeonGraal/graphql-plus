﻿using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeEnums(
  IMerge<EnumValueAst> enumValues
) : NamedMerger<EnumDeclAst>
{
  protected override string ItemMatchKey(EnumDeclAst item)
    => item.Extends ?? "";

  public override bool CanMerge(EnumDeclAst[] items)
    => base.CanMerge(items)
      && items.CanMerge(item => item.Description)
      && items.ManyMerge(e => e.Values, enumValues);

  protected override EnumDeclAst MergeGroup(EnumDeclAst[] items)
    => items.First() with { Description = items.MergeDescriptions() };
}
