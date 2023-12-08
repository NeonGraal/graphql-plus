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
}
