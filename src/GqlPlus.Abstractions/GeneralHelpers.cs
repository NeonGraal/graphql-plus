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

  public static string Joined<T>(this IEnumerable<T?>? items, Func<T?, string> mapping)
    => (items?.Select(mapping)).Joined();

  [return: NotNull]
  public static T ThrowIfNull<T>([NotNull] this T? value, [CallerArgumentExpression(nameof(value))] string? expression = default)
  {
    if (value is null) {
      throw new ArgumentNullException(expression);
    }

    return value;
  }
}
