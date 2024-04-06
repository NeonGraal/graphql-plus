using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Merging;
using GqlPlus.Verifier.Parse;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification;

public class MergeSchemaTests(
    Parser<SchemaAst>.D parser,
    IMerge<SchemaAst> merger)
{
  [Fact]
  public void CanMerge_AllSchemas()
  {
    var schemas = SchemaValidData.Values
      .SelectMany(kv => kv.Value)
      .Select(input => Parse(input).Required())
      .ToArray();

    var result = merger.CanMerge(schemas);

    result.Should().BeEmpty();
  }

  [Theory]
  [ClassData(typeof(SchemaValidData))]
  public void CanMerge_Schemas(string group)
  {
    var schemas = SchemaValidData.Values[group]
      .Select(input => Parse(input).Required())
      .ToArray();

    var result = merger.CanMerge(schemas);

    result.Should().BeEmpty();
  }

  [Theory]
  [ClassData(typeof(VerifySchemaValidMergesData))]
  public void CanMerge_Valid(string merge)
  {
    var input = VerifySchemaValidMergesData.Source[merge];
    var schemas = ReplaceObjects([input])
      .Select(input => Parse(input).Required());

    var result = merger.CanMerge(schemas);

    result.Should().BeEmpty();
  }

  [Fact]
  public async Task Merge_AllSchemas()
  {
    var schemas = SchemaValidData.Values
      .SelectMany(kv => kv.Value)
      .Select(input => Parse(input).Required())
      .ToArray();

    var result = merger.Merge(schemas);

    var settings = new VerifySettings();
    settings.ScrubEmptyLines();
    await Verify(result.Select(s => s.Render()), settings);
  }

  [Theory]
  [ClassData(typeof(SchemaValidData))]
  public async Task Merge_Schemas(string group)
  {
    var schemas = SchemaValidData.Values[group]
      .Select(input => Parse(input).Required())
      .ToArray();

    var result = merger.Merge(schemas);

    var settings = new VerifySettings();
    settings.ScrubEmptyLines();
    settings.UseTextForParameters(group);

    await Verify(result.Select(s => s.Render()), settings);
  }

  [Theory]
  [ClassData(typeof(VerifySchemaValidMergesData))]
  public async Task Merge_Valid(string merge)
  {
    var input = VerifySchemaValidMergesData.Source[merge];
    if (input.Contains("object", StringComparison.Ordinal)) {
      await WhenAll(s_replacements
        .Select(r => Verify_Merge(ReplaceObject(input, r.Item1, r.Item2), r.Item1 + "-" + merge))
        .ToArray());
    } else {
      await Verify_Merge(input, merge);
    }
  }

  private readonly Parser<SchemaAst>.L _parser = parser;

  private static IEnumerable<string> ValidObjects
    => ReplaceObjects(VerifySchemaValidObjectsData.Source.Values);

  private static IEnumerable<string> ValidMerges
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

  private IResult<SchemaAst> Parse(string schema)
  {
    Tokenizer tokens = new(schema);
    return _parser.Parse(tokens, "Schema");
  }

  private static readonly (string, string)[] s_replacements = [("dual", "Dual"), ("input", "InP"), ("output", "OutP")];

  private static IEnumerable<string> ReplaceObjects(IEnumerable<string> inputs)
    => inputs.SelectMany(input => input.Contains("object ", StringComparison.Ordinal)
        ? s_replacements.Select(r => ReplaceObject(input, r.Item1, r.Item2))
        : [input]);

  private static string ReplaceObject(string input, string objectReplace, string objReplace)
    => input
    .Replace("object", objectReplace, StringComparison.InvariantCulture)
    .Replace("Obj", objReplace, StringComparison.InvariantCulture);

  private async Task Verify_Merge(string input, string test)
  {
    var parse = Parse(input);

    var result = merger.Merge([parse.Required()]);

    var settings = new VerifySettings();
    settings.ScrubEmptyLines();
    settings.UseDirectory(nameof(MergeSchemaTests));
    settings.UseTypeName("Merge");
    settings.UseMethodName(test);

    await Verify(result.Select(s => s.Render()), settings);
  }

  private static async Task WhenAll(params Task[] tasks)
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
