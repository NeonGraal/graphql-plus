using System.Collections.Immutable;
using System.Globalization;

namespace GqlPlus.Ast;

public static class AstExtensions
{
  public static bool NullEqual(this string? left, string? right)
    => string.IsNullOrEmpty(left) && string.IsNullOrEmpty(right)
    || !string.IsNullOrEmpty(left) && !string.IsNullOrEmpty(right) && left!.Equals(right, StringComparison.Ordinal);

  public static bool NullEqual(this decimal? left, decimal? right)
    => left is null && right is null
    || left is not null && left == right;

  public static bool NullEqual<T>(this T? left, T? right)
    where T : IEquatable<T>
    => left is null && right is null
    || left is not null && right is not null && left.Equals(right);

  public static bool OrderedEqual<T>(this IEnumerable<T> left, IEnumerable<T> right, IComparer<T>? comparer = null)
    => left.OrderBy(t => t, comparer).SequenceEqual(right.OrderBy(t => t, comparer));

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

  private static IEnumerable<string?>? AsFields<T>(IEnumerable<T>? items)
    => items?.Any(i => i is AstAbbreviated) == true
    ? items.OfType<AstAbbreviated>().SelectMany(i => i.GetFields())
    : items?.Any() == true
      ? items.Select(i => $"{i}")
      : null;

  public static string Debug(this IEnumerable<string?>? items)
    => string.Join(", ", items?.OrderBy(t => t, StringComparer.Ordinal).Select(i => $"'{i}'") ?? []);

  internal static IEnumerable<string?> Bracket(this IGqlpAbbreviated? item, string before, string after)
    => item?.GetFields().Prepend(before).Append(after) ?? [];

  [return: NotNullIfNotNull(nameof(text))]
  public static string? Capitalize(this string? text)
    => text?.Length > 0
      ? char.ToUpper(text[0], CultureInfo.InvariantCulture) + text[1..]
      : text;

  [return: NotNullIfNotNull(nameof(text))]
  public static string? Camelize(this string? text)
    => text?.Length > 0
      ? char.ToLower(text[0], CultureInfo.InvariantCulture) + text[1..]
      : text;

  public static string Prefixed(this IGqlpAbbreviated? ast, string prefix)
    => ast is null ? "" : $"{prefix}{ast}";

  public static IGqlpFields<TValue> ToObject<TItem, TValue>(this IEnumerable<TItem> items, Func<TItem, IGqlpFieldKey> key, Func<TItem, TValue> value)
    where TValue : IGqlpValue<TValue>
    => new AstFields<TValue>(items.Distinct().ToImmutableDictionary(key, value));
}
