using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace GqlPlus.Parsing;

public static class ParserExtensions
{
  [return: NotNull]
  public static T ThrowIfNull<T>([NotNull] this T? value, [CallerArgumentExpression(nameof(value))] string? expression = default)
  {
    ArgumentNullException.ThrowIfNull(value, expression);
    return value;
  }
}
