
// Generated from .\test\GqlPlus.Verifier.ComponentTests\Verification\Schema

namespace GqlPlus.Verifier.Verification;

public partial class VerifySchemaTests
{
  private static readonly Dictionary<string, string> s_schemaInvalidObjects = new() {
    ["alts-diff-mods"] = "object Test { | Test1 } object Test { | Test1[] } object Test1 { }",
    ["alts-mods-undef"] = "object Test { | Alt[Scalar] } object Alt { }",
    ["alts-mods-wrong"] = "object Test { | Alt[Test] } object Alt { }",
    ["alts-more"] = "object Test { | Recurse } object Recurse { | More } object More { | Test }",
    ["alts-recurse"] = "object Test { | Recurse } object Recurse { | Test }",
    ["alts-self"] = "object Test { | Test }",
    ["fields-alias"] = "object Test { field1[alias]: Test } object Test { field2[alias]: Test[] }",
    ["fields-diff-mods"] = "object Test { field: Test } object Test { field: Test[] }",
    ["fields-diff-type"] = "object Test { field: Test } object Test { field: Test1 } object Test1 { }",
    ["fields-mods-undef"] = "object Test { field: Test[Random] }",
    ["fields-mods-wrong"] = "object Test { field: Test[Test] }",
    ["generic-alt-undef"] = "object Test { | $type }",
    ["generic-arg-less"] = "object Test { field: Ref } object Ref<$ref> { | $ref }",
    ["generic-arg-more"] = "object Test<$type> { field: Ref<$type> } object Ref { }",
    ["generic-arg-undef"] = "object Test { field: Ref<$type> } object Ref<$ref> { | $ref }",
    ["generic-field-undef"] = "object Test { field: $type }",
    ["generic-param-undef"] = "object Test { field: Ref<Test1> } object Ref<$ref> { | $ref }",
    ["generic-parent-less"] = "object Test { :Ref } object Ref<$ref> { | $ref }",
    ["generic-parent-more"] = "object Test { :Ref<Number> } object Ref { }",
    ["generic-parent-undef"] = "object Test { :$type }",
    ["generic-unused"] = "object Test<$type> { }",
    ["input-field-null"] = "input Test { field: Test = null }",
    ["input-parent-output"] = "input Test { :Bad } output Bad { }",
    ["output-enum-bad"] = "output Test { field = unknown }",
    ["output-enums-diff"] = "output Test { field = true } output Test { field = false }",
    ["output-enumValue-bad"] = "output Test { field = Boolean.unknown }",
    ["output-enumValue-wrong"] = "output Test { field = Wrong.unknown } input Wrong { }",
    ["output-generic-enum-bad"] = "output Test { | Ref<Boolean.unknown> } output Ref<$type> { field: $type }",
    ["output-generic-enum-wrong"] = "output Test { | Ref<Wrong.unknown> } output Ref<$type> { field: $type } output Wrong { }",
    ["output-params-diff"] = "output Test { field(Param): Test } output Test { field(Param?): Test } input Param { }",
    ["output-params-mods-undef"] = "output Test { field(Param[Scalar]): Test } input Param { }",
    ["output-params-mods-wrong"] = "output Test { field(Param[Test]): Test } input Param { }",
    ["output-params-undef"] = "output Test { field(Param): Test }",
    ["output-parent-input"] = "output Test { :Bad } input Bad { }",
    ["parent-alt-mods"] = "object Test { :Parent | Alt } object Parent { | Alt[] } object Alt { }",
    ["parent-alt-more"] = "object Test { :Recurse | Alt } object Recurse { :More } object More { :Parent } object Parent { | Alt[] } object Alt { }",
    ["parent-alt-recurse"] = "object Test { :Recurse | Alt } object Recurse { :Parent } object Parent { | Alt[] } object Alt { }",
    ["parent-alt-self"] = "object Test { :Alt } object Alt { | Test }",
    ["parent-alt-self-more"] = "object Test { :Alt } object Alt { | More } object More { :Recurse } object Recurse { | Test }",
    ["parent-alt-self-recurse"] = "object Test { :Alt } object Alt { | Recurse } object Recurse { :Test }",
    ["parent-fields-alias"] = "object Test { :Parent field1[alias]: Test } object Parent { field2[alias]: Parent }",
    ["parent-fields-alias-more"] = "object Test { :Recurse field1[alias]: Test } object Recurse { :More } object More { :Parent } object Parent { field2[alias]: Parent }",
    ["parent-fields-alias-recurse"] = "object Test { :Recurse field1[alias]: Test } object Recurse { :Parent } object Parent { field2[alias]: Parent }",
    ["parent-fields-mods"] = "object Test { :Parent field: Test } object Parent { field: Test[] }",
    ["parent-fields-mods-more"] = "object Test { :Recurse field: Test } object Recurse { :More } object More { :Parent } object Parent { field: Test[] }",
    ["parent-fields-mods-recurse"] = "object Test { :Recurse field: Test } object Recurse { :Parent } object Parent { field: Test[] }",
    ["parent-more"] = "object Test { :Recurse } object Recurse { :More } object More { :Test }",
    ["parent-recurse"] = "object Test { :Recurse } object Recurse { :Test }",
    ["parent-self"] = "object Test { :Test }",
    ["parent-self-alt"] = "object Test { | Alt } object Alt { :Test }",
    ["parent-self-alt-more"] = "object Test { | Alt } object Alt { :More } object More { | Recurse } object Recurse { :Test }",
    ["parent-self-alt-recurse"] = "object Test { | Alt } object Alt { :Recurse } object Recurse { | Test }",
    ["parent-undef"] = "object Test { :Parent }",
    ["unique-alias"] = "object Test [a] { } object Dup [a] { }",
  };

