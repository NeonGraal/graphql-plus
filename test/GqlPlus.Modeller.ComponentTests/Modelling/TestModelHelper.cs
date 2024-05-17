using System.Runtime.CompilerServices;

namespace GqlPlus.Modelling;

internal static class TestModelHelper
{
  private static readonly string[] s_separator = ["\r\n", "\r", "\n"];

  internal static string[] ToLines(this string value)
    => value.Split(s_separator, StringSplitOptions.RemoveEmptyEntries);

  internal static IEnumerable<string> Indent(this IEnumerable<string>? value)
    => value?.Select(s => "  " + s) ?? [];

  internal static string[] Tidy(this string[] value)
    => [.. value.Where(s => !string.IsNullOrWhiteSpace(s))];

  internal static string[] TypeRefFor<TKind>(this string? name, TKind kind, [CallerArgumentExpression(nameof(name))] string? label = null)
  {
    if (string.IsNullOrWhiteSpace(name)) {
      return [];
    }

    label = label?.Split('.').LastOrDefault()?.Camelize();

    string kindTag = typeof(TKind).TypeTag();
    return [$"{label}: !_TypeRef({kindTag})",
      "  name: " + name,
      $"  typeKind: !{kindTag} {kind}"];
  }

  internal static (string, TItem)[] ParentItems<TItem>(this IEnumerable<TItem> items, string parent)
    => [.. items.Select(i => (parent, i))];

  private static string Escape(string input, params string[] args)
    => args.Aggregate(input, (text, esc) => text.Replace(esc, "\\" + esc, StringComparison.Ordinal));

  internal static string YamlQuoted(this string? input)
    => input is null ? ""
    : input.Contains('\'', StringComparison.Ordinal)
      ? '"' + Escape(input, "\\", "\"") + '"'
      : "'" + input.Replace("'", "''", StringComparison.Ordinal) + "'";
}
