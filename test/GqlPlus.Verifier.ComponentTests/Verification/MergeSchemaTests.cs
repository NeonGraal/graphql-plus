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
  public void CanMerge_Schemas()
  {
    var schemas = AllValid
      .Select(input => Parse(input).Required())
      .ToArray();

    var result = merger.CanMerge(schemas);

    result.Should().BeTrue();
  }

  [Fact]
  public async Task Merge_Schemas()
  {
    var schemas = AllValid
      .Select(input => Parse(input).Required())
      .ToArray();

    var result = merger.Merge(schemas);

    await Verify(result.Select(s => s.Render()));
  }

  [Theory]
  [ClassData(typeof(VerifySchemaValidMergesData))]
  public async Task Merge_Valid(string merge)
  {
    var input = VerifySchemaValidMergesData.Source[merge];
    if (input.StartsWith("object", StringComparison.Ordinal)) {
      await WhenAll(
        Verify_Merge(ReplaceObject(input, "dual", "Dual"), "dual-" + merge),
        Verify_Merge(ReplaceObject(input, "input", "In"), "input-" + merge),
        Verify_Merge(ReplaceObject(input, "output", "Out"), "output-" + merge));
    } else {
      await Verify_Merge(input, merge);
    }
  }

  private readonly Parser<SchemaAst>.L _parser = parser;
  private static IEnumerable<string> AllValid
    => VerifySchemaValidObjectsData.Source.Values
      .SelectMany(input => new[] {
        ReplaceObject(input, "dual", "Dual"),
        ReplaceObject(input, "input", "In"),
        ReplaceObject(input, "output", "Out"),
      })
      .Concat(VerifySchemaValidMergesData.Source.Values)
      .Concat(VerifySchemaValidSchemasData.Source.Values)
      .Concat(VerifySchemaValidTypesData.Source.Values);


  private IResult<SchemaAst> Parse(string schema)
  {
    Tokenizer tokens = new(schema);
    return _parser.Parse(tokens, "Schema");
  }

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
