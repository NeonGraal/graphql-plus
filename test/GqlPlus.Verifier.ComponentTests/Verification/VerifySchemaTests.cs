using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Merging;
using GqlPlus.Verifier.Parse;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification;

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

      Verify_Valid(ReplaceObject(input, "input", "In"));
      Verify_Valid(ReplaceObject(input, "output", "Out"));
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

      Verify_Valid(ReplaceObject(input, "input", "In"));
      Verify_Valid(ReplaceObject(input, "output", "Out"));
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
        Verify_Invalid(ReplaceObject(input, "input", "In"), "input-" + schema),
        Verify_Invalid(ReplaceObject(input, "output", "Out"), "output-" + schema));
    } else {
      await Verify_Invalid(input, schema);
    }
  }

  [Fact]
  public void CanMerge_Schemas()
  {
    var schemas = s_validObjects.Values
      .SelectMany(input => new[] {
        ReplaceObject(input, "input", "In"),
        ReplaceObject(input, "output", "Out"),
      })
      .Concat(s_validMerges.Values)
      .Concat(s_validSchemas.Values)
      .Select(input => Parse(input).Required())
      .ToArray();

    var result = merger.CanMerge(schemas);

    result.Should().BeTrue();
  }

  [Fact]
  public async Task Merge_Schemas()
  {
    var schemas = s_validObjects.Values
      .SelectMany(input => new[] {
        ReplaceObject(input, "input", "In"),
        ReplaceObject(input, "output", "Out"),
      })
      .Concat(s_validMerges.Values)
      .Concat(s_validSchemas.Values)
      .Select(input => Parse(input).Required())
      .ToArray();

    var result = merger.Merge(schemas);

    await Verify(result.Select(s => s.Render()));
  }

  [Theory]
  [MemberData(nameof(ValidMerges))]
  public async Task Merge_Valid(string schema)
  {
    var input = s_validMerges[schema];
    if (input.StartsWith("object", StringComparison.Ordinal)) {
      await WhenAll(
        Verify_Merge(ReplaceObject(input, "input", "In"), "input-" + schema),
        Verify_Merge(ReplaceObject(input, "output", "Out"), "output-" + schema));
    } else {
      await Verify_Merge(input, schema);
    }
  }

  private static readonly Map<string> s_validSchemas = new() {
    ["category-output"] = "category { Cat } output Cat { }",
    ["directive-param"] = "directive @DirParam(DirParamIn) { all } input DirParamIn { }",
    ["enum-extends"] = "enum EnExt { :EnExtBase valExt } enum EnExtBase { valBase } ",
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
    ["category"] = "category { Category } output Category { }",
    ["category-alias"] = "category [Cat1] { CatAlias } category [Cat2] { CatAlias } output CatAlias { }",
    ["directive"] = "directive @Dir { inline } directive @Dir { spread }",
    ["directive-alias"] = "directive @DirAlias [Dir1] { variable } directive @DirAlias [Dir2] { field }",
    ["directive-params"] = "directive @DirParams(DirParamsIn) { operation } directive @DirParams { fragment } input DirParamsIn { }",
    ["option"] = "option Option { } option Option { }",
    ["option-alias"] = "option OptAlias [Opt1] { } option OptAlias [Opt2] { }",
    ["option-setting"] = "option OptSetting { setting=true } option OptSetting { setting=[0] }",
    ["enum-alias"] = "enum EnAlias [En1] { alias } enum EnAlias [En2] { alias }",
    ["enum-diff"] = "enum EnDiff { one } enum EnDiff { two }",
    ["enum-same"] = "enum EnSame { same } enum EnSame { same }",
    ["enum-value-alias"] = "enum EnValAlias { value [val1] } enum EnValAlias { value [val2] }",
    ["object"] = "object Obj { } object Obj { }",
    ["object-alias"] = "object ObjAlias [Obj1] { } object ObjAlias [Obj2] { }",
    ["object-base"] = "object ObjBase { : BaseObj } object ObjBase { : BaseObj } object BaseObj { }",
    ["object-params"] = "object ObjParams<$test> { test: $test } object ObjParams<$type> { type: $type }",
    ["object-alts"] = "object ObjAlts { | ObjAltsType } object ObjAlts { | ObjAltsType } object ObjAltsType { }",
    ["object-fields"] = "object ObjFields { field: ObjFields } object ObjFields { field: ObjFields }",
    ["object-field-alias"] = "object FieldAlias { field [field1]: FieldAlias } object FieldAlias { field [field2]: FieldAlias }",
    ["output-field-params"] = "output FieldParams { field(FieldParam): FieldParams } output FieldParams { field: FieldParams } input FieldParam { }",
    ["output-field-enums"] = "output FieldEnums { field = Boolean.true } output FieldEnums { field = true }",
    ["output-field-enum-alias"] = "output FieldEnumAlias { field [field1] = Boolean.true } output FieldEnumAlias { field [field2] = true }",
    ["scalar-alias"] = "scalar NumAlias [Num1] { number } scalar NumAlias [Num2] { number }",
    ["scalar-number"] = "scalar Num { number } scalar Num { number }",
    ["scalar-number-same"] = "scalar NumSame { number 1~9 } scalar NumSame { number 1~9 }",
    ["scalar-number-diff"] = "scalar NumDiff { number 1~9 } scalar NumDiff { number }",
    ["scalar-string"] = "scalar Str { string } scalar Str { string }",
    ["scalar-string-same"] = "scalar StrSame { string /a+/ } scalar StrSame { string /a+/ }",
    ["scalar-string-diff"] = "scalar StrDiff { string /a+/ } scalar StrDiff { string }",
    ["scalar-union-same"] = "scalar UnSame { union | Boolean } scalar UnSame { union | Boolean }",
    ["scalar-union-diff"] = "scalar UnDiff { union | Boolean } scalar UnDiff { union | Number }",
  };
  public static IEnumerable<object[]> ValidMerges => SchemaKeys(s_validMerges);

  private static readonly Map<string> s_validObjects = new() {
    ["alts-mods-Boolean"] = "object ObjAltMods { | ObjModsAlt[^] } object ObjModsAlt { }",
    ["base"] = "object ObjTestBase { : ObjBaseTest } object ObjBaseTest { }",
    ["fields-mods-Enum"] = "object ObjFieldMods { field: ObjFieldMods[ObjFieldEnum] } enum ObjFieldEnum { value } ",
    ["generic-alt"] = "object ObjGenAlt<$type> { | $type }",
    ["generic-base"] = "object ObjGenBase<$type> { : $type }",
    ["generic-field"] = "object ObjGenField<$type> { field: $type }",
    ["generic-alt-arg"] = "object ObjGenAltArg<$type> { | ObjGenAltRef<$type> } object ObjGenAltRef<$ref> { | $ref }",
    ["generic-base-arg"] = "object ObjGenBaseArg<$type> { : ObjGenBaseRef<$type> } object ObjGenBaseRef<$ref> { | $ref }",
    ["generic-field-arg"] = "object ObjGenFieldArg<$type> { field: ObjGenFieldRef<$type> } object ObjGenFieldRef<$ref> { | $ref }",
    ["generic-param"] = "object ObjGenParam { field: ObjGenParamRef<ObjGenParamAlt> } object ObjGenParamRef<$ref> { | $ref } object ObjGenParamAlt { }",
    ["input-field-Number"] = "input InFieldNum { field: Number = 0 }",
    ["input-field-String"] = "input InFieldStr { field: String = '' }",
    ["input-field-Enum"] = "input InFieldEnum { field: InEnumField = value } enum InEnumField { value }",
    ["input-field-null"] = "input InFieldNull { field: InFieldNull? = null }",
    ["output-field-enum"] = "output OutFieldEnum { field = OutEnumField.outEnumField } enum OutEnumField { outEnumField }",
    ["output-field-enum-extends"] = "output OutFieldExtends { field = OutEnumExtends.outEnumExtends } enum OutEnumExtends { : OutEnumExtended outExtended } enum OutEnumExtended { outEnumExtends }",
    ["output-field-value"] = "output OutFieldValue { field = outEnumValue } enum OutEnumValue { outEnumValue }",
    ["output-generic-enum"] = "output OutGenEnum { | OutGenEnumRef<OutEnumGen.outEnumGen> } output OutGenEnumRef<$type> { field: $type } enum OutEnumGen { outEnumGen }",
    ["output-generic-extends"] = "output OutGenExtends { | OutGenExtendsRef<OutExtendsGen.outGenExtends> } output OutGenExtendsRef<$type> { field: $type } enum OutExtendsGen { : OutExtendedGen outGenExtended } enum OutExtendedGen { outGenExtends }",
    ["output-generic-value"] = "output OutGenValue { | OutGenValueRef<outValueGen> } output OutGenValueRef<$type> { field: $type } enum OutValueGen { outValueGen }",
    ["output-params"] = "output OutParams { field(OutParam): OutParams } input OutParam { }",
    ["output-params-mods-Scalar"] = "output OutParamsScalar { field(OutParamScalar[OutScalarParam]): OutParamsScalar } input OutParamScalar { } scalar OutScalarParam { number 1 ~ 10 }",
  };
  public static IEnumerable<object[]> ValidObjects => SchemaKeys(s_validObjects);

  private static readonly Map<string> s_invalidObjects = new() {
    ["alts-mods-undef"] = "object Test { | Test[Scalar] }",
    ["alts-mods-wrong"] = "object Test { | Test[Test] }",
    ["alts-diff-mods"] = "object Test { | Test1 } object Test { | Test1[] } object Test1 { }",
    ["base-undef"] = "object Test { : Base }",
    ["fields-diff-type"] = "object Test { field: Test } object Test { field: Test1 } object Test1 { }",
    ["fields-diff-mods"] = "object Test { field: Test } object Test { field: Test[] }",
    ["fields-mods-undef"] = "object Test { field: Test[Random] }",
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
