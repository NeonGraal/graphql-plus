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
    ["Constraint"] = "Cnst",
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
    ["Unused"] = "Unsd",
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

  protected VerifySettings CustomSettings(string category, string group, string file)
  {
    VerifySettings settings = new();
    settings.ScrubEmptyLines();
    settings.UseDirectory($"{category}{group}Tests");
    settings.UseFileName(file);

    return settings.CheckAutoVerify();
  }

  protected static async Task<string> ReadFile(string file, string extn, params string[] dirs)
    => await File.ReadAllTextAsync(Path.Join(["Samples", .. dirs, file + "." + extn]));

  protected static async Task<string> ReadSchema(string schema, params string[] dirs)
    => await ReadFile(schema, "graphql+", ["Schema", .. dirs]);
}