  public class SchemaInvalidObjects : TheoryData<string>
  {
    public SchemaInvalidObjects()
    {
      Add("alts-diff-mods");
      Add("alts-mods-undef");
      Add("alts-mods-wrong");
      Add("alts-more");
      Add("alts-recurse");
      Add("alts-self");
      Add("fields-alias");
      Add("fields-diff-mods");
      Add("fields-diff-type");
      Add("fields-mods-undef");
      Add("fields-mods-wrong");
      Add("generic-alt-undef");
      Add("generic-arg-less");
      Add("generic-arg-more");
      Add("generic-arg-undef");
      Add("generic-field-undef");
      Add("generic-param-undef");
      Add("generic-parent-less");
      Add("generic-parent-more");
      Add("generic-parent-undef");
      Add("generic-unused");
      Add("input-field-null");
      Add("input-parent-output");
      Add("output-enum-bad");
      Add("output-enums-diff");
      Add("output-enumValue-bad");
      Add("output-enumValue-wrong");
      Add("output-generic-enum-bad");
      Add("output-generic-enum-wrong");
      Add("output-params-diff");
      Add("output-params-mods-undef");
      Add("output-params-mods-wrong");
      Add("output-params-undef");
      Add("output-parent-input");
      Add("parent-alt-mods");
      Add("parent-alt-more");
      Add("parent-alt-recurse");
      Add("parent-alt-self");
      Add("parent-alt-self-more");
      Add("parent-alt-self-recurse");
      Add("parent-fields-alias");
      Add("parent-fields-alias-more");
      Add("parent-fields-alias-recurse");
      Add("parent-fields-mods");
      Add("parent-fields-mods-more");
      Add("parent-fields-mods-recurse");
      Add("parent-more");
      Add("parent-recurse");
      Add("parent-self");
      Add("parent-self-alt");
      Add("parent-self-alt-more");
      Add("parent-self-alt-recurse");
      Add("parent-undef");
      Add("unique-alias");
    }
  }
  private static readonly Dictionary<string, string> s_schemaInvalidSchemas = new() {
    ["bad-parse"] = "",
    ["category-diff-mods"] = "category { Test } category { Test? } output Test { }",
    ["category-duplicate"] = "category { Test } category test { Output } output Test { } output Output { }",
    ["category-dup-alias"] = "category [a] { Test } category [a] { Output } output Test { } output Output { }",
    ["category-output-generic"] = "category { Test } output Test<$a> { | $a }",
    ["category-output-undef"] = "category { Test }",
    ["category-output-wrong"] = "category { Test } input Test { }",
    ["directive-diff-option"] = "directive @Test { all } directive @Test { ( repeatable ) all }",
    ["directive-diff-parameter"] = "directive @Test(Test) { all } directive @Test(Test?) { all } input Test { }",
    ["directive-no-param"] = "directive @Test(Test) { all }",
    ["enum-dup-alias"] = "enum Test [a] { test } enum Dup [a] { dup }",
    ["enum-parent-alias-dup"] = "enum Test { :Parent test[alias] } enum Parent { parent[alias] }",
    ["enum-parent-diff"] = "enum Test { :Parent test } enum Test { test } enum Parent { parent }",
    ["enum-parent-undef"] = "enum Test { :Parent test }",
    ["enum-parent-wrong"] = "enum Test { :Parent test } output Parent { }",
    ["option-diff-name"] = "option Test { } option Schema { }",
    ["scalar-diff-kind"] = "scalar Test { string } scalar Test { number }",
    ["scalar-dup-alias"] = "scalar Test [a] { Boolean } scalar Dup [a] { Boolean }",
    ["scalar-parent-self"] = "scalar Test { :Test Boolean }",
    ["scalar-parent-self-parent"] = "scalar Test { :Parent Boolean } scalar Parent { :Test Boolean }",
    ["scalar-parent-self-more"] = "scalar Test { :Parent Boolean } scalar Parent { :Recurse Boolean } scalar Recurse { :More Boolean } scalar More { :Test Boolean }",
    ["scalar-parent-self-recurse"] = "scalar Test { :Parent Boolean } scalar Parent { :Recurse Boolean } scalar Recurse { :Test Boolean }",
    ["scalar-parent-undef"] = "scalar Test { :Parent Boolean }",
    ["scalar-parent-wrong-kind"] = "scalar Test { :Parent Boolean } scalar Parent { String }",
    ["scalar-parent-wrong-type"] = "scalar Test { :Parent Boolean } output Parent { }",
    ["scalar-enum-parent-unique"] = "scalar Test { :Parent Enum Enum.value } scalar Parent { Enum Dup.value } enum Enum { value } enum Dup { value }",
    ["scalar-enum-undef"] = "scalar Test { enum undef }",
    ["scalar-enum-undef-all"] = "scalar Test { enum Undef.* }",
    ["scalar-enum-undef-member"] = "scalar Test { enum Enum.undef } enum Enum { value }",
    ["scalar-enum-undef-value"] = "scalar Test { enum Undef.value }",
    ["scalar-enum-unique"] = "scalar Test { enum Enum.value Dup.value } enum Enum { value } enum Dup { value }",
    ["scalar-enum-unique-all"] = "scalar Test { enum Enum.* Dup.* } enum Enum { value } enum Dup { value }",
    ["scalar-enum-unique-member"] = "scalar Test { enum Enum.value Dup.* } enum Enum { value } enum Dup { value }",
    ["scalar-enum-wrong"] = "scalar Test { enum Bad.value } output Bad { }",
    ["scalar-number-parent"] = "scalar Test { :Parent number 1> } scalar Parent { number !1> }",
    ["scalar-string-diff"] = "scalar Test { string /a+/} scalar Test { string !/a+/ }",
    ["scalar-string-parent"] = "scalar Test { :Parent string /a+/} scalar Parent { string !/a+/ }",
    ["scalar-union-more"] = "scalar Test { union | Bad } scalar Bad { union | More } scalar More { union | Test }",
    ["scalar-union-parent"] = "scalar Test { :Parent union } scalar Parent { union | Test }",
    ["scalar-union-parent-more"] = "scalar Test { :Parent union } scalar Parent { union | More } scalar More { :Bad union } scalar Bad { union | Test }",
    ["scalar-union-parent-recurse"] = "scalar Test { :Parent union } scalar Parent { union | Bad } scalar Bad { union | Test }",
    ["scalar-union-recurse"] = "scalar Test { union | Bad } scalar Bad { union | Test }",
    ["scalar-union-more-parent"] = "scalar Test { union | Recurse } scalar Recurse { :Parent union } scalar Parent { union | More } scalar More { :Bad union } scalar Bad { union | Test }",
    ["scalar-union-recurse-parent"] = "scalar Test { union | Bad } scalar Bad { :Parent union } scalar Parent { union | Test }",
    ["scalar-union-self"] = "scalar Test { union | Test }",
    ["scalar-union-undef"] = "scalar Test { union | Bad }",
    ["scalar-union-wrong"] = "scalar Test { union | Bad } input Bad { }",
    ["unique-type-alias"] = "enum Test [a] { Value } output Dup [a] { }",
    ["unique-types"] = "enum Test { Value } output Test { }",
  };

