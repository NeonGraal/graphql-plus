using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using GqlPlus.Ast.Schema;

namespace GqlPlus.Ast;

public static class AstExtensions
{
  public static bool NullEqual<T>(this T? left, T? right)
    where T : IEquatable<T>
    => left is null && right is null
    || left is not null && left.Equals(right);

  public static bool NullEqual(this decimal? left, decimal? right)
    => left is null && right is null
    || left is not null && left == right;

  public static bool OrderedEqual<T>(this IEnumerable<T> left, IEnumerable<T> right, IComparer<T>? comparer = null)
    => left.Order(comparer).SequenceEqual(right.Order(comparer));

  public static TResult[] ArrayOf<TResult>(this IEnumerable<object> items)
    => [.. items.OfType<TResult>()];

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
      result = result?.Order();
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
    => string.Join(", ", items?.Order(StringComparer.Ordinal).Select(i => $"'{i}'") ?? []);

  public static string Debug<T>(this IEnumerable<T?>? items, Func<T?, string> mapping)
    => (items?.Select(mapping)).Debug();

  public static string Joined(this IEnumerable<string?>? items, string by = " ")
    => string.Join(by,
      items?.Where(i => !string.IsNullOrWhiteSpace(i))
      ?? []);

  public static string Joined<T>(this IEnumerable<T?>? items, Func<T?, string> mapping)
    => (items?.Select(mapping)).Joined();

  internal static IEnumerable<string?> Bracket(this AstAbbreviated? item, string before, string after)
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

  public static string Prefixed(this string? text, string prefix)
    => text?.Length > 0 ? prefix + text : "";

  public static string Prefixed(this AstAbbreviated? ast, string prefix)
    => ast is null ? "" : $"{prefix}{ast}";

  public static string Suffixed(this string? text, string suffix)
    => text?.Length > 0 ? text + suffix : "";

  public static string Quoted(this string? text, string quote)
    => text?.Length > 0
    ? string.Concat(
      quote,
      text
        .Replace("\\", "\\\\", StringComparison.InvariantCulture)
        .Replace(quote, "\\" + quote, StringComparison.InvariantCulture),
      quote)
    : "";

  public static void AddError<TAst>(this ITokenMessages errors, TAst item, string message)
    where TAst : AstAbbreviated
  {
    if (errors is null || item is null) {
      return;
    }

    errors.Add(item.Error(message));
  }

  public static AstFields<TValue> ToObject<TItem, TValue>(this IEnumerable<TItem> items, Func<TItem, FieldKeyAst> key, Func<TItem, TValue> value)
    where TValue : AstValue<TValue>
    => new(items.Distinct().ToDictionary(key, value));

  public static IEnumerable<IGrouping<string, TAliased>> AliasedGroup<TAliased>(this TAliased[] items)
    where TAliased : AstAliased
  {
    HashSet<string> names = items.Select(d => d.Name).Distinct().ToHashSet();

    return items.SelectMany(t => t.Aliases.Select(a => (Id: a, Item: t)))
      .Where(p => !names.Contains(p.Id))
      .GroupBy(p => p.Id, p => p.Item)
      .Union(items.GroupBy(t => t.Name));
  }

  public static IMap<TResult> AliasedMap<TAliased, TResult>(this TAliased[] items, Func<IEnumerable<TAliased>, TResult> element)
    where TAliased : AstAliased
    => AliasedGroup(items)
      .ToMap(g => g.Key, g => element(g));
}
