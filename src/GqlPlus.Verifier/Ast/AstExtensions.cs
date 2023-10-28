using System.Diagnostics.CodeAnalysis;

namespace GqlPlus.Verifier.Ast;

public static class AstExtensions
{
  public static bool NullEqual<T>(this T? left, T? right)
    where T : IEquatable<T>
    => left is null && right is null
    || left is not null && left.Equals(right);

  public static bool OrderedEqual<T>(this IEnumerable<T> left, IEnumerable<T> right, IComparer<T>? comparer = null)
    => left.Order(comparer).SequenceEqual(right.Order(comparer));

  public static IEnumerable<string> AsString<T>(this IEnumerable<T>? items)
    => items?.Any() == true
      ? items.Where(i => i is not null).Select(i => $"{i}")
      : Enumerable.Empty<string>();

  public static IEnumerable<string> Bracket<T>(
    this IEnumerable<T>? items,
    string before,
    string after,
    Func<T, string> formatter)
   => items?.Any() == true
      ? items.Select(formatter).Prepend(before).Append(after)
      : Enumerable.Empty<string>();

  public static IEnumerable<string?> Bracket<T>(
    this IEnumerable<T>? items,
    string before = "",
    string after = "")
   => items?.Any(i => i is AstBase) == true
      ? items.OfType<AstBase>()
        .SelectMany(i => i.GetFields())
        .Prepend(before)
        .Append(after)
      : items?.Any() == true
      ? items.Select(i => $"{i}").Prepend(before).Append(after)
      : Enumerable.Empty<string>();

  public static string Joined(this IEnumerable<string?>? items)
    => string.Join(" ",
      items?.Where(i => !string.IsNullOrWhiteSpace(i))
      ?? Array.Empty<string>());

  public static string Joined(this IEnumerable<string?>? items, Func<string?, string> mapping)
    => (items?.Select(mapping)).Joined();

  public static string Joined(this IEnumerable<string?>? items, string prefix)
    => items.Joined(s => prefix + s);

  internal static IEnumerable<string?> Bracket(this AstBase? item, string before, string after)
    => item is null
    ? Array.Empty<string?>()
    : item.GetFields().Prepend(before).Append(after);

  public static string? Camelize(this string? text)
    => text?.Length > 0
      ? char.ToLower(text[0]) + text[1..]
      : text;

  public static string Prefixed(this string? text, string prefix)
    => text?.Length > 0 ? prefix + text : "";

  public static string Suffixed(this string? text, string suffix)
    => text?.Length > 0 ? text + suffix : "";

  public static string Quoted(this string? text, string quote)
    => text?.Length > 0
    ? quote + text.Replace("\\", "\\\\").Replace(quote, "\\" + quote) + quote
    : "";
}
