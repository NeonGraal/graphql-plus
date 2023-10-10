namespace GqlPlus.Verifier.Ast;

public static class AstExtensions
{
  public static bool NullEqual<T>(this T? left, T? right)
    where T : IEquatable<T>
    => left is null && right is null
    || left is not null && left.Equals(right);

  public static IEnumerable<string> Bracket<T>(
    this IEnumerable<T> enumerable,
    string before,
    string after,
    Func<T, string> formatter)
  {
    return enumerable.Any()
      ? enumerable.Select(formatter).Prepend(before).Append(after)
      : Array.Empty<string>();
  }

  public static string Prefixed(this string? text, string prefix)
    => text?.Length > 0 ? prefix + text : "";

  public static string Suffixed(this string? text, string suffix)
    => text?.Length > 0 ? text + suffix : "";
}
