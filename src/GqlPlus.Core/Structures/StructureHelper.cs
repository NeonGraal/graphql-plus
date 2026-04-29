using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace GqlPlus.Structures;

public static class StructureHelper
{

  public static bool BothValued<T>([NotNullWhen(true)] this T? left, [NotNullWhen(true)] T? right)
    => left is not null && right is not null;

  public static readonly Regex IdentifierRegex = new(@"^[\w_][\w\d_]*$");

  public static bool IsIdentifier(this string? text)
  {
    if (string.IsNullOrEmpty(text)) {
      return false;
    }

    return IdentifierRegex.IsMatch(text);
  }
  public static bool IsSingleFlag(this int flag)
  {
    while (flag > 0) {
      bool rem = (flag & 1) > 0;
      flag >>= 1;
      if (rem) {
        return flag == 0;
      }
    }

    return false;
  }
}
