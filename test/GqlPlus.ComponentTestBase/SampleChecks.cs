using GqlPlus.Abstractions;

using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace GqlPlus;

public class SampleChecks
{
  protected async Task CheckErrors(string category, string file, ITokenMessages errors, bool includeVerify = false)
  {
    List<string> suffixes = ["", "parse-"];
    if (includeVerify) {
      suffixes.Add("verify-");
    }

    List<string> expected = [];
    foreach (string suffix in suffixes) {
      string errorsFile = $"Samples/{category}/{file}.{suffix}errors";

      if (File.Exists(errorsFile)) {
        expected.AddRange(await File.ReadAllLinesAsync(errorsFile));
      }
    }

    if (expected.Count == 0) {
      return;
    }

    string[] missing = expected.Where(e
        => !errors.Any(error
          => error.Message.Contains(e, StringComparison.InvariantCulture))
      ).ToArray();

    ITokenMessage[] extra = errors.Where(error
        => !expected.Any(e
          => error.Message.Contains(e, StringComparison.InvariantCulture))
      ).ToArray();

    using AssertionScope scope = new();
    missing.Should().BeNullOrEmpty("Missing errors");
    extra.Should().BeNullOrEmpty("Extra errors");
  }

  protected VerifySettings CustomSettings(string category, string group, string file)
  {
    VerifySettings settings = new();
    settings.ScrubEmptyLines();
    settings.UseDirectory($"{category}{group}Tests");
    settings.UseFileName(file);

    return settings;
  }

  protected static async Task<string> ReadFile(string file, string extn, params string[] dirs)
    => await File.ReadAllTextAsync(Path.Join(["Samples", .. dirs, file + "." + extn]));

  protected static async Task<string> ReadSchema(string schema, params string[] dirs)
    => await ReadFile(schema, "graphql+", ["Schema", .. dirs]);
}
