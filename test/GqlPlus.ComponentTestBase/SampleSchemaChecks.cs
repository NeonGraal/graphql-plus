using GqlPlus.Abstractions.Schema;
using GqlPlus.Parsing;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus;

public class SampleSchemaChecks(
  Parser<IGqlpSchema>.D schemaParser
) : SampleChecks
{
  private readonly Parser<IGqlpSchema>.L _schemaParser = schemaParser;

  protected IResult<IGqlpSchema> Parse(string schema, string label)
  {
    Tokenizer tokens = new(schema);
    return _schemaParser.Parse(tokens, label);
  }

  protected async Task<IGqlpSchema> ParseSample(string label, string sample, params string[] dirs)
  {
    string schema = await ReadSchema(sample, dirs);
    return Parse(schema, label).Required();
  }

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
