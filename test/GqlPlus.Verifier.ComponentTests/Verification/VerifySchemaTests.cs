using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Merging;
using GqlPlus.Verifier.Parse;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification;

[UsesVerify]
public class VerifySchemaTests(
    Parser<SchemaAst>.D parser,
    IVerify<SchemaAst> verifier,
    IMerge<SchemaAst> merger)
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
  [MemberData(nameof(ValidMerges))]
  public void Verify_ValidMerges(string schema)
  {
    var input = s_validMerges[schema];
    if (input.StartsWith("object", StringComparison.Ordinal)) {
      using var scope = new AssertionScope();

      Verify_Valid(input.Replace("object", "input"));
      Verify_Valid(input.Replace("object", "output"));
    } else {
      Verify_Valid(input);
    }
  }

  [Theory]
  [MemberData(nameof(ValidObjects))]
  public void Verify_ValidObjects(string schema)
  {
    var input = s_validObjects[schema];
    if (input.StartsWith("object", StringComparison.Ordinal)) {
      using var scope = new AssertionScope();

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
      await WhenAll(
        Verify_Invalid(input.Replace("object", "input"), "input-" + schema),
        Verify_Invalid(input.Replace("object", "output"), "output-" + schema));
    } else {
      await Verify_Invalid(input, schema);
    }
  }

  [Fact(Skip = "WIP")]
  public void CanMerge_Schemas()
  {
    var schemas = s_validObjects.Values
      .SelectMany(input => new[] {
        input.Replace("object", "input"),
        input.Replace("object", "output"),
      })
      .Concat(s_validMerges.Values)
      .Concat(s_validSchemas.Values)
      .Select(input => Parse(input).Required())
      .ToArray();

    var result = merger.CanMerge(schemas);

    result.Should().BeTrue();
  }

  [Fact(Skip = "WIP")]
  public async Task Merge_Schemas()
  {
    var schemas = s_validObjects.Values
      .SelectMany(input => new[] {
        input.Replace("object", "input"),
        input.Replace("object", "output"),
      })
      .Concat(s_validMerges.Values)
      .Concat(s_validSchemas.Values)
      .Select(input => Parse(input).Required())
      .ToArray();

    var result = merger.Merge(schemas);

    await Verify(result.Render());
  }

  [Theory(Skip = "WIP")]
  [MemberData(nameof(ValidMerges))]
  public async Task Merge_Valid(string schema)
  {
    var input = s_validMerges[schema];
    if (input.StartsWith("object", StringComparison.Ordinal)) {
      await WhenAll(
        Verify_Merge(input.Replace("object", "input"), "input-" + schema),
        Verify_Merge(input.Replace("object", "output"), "output-" + schema));
    } else {
      await Verify_Merge(input, schema);
    }
  }

  private static readonly Map<string> s_validSchemas = new() {
    ["category-output"] = "category { Test } output Test { }",
    ["directive-parameter"] = "directive @Test(Test) { all } input Test { }",
    ["enum-extends"] = "enum Test { :Base test } enum Base { base } ",
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
    ["enum-base-diff"] = "enum Test { : Base test } enum Test { test } enum Base { base }",
    ["enum-base-undef"] = "enum Test { : Base test }",
    ["enum-base-wrong"] = "enum Test { : Base test } output Base { }",
    ["scalar-diff-kind"] = "scalar Test { string } scalar Test { number }",
    ["scalar-string-diff"] = "scalar Test { string /a+/} scalar Test { string /a+/! }",
    ["scalar-union-recurse"] = "scalar Test { union | Bad } scalar Bad { union | Test }",
    ["scalar-union-more"] = "scalar Test { union | Recurse } scalar Recurse { union | Bad } scalar Bad { union | Test }",
    ["scalar-union-self"] = "scalar Test { union | Test }",
    ["scalar-union-undef"] = "scalar Test { union | Bad }",
    ["scalar-union-wrong"] = "scalar Test { union | Bad } input Bad { }",
  };
  public static IEnumerable<object[]> InvalidSchemas => SchemaKeys(s_invalidSchemas);

  private static readonly Map<string> s_validMerges = new() {
    ["directive-params"] = "directive @Test(Test) { all } directive @Test { all } input Test { }",
    ["directive"] = "directive @Test { all } directive @Test { all }",
    ["enum-same"] = "enum Test { one } enum Test { one }",
    ["enum-diff"] = "enum Test { one } enum Test { two }",
    ["object"] = "object Test { } object Test { }",
    ["object-base"] = "object Test { : Base } object Test { : Base } object Base { }",
    ["object-params"] = "object Test<$test> { test: $test } object Test<$type> { type: $type }",
    ["object-alts"] = "object Test { | Type } object Test { | Type } object Type { }",
    ["object-fields"] = "object Test { field: Test } object Test { field: Test }",
    ["output-field-params"] = "output Test { field(Param): Test } output Test { field: Test } input Param { }",
    ["output-field-enums"] = "output Test { field = Boolean.true } output Test { field = true }",
    ["scalar-number"] = "scalar Test { number } scalar Test { number }",
    ["scalar-number-same"] = "scalar Test { number 1:9 } scalar Test { number 1:9 }",
    ["scalar-number-diff"] = "scalar Test { number 1:9 } scalar Test { number }",
    ["scalar-string"] = "scalar Test { string } scalar Test { string }",
    ["scalar-string-same"] = "scalar Test { string /a+/ } scalar Test { string /a+/ }",
    ["scalar-string-diff"] = "scalar Test { string /a+/ } scalar Test { string }",
    ["scalar-union-same"] = "scalar Test { union | Boolean } scalar Test { union | Boolean }",
    ["scalar-union-diff"] = "scalar Test { union | Boolean } scalar Test { union | Number }",
  };
  public static IEnumerable<object[]> ValidMerges => SchemaKeys(s_validMerges);

  private static readonly Map<string> s_validObjects = new() {
    ["alts-mods-Boolean"] = "object Test { | Alt[~] } object Alt { }",
    ["base"] = "object Test { : Base } object Base { }",
    ["fields-mods-Enum"] = "object Test { field: Test[Enum] } enum Enum { value } ",
    ["generic-alt"] = "object Test<$type> { | $type }",
    ["generic-base"] = "object Test<$type> { : $type }",
    ["generic-field"] = "object Test<$type> { field: $type }",
    ["generic-alt-arg"] = "object Test<$type> { | Ref<$type> } object Ref<$ref> { | $ref }",
    ["generic-base-arg"] = "object Test<$type> { : Ref<$type> } object Ref<$ref> { | $ref }",
    ["generic-field-arg"] = "object Test<$type> { field: Ref<$type> } object Ref<$ref> { | $ref }",
    ["generic-param"] = "object Test { field: Ref<Alt> } object Ref<$ref> { | $ref } object Alt { }",
    ["input-field-Number"] = "input Test { field: Number = 0 }",
    ["input-field-String"] = "input Test { field: String = '' }",
    ["input-field-Enum"] = "input Test { field: Enum = value } enum Enum { value }",
    ["input-field-null"] = "input Test { field: Test? = null }",
    ["output-generic-enum"] = "output Test { | Ref<Boolean.false> } output Ref<$type> { field: $type }",
    ["output-generic-value"] = "output Test { | Ref<false> } output Ref<$type> { field: $type }",
    ["output-params"] = "output Test { field(Param): Test } input Param { }",
    ["output-params-mods-Scalar"] = "output Test { field(Param[Scalar]): Test } input Param { } scalar Scalar { number 1 : 10 }",
  };
  public static IEnumerable<object[]> ValidObjects => SchemaKeys(s_validObjects);

  private static readonly Map<string> s_invalidObjects = new() {
    ["alts-mods-undef"] = "object Test { | Test[Scalar] }",
    ["alts-mods-wrong"] = "object Test { | Test[Test] }",
    ["alts-diff-mods"] = "object Test { | Test1 } object Test { | Test1[] } object Test1 { }",
    ["base-undef"] = "object Test { : Base }",
    ["fields-diff-type"] = "object Test { field: Test } object Test { field: Test1 } object Test1 { }",
    ["fields-diff-mods"] = "object Test { field: Test } object Test { field: Test[] }",
    ["fields-mods-undef"] = "object Test { field: Test[Enum] }",
    ["fields-mods-wrong"] = "object Test { field: Test[Test] }",
    ["generic-alt-undef"] = "object Test { | $type }",
    ["generic-base-undef"] = "object Test { : $type }",
    ["generic-field-undef"] = "object Test { field: $type }",
    ["generic-arg-undef"] = "object Test { field: Ref<$type> } object Ref<$ref> { | $ref }",
    ["generic-arg-more"] = "object Test<$type> { field: Ref<$type> } object Ref { }",
    ["generic-arg-less"] = "object Test { field: Ref } object Ref<$ref> { | $ref }",
    ["generic-param-undef"] = "object Test { field: Ref<Test1> } object Ref<$ref> { | $ref }",
    ["generic-unused"] = "object Test<$type> { }",
    ["input-field-null"] = "input Test { field: Test = null }",
    ["input-base-output"] = "input Test { : Bad } output Bad { }",
    ["output-base-input"] = "output Test { : Bad } input Bad { }",
    ["output-enum-bad"] = "output Test { field = unknown }",
    ["output-enums-diff"] = "output Test { field = true } output Test { field = false }",
    ["output-enumValue-bad"] = "output Test { field = Boolean.unknown }",
    ["output-enumValue-wrong"] = "output Test { field = Wrong.unknown } input Wrong { }",
    ["output-generic-enum-bad"] = "output Test { | Ref<Boolean.unknown> } output Ref<$type> { field: $type }",
    ["output-generic-enum-wrong"] = "output Test { | Ref<Wrong.unknown> } output Ref<$type> { field: $type } output Wrong { }",
    ["output-params-diff"] = "output Test { field(Param): Test } output Test { field(Param?): Test } input Param { }",
    ["output-params-undef"] = "output Test { field(Param): Test }",
    ["output-params-mods-undef"] = "output Test { field(Param[Scalar]): Test } input Param { }",
    ["output-params-mods-wrong"] = "output Test { field(Param[Test]): Test } input Param { }",
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

  private async Task Verify_Merge(string input, string test)
  {
    var parse = Parse(input);

    var result = merger.Merge([parse.Required()]);

    var settings = new VerifySettings();
    settings.ScrubEmptyLines();
    settings.UseMethodName(test + "-merge");

    await Verify(result.Render(), settings);
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