  public class SchemaInvalidSchemas : TheoryData<string>
  {
    public SchemaInvalidSchemas()
    {
      Add("bad-parse");
      Add("category-diff-mods");
      Add("category-duplicate");
      Add("category-dup-alias");
      Add("category-output-generic");
      Add("category-output-undef");
      Add("category-output-wrong");
      Add("directive-diff-option");
      Add("directive-diff-parameter");
      Add("directive-no-param");
      Add("enum-dup-alias");
      Add("enum-parent-alias-dup");
      Add("enum-parent-diff");
      Add("enum-parent-undef");
      Add("enum-parent-wrong");
      Add("option-diff-name");
      Add("scalar-diff-kind");
      Add("scalar-dup-alias");
      Add("scalar-parent-self");
      Add("scalar-parent-self-parent");
      Add("scalar-parent-self-more");
      Add("scalar-parent-self-recurse");
      Add("scalar-parent-undef");
      Add("scalar-parent-wrong-kind");
      Add("scalar-parent-wrong-type");
      Add("scalar-enum-parent-unique");
      Add("scalar-enum-undef");
      Add("scalar-enum-undef-all");
      Add("scalar-enum-undef-member");
      Add("scalar-enum-undef-value");
      Add("scalar-enum-unique");
      Add("scalar-enum-unique-all");
      Add("scalar-enum-unique-member");
      Add("scalar-enum-wrong");
      Add("scalar-number-parent");
      Add("scalar-string-diff");
      Add("scalar-string-parent");
      Add("scalar-union-more");
      Add("scalar-union-parent");
      Add("scalar-union-parent-more");
      Add("scalar-union-parent-recurse");
      Add("scalar-union-recurse");
      Add("scalar-union-more-parent");
      Add("scalar-union-recurse-parent");
      Add("scalar-union-self");
      Add("scalar-union-undef");
      Add("scalar-union-wrong");
      Add("unique-type-alias");
      Add("unique-types");
    }
  }
  private static readonly Dictionary<string, string> s_schemaValidMerges = new() {
    ["category"] = "category { Category } category category { Category } output Category { }",
    ["category-alias"] = "category [CatA1] { CatAlias } category [CatA2] { CatAlias } output CatAlias { }",
    ["category-mods"] = "category [CatM1] { CatMods? } category [CatM2] { CatMods? } output CatMods { }",
    ["directive"] = "directive @Dir { inline } directive @Dir { spread }",
    ["directive-alias"] = "directive @DirAlias [DirA1] { variable } directive @DirAlias [DirA2] { field }",
    ["directive-params"] = "directive @DirParams(DirParamsIn) { operation } directive @DirParams { fragment } input DirParamsIn { }",
    ["option"] = "option Option { } option Option { }",
    ["option-alias"] = "option OptAlias [Opt1] { } option OptAlias [Opt2] { }",
    ["option-setting"] = "option OptSetting { setting=true } option OptSetting { setting=[0] }",
    ["enum-alias"] = "enum EnAlias [En1] { alias } enum EnAlias [En2] { alias }",
    ["enum-diff"] = "enum EnDiff { one } enum EnDiff { two }",
    ["enum-same"] = "enum EnSame { same } enum EnSame { same }",
    ["enum-same-parent"] = "enum EnSameParent { :EnParent sameP } enum EnSameParent { :EnParent sameP } enum EnParent { parent }",
    ["enum-value-alias"] = "enum EnValAlias { value [val1] } enum EnValAlias { value [val2] }",
    ["object"] = "object Obj { } object Obj { }",
    ["object-alias"] = "object ObjAlias [Obj1] { } object ObjAlias [Obj2] { }",
    ["object-alts"] = "object ObjAlts { | ObjAltsType } object ObjAlts { | ObjAltsType } object ObjAltsType { }",
    ["object-fields"] = "object ObjFields { field: ObjFields } object ObjFields { field: ObjFields }",
    ["object-fields-alias"] = "object FieldAlias { field [field1]: FieldAlias } object FieldAlias { field [field2]: FieldAlias }",
    ["output-fields-enums"] = "output FieldEnums { field = Boolean.true } output FieldEnums { field = true }",
    ["output-fields-enum-alias"] = "output FieldEnumAlias { field [field1] = Boolean.true } output FieldEnumAlias { field [field2] = true }",
    ["output-fields-params"] = "output FieldParams { field(FieldParam1): FieldParams } output FieldParams { field(FieldParam2): FieldParams } input FieldParam1 { } input FieldParam2 { }",
    ["object-params"] = "object ObjParams<$test> { test: $test } object ObjParams<$type> { type: $type }",
    ["object-parent"] = "object ObjPrnt { :PrntObj } object ObjPrnt { :PrntObj } object PrntObj { }",
    ["scalar-alias"] = "scalar NumAlias [Num1] { number } scalar NumAlias [Num2] { number }",
    ["scalar-number"] = "scalar Num { number } scalar Num { number }",
    ["scalar-number-diff"] = "scalar NumDiff { number 1~9 } scalar NumDiff { number }",
    ["scalar-number-same"] = "scalar NumSame { number 1~9 } scalar NumSame { number 1~9 }",
    ["scalar-string"] = "scalar Str { string } scalar Str { string }",
    ["scalar-string-diff"] = "scalar StrDiff { string /a+/ } scalar StrDiff { string }",
    ["scalar-string-same"] = "scalar StrSame { string /a+/ } scalar StrSame { string /a+/ }",
    ["scalar-union-diff"] = "scalar UnDiff { union | Boolean } scalar UnDiff { union | Number }",
    ["scalar-union-same"] = "scalar UnSame { union | Boolean } scalar UnSame { union | Boolean }",
  };

