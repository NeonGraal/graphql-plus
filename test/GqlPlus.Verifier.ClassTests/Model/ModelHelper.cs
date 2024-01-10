namespace GqlPlus.Verifier.Model;

internal static class ModelHelper
{
  private static readonly string[] s_separator = ["\r\n", "\r", "\n"];

  internal static string[] ToLines(this string value)
    => value.Split(s_separator, StringSplitOptions.RemoveEmptyEntries);

  internal static string[] Tidy(this string[] value)
    => [.. value.Where(s => !string.IsNullOrWhiteSpace(s))];
}
