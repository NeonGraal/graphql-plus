using System.Text.RegularExpressions;

namespace GqlPlus.Models;

internal static class NameFilter
{
  internal static bool Matches(string pattern, string name)
  {
    // '.' matches any single character, '*' matches zero or more characters.
    // Build a regex: escape all regex special chars first,
    // then un-escape '.' (should stay as '.') and replace '*' (was '\*') with '.*'.
    string escaped = Regex.Escape(pattern)
      .Replace("\\.", ".")
      .Replace("\\*", ".*");

    return Regex.IsMatch(name, "^" + escaped + "$");
  }
}
