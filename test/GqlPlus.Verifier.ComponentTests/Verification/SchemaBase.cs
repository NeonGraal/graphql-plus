using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema;
using GqlPlus.Parse;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Verification;

#pragma warning disable CA1034 // Nested types should not be visible
public class SchemaBase(
    Parser<IGqlpSchema>.D parser
)
{
  private readonly Parser<IGqlpSchema>.L _parser = parser;

  protected static bool IsObjectInput(string input)
    => input is not null && input.Contains("object ", StringComparison.Ordinal);

  protected static IEnumerable<string> ValidObjects
    => ReplaceObjects(VerifySchemaValidObjectsData.Source.Values);

  protected static IEnumerable<string> ValidMerges
    => ReplaceObjects(VerifySchemaValidMergesData.Source.Values);

  public class SchemaValidData
    : TheoryData<string>
  {
    public static readonly Dictionary<string, IEnumerable<string>> Values = new() {
      ["Objects"] = ValidObjects,
      ["Merges"] = ValidMerges,
      ["Globals"] = VerifySchemaValidGlobalsData.Source.Values,
      ["Simple"] = VerifySchemaValidSimpleData.Source.Values,
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

  public static readonly (string, string)[] Replacements = [("dual", "Dual"), ("input", "Inp"), ("output", "Outp")];

  protected static IEnumerable<string> ReplaceObjects(IEnumerable<string> inputs)
    => inputs.SelectMany(input => input.Contains("object ", StringComparison.Ordinal)
        ? Replacements.Select(r => ReplaceObject(input, r.Item1, r.Item2))
        : [input]);

  protected static string ReplaceObject(string input, string objectReplace, string objReplace)
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
}
