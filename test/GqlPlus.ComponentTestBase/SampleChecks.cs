using System.Globalization;
using GqlPlus.Abstractions;

namespace GqlPlus;

public class SampleChecks
{
  protected static readonly Map<string> Abbreviations = new() {
    ["Backslash"] = "Bcks",
    ["Between"] = "Btwn",
    ["Boolean"] = "Bool",
    ["Category"] = "Ctgr",
    ["Complex"] = "Cmpl",
    ["Descrs"] = "Dscrs",
    ["Directive"] = "Drct",
    ["Domain"] = "Dmn",
    ["Double"] = "Dbl",
    ["Generic"] = "Gnrc",
    ["Input"] = "Inp",
    ["Number"] = "Nmbr",
    ["Object"] = "Obj",
    ["Option"] = "Optn",
    ["Optional"] = "Optl",
    ["Output"] = "Outp",
    ["Parent"] = "Prnt",
    ["Schema"] = "Schm",
    ["Setting"] = "Stng",
    ["Simple"] = "Smpl",
    ["Single"] = "Sngl",
    ["String"] = "Str",
    ["Unique"] = "Unq",
  };

  private static readonly TextInfo s_textInfo = CultureInfo.InvariantCulture.TextInfo;

  protected static string[] TitleWords(string? input)
    => input is null ? []
    : [.. s_textInfo.ToTitleCase(input).Split('-')];

  protected async Task CheckErrors(string category, string directory, string file, ITokenMessages errors, bool includeVerify = false)
  {
    List<string> suffixes = ["", "parse-"];
    if (includeVerify) {
      suffixes.Add("verify-");
    }

    string path = $"Samples/{category}/";
    if (!string.IsNullOrWhiteSpace(directory)) {
      path += directory + "/";
    }

    List<string> expected = [];
    foreach (string suffix in suffixes) {
      string errorsFile = $"{path}/{file}.{suffix}errors";

      if (File.Exists(errorsFile)) {
        expected.AddRange(await File.ReadAllLinesAsync(errorsFile));
      }
    }

    if (expected.Count == 0) {
      if (includeVerify && errors?.Count > 0 && AttributeReader.TryGetProjectDirectory(out string? project)) {
        IOrderedEnumerable<string> errorLines = errors.Select(e => e.ToString() ?? "").Distinct().Order();
        await File.WriteAllLinesAsync($"{project}/{path}/{file}.verify+errors", errorLines);
      }

      return;
    }

    string[] missing = [.. expected.Where(e
        => !errors.Any(error
          => error.Message.Contains(e, StringComparison.InvariantCulture)))
      .Distinct()];

    string[] extra = [.. errors.Where(error
        => !expected.Any(e
          => error.Message.Contains(e, StringComparison.InvariantCulture)))
      .Select(error => error.Message)
      .Distinct()];

    errors.ShouldSatisfyAllConditions(
      () => missing.ShouldBeEmpty("Missing errors"),
      () => extra.ShouldBeEmpty("Extra errors"));
  }

  protected VerifySettings CustomSettings(string category, string group, string file, string section = "", bool scrubEmptyLines = true)
  {
    VerifySettings settings = new();
    settings.UseFileName(file);
    settings.UseDirectory(new string[] { $"{category}{group}Tests", section }.Joined("/"));
    if (scrubEmptyLines) {
      settings.ScrubEmptyLines();
    }


    return settings.CheckAutoVerify();
  }

  protected static async Task<string> ReadFile(string file, string extn, params string[] dirs)
    => await File.ReadAllTextAsync(Path.Join(["Samples", .. dirs, file + "." + extn]));

  protected static async Task<string> ReadSchema(string schema, params string[] dirs)
    => await ReadFile(schema, "graphql+", ["Schema", .. dirs]);

  protected static bool IsObjectInput(string input)
    => input is not null && input.Contains("object ", StringComparison.Ordinal);

  private static string PascalCase(string? input)
    => string.Concat(TitleWords(input).Select(s => Abbreviations.TryGetValue(s, out string? abbr) ? abbr : s));

