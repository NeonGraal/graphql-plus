using GqlPlus.Abstractions;

namespace GqlPlus;

public class SampleChecks
{
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
      if (includeVerify) {
        OrderedEmpty(errors.Select(e => e.Message), $"'{path}{file}.verify-errors' should contain");
      }

      return;
    }

    string[] missing = [.. expected.Where(e
        => !errors.Any(error
          => error.Message.Contains(e, StringComparison.InvariantCulture))
      )];

    string[] extra = [.. errors.Where(error
        => !expected.Any(e
          => error.Message.Contains(e, StringComparison.InvariantCulture))
      ).Select(error => error.Message)];

    errors.ShouldSatisfyAllConditions(
      () => OrderedEmpty(extra, $"Extra errors in '{path}{file}.verify-errors'"),
      () => OrderedEmpty(missing, $"Missing errors in '{path}{file}.verify-errors'"));

    static void OrderedEmpty(IEnumerable<string> messages, string message)
    {
      string empty = string.Join(Environment.NewLine, messages.Distinct().Order());
      empty.ShouldBeEmpty(message);
    }
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
