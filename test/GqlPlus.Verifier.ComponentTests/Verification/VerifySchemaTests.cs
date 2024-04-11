using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Parse;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification;

public class VerifySchemaTests(
    Parser<SchemaAst>.D parser,
    IVerify<SchemaAst> verifier
) : SchemaBase(parser)
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
    if (IsObjectInput(input)) {
      using var scope = new AssertionScope();

      foreach (var (objLabel, objAbbr) in Replacements) {
        Verify_Valid(ReplaceObject(input, objLabel, objAbbr));
      }
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
    if (IsObjectInput(input)) {
      using var scope = new AssertionScope();

      foreach (var (objLabel, objAbbr) in Replacements) {
        Verify_Valid(ReplaceObject(input, objLabel, objAbbr));
      }
    } else {
      Verify_Valid(input);
    }
  }

  [Theory]
  [ClassData(typeof(VerifySchemaInvalidObjectsData))]
  public async Task Verify_InvalidObjects(string obj)
  {
    var input = VerifySchemaInvalidObjectsData.Source[obj];
    if (IsObjectInput(input)) {
      await WhenAll(Replacements
        .Select(r => Verify_Invalid(ReplaceObject(input, r.Item1, r.Item2), r.Item1 + "-" + obj))
        .ToArray());
    } else {
      await Verify_Invalid(input, obj);
    }
  }

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

    result.Should().NotBeEmpty(input);

    var settings = new VerifySettings();
    settings.ScrubEmptyLines();
    settings.UseDirectory(nameof(VerifySchemaTests));
    settings.UseTypeName("Invalid");
    settings.UseMethodName(test);

    await Verify(result.Select(m => m.Message), settings);
  }
}