  public class SchemaValidMerges : TheoryData<string>
  {
    public SchemaValidMerges()
    {
      Add("category");
      Add("category-alias");
      Add("category-mods");
      Add("directive");
      Add("directive-alias");
      Add("directive-params");
      Add("option");
      Add("option-alias");
      Add("option-setting");
      Add("enum-alias");
      Add("enum-diff");
      Add("enum-same");
      Add("enum-same-parent");
      Add("enum-value-alias");
      Add("object");
      Add("object-alias");
      Add("object-alts");
      Add("object-fields");
      Add("object-fields-alias");
      Add("output-fields-enums");
      Add("output-fields-enum-alias");
      Add("output-fields-params");
      Add("object-params");
      Add("object-parent");
      Add("scalar-alias");
      Add("scalar-number");
      Add("scalar-number-diff");
      Add("scalar-number-same");
      Add("scalar-string");
      Add("scalar-string-diff");
      Add("scalar-string-same");
      Add("scalar-union-diff");
      Add("scalar-union-same");
    }
  }
  private static readonly Dictionary<string, string> s_schemaValidObjects = new() {
    ["alts-mods-Boolean"] = "object ObjAltMods { | ObjModsAlt[^] } object ObjModsAlt { }",
    ["fields-mods-Enum"] = "object ObjFieldMods { field: ObjFieldMods[ObjFieldEnum] } enum ObjFieldEnum { value }",
    ["generic-alt"] = "object ObjGenAlt<$type> { | $type }",
    ["generic-alt-arg"] = "object ObjGenAltArg<$type> { | ObjGenAltRef<$type> } object ObjGenAltRef<$ref> { | $ref }",
    ["generic-field-arg"] = "object ObjGenFieldArg<$type> { field: ObjGenFieldRef<$type> } object ObjGenFieldRef<$ref> { | $ref }",
    ["generic-field"] = "object ObjGenField<$type> { field: $type }",
    ["generic-parent-arg"] = "object ObjGenPrntArg<$type> { :ObjGenPrntRef<$type> } object ObjGenPrntRef<$ref> { | $ref }",
    ["generic-param"] = "object ObjGenParam { field: ObjGenParamRef<ObjGenParamAlt> } object ObjGenParamRef<$ref> { | $ref } object ObjGenParamAlt { }",
    ["generic-parent"] = "object ObjGenPrnt<$type> { :$type }",
    ["input-field-Enum"] = "input InFieldEnum { field: InEnumField = value } enum InEnumField { value }",
    ["input-field-Number"] = "input InFieldNum { field: Number = 0 }",
    ["input-field-String"] = "input InFieldStr { field: String = '' }",
    ["input-field-null"] = "input InFieldNull { field: InFieldNull? = null }",
    ["output-field-enum"] = "output OutFieldEnum { field = OutEnumField.outEnumField } enum OutEnumField { outEnumField }",
    ["output-field-enum-parent"] = "output OutFieldParent { field = OutEnumParented.outEnumParent } enum OutEnumParented { :OutEnumParent outParent ed } enum OutEnumParent { outEnumParent }",
    ["output-field-value"] = "output OutFieldValue { field = outEnumValue } enum OutEnumValue { outEnumValue }",
    ["output-generic-enum"] = "output OutGenEnum { | OutGenEnumRef<OutEnumGen.outEnumGen> } output OutGenEnumRef<$type> { field: $type } enum OutEnumGen { outEnumGen }",
    ["output-generic-parent"] = "output OutGenParent { | OutGenParentRef<OutParentGen.outGenParent> } output OutGenParentRef<$type> { field: $type } enum OutParentGen { :OutPrntendedGen outGenPrntended } enum OutPrntendedGen { outGenParent }",
    ["output-generic-value"] = "output OutGenValue { | OutGenValueRef<outValueGen> } output OutGenValueRef<$type> { field: $type } enum OutValueGen { outValueGen }",
    ["output-params"] = "output OutParams { field(OutParam): OutParams } input OutParam { }",
    ["output-params-mods-Scalar"] = "output OutParamsScalar { field(OutParamScalar[OutScalarParam]): OutParamsScalar } input OutParamScalar { } scalar OutScalarParam { number 1 ~ 10 }",
    ["output-parent-params"] = "output OutPrntParams { :OutParamsParent field(OutPrntParam): OutPrntParams } output OutParamsParent { field(OutParamParent): OutPrntParams } input OutPrntParam { } input OutParamParent { }",
    ["parent"] = "object ObjTestParent { :ObjParentTest } object ObjParentTest { }",
    ["parent-alts"] = "object ObjPrntAlt { :ObjAltPrnt | Number } object ObjAltPrnt { | String }",
    ["parent-fields"] = "object ObjPrntFields { :ObjFieldsParent field: Number } object ObjFieldsParent { parent: String }",
    ["parent-params-diff"] = "object ObjPrntPrmsDiff<$a> { :ObjPrmsPrntDiff<$a> field: $a } object ObjPrmsPrntDiff<$b> { | $b }",
    ["parent-params-same"] = "object ObjPrntPrmsSame<$a> { :ObjPrmsPrntSame<$a> field: $a } object ObjPrmsPrntSame<$a> { | $a }",
  };

