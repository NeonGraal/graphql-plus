using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace GqlPlus;

public static class StringHelpers
{
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

  public static string IfWhiteSpace(this string? text, string replacement = "")
    => string.IsNullOrWhiteSpace(text) ? replacement : text!;

  public static Map<TValue> MapWith<TValue>(this string key, TValue value)
    => new() { [key] = value };

  public static bool NullEqual(this string? left, string? right)
    => string.IsNullOrEmpty(left) && string.IsNullOrEmpty(right)
    || !string.IsNullOrEmpty(left) && !string.IsNullOrEmpty(right) && left!.Equals(right, StringComparison.Ordinal);

  public static string Prefixed(this string? text, string prefix)
    => text?.Length > 0 ? prefix + text : "";

  public static string Quoted(this string? text, char quote)
    => text.Quoted(quote.ToString());

  public static string Quoted(this string? text, string quote)
    => text?.Length > 0
    ? string.Concat(
      quote,
      text
        .Replace("\\", "\\\\")
        .Replace(quote, "\\" + quote),
      quote)
    : "";

  public static string Suffixed(this string? text, string suffix)
    => text?.Length > 0 ? text + suffix : "";
}
