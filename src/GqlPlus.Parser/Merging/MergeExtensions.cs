using System.Runtime.CompilerServices;

using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema;
using GqlPlus.Result;

namespace GqlPlus.Merging;

#pragma warning disable CA1508 // Avoid dead conditional code
public static class MergeExtensions
{
  public static IMessages CanMergeStruct<TItem, TObjField>(
      this IEnumerable<TItem> items,
      Func<TItem, TObjField> field,
      [CallerArgumentExpression(nameof(field))] string? fieldExpr = null)
    where TItem : IGqlpError
    where TObjField : struct
  {
    items.ThrowIfNull();
    field.ThrowIfNull();

    TObjField? result = default;

#pragma warning disable CA1062 // Validate arguments of public methods
    foreach (TItem item in items) {
      TObjField? value = field(item);
#pragma warning restore CA1062 // Validate arguments of public methods
      if (value is null || value.Equals(default)) {
        continue;
      }

      if (result is null || result.Equals(default)) {
        result = value;
        continue;
      }

      if (!result.Equals(value)) {
        return item.MakeError($"Different values merging {fieldExpr}: {result} != {value}");
      }
    }

    return Messages.New;
  }

  public static IMessages CanMergeString<TItem>(
      this IEnumerable<TItem> items,
      Func<TItem, string?> field,
      [CallerArgumentExpression(nameof(field))] string? fieldExpr = null)
    where TItem : IGqlpError
  {
    items.ThrowIfNull();
    field.ThrowIfNull();

    string? result = null;

#pragma warning disable CA1062 // Validate arguments of public methods
    foreach (TItem item in items) {
      string? value = field(item);
#pragma warning restore CA1062 // Validate arguments of public methods
      if (value.IsWhiteSpace()) {
        continue;
      }

      if (result.IsWhiteSpace()) {
        result = value;
        continue;
      }

      if (!result!.Equals(value, StringComparison.Ordinal)) {
        return item.MakeError($"Different values merging {fieldExpr}: {result} != {value}");
      }
    }

    return Messages.New;
  }

  public static IMessages CanMerge<TItem, TObjField>(
      this IEnumerable<TItem> items,
      Func<TItem, TObjField?> field,
      IMerge<TObjField> merger)
    where TObjField : IGqlpError
  {
    merger.ThrowIfNull();

    TObjField[] fields = [.. items.Select(field).Where(f => f is not null).Cast<TObjField>()];

#pragma warning disable CA1062 // Validate arguments of public methods
    return fields.Length > 0 ? merger.CanMerge(fields) : Messages.New;
#pragma warning restore CA1062 // Validate arguments of public methods
  }

  public static IMessages ManyCanMerge<TItem, TGroup>(
      this IEnumerable<TItem> items,
      Func<TItem, IEnumerable<TGroup>> many,
      IMerge<TGroup> merger)
    where TGroup : IGqlpError
  {
    merger.ThrowIfNull();

    TGroup[] groups = [.. items.SelectMany(many)];
#pragma warning disable CA1062 // Validate arguments of public methods
    return groups.Length < 2 ? Messages.New
      : merger.CanMerge(groups);
#pragma warning restore CA1062 // Validate arguments of public methods
  }

  public static IEnumerable<TObjField> Merge<TItem, TObjField>(
      this IEnumerable<TItem> items,
      Func<TItem, TObjField?> field,
      IMerge<TObjField> merger)
    where TObjField : IGqlpError
  {
    merger.ThrowIfNull();

    TObjField[] fields = [.. items.Select(field).Where(f => f is not null).Cast<TObjField>()];

#pragma warning disable CA1062 // Validate arguments of public methods
    return merger.Merge(fields);
#pragma warning restore CA1062 // Validate arguments of public methods
  }

  public static IEnumerable<TGroup> ManyMerge<TItem, TGroup>(
      this IEnumerable<TItem> items,
      Func<TItem, IEnumerable<TGroup>> many,
      IMerge<TGroup> merger)
    where TGroup : IGqlpError
  {
    merger.ThrowIfNull();

#pragma warning disable CA1062 // Validate arguments of public methods
    return merger.Merge(items.SelectMany(many));
#pragma warning restore CA1062 // Validate arguments of public methods
  }

  public static IMessages ManyGroupCanMerge<TItem, TGroup>(
      this IEnumerable<TItem> items,
      Func<TItem, IEnumerable<TGroup>> many,
      Func<TGroup, string> key,
      IMerge<TGroup> merger)
    where TGroup : IGqlpError
    => Messages.New
      .Add(items
        .SelectMany(many).GroupBy(key)
        .SelectMany(p => merger.CanMerge([.. p])));

  public static IEnumerable<TGroup> ManyGroupMerger<TItem, TGroup>(
      this IEnumerable<TItem> items,
      Func<TItem, IEnumerable<TGroup>> many,
      Func<TGroup, string> key,
      IMerge<TGroup> merger)
    where TGroup : IGqlpError
  {
    List<Indexed<TGroup>> result = [];
    IEnumerable<IGrouping<string, Indexed<TGroup>>> groups = items.SelectMany(many).Select(Indexed<TGroup>.To).GroupBy(i => key(i.Item));

    foreach (IGrouping<string, Indexed<TGroup>> group in groups) {
      TGroup item = group.Combine(i => i.Item, merger);
      result.Add(new(item, group.Min(i => i.Index)));
    }

    return result.OrderBy(i => i.Index).Select(i => i.Item);
  }

  public static IEnumerable<TItem> GroupMerger<TItem>(this IEnumerable<TItem> items, Func<TItem, string> key, Func<TItem[], TItem> merger)
  {
    merger.ThrowIfNull();

    List<Indexed<TItem>> result = [];
    IEnumerable<IGrouping<string, Indexed<TItem>>> groups = items.Select(Indexed<TItem>.To).GroupBy(i => key(i.Item));

    foreach (IGrouping<string, Indexed<TItem>> group in groups) {
#pragma warning disable CA1062 // Validate arguments of public methods
      TItem? item = merger([.. group.Select(i => i.Item)]);
#pragma warning restore CA1062 // Validate arguments of public methods
      result.Add(new(item, group.Min(i => i.Index)));
    }

    return result.OrderBy(i => i.Index).Select(i => i.Item);
  }

  internal static TDescr MakeDescription<TDescr, TItem>(this TDescr descr, IEnumerable<TItem> items)
    where TDescr : IAstSetDescription
    where TItem : IGqlpDescribed
  {
    string description = items.Select(item => item.Description).Joined(" ");
    if (!description.IsWhiteSpace()) {
      descr.SetDescription(description);
    }

    return descr;
  }

  public static TObjField Combine<TItem, TObjField>(this IEnumerable<TItem> items, Func<TItem, TObjField> field, IMerge<TObjField> merger)
    where TObjField : IGqlpError
  {
    merger.ThrowIfNull();

#pragma warning disable CA1062 // Validate arguments of public methods
    return merger.Merge(items.Select(field)).First();
#pragma warning restore CA1062 // Validate arguments of public methods
  }

  private record struct Indexed<TItem>(TItem Item, int Index)
  {
    public static Indexed<TItem> To(TItem item, int n)
      => new(item, n);
  }
}
