using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Parse;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification;

public class MergeSchemaBase(
    Parser<SchemaAst>.D parser
)
{
  private readonly Parser<SchemaAst>.L _parser = parser;

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
      ["Schemas"] = VerifySchemaValidSchemasData.Source.Values,
      ["Types"] = VerifySchemaValidTypesData.Source.Values,
    };
    public SchemaValidData()
    {
      foreach (var item in Values.Keys) {
        Add(item);
      }
    }
  }

  protected IResult<SchemaAst> Parse(string schema)
  {
    Tokenizer tokens = new(schema);
    return _parser.Parse(tokens, "Schema");
  }

  protected static readonly (string, string)[] s_replacements = [("dual", "Dual"), ("input", "InP"), ("output", "OutP")];

  protected static IEnumerable<string> ReplaceObjects(IEnumerable<string> inputs)
    => inputs.SelectMany(input => input.Contains("object ", StringComparison.Ordinal)
        ? s_replacements.Select(r => ReplaceObject(input, r.Item1, r.Item2))
        : [input]);

  protected static string ReplaceObject(string input, string objectReplace, string objReplace)
    => input is null ? ""
    : input
      .Replace("object", objectReplace, StringComparison.InvariantCulture)
      .Replace("Obj", objReplace, StringComparison.InvariantCulture);

  protected static async Task WhenAll(params Task[] tasks)
  {
    using var scope = new AssertionScope();

    var all = Task.WhenAll(tasks);

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