  public class SchemaValidObjects : TheoryData<string>
  {
    public SchemaValidObjects()
    {
      Add("alts-mods-Boolean");
      Add("fields-mods-Enum");
      Add("generic-alt");
      Add("generic-alt-arg");
      Add("generic-field-arg");
      Add("generic-field");
      Add("generic-parent-arg");
      Add("generic-param");
      Add("generic-parent");
      Add("input-field-Enum");
      Add("input-field-Number");
      Add("input-field-String");
      Add("input-field-null");
      Add("output-field-enum");
      Add("output-field-enum-parent");
      Add("output-field-value");
      Add("output-generic-enum");
      Add("output-generic-parent");
      Add("output-generic-value");
      Add("output-params");
      Add("output-params-mods-Scalar");
      Add("output-parent-params");
      Add("parent");
      Add("parent-alts");
      Add("parent-fields");
      Add("parent-params-diff");
      Add("parent-params-same");
    }
  }
  private static readonly Dictionary<string, string> s_schemaValidSchemas = new() {
    ["category-output"] = "category { Cat } output Cat { }",
    ["directive-param"] = "directive @DirParam(DirParamIn) { all } input DirParamIn { }",
    ["enum-parent"] = "enum EnTestPrnt { :EnPrntTest valPrnt } enum EnPrntTest { valTest }",
    ["enum-parent-alias"] = "enum EnPrntAlias { :EnAliasPrnt valPrnt valAlias[alias] } enum EnAliasPrnt { valAlias }",
    ["enum-parent-dup"] = "enum EnPrntDup { :EnDupPrnt valPrnt  } enum EnDupPrnt { valDup[valPrnt] }",
    ["scalar-enum-all"] = "scalar ScalEnumAll { enum EnumScalAll.* } enum EnumScalAll { scal_all scal_enum_all }",
    ["scalar-enum-all-parent"] = "scalar ScalEnumAllParent { enum EnumScalAllParent.* } enum EnumScalAllParent { :EnumScalParentAll scal_all } enum EnumScalParentAll { scal_enum_all }",
    ["scalar-enum-member"] = "scalar ScalMember { enum scal_member } enum MemberScal { scal_member }",
    ["scalar-enum-parent"] = "scalar ScalEnumPrnt { :ScalPrntEnum Enum scal_enum } scalar ScalPrntEnum { Enum scal_parent } enum EnumScalPrnt { scal_enum scal_parent }",
    ["scalar-enum-unique"] = "scalar ScalEnumUnique { enum EnumScalUnique.* !EnumScalUnique.dup EnumScalDup.dup } enum EnumScalUnique { value dup } enum EnumScalDup { dup }",
    ["scalar-enum-unique-parent"] = "scalar ScalEnumUniqueParent { enum EnumScalUniqueParent.* !EnumScalUniqueParent.dup EnumScalDupParent.dup } enum EnumScalUniqueParent { :EnumScalParentUnique value } enum EnumScalParentUnique { dup } enum EnumScalDupParent { dup }",
    ["scalar-enum-value"] = "scalar ScalEnum { Enum EnumScal.scal_enum } enum EnumScal { scal_enum }",
    ["scalar-enum-value-parent"] = "scalar ScalEnumParent { Enum EnumScalParent.scal_enum } enum EnumScalParent { :EnumParentScal scal_parent } enum EnumParentScal { scal_enum }",
    ["scalar-number-parent"] = "scalar ScalNumPrnt { :ScalPrntNum Number 2>} scalar ScalPrntNum { Number <2 }",
    ["scalar-parent"] = "scalar ScalPrntTest { :ScalTestPrnt Boolean } scalar ScalTestPrnt { Boolean }",
    ["scalar-string-parent"] = "scalar ScalStrPrnt { :ScalPrntStr String /a+/ } scalar ScalPrntStr { String /b+/ }",
    ["scalar-union-parent"] = "scalar ScalUnionPrnt { :ScalPrntUnion Union | String } scalar ScalPrntUnion { Union | Number }",
  };

  public class SchemaValidSchemas : TheoryData<string>
  {
    public SchemaValidSchemas()
    {
      Add("category-output");
      Add("directive-param");
      Add("enum-parent");
      Add("enum-parent-alias");
      Add("enum-parent-dup");
      Add("scalar-enum-all");
      Add("scalar-enum-all-parent");
      Add("scalar-enum-member");
      Add("scalar-enum-parent");
      Add("scalar-enum-unique");
      Add("scalar-enum-unique-parent");
      Add("scalar-enum-value");
      Add("scalar-enum-value-parent");
      Add("scalar-number-parent");
      Add("scalar-parent");
      Add("scalar-string-parent");
      Add("scalar-union-parent");
    }
  }
}
