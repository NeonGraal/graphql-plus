using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Merging;
using GqlPlus.Verifier.Parse;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification;

public partial class VerifySchemaTests(
    Parser<SchemaAst>.D parser,
    IVerify<SchemaAst> verifier,
    IMerge<SchemaAst> merger)
{
  [Theory]
  [ClassData(typeof(SchemaValidSchemas))]
  public void Verify_ValidSchemas(string schema)
    => Verify_Valid(s_schemaValidSchemas[schema]);

  [Theory]
  [ClassData(typeof(SchemaInvalidSchemas))]
  public async Task Verify_InvalidSchemas(string schema)
    => await Verify_Invalid(s_schemaInvalidSchemas[schema], schema);

  [Theory]
  [ClassData(typeof(SchemaValidMerges))]
  public void Verify_ValidMerges(string schema)
  {
    var input = s_schemaValidMerges[schema];
    if (input.StartsWith("object", StringComparison.Ordinal)) {
      using var scope = new AssertionScope();

      Verify_Valid(ReplaceObject(input, "input", "In"));
      Verify_Valid(ReplaceObject(input, "output", "Out"));
    } else {
      Verify_Valid(input);
    }
  }

  [Theory]
  [ClassData(typeof(SchemaValidObjects))]
  public void Verify_ValidObjects(string schema)
  {
    var input = s_schemaValidObjects[schema];
    if (input.StartsWith("object", StringComparison.Ordinal)) {
      using var scope = new AssertionScope();

      Verify_Valid(ReplaceObject(input, "input", "In"));
      Verify_Valid(ReplaceObject(input, "output", "Out"));
    } else {
      Verify_Valid(input);
    }
  }

  [Theory]
  [ClassData(typeof(SchemaInvalidObjects))]
  public async Task Verify_InvalidObjects(string schema)
  {
    var input = s_schemaInvalidObjects[schema];
    if (input.StartsWith("object", StringComparison.Ordinal)) {
      await WhenAll(
        Verify_Invalid(ReplaceObject(input, "input", "In"), "input-" + schema),
        Verify_Invalid(ReplaceObject(input, "output", "Out"), "output-" + schema));
    } else {
      await Verify_Invalid(input, schema);
    }
  }

  [Fact]
  public void CanMerge_Schemas()
  {
    var schemas = s_schemaValidObjects.Values
      .SelectMany(input => new[] {
        ReplaceObject(input, "input", "In"),
        ReplaceObject(input, "output", "Out"),
      })
      .Concat(s_schemaValidMerges.Values)
      .Concat(s_schemaValidSchemas.Values)
      .Select(input => Parse(input).Required())
      .ToArray();

    var result = merger.CanMerge(schemas);

    result.Should().BeTrue();
  }

  [Fact]
  public async Task Merge_Schemas()
  {
    var schemas = s_schemaValidObjects.Values
      .SelectMany(input => new[] {
        ReplaceObject(input, "input", "In"),
        ReplaceObject(input, "output", "Out"),
      })
      .Concat(s_schemaValidMerges.Values)
      .Concat(s_schemaValidSchemas.Values)
      .Select(input => Parse(input).Required())
      .ToArray();

    var result = merger.Merge(schemas);

    await Verify(result.Select(s => s.Render()));
  }

  [Theory]
  [ClassData(typeof(SchemaValidMerges))]
  public async Task Merge_Valid(string schema)
  {
    var input = s_schemaValidMerges[schema];
    if (input.StartsWith("object", StringComparison.Ordinal)) {
      await WhenAll(
        Verify_Merge(ReplaceObject(input, "input", "In"), "input-" + schema),
        Verify_Merge(ReplaceObject(input, "output", "Out"), "output-" + schema));
    } else {
      await Verify_Merge(input, schema);
    }
  }

  private static IEnumerable<object[]> SchemaKeys(Map<string> schemas)
    => schemas.Keys.Select(k => new object[] { k });

  private readonly Parser<SchemaAst>.L _parser = parser;

  private IResult<SchemaAst> Parse(string schema)
  {
    Tokenizer tokens = new(schema);
    return _parser.Parse(tokens, "Schema");
  }

  private static string ReplaceObject(string input, string objectReplace, string objReplace)
    => input
    .Replace("object", objectReplace)
    .Replace("Obj", objReplace);

  private void Verify_Valid(string input)
  {
    var parse = Parse(input);

    if (parse is IResultError<SchemaAst> error) {
      error.Message.Should().BeNull();
    }

    var result = new TokenMessages();

    verifier.Verify(parse.Required(), result);

    result.Should().BeNullOrEmpty();
  }

  private async Task Verify_Invalid(string input, string test)
  {
    var parse = Parse(input);

    var result = new TokenMessages();
    if (parse.IsOk()) {
      verifier.Verify(parse.Required(), result);
    } else {
      parse.IsError(result.Add);
    }

    result.Should().NotBeEmpty();

    var settings = new VerifySettings();
    settings.ScrubEmptyLines();
    settings.UseMethodName(test);

    await Verify(result.Select(m => m.Message), settings);
  }

  private async Task Verify_Merge(string input, string test)
  {
    var parse = Parse(input);

    var result = merger.Merge([parse.Required()]);

    var settings = new VerifySettings();
    settings.ScrubEmptyLines();
    settings.UseMethodName(test + "-merge");

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
