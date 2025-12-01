namespace GqlPlus.Convert;

public static class ConvertTestsHelpers
{
  public static string[] PrefixFirst(this string[] lines, string prefix, string indent = "")
    => lines is null ? [] : [prefix + lines[0], .. lines.Skip(1).Indent(indent)];

  public static string[] SuffixLast(this string[] lines, string suffix)
    => lines is null ? [] : [.. lines.Take(lines.Length - 1), lines.Last() + suffix];

  public static IEnumerable<string> Indent(this IEnumerable<string> lines, string indent = "  ")
    => string.IsNullOrEmpty(indent) ? lines : lines.Select(l => indent + l);

  public static string[][] Indent(this string[][] lines, string indent = "  ")
    => string.IsNullOrEmpty(indent) ? lines : [.. lines.Select(l => l.Indent(indent).ToArray())];
}
