﻿using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Merging;

internal class MergeConstants
  : BaseMerger<ConstantAst>
{
  public override IEnumerable<ConstantAst> Merge(IEnumerable<ConstantAst> items)
    => items is not null
      ? items.Count() > 1
        ? [items.Aggregate(CombineConstants)]
        : items
      : [];

  private ConstantAst CombineConstants(ConstantAst a, ConstantAst b)
  {
    if (a.Values.Length > 0 || b.Values.Length > 0) {
      var values = a.Values.Append(b);

      if (b.Values.Length > 0) {
        values = a.Values.Length == 0
          ? b.Values.Prepend(a)
          : a.Values.Concat(b.Values).Distinct();
      }

      return b with { Value = null, Fields = [], Values = [.. values] };
    }

    if (a.Fields.Any() && b.Fields.Any()) {
      var fields = a.Fields.Concat(b.Fields)
        .ToLookup(p => p.Key, p => p.Value)
        .ToDictionary(g => g.Key, g => Merge(g).First());

      return b with { Fields = new(fields) };
    }

    return b;
  }
}
