using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace GqlPlus;

public static class GeneralHelpers
{
  public static TResult[] ArrayOf<TResult>(this IEnumerable<object>? items)
    => [.. items?.OfType<TResult>() ?? []];

  public static string Joined(this IEnumerable<string?>? items, string by = " ")
    => string.Join(by,
      items?.Where(i => !string.IsNullOrWhiteSpace(i))
      ?? []);

  public static string Joined<T>(this IEnumerable<T?>? items, Func<T?, string> mapping, string by = " ")
    => items?.Select(mapping).Joined(by) ?? "";

  [return: NotNull]
  public static T ThrowIfNull<T>([NotNull] this T? value, [CallerArgumentExpression(nameof(value))] string? expression = default)
  {
    if (value is null) {
      throw new ArgumentNullException(expression);
    }

    return value;
  }

  public static bool OrderedEqual<T>(this IEnumerable<T> left, IEnumerable<T> right, IComparer<T>? comparer = null)
    => left.OrderBy(l => l, comparer).SequenceEqual(right.OrderBy(r => r, comparer));

  public static string Quoted(this string? text, string quote)
    => text?.Length > 0
    ? string.Concat(
      quote,
      text
        .Replace("\\", "\\\\")
        .Replace(quote, "\\" + quote),
      quote)
    : "";

  public static string Surround(
    this IEnumerable<string>? items,
    string before,
    string after,
    string by = " ")
   => before + items.Joined(by) + after;

  public static string Surround<T>(
    this IEnumerable<T>? items,
    string before,
    string after,
    Func<T?, string> formatter,
    string by = " ")
   => before + items.Joined(formatter, by) + after;
}
