using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Merging;

public static class MergeExtensions
{
  public static bool CanMerge<TItem, TField>(this IEnumerable<TItem> items, Func<TItem, TField?> field)
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

  public static bool CanMerge<TItem>(this IEnumerable<TItem> items, Func<TItem, string?> field)
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

  public static bool ManyGroupMerge<TItem, TGroup>(
      this IEnumerable<TItem> items,
      Func<TItem, IEnumerable<TGroup>> many,
      Func<TGroup, string> groupKey,
      IMerge<TGroup> merger)
    => items.SelectMany(many).GroupBy(groupKey).All(p => merger.CanMerge([.. p]));

  public static bool ManyMerge<TItem, TGroup>(
      this IEnumerable<TItem> items,
      Func<TItem, IEnumerable<TGroup>> many,
      IMerge<TGroup> merger)
  {
    TGroup[] groups = [.. items.SelectMany(many)];
    return groups.Length < 2 || merger.CanMerge(groups);
  }

  public static string MergeDescriptions<TItem>(this TItem[] items)
    where TItem : IAstDescribed
    => items
      .Select(item => item.Description)
      .FirstOrDefault(descr => !string.IsNullOrWhiteSpace(descr))
      ?? "";

}
