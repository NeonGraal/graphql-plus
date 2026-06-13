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

  internal static bool Matches(string[] patterns, string name)
  {
    foreach (string pattern in patterns) {
      if (Matches(pattern, name)) {
        return true;
      }
    }

    return false;
  }

  internal static bool MatchesAny(string[] patterns, string[] names)
  {
    foreach (string name in names) {
      if (Matches(patterns, name)) {
        return true;
      }
    }

    return false;
  }
}
