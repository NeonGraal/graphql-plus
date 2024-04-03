using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Merging;
using GqlPlus.Verifier.Parse;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification;

public class VerifySchemaTests(
    Parser<SchemaAst>.D parser,
    IVerify<SchemaAst> verifier)
{
  [Theory]
  [ClassData(typeof(VerifySchemaValidSchemasData))]
  public void Verify_ValidSchemas(string schema)
    => Verify_Valid(VerifySchemaValidSchemasData.Source[schema]);

  [Theory]
  [ClassData(typeof(VerifySchemaInvalidSchemasData))]
  public async Task Verify_InvalidSchemas(string schema)
    => await Verify_Invalid(VerifySchemaInvalidSchemasData.Source[schema], schema);

  [Theory]
  [ClassData(typeof(VerifySchemaValidMergesData))]
  public void Verify_ValidMerges(string schema)
  {
    var input = VerifySchemaValidMergesData.Source[schema];
    if (input.StartsWith("object", StringComparison.Ordinal)) {
      using var scope = new AssertionScope();

      Verify_Valid(ReplaceObject(input, "input", "In"));
      Verify_Valid(ReplaceObject(input, "output", "Out"));
    } else {
      Verify_Valid(input);
    }
  }

  [Theory]
  [ClassData(typeof(VerifySchemaValidTypesData))]
  public void Verify_ValidTypes(string type)
    => Verify_Valid(VerifySchemaValidTypesData.Source[type]);

  [Theory]
  [ClassData(typeof(VerifySchemaInvalidTypesData))]
  public async Task Verify_InvalidTypes(string type)
    => await Verify_Invalid(VerifySchemaInvalidTypesData.Source[type], type);

  [Theory]
  [ClassData(typeof(VerifySchemaValidObjectsData))]
  public void Verify_ValidObjects(string obj)
  {
    var input = VerifySchemaValidObjectsData.Source[obj];
    if (input.StartsWith("object", StringComparison.Ordinal)) {
      using var scope = new AssertionScope();

      Verify_Valid(ReplaceObject(input, "dual", "Dual"));
      Verify_Valid(ReplaceObject(input, "input", "In"));
      Verify_Valid(ReplaceObject(input, "output", "Out"));
    } else {
      Verify_Valid(input);
    }
  }

  [Theory]
  [ClassData(typeof(VerifySchemaInvalidObjectsData))]
  public async Task Verify_InvalidObjects(string obj)
  {
    var input = VerifySchemaInvalidObjectsData.Source[obj];
    if (input.StartsWith("object", StringComparison.Ordinal)) {
      await WhenAll(
        Verify_Invalid(ReplaceObject(input, "dual", "Dual"), "dual-" + obj),
        Verify_Invalid(ReplaceObject(input, "input", "In"), "input-" + obj),
        Verify_Invalid(ReplaceObject(input, "output", "Out"), "output-" + obj));
    } else {
      await Verify_Invalid(input, obj);
    }
  }

  private readonly Parser<SchemaAst>.L _parser = parser;

  private IResult<SchemaAst> Parse(string schema)
  {
    Tokenizer tokens = new(schema);
    return _parser.Parse(tokens, "Schema");
  }

  private static string ReplaceObject(string input, string objectReplace, string objReplace)
    => input
    .Replace("object", objectReplace, StringComparison.InvariantCulture)
    .Replace("Obj", objReplace, StringComparison.InvariantCulture);

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
    settings.UseDirectory(nameof(VerifySchemaTests));
    settings.UseTypeName("Invalid");
    settings.UseMethodName(test);

    await Verify(result.Select(m => m.Message), settings);
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
