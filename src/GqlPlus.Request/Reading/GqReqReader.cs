namespace GqlPlus.Request.Reading;

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

    bool hasKeyValueFormat = lines[0].IndexOf('=') >= 0;

    if (!hasKeyValueFormat) {
      return new GqReqInput(null, null, input.Trim(), []);
    }

    return ParseKeyValueLines(lines);
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
