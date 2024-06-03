using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace GqlPlus;

public static class GeneralHelpers
{
  [return: NotNull]
  public static T ThrowIfNull<T>([NotNull] this T? value, [CallerArgumentExpression(nameof(value))] string? expression = default)
  {
    ArgumentNullException.ThrowIfNull(value, expression);
    return value;
  }

  public static TResult[] ArrayOf<TResult>(this IEnumerable<object>? items)
    => [.. items?.OfType<TResult>() ?? []];
}
