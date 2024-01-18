using System.Runtime.CompilerServices;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

internal static class ModelHelper
{
  private static readonly string[] s_separator = ["\r\n", "\r", "\n"];

  internal static string[] ToLines(this string value)
    => value.Split(s_separator, StringSplitOptions.RemoveEmptyEntries);

  internal static string[] Tidy(this string[] value)
    => [.. value.Where(s => !string.IsNullOrWhiteSpace(s))];

  internal static string[] TypeRefFor<TKind>(this string name, TKind Kind, [CallerArgumentExpression(nameof(name))] string? label = null)
  {
    var kindTag = typeof(TKind).TypeTag();
    return [$"{label}: !_TypeRef({kindTag})",
      $"  kind: !{kindTag} {Kind}",
      "  name: " + name];
  }
}
