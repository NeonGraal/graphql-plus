using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Parse;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification;

[UsesVerify]
public class SchemaVerifierTests(
    Parser<SchemaAst>.D parser,
    IVerify<SchemaAst> verifier)
{
  private readonly Parser<SchemaAst>.L _parser = parser;

  [Theory]
  [MemberData(nameof(ValidSchemas))]
  public void Verify_ValidSchemas_ReturnsValid(string schema)
  {
    var parse = Parse(s_validSchemas[schema]);
    if (parse is IResultError<SchemaAst> error) {
      error.Message.Should().BeNull();
    }

    var result = verifier.Verify(parse.Required());

    result.Should().BeNullOrEmpty();
  }

  [Theory]
  [MemberData(nameof(InvalidSchemas))]
  public async Task Verify_InvalidSchemas_ReturnsInvalidAsync(string schema)
  {
    var parse = Parse(s_invalidSchemas[schema]);

    var result = new TokenMessages();
    if (parse.IsOk()) {
      result.AddRange(verifier.Verify(parse.Required()));
    } else {
      parse.IsError(result.Add);
    }

    var settings = new VerifySettings();
    settings.ScrubEmptyLines();
    settings.UseFileName(schema);

    await Verify(result.Select(m => m.Message), settings);
  }

  private IResult<SchemaAst> Parse(string schema)
  {
    Tokenizer tokens = new(schema);
    return _parser.Parse(tokens, "Schema");
  }

  private static readonly Map<string> s_validSchemas = new() {
    ["category-output"] = "category { Test } output Test { }",
    ["directive-parameter"] = "directive @Test(Test) { all } input Test { }",
    ["directive-merge"] = "directive @Test { all } directive @Test { all }",
    ["enum-merge"] = "enum Test { one } enum Test { two }",
    ["enum-extends"] = "enum Base { one } enum Test { : Base two }",
    ["input-merge"] = "input Test { } input Test { }",
    ["output-merge"] = "output Test { } output Test { }",
    ["scalar-merge"] = "scalar Test { string } scalar Test { string }",
  };

  public static IEnumerable<object[]> ValidSchemas => s_validSchemas.Keys.Select(k => new object[] { k });

  private static readonly Map<string> s_invalidSchemas = new() {
    ["bad-parse"] = "",
    ["unique-types"] = "enum Test { Value } output Test { }",
    ["category-no-output"] = "category { Test }",
    ["category-duplicate"] = "category { Test } category test { Output } output Test { } output Output { }",
    ["category-dup-alias"] = "category [a] { Test } category [a] { Output } output Test { } output Output { }",
    ["directive-diff-option"] = "directive @Test { all } directive @Test { ( repeatable ) all }",
    ["directive-no-param"] = "directive @Test(Test) { all }",
    ["enum-no-base"] = "enum Test { : Base all }",
    ["enum-diff-base"] = "enum Test { : Base all } enum Test { all } enum Base { all }",
  };

  public static IEnumerable<object[]> InvalidSchemas => s_invalidSchemas.Keys.Select(k => new object[] { k });
}
