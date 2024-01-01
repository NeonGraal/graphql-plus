using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Merging;

public static class MergeExtensions
{
  public static bool CanMerge<TItem, TField>(
      this IEnumerable<TItem> items,
      Func<TItem, TField?> field)
  {
    TField? result = default;

    foreach (var item in items) {
      var value = field(item);
      if (value is null || value.Equals(default)) {
        continue;
      }

      if (result is null || result.Equals(default)) {
        result = value;
        continue;
      }

      if (!result.Equals(value)) {
        return false;
      }
    }

    return true;
  }

  public static bool CanMerge<TItem, TField>(
      this IEnumerable<TItem> items,
      Func<TItem, TField> field,
      IMerge<TField> merger)
    => merger.CanMerge(items.Select(field));

  public static bool CanMerge<TItem>(
      this IEnumerable<TItem> items,
      Func<TItem, string?> field)
  {
    var result = "";

    foreach (var item in items) {
      var value = field(item);
      if (string.IsNullOrEmpty(value)) {
        continue;
      }

      if (string.IsNullOrEmpty(result)) {
        result = value;
        continue;
      }

      if (result != value) {
        return false;
      }
    }

    return true;
  }

  public static bool ManyCanMerge<TItem, TGroup>(
      this IEnumerable<TItem> items,
      Func<TItem, IEnumerable<TGroup>> many,
      IMerge<TGroup> merger)
  {
    TGroup[] groups = [.. items.SelectMany(many)];
    return groups.Length < 2 || merger.CanMerge(groups);
  }

  public static IEnumerable<TGroup> ManyMerge<TItem, TGroup>(
      this IEnumerable<TItem> items,
      Func<TItem, IEnumerable<TGroup>> many,
      IMerge<TGroup> merger)
    => merger.Merge(items.SelectMany(many));

  public static bool ManyGroupCanMerge<TItem, TGroup>(
      this IEnumerable<TItem> items,
      Func<TItem, IEnumerable<TGroup>> many,
      Func<TGroup, string> key,
      IMerge<TGroup> merger)
    => items.SelectMany(many).GroupBy(key)
      .All(p => merger.CanMerge([.. p]));

  public static IEnumerable<TGroup> ManyGroupMerger<TItem, TGroup>(
      this IEnumerable<TItem> items,
      Func<TItem, IEnumerable<TGroup>> many,
      Func<TGroup, string> key,
      IMerge<TGroup> merger)
  {
    List<Indexed<TGroup>> result = [];
    var groups = items.SelectMany(many).Select(Indexed<TGroup>.To).GroupBy(i => key(i.Item));

    foreach (var group in groups) {
      var item = group.Combine(i => i.Item, merger);
      result.Add(new(item, group.Min(i => i.Index)));
    }

    return result.OrderBy(i => i.Index).Select(i => i.Item);
  }

  public static IEnumerable<TItem> GroupMerger<TItem>(this IEnumerable<TItem> items, Func<TItem, string> key, Func<TItem[], TItem> merger)
  {
    List<Indexed<TItem>> result = [];
    var groups = items.Select(Indexed<TItem>.To).GroupBy(i => key(i.Item));

    foreach (var group in groups) {
      var item = merger([.. group.Select(i => i.Item)]);
      result.Add(new(item, group.Min(i => i.Index)));
    }

    return result.OrderBy(i => i.Index).Select(i => i.Item);
  }

  public static string MergeDescriptions<TItem>(this IEnumerable<TItem> items)
    where TItem : IAstDescribed
    => items
      .Select(item => item.Description)
      .FirstOrDefault(descr => !string.IsNullOrWhiteSpace(descr))
      ?? "";

  public static TField Combine<TItem, TField>(this IEnumerable<TItem> items, Func<TItem, TField> field, IMerge<TField> merger)
    => merger.Merge(items.Select(field)).First();

  private record struct Indexed<TItem>(TItem Item, int Index)
  {
    public static Indexed<TItem> To(TItem item, int n)
      => new(item, n);
  }
}
