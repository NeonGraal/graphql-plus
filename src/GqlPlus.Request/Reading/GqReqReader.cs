namespace GqlPlus.Reading;

public static class GqReqReader
{
  private static readonly char[] s_separator = ['='];

  public static GqReqInput Read(string input)
  {
    if (input is null) {
      throw new ArgumentNullException(nameof(input));
    }

    string[] lines = input.Split(["\r\n", "\n"], StringSplitOptions.RemoveEmptyEntries);

    if (lines.Length == 0) {
      return new GqReqInput(null, null, "", []);
    }

    if (IsListInput(lines[0])) {
      return ParseListLines(lines);
    }

    if (lines[0].IndexOf('=') < 0) {
      return new GqReqInput(null, null, input.Trim(), []);
    }

    return ParseKeyValueLines(lines);
  }

  private static bool IsListInput(string line)
  {
    string trimmed = line.TrimStart();
    return trimmed == "-" || trimmed.StartsWith("- ", StringComparison.Ordinal);
  }

  private static GqReqInput ParseListLines(string[] lines)
  {
    List<string> values = [];

    foreach (string line in lines) {
      string item = line.TrimStart();

      if (item == "-") {
        values.Add("");
      } else if (item.StartsWith("- ", StringComparison.Ordinal)) {
        values.Add(item[2..].Trim());
      } else {
        return new GqReqInput(null, null, string.Join(Environment.NewLine, lines).Trim(), []);
      }
    }

    return new GqReqInput(null, null, values[0], []) {
      PositionalParameters = values.Skip(1).ToArray(),
    };
  }

  private static GqReqInput ParseKeyValueLines(string[] lines)
  {
    string? category = null;
    string? operation = null;
    string? definition = null;
    List<(string Path, string Value)> parameters = [];

    foreach (string line in lines) {
      string[] parts = line.Split(s_separator, 2);

      if (parts.Length < 2) {
        continue;
      }

      string key = parts[0].Trim();
      string value = parts[1].Trim();

      if (key.StartsWith("parameters.", StringComparison.Ordinal)) {
        parameters.Add((key["parameters.".Length..], value));
      } else {
        switch (key) {
          case "category":
            category = value;
            break;
          case "operation":
            operation = value;
            break;
          case "definition":
            definition = value;
            break;
        }
      }
    }

    return new GqReqInput(category, operation, definition ?? "", parameters);
  }
}
