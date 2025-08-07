using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;
using GqlPlus.Abstractions;
using GqlPlus.Structures;

namespace GqlPlus;

public static class GeneralHelpers
{
  public static T[] ArrayOf<T>(this IEnumerable<object>? items)
    => [.. items?.OfType<T>() ?? []];

  public static T[] ArrayJust<T>(this IEnumerable<T?>? items)
    => [.. items?.OfType<T>() ?? []];

  public static Dictionary<TKey, TValue> DictWith<TKey, TValue>(this TKey key, TValue value)
    where TKey : notnull
    => new() { [key] = value };

  public static string[]? FlagNames<TEnum>(this TEnum flagValue)
    where TEnum : Enum
  {
    Type type = typeof(TEnum);
    if (!type.GetCustomAttributes<FlagsAttribute>().Any()) {
      return null;
    }

    int flags = (int)(object)flagValue;
    List<string> result = [];

    foreach (object? value in Enum.GetValues(type)) {
      int flag = (int)value;
      if (flag.IsSingleFlag() && (flags & flag) == flag) {
        result.Add(Enum.GetName(type, flag));
      }
    }

    return [.. result];
  }

  public static string IfWhiteSpace(this string? text, string replacement = "")
    => string.IsNullOrWhiteSpace(text) ? replacement : text!;

  public static string Joined(this IEnumerable<string?>? items, string by = " ")
    => string.Join(by,
      items?.Where(i => !string.IsNullOrWhiteSpace(i))
      ?? []);

  public static string Joined<T>(this IEnumerable<T?>? items, Func<T?, string> mapping, string by = " ")
    => (items?.Select(mapping).Joined(by)).IfWhiteSpace();

  public static Map<TValue> MapWith<TValue>(this string key, TValue value)
    => new() { [key] = value };

  public static bool OrderedEqual<T>(this IEnumerable<T> left, IEnumerable<T> right, IComparer<T>? comparer = null)
    => left.OrderBy(l => l, comparer).SequenceEqual(right.OrderBy(r => r, comparer));

  public static string Prefixed(this string? text, string prefix)
    => text?.Length > 0 ? prefix + text : "";

  public static string Suffixed(this string? text, string suffix)
    => text?.Length > 0 ? text + suffix : "";

  [return: NotNull]
  public static T ThrowIfNull<T>([NotNull] this T? value, [CallerArgumentExpression(nameof(value))] string? expression = default)
  {
    if (value is null) {
      throw new ArgumentNullException(expression);
    }

    return value;
  }

  public static string TrueFalse(this bool value)
    => value ? "true" : "false";

  public static string TrueFalse(this bool? value)
    => value is null ? "" : value == true ? "true" : "false";

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

  public static string Show(this IGqlpAbbreviated? abbr)
  {
    if (abbr is null) {
      return "";
    }

    using StringWriter sw = new();
    int indent = 0;
    string[] begins = ["(", "{", "[", "<"];
    string[] ends = [")", "}", "]", ">"];
    foreach (string? field in abbr.GetFields()) {
      if (string.IsNullOrWhiteSpace(field)) {
        continue;
      }

      if (begins.Contains(field)) {
        Write(field!);
        indent++;
      } else if (ends.Contains(field)) {
        indent--;
        Write(field!);
      } else {
        Write(field!);
      }
    }

    return sw.ToString();

    void Write(string text)
    {
      for (int i = 0; i < indent; i++) {
        sw.Write("  ");
      }

      sw.WriteLine(text);
    }
  }

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
