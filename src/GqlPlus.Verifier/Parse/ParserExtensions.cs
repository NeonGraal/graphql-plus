﻿using System.Runtime.CompilerServices;

namespace GqlPlus.Verifier.Parse;

public static class ParserExtensions
{
  public static T ThrowIfNull<T>([NotNull] this T? value, [CallerArgumentExpression(nameof(value))] string? expression = default)
  {
    ArgumentNullException.ThrowIfNull(value, expression);
    return value;
  }
}
