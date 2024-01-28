
// Generated from .\test\GqlPlus.Verifier.ComponentTests\Verification\Schema

namespace GqlPlus.Verifier.Verification;

public partial class VerifySchemaTests {
  private readonly static Dictionary<string, string> s_schemaInvalidObjects = new() {
        ["alts-mods-undef"] = "object Test { | Test[Scalar] }",
        ["alts-mods-wrong"] = "object Test { | Test[Test] }",
        ["alts-diff-mods"] = "object Test { | Test1 } object Test { | Test1[] } object Test1 { }",
        ["extends-undef"] = "object Test { : Extends }",
        ["fields-diff-type"] = "object Test { field: Test } object Test { field: Test1 } object Test1 { }",
        ["fields-diff-mods"] = "object Test { field: Test } object Test { field: Test[] }",
        ["fields-mods-undef"] = "object Test { field: Test[Random] }",
        ["fields-mods-wrong"] = "object Test { field: Test[Test] }",
        ["generic-alt-undef"] = "object Test { | $type }",
        ["generic-extends-undef"] = "object Test { : $type }",
        ["generic-field-undef"] = "object Test { field: $type }",
        ["generic-arg-undef"] = "object Test { field: Ref<$type> } object Ref<$ref> { | $ref }",
        ["generic-arg-more"] = "object Test<$type> { field: Ref<$type> } object Ref { }",
        ["generic-arg-less"] = "object Test { field: Ref } object Ref<$ref> { | $ref }",
        ["generic-param-undef"] = "object Test { field: Ref<Test1> } object Ref<$ref> { | $ref }",
        ["generic-unused"] = "object Test<$type> { }",
        ["input-field-null"] = "input Test { field: Test = null }",
        ["input-extends-output"] = "input Test { : Bad } output Bad { }",
        ["output-extends-input"] = "output Test { : Bad } input Bad { }",
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
  public class SchemaInvalidObjects : TheoryData<string> {
    public SchemaInvalidObjects() {
        Add("alts-mods-undef");
        Add("alts-mods-wrong");
        Add("alts-diff-mods");
        Add("extends-undef");
        Add("fields-diff-type");
        Add("fields-diff-mods");
        Add("fields-mods-undef");
        Add("fields-mods-wrong");
        Add("generic-alt-undef");
        Add("generic-extends-undef");
        Add("generic-field-undef");
        Add("generic-arg-undef");
        Add("generic-arg-more");
        Add("generic-arg-less");
        Add("generic-param-undef");
        Add("generic-unused");
        Add("input-field-null");
        Add("input-extends-output");
        Add("output-extends-input");
        Add("output-enum-bad");
        Add("output-enums-diff");
        Add("output-enumValue-bad");
        Add("output-enumValue-wrong");
        Add("output-generic-enum-bad");
        Add("output-generic-enum-wrong");
        Add("output-params-diff");
        Add("output-params-undef");
        Add("output-params-mods-undef");
        Add("output-params-mods-wrong");
    }
  }
  private readonly static Dictionary<string, string> s_schemaInvalidSchemas = new() {
        ["bad-parse"] = "",
        ["unique-types"] = "enum Test { Value } output Test { }",
        ["category-no-output"] = "category { Test }",
        ["category-duplicate"] = "category { Test } category test { Output } output Test { } output Output { }",
        ["category-dup-alias"] = "category [a] { Test } category [a] { Output } output Test { } output Output { }",
        ["directive-diff-option"] = "directive @Test { all } directive @Test { ( repeatable ) all }",
        ["directive-no-param"] = "directive @Test(Test) { all }",
        ["directive-diff-parameter"] = "directive @Test(Test) { all } directive @Test(Test?) { all } input Test { }",
        ["enum-extends-diff"] = "enum Test { : Extends test } enum Test { test } enum Extends { extends }",
        ["enum-extends-undef"] = "enum Test { : Extends test }",
        ["enum-extends-wrong"] = "enum Test { : Extends test } output Extends { }",
        ["scalar-extends-undef"] = "scalar Test { Boolean : Extends }",
        ["scalar-extends-wrong-type"] = "scalar Test { Boolean : Extends } output Extends { }",
        ["scalar-extends-wrong-kind"] = "scalar Test { Boolean : Extends } scalar Extends { String }",
        ["scalar-diff-kind"] = "scalar Test { string } scalar Test { number }",
        ["scalar-string-diff"] = "scalar Test { string /a+/} scalar Test { string !/a+/ }",
        ["scalar-union-recurse"] = "scalar Test { union | Bad } scalar Bad { union | Test }",
        ["scalar-union-more"] = "scalar Test { union | Recurse } scalar Recurse { union | Bad } scalar Bad { union | Test }",
        ["scalar-union-self"] = "scalar Test { union | Test }",
        ["scalar-union-undef"] = "scalar Test { union | Bad }",
        ["scalar-union-wrong"] = "scalar Test { union | Bad } input Bad { }",
    };
  public class SchemaInvalidSchemas : TheoryData<string> {
    public SchemaInvalidSchemas() {
        Add("bad-parse");
        Add("unique-types");
        Add("category-no-output");
        Add("category-duplicate");
        Add("category-dup-alias");
        Add("directive-diff-option");
        Add("directive-no-param");
        Add("directive-diff-parameter");
        Add("enum-extends-diff");
        Add("enum-extends-undef");
        Add("enum-extends-wrong");
        Add("scalar-extends-undef");
        Add("scalar-extends-wrong-type");
        Add("scalar-extends-wrong-kind");
        Add("scalar-diff-kind");
        Add("scalar-string-diff");
        Add("scalar-union-recurse");
        Add("scalar-union-more");
        Add("scalar-union-self");
        Add("scalar-union-undef");
        Add("scalar-union-wrong");
    }
  }
  private readonly static Dictionary<string, string> s_schemaValidMerges = new() {
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
        ["object-extends"] = "object ObjBase { : BaseObj } object ObjBase { : BaseObj } object BaseObj { }",
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
  public class SchemaValidMerges : TheoryData<string> {
    public SchemaValidMerges() {
        Add("category");
        Add("category-alias");
        Add("directive");
        Add("directive-alias");
        Add("directive-params");
        Add("option");
        Add("option-alias");
        Add("option-setting");
        Add("enum-alias");
        Add("enum-diff");
        Add("enum-same");
        Add("enum-value-alias");
        Add("object");
        Add("object-alias");
        Add("object-extends");
        Add("object-params");
        Add("object-alts");
        Add("object-fields");
        Add("object-field-alias");
        Add("output-field-params");
        Add("output-field-enums");
        Add("output-field-enum-alias");
        Add("scalar-alias");
        Add("scalar-number");
        Add("scalar-number-same");
        Add("scalar-number-diff");
        Add("scalar-string");
        Add("scalar-string-same");
        Add("scalar-string-diff");
        Add("scalar-union-same");
        Add("scalar-union-diff");
    }
  }
  private readonly static Dictionary<string, string> s_schemaValidObjects = new() {
        ["alts-mods-Boolean"] = "object ObjAltMods { | ObjModsAlt[^] } object ObjModsAlt { }",
        ["extends"] = "object ObjTestBase { : ObjBaseTest } object ObjBaseTest { }",
        ["fields-mods-Enum"] = "object ObjFieldMods { field: ObjFieldMods[ObjFieldEnum] } enum ObjFieldEnum { value }",
        ["generic-alt"] = "object ObjGenAlt<$type> { | $type }",
        ["generic-extends"] = "object ObjGenBase<$type> { : $type }",
        ["generic-field"] = "object ObjGenField<$type> { field: $type }",
        ["generic-alt-arg"] = "object ObjGenAltArg<$type> { | ObjGenAltRef<$type> } object ObjGenAltRef<$ref> { | $ref }",
        ["generic-extends-arg"] = "object ObjGenBaseArg<$type> { : ObjGenBaseRef<$type> } object ObjGenBaseRef<$ref> { | $ref }",
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
  public class SchemaValidObjects : TheoryData<string> {
    public SchemaValidObjects() {
        Add("alts-mods-Boolean");
        Add("extends");
        Add("fields-mods-Enum");
        Add("generic-alt");
        Add("generic-extends");
        Add("generic-field");
        Add("generic-alt-arg");
        Add("generic-extends-arg");
        Add("generic-field-arg");
        Add("generic-param");
        Add("input-field-Number");
        Add("input-field-String");
        Add("input-field-Enum");
        Add("input-field-null");
        Add("output-field-enum");
        Add("output-field-enum-extends");
        Add("output-field-value");
        Add("output-generic-enum");
        Add("output-generic-extends");
        Add("output-generic-value");
        Add("output-params");
        Add("output-params-mods-Scalar");
    }
  }
  private readonly static Dictionary<string, string> s_schemaValidSchemas = new() {
        ["category-output"] = "category { Cat } output Cat { }",
        ["directive-param"] = "directive @DirParam(DirParamIn) { all } input DirParamIn { }",
        ["enum-extends"] = "enum EnExt { :EnExtBase valExt } enum EnExtBase { valBase }",
        ["scalar-extends"] = "scalar ScalExt { Boolean :ScalExtBase } scalar ScalExtBase { Boolean }",
    };
  public class SchemaValidSchemas : TheoryData<string> {
    public SchemaValidSchemas() {
        Add("category-output");
        Add("directive-param");
        Add("enum-extends");
        Add("scalar-extends");
    }
  }
}
