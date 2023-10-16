namespace GqlPlus.Verifier.Ast;

public static class AstExtensions
{
  public static bool NullEqual<T>(this T? left, T? right)
    where T : IEquatable<T>
    => left is null && right is null
    || left is not null && left.Equals(right);

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

  public static IEnumerable<string> Bracket<T>(
    this IEnumerable<T>? items,
    string before,
    string after)
   => items?.Any() == true
      ? items.Select(i => $"{i}").Prepend(before).Append(after)
      : Enumerable.Empty<string>();

  internal static IEnumerable<string?> Bracket<T>(
    string before,
    string after,
    T[]? items)
  => items?.Any(i => i is AstBase) == true
      ? items.OfType<AstBase>()
        .SelectMany(i => i.GetFields())
        .Prepend(before)
        .Append(after)
      : Enumerable.Empty<string>();

  public static string Prefixed(this string? text, string prefix)
    => text?.Length > 0 ? prefix + text : "";

  public static string Suffixed(this string? text, string suffix)
    => text?.Length > 0 ? text + suffix : "";
}
