using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging;
using GqlPlus.Parsing;
using GqlPlus.Result;
using GqlPlus.Token;

using Grpc.Core;

namespace GqlPlus;

public class SchemaDataBase(
    Parser<IGqlpSchema>.D parser
) : SampleChecks
{
  private readonly Parser<IGqlpSchema>.L _parser = parser;

  protected static bool IsObjectInput(string input)
    => input is not null && input.Contains("object ", StringComparison.Ordinal);

  public static readonly (string, string)[] Replacements = [("dual", "Dual"), ("input", "Inp"), ("output", "Outp")];

  public static readonly Map<string> Abbreviations = new() { ["Generic"] = "Gen" };

  protected static IEnumerable<string> ReplaceKeys(IDictionary<string, string> inputs)
    => inputs
      .ThrowIfNull()
      .Keys
      .SelectMany(k => IsObjectInput(inputs[k])
        ? Replacements.Select(r => r.Item1 + "-" + k)
        : [k])
      .Order();

  protected async static Task<IEnumerable<string>> ReplaceSchemaKeys(string group)
  {
    IEnumerable<Task<(string input, string file)>> tasks = SchemaValidData
      .Files[group]
      .Select(async file => (input: await ReadSchema(file, "Valid" + group), file));

    return (await Task.WhenAll(tasks))
        .SelectMany(p => IsObjectInput(p.input)
          ? Replacements.Select(r => r.Item1 + "-" + p.file)
          : [p.file])
        .Order();
  }

  protected static IEnumerable<string> ReplaceValues(IDictionary<string, string> inputs)
    => inputs
      .ThrowIfNull()
      .SelectMany(kv => ReplaceValue(kv.Value, kv.Key));

  protected static IEnumerable<string> ReplaceValue(string input, string testName)
    => input
      .ThrowIfNull()
      .Contains("object ", StringComparison.Ordinal)
        ? Replacements.Select(r => ReplaceInput(input, testName, r.Item1, r.Item2))
        : [input];

  protected static void ReplaceAction(string input, string testName, Action<string, string> action)
  {
    ArgumentNullException.ThrowIfNull(action);

    if (IsObjectInput(input)) {
      foreach ((string label, string abbr) in Replacements) {
        action(ReplaceInput(input, abbr, label, abbr), label + "-" + testName);
      }
    } else {
      action(input, testName);
    }
  }

  protected static async Task ReplaceActionAsync(string input, string testName, Func<string, string, Task> action)
  {
    ArgumentNullException.ThrowIfNull(action);

    if (IsObjectInput(input)) {
      await WhenAll(Replacements
        .Select(r => action(ReplaceInput(input, testName, r.Item1, r.Item2), r.Item1 + "-" + testName))
        .ToArray());
    } else {
      await action(input, testName);
    }
  }

  protected static async Task ReplaceFile(string testDirectory, string testName, Action<string, string> action)
  {
    ArgumentNullException.ThrowIfNull(action);
    string input = await ReadSchema(testName, testDirectory);

    if (IsObjectInput(input)) {
      using AssertionScope scope = new();
      foreach ((string label, string abbr) in Replacements) {
        action(ReplaceInput(input, abbr, label, abbr), label + "-" + testName);
      }
    } else {
      action(input, testName);
    }
  }

  protected static async Task ReplaceFileAsync(string testDirectory, string testName, Func<string, string, Task> action)
  {
    ArgumentNullException.ThrowIfNull(action);
    string input = await ReadSchema(testName, testDirectory);

    if (IsObjectInput(input)) {
      await WhenAll(Replacements
        .Select(r => action(ReplaceInput(input, testName, r.Item1, r.Item2), r.Item1 + "-" + testName))
        .ToArray());
    } else {
      await action(input, testName);
    }
  }

  protected static string ReplaceInput(string input, string testName, string objectReplace, string objReplace)
    => input is null ? ""
    : input
      .Replace("object", objectReplace, StringComparison.InvariantCulture)
      .Replace("Obj", objReplace, StringComparison.InvariantCulture)
      .Replace("Name", PascalCase(testName), StringComparison.InvariantCulture);

  private static string PascalCase(string input)
    => input is null ? ""
    : string.Concat(input
      .Split('-')
      .Select(s => s.ToUpperInvariant()[0] + s[1..])
      .Select(s => Abbreviations.TryGetValue(s, out string? abbr) ? abbr : s)
      );

  protected static async Task WhenAll(params Task[] tasks)
  {
    using AssertionScope scope = new();

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

  protected async Task<IEnumerable<string>> SchemaValidAll()
  {
    IEnumerable<Task<IEnumerable<string>>> tasks = SchemaValidData
      .Files
      .SelectMany(kv => kv.Value.Select(file => (file, dir: "Valid" + kv.Key)))
      .Select(async p => ReplaceValue(await ReadSchema(p.file, p.dir), p.file));

    return (await Task.WhenAll(tasks))
      .SelectMany(i => i);
  }

  protected async Task<IEnumerable<string>> SchemaValidGroup(string group)
  {
    IEnumerable<Task<IEnumerable<string>>> tasks = SchemaValidData
      .Files[group]
      .Select(async file => ReplaceValue(await ReadSchema(file, "Valid" + group), file));

    return (await Task.WhenAll(tasks))
      .SelectMany(i => i);
  }

  protected IResult<IGqlpSchema> Parse(string schema)
  {
    Tokenizer tokens = new(schema);
    return _parser.Parse(tokens, "Schema");
  }
}