  private static string CamelCase(string? input)
    => string.Concat(TitleWords(input)
      .Select(s => Abbreviations.TryGetValue(s, out string? abbr) ? abbr : s)
      .Select((s, i) => i > 0 ? s : s.ToLowerInvariant()));

  public static readonly (string, string)[] Replacements = [("dual", "Dual"), ("input", "Inp"), ("output", "Outp")];

  protected static string ReplaceName(string? input, string testName)
    => input is null ? ""
    : input
      .Replace("name", CamelCase(testName), StringComparison.InvariantCulture)
      .Replace("Name", PascalCase(testName), StringComparison.InvariantCulture);

  protected static string ReplaceObject(string? input, string testName, string objectReplace, string objReplace)
    => input is null ? ""
    : input
      .Replace("object", objectReplace, StringComparison.InvariantCulture)
      .Replace("Obj", objReplace, StringComparison.InvariantCulture)
      .Replace("name", CamelCase(testName), StringComparison.InvariantCulture)
      .Replace("Name", PascalCase(testName), StringComparison.InvariantCulture);

  protected static IEnumerable<string> ReplaceValue(string input, string testName)
    => input
      .ThrowIfNull()
      .Contains("object ", StringComparison.Ordinal)
        ? Replacements.Select(r => ReplaceObject(input, testName, r.Item1, r.Item2))
        : [ReplaceName(input, testName)];

  protected static async Task ReplaceFile(string testDirectory, string testName, Action<string, string, string> action)
  {
    ArgumentNullException.ThrowIfNull(action);
    string input = await ReadSchema(testName, testDirectory);

    if (IsObjectInput(input)) {
      action.ShouldSatisfyAllConditions(
        () => {
          foreach ((string label, string abbr) in Replacements) {
            action(ReplaceObject(input, abbr, label, abbr), testDirectory, testName + "+" + label);
          }
        });
    } else {
      action(ReplaceName(input, testName), testDirectory, testName);
    }
  }

  protected static async Task ReplaceFileAsync(string testDirectory, string testName, Func<string, string, string, Task> action)
  {
    ArgumentNullException.ThrowIfNull(action);
    string input = await ReadSchema(testName, testDirectory);

    if (IsObjectInput(input)) {
      await WhenAll([.. Replacements
        .Select(r => action(ReplaceObject(input, testName, r.Item1, r.Item2), testDirectory, testName + "+" + r.Item1))]);
    } else {
      await action(ReplaceName(input, testName), testDirectory, testName);
    }
  }

  protected async Task<IEnumerable<string>> SchemaValidDataAll()
  {
    IEnumerable<Task<IEnumerable<string>>> tasks = SchemaValidData
      .Files
      .SelectMany(kv => kv.Value.Select(file => (file, dir: kv.Key)))
      .Select(async p => ReplaceValue(await ReadSchema(p.file, p.dir), p.file));

    return (await Task.WhenAll(tasks))
      .SelectMany(i => i);
  }

  protected async Task<IEnumerable<string>> SchemaValidDataGroup(string group)
  {
    IEnumerable<Task<IEnumerable<string>>> tasks = SchemaValidData
      .Files[group]
      .Select(async file => ReplaceValue(await ReadSchema(file, group), file));

    return (await Task.WhenAll(tasks))
      .SelectMany(i => i);
  }

  protected static async Task<IEnumerable<string>> ReplaceSchemaKeys(string group)
  {
    IEnumerable<Task<(string input, string file)>> tasks = SchemaValidData
      .Files[group]
      .Select(async file => (input: await ReadSchema(file, group), file));

    return (await Task.WhenAll(tasks))
        .SelectMany(p => IsObjectInput(p.input)
          ? Replacements.Select(r => p.file + "+" + r.Item1)
          : [p.file])
        .Order();
  }

  protected static async Task WhenAll(params Task[] tasks)
  {
    Task all = Task.WhenAll(tasks);

    try {
      await all;
    } catch (Exception) {
      if (all.Exception is not null) {
        throw all.Exception;
      }

      throw;
    }
  }
}
