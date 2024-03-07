using System.Runtime.CompilerServices;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

internal static class TestModelHelper
{
  private static readonly string[] s_separator = ["\r\n", "\r", "\n"];

  internal static string[] ToLines(this string value)
    => value.Split(s_separator, StringSplitOptions.RemoveEmptyEntries);

  internal static string[] Tidy(this string[] value)
    => [.. value.Where(s => !string.IsNullOrWhiteSpace(s))];

  internal static string[] TypeRefFor<TKind>(this string? name, TKind kind, [CallerArgumentExpression(nameof(name))] string? label = null)
  {
    if (string.IsNullOrWhiteSpace(name)) {
      return [];
    }

    var kindTag = typeof(TKind).TypeTag();
    return [$"{label}: !_TypeRef({kindTag})",
      $"  kind: !{kindTag} {kind}",
      "  name: " + name];
  }
}
