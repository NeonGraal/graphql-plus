namespace GqlPlus;

public static class IEnumerableHelpers
{
  public static T[] ArrayOf<T>(this IEnumerable<object>? items)
    => [.. items?.OfType<T>() ?? []];

  public static TResult[] AsArray<TSource, TResult>(this IEnumerable<TSource>? items, Func<TSource, TResult> mapper)
    => [.. items?.Select(mapper) ?? []];

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

  public static IEnumerable<string?> ConcatIf(this IEnumerable<string?>? items, bool test,
    Func<IEnumerable<string?>?>? testValues = null, Func<IEnumerable<string?>?>? elseValues = null)
    => (items ?? []).Concat((test ? testValues?.Invoke() : elseValues?.Invoke()) ?? []);

  public static IEnumerable<string?> ConcatNull<T>(
      this IEnumerable<string?>? items,
      T? value,
      Func<T, IEnumerable<string?>?>? testValues = null,
      Func<IEnumerable<string?>?>? nullValues = null)
    => (items ?? []).Concat((value is null ? nullValues?.Invoke() : testValues?.Invoke(value)) ?? []);

  public static string Debug(this IEnumerable<string?>? items)
    => (items?.OrderBy(t => t, StringComparer.Ordinal)).Joined(i => $"'{i}'", ", ");

  public static string Joined(this IEnumerable<string?>? items, string by = " ")
    => string.Join(by, items?.RemoveEmpty() ?? []);

  public static string Joined<T>(this IEnumerable<T?>? items, Func<T?, string> mapping, string by = " ")
    => (items?.Select(mapping).Joined(by)).IfWhiteSpace();

  public static bool OrderedEqual<T>(this IEnumerable<T> left, IEnumerable<T> right, IComparer<T>? comparer = null)
    => left.OrderBy(l => l, comparer).SequenceEqual(right.OrderBy(r => r, comparer));

  public static IEnumerable<string> RemoveEmpty(this IEnumerable<string?>? items)
    => items?.Where(i => !string.IsNullOrWhiteSpace(i)).Cast<string>() ?? [];

  public static string Surround(
    this IEnumerable<string>? items,
    string before,
    string after,
    string by = " ")
   => items.Joined(by).Surrounded(before, after);

  public static string Surround<T>(
    this IEnumerable<T>? items,
    string before,
    string after,
    Func<T?, string> formatter,
    string by = " ")
   => items.Joined(formatter, by).Surrounded(before, after);
}
