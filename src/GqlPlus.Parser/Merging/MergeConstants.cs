using System.Collections.Immutable;

using GqlPlus.Ast;

namespace GqlPlus.Merging;

internal class MergeConstants
  : BaseMerger<IGqlpConstant>
{
  public override IEnumerable<IGqlpConstant> Merge(IEnumerable<IGqlpConstant> items)
  {
    if (items is null) {
      return [];
    }

    IGqlpConstant[] list = [.. items];
    return list.Length > 1
      ? [list.Aggregate(CombineConstants)]
    : list;
  }

  private IGqlpConstant CombineConstants(IGqlpConstant a, IGqlpConstant b)
    => a.Values.Any() || b.Values.Any()
      ? MergeValues(a, b)
      : a.Fields.Any() && b.Fields.Any()
        ? MergeFields(a, b)
        : b;

  private static IGqlpConstant MergeValues(IGqlpConstant a, IGqlpConstant b)
  {
    IEnumerable<IGqlpConstant> values = a.Values.Append(b);

    if (b.Values.Any()) {
      values = a.Values.Any()
        ? a.Values.Concat(b.Values).Distinct()
        : b.Values.Prepend(a);
    }

    return (ConstantAst)b with { Value = null, Fields = new FieldsAst<IGqlpConstant>(), Values = values.ArrayOf<ConstantAst>() };
  }

  private IGqlpConstant MergeFields(IGqlpConstant a, IGqlpConstant b)
  {
    ImmutableDictionary<IGqlpFieldKey, IGqlpConstant> fields = a.Fields.Concat(b.Fields)
      .ToLookup(p => p.Key, p => p.Value)
      .ToImmutableDictionary(g => g.Key, g => Merge(g).First());

    return (ConstantAst)b with { Fields = new FieldsAst<IGqlpConstant>(fields) };
  }
}
