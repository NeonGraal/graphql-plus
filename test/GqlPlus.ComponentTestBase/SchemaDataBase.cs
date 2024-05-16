using GqlPlus.Abstractions.Schema;
using GqlPlus.Parsing;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus;

#pragma warning disable CA1034 // Nested types should not be visible
public class SchemaDataBase(
    Parser<IGqlpSchema>.D parser
)
{
  private readonly Parser<IGqlpSchema>.L _parser = parser;

  protected static bool IsObjectInput(string input)
    => input is not null && input.Contains("object ", StringComparison.Ordinal);

  protected static IEnumerable<string> ValidObjects
    => ReplaceValues(SchemaValidObjectsData.Source.Values);

  protected static IEnumerable<string> ValidMerges
    => ReplaceValues(SchemaValidMergesData.Source.Values);

  public static readonly (string, string)[] Replacements = [("dual", "Dual"), ("input", "Inp"), ("output", "Outp")];

  protected static IEnumerable<string> ReplaceKeys(IDictionary<string, string> inputs)
    => inputs
      .ThrowIfNull()
      .Keys
      .SelectMany(k => IsObjectInput(inputs[k])
        ? Replacements.Select(r => r.Item1 + "-" + k)
        : [k])
      .Order();

  protected static IEnumerable<string> ReplaceValues(IEnumerable<string> inputs)
    => inputs
      .ThrowIfNull()
      .SelectMany(input => input.Contains("object ", StringComparison.Ordinal)
        ? Replacements.Select(r => ReplaceValue(input, r.Item1, r.Item2))
        : [input]);

  protected static string ReplaceValue(string input, string objectReplace, string objReplace)
    => input is null ? ""
    : input
      .Replace("object", objectReplace, StringComparison.InvariantCulture)
      .Replace("Obj", objReplace, StringComparison.InvariantCulture);

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

  public class SchemaValidData
    : TheoryData<string>
  {
    public static readonly Dictionary<string, IEnumerable<string>> Values = new() {
      ["Objects"] = ValidObjects,
      ["Merges"] = ValidMerges,
      ["Globals"] = SchemaValidGlobalsData.Source.Values,
      ["Simple"] = SchemaValidSimpleData.Source.Values,
    };
    public SchemaValidData()
    {
      foreach (string item in Values.Keys) {
        Add(item);
      }
    }
  }

  protected IResult<IGqlpSchema> Parse(string schema)
  {
    Tokenizer tokens = new(schema);
    return _parser.Parse(tokens, "Schema");
  }

  protected VerifySettings SchemaSettings(string category, string test)
  {
    VerifySettings settings = new();
    settings.ScrubEmptyLines();
    settings.UseDirectory($"Schema{category}Tests");
    settings.UseFileName(test);

    return settings;
  }
}
