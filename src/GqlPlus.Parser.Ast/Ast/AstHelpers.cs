namespace GqlPlus.Ast;

public static class AstHelpers
{
  public static IEnumerable<string?> Bracket(this IAstAbbreviated? item, string before, string after)
    => item?.GetFields().Prepend(before).Append(after) ?? [];

  public static string Prefixed(this IAstAbbreviated? ast, string prefix)
    => ast is null ? "" : $"{prefix}{ast}";

  public static string Show(this IAstAbbreviated? abbr)
  {
    if (abbr is null) {
      return "";
    }

    using StringWriter sw = new();
    int indent = 0;
    string[] begins = ["(", "{", "[", "<"];
    string[] ends = [")", "}", "]", ">"];
    foreach (string? field in abbr.GetFields()) {
      if (string.IsNullOrWhiteSpace(field)) {
        continue;
      }

      if (begins.Contains(field)) {
        Write(field!);
        indent++;
      } else if (ends.Contains(field)) {
        indent--;
        Write(field!);
      } else {
        Write(field!);
      }
    }

    return sw.ToString();

    void Write(string text)
    {
      for (int i = 0; i < indent; i++) {
        sw.Write("  ");
      }

      sw.WriteLine(text);
    }
  }
}

public static class AstEnumerableHelpers
{
  private static IEnumerable<string?>? AsFields<T>(IEnumerable<T>? items)
    => items?.Any(i => i is IAstAbbreviated) == true
    ? items.OfType<IAstAbbreviated>().SelectMany(i => i.GetFields())
    : items?.Any() == true
      ? items.Select(i => $"{i}")
      : null;

  public static IEnumerable<string?> Bracket<T>(
    this IEnumerable<T>? items,
    string before = "",
    string after = "",
    bool sort = false)
  {
    IEnumerable<string?>? result = AsFields(items);

    if (sort) {
      result = result?.OrderBy(t => t);
    }

    return result
        ?.Prepend(before)
        ?.Append(after)
        ?? [];
  }
}
