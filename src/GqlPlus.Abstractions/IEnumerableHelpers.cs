using GqlPlus.Abstractions;

namespace GqlPlus;

public static class IEnumerableHelpers
{
  public static T[] ArrayOf<T>(this IEnumerable<object>? items)
    => [.. items?.OfType<T>() ?? []];

  public static TResult[] AsArray<TSource, TResult>(this IEnumerable<TSource>? items, Func<TSource, TResult> mapper)
    => [.. items?.Select(mapper) ?? []];

  private static IEnumerable<string?>? AsFields<T>(IEnumerable<T>? items)
    => items?.Any(i => i is IGqlpAbbreviated) == true
    ? items.OfType<IGqlpAbbreviated>().SelectMany(i => i.GetFields())
    : items?.Any() == true
      ? items.Select(i => $"{i}")
      : null;
  public static IEnumerable<string> AsString<T>(this IEnumerable<T>? items)
    => items?.Any() == true
      ? items.Where(i => i is not null).Select(i => $"{i}")
      : [];

  public static IEnumerable<string> Bracket<T>(
    this IEnumerable<T>? items,
    string before,
    string after,
    Func<T, string> formatter)
   => items?.Any() == true
      ? items.Select(formatter).Prepend(before).Append(after)
      : [];

  public static IEnumerable<string?> Bracket<T>(
    this IEnumerable<T>? items,
    string before = "",
    string after = "",
    bool sort = false)
  {
    IEnumerable<string?>? result = AsFields(items);

    if (sort) {
      result = result?.OrderBy(t => t);
    }

    return result
        ?.Prepend(before)
        ?.Append(after)
        ?? [];
  }

  public static string Debug(this IEnumerable<string?>? items)
    => string.Join(", ", items?.OrderBy(t => t, StringComparer.Ordinal).Select(i => $"'{i}'") ?? []);

  public static string Joined(this IEnumerable<string?>? items, string by = " ")
    => string.Join(by,
      items?.Where(i => !string.IsNullOrWhiteSpace(i))
      ?? []);

  public static string Joined<T>(this IEnumerable<T?>? items, Func<T?, string> mapping, string by = " ")
    => (items?.Select(mapping).Joined(by)).IfWhiteSpace();

  public static bool OrderedEqual<T>(this IEnumerable<T> left, IEnumerable<T> right, IComparer<T>? comparer = null)
    => left.OrderBy(l => l, comparer).SequenceEqual(right.OrderBy(r => r, comparer));

  public static string Surround(
    this IEnumerable<string>? items,
    string before,
    string after,
    string by = " ")
   => items.Joined(by).Prefixed(before).Suffixed(after);

  public static string Surround<T>(
    this IEnumerable<T>? items,
    string before,
    string after,
    Func<T?, string> formatter,
    string by = " ")
   => items.Joined(formatter, by).Prefixed(before).Suffixed(after);
}
