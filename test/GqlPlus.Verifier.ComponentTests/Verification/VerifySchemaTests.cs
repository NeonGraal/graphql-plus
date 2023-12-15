using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Parse;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification;

[UsesVerify]
public class VerifySchemaTests(
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
  public async Task Verify_InvalidSchemas_ReturnsInvalid(string schema)
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
    settings.UseMethodName(schema);

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
    ["enum-extends"] = "enum Base { one } enum Test { :Base two }",
    ["input-merge"] = "input Test { } input Test { }",
    ["input-merge-alts"] = "input Test { | Test1 } input Test { | Test1 } input Test1 { }",
    ["input-merge-fields"] = "input Test { field: Test } input Test { field: Test }",
    ["input-field-optional-null"] = "input Test { field: Test? = null}",
    ["output-merge"] = "output Test { } output Test { }",
    ["output-merge-alts"] = "output Test { | Test1 } output Test { | Test1 } output Test1 { }",
    ["output-merge-fields"] = "output Test { field: Test } output Test { field: Test }",
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
    ["input-diff-base"] = "input Test { :Base } input Test { } input Base { }",
    ["input-alts-diff-mods"] = "input Test { | Test1 } input Test { | Test1[] } input Test1 { }",
    ["input-fields-diff-type"] = "input Test { field: Test } input Test { field: Test1 } input Test1 { }",
    ["input-fields-diff-mods"] = "input Test { field: Test } input Test { field: Test[] } ",
    ["input-field-null"] = "input Test { field: Test = null}",
    ["output-diff-base"] = "output Test { :Base } output Test { } output Base { }",
    ["output-alts-diff-mods"] = "output Test { | Test1 } output Test { | Test1[] } output Test1 { }",
    ["output-fields-diff-type"] = "output Test { field: Test } output Test { field: Test1 } output Test1 { }",
    ["output-fields-diff-mods"] = "output Test { field: Test } output Test { field: Test[] } ",
    ["scalar-diff-kind"] = "scalar Test { string } scalar Test { number }",
  };

  public static IEnumerable<object[]> InvalidSchemas => s_invalidSchemas.Keys.Select(k => new object[] { k });
}
