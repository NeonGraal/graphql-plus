using System.Collections.Immutable;

using GqlPlus.Ast;

namespace GqlPlus.Merging;

internal class MergeConstants
  : BaseMerger<IAstConstant>
{
  public override IEnumerable<IAstConstant> Merge(IEnumerable<IAstConstant> items)
  {
    if (items is null) {
      return [];
    }

    IAstConstant[] list = [.. items];
    return list.Length > 1
      ? [list.Aggregate(CombineConstants)]
    : list;
  }

  private IAstConstant CombineConstants(IAstConstant a, IAstConstant b)
    => a.Values.Any() || b.Values.Any()
      ? MergeValues(a, b)
      : a.Fields.Any() && b.Fields.Any()
        ? MergeFields(a, b)
        : b;

  private static IAstConstant MergeValues(IAstConstant a, IAstConstant b)
  {
    IEnumerable<IAstConstant> values = a.Values.Append(b);

    if (b.Values.Any()) {
      values = a.Values.Any()
        ? a.Values.Concat(b.Values).Distinct()
        : b.Values.Prepend(a);
    }

    return (ConstantAst)b with { Value = null, Fields = new FieldsAst<IAstConstant>(), Values = values.ArrayOf<ConstantAst>() };
  }

  private IAstConstant MergeFields(IAstConstant a, IAstConstant b)
  {
    ImmutableDictionary<IAstFieldKey, IAstConstant> fields = a.Fields.Concat(b.Fields)
      .ToLookup(p => p.Key, p => p.Value)
      .ToImmutableDictionary(g => g.Key, g => Merge(g).First());

    return (ConstantAst)b with { Fields = new FieldsAst<IAstConstant>(fields) };
  }

  internal static MergeConstants Factory(IMergerRepository _) => new();
}
