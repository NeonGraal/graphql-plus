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
  [Theory]
  [MemberData(nameof(ValidSchemas))]
  public void Verify_ValidSchemas(string schema)
    => Verify_Valid(s_validSchemas[schema]);

  [Theory]
  [MemberData(nameof(InvalidSchemas))]
  public async Task Verify_InvalidSchemas(string schema)
    => await Verify_Invalid(s_invalidSchemas[schema], schema);

  [Theory]
  [MemberData(nameof(ValidObjects))]
  public void Verify_ValidObjects(string schema)
  {
    var input = s_validObjects[schema];
    if (input.StartsWith("object", StringComparison.Ordinal)) {
      Verify_Valid(input.Replace("object", "input"));
      Verify_Valid(input.Replace("object", "output"));
    } else {
      Verify_Valid(input);
    }
  }

  [Theory]
  [MemberData(nameof(InvalidObjects))]
  public async Task Verify_InvalidObjects(string schema)
  {
    var input = s_invalidObjects[schema];
    if (input.StartsWith("object", StringComparison.Ordinal)) {
      using var scope = new AssertionScope();

      await Verify_Invalid(input.Replace("object", "input"), "input-" + schema);
      await Verify_Invalid(input.Replace("object", "output"), "output-" + schema);
    } else {
      await Verify_Invalid(input, schema);
    }
  }

  private static readonly Map<string> s_validSchemas = new() {
    ["category-output"] = "category { Test } output Test { }",
    ["directive-parameter"] = "directive @Test(Test) { all } input Test { }",
    ["directive-merge-parameter"] = "directive @Test(Test) { all } directive @Test { all } input Test { }",
    ["directive-merge"] = "directive @Test { all } directive @Test { all }",
    ["enum-merge"] = "enum Test { one } enum Test { two }",
    ["enum-extends"] = "enum Base { base } enum Test { :Base test }",
    ["scalar-merge"] = "scalar Test { string } scalar Test { string }",
  };
  public static IEnumerable<object[]> ValidSchemas => SchemaKeys(s_validSchemas);

  private static readonly Map<string> s_invalidSchemas = new() {
    ["bad-parse"] = "",
    ["unique-types"] = "enum Test { Value } output Test { }",
    ["category-no-output"] = "category { Test }",
    ["category-duplicate"] = "category { Test } category test { Output } output Test { } output Output { }",
    ["category-dup-alias"] = "category [a] { Test } category [a] { Output } output Test { } output Output { }",
    ["directive-diff-option"] = "directive @Test { all } directive @Test { ( repeatable ) all }",
    ["directive-no-param"] = "directive @Test(Test) { all }",
    ["directive-diff-parameter"] = "directive @Test(Test) { all } directive @Test(Test?) { all } input Test { }",
    ["enum-no-base"] = "enum Test { : Base test }",
    ["enum-diff-base"] = "enum Test { : Base test } enum Test { test } enum Base { base }",
    ["scalar-diff-kind"] = "scalar Test { string } scalar Test { number }",
  };
  public static IEnumerable<object[]> InvalidSchemas => SchemaKeys(s_invalidSchemas);

  private static readonly Map<string> s_validObjects = new() {
    ["merge"] = "object Test { } object Test { }",
    ["merge-alts"] = "object Test { | Test1 } object Test { | Test1 } object Test1 { }",
    ["merge-fields"] = "object Test { field: Test } object Test { field: Test }",
    ["input-field-optional-null"] = "input Test { field: Test? = null}",
    ["output-merge-params"] = "output Test { field(Param): Test } output Test { field: Test } input Param { }",
    ["output-merge-enums"] = "output Test { field = true } output Test { field = true }",
  };
  public static IEnumerable<object[]> ValidObjects => SchemaKeys(s_validObjects);

  private static readonly Map<string> s_invalidObjects = new() {
    ["diff-base"] = "object Test { :Base } object Test { } object Base { }",
    ["alts-diff-mods"] = "object Test { | Test1 } object Test { | Test1[] } object Test1 { }",
    ["fields-diff-type"] = "object Test { field: Test } object Test { field: Test1 } object Test1 { }",
    ["fields-diff-mods"] = "object Test { field: Test } object Test { field: Test[] } ",
    ["input-field-null"] = "input Test { field: Test = null }",
    ["output-diff-params"] = "output Test { field(Param): Test } output Test { field(Param?): Test } input Param { }",
    ["output-bad-enum"] = "output Test { field = unknown }",
    ["output-diff-enums"] = "output Test { field = true } output Test { field = false }",
  };
  public static IEnumerable<object[]> InvalidObjects => SchemaKeys(s_invalidObjects);

  private static IEnumerable<object[]> SchemaKeys(Map<string> schemas)
    => schemas.Keys.Select(k => new object[] { k });

  private readonly Parser<SchemaAst>.L _parser = parser;

  private IResult<SchemaAst> Parse(string schema)
  {
    Tokenizer tokens = new(schema);
    return _parser.Parse(tokens, "Schema");
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

    var settings = new VerifySettings();
    settings.ScrubEmptyLines();
    settings.UseMethodName(test);

    await Verify(result.Select(m => m.Message), settings);
  }
}
