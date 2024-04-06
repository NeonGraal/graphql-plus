
// Generated from .\test\GqlPlus.Verifier.ComponentTests\Verification\Schema

namespace GqlPlus.Verifier.Verification;

public class VerifySchemaInvalidObjectsData
  : TheoryData<string>
{
  public static readonly Dictionary<string, string> Source = new() {
    ["alts-diff-mods"] = "object Test { | Test1 } object Test { | Test1[] } object Test1 { }",
    ["alts-mods-undef"] = "object Test { | Alt[Scalar] } object Alt { }",
    ["alts-mods-wrong"] = "object Test { | Alt[Test] } object Alt { }",
    ["alts-more"] = "object Test { | Recurse } object Recurse { | More } object More { | Test }",
    ["alts-recurse"] = "object Test { | Recurse } object Recurse { | Test }",
    ["alts-self"] = "object Test { | Test }",
    ["dual-alt-input"] = "dual Test { | Bad } input Bad { }",
    ["dual-alt-output"] = "dual Test { | Bad } output Bad { }",
    ["dual-alt-param-input"] = "dual Test { | Param<Bad> } dual Param<$T> { | $T } input Bad { }",
    ["dual-alt-param-output"] = "dual Test { | Param<Bad> } dual Param<$T> { | $T } output Bad { }",
    ["dual-field-input"] = "dual Test { field: Bad } input Bad { }",
    ["dual-field-output"] = "dual Test { field: Bad } output Bad { }",
    ["dual-field-param-input"] = "dual Test { field: Param<Bad> } dual Param<$T> { | $T } input Bad { }",
    ["dual-field-param-output"] = "dual Test { field: Param<Bad> } dual Param<$T> { | $T } output Bad { }",
    ["dual-parent-input"] = "dual Test { :Bad } input Bad { }",
    ["dual-parent-output"] = "dual Test { :Bad } output Bad { }",
    ["dual-parent-param-input"] = "dual Test { :Param<Bad> } dual Param<$T> { | $T } input Bad { }",
    ["dual-parent-param-output"] = "dual Test { :Param<Bad> } dual Param<$T> { | $T } output Bad { }",
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
    ["input-alt-output"] = "input Test { | Bad } output Bad { }",
    ["input-field-null"] = "input Test { field: Test = null }",
    ["input-field-output"] = "input Test { field: Bad } output Bad { }",
    ["input-parent-output"] = "input Test { :Bad } output Bad { }",
    ["output-alt-input"] = "output Test { | Bad } input Bad { }",
    ["output-enum-bad"] = "output Test { field = unknown }",
    ["output-enums-diff"] = "output Test { field = true } output Test { field = false }",
    ["output-enumValue-bad"] = "output Test { field = Boolean.unknown }",
    ["output-enumValue-wrong"] = "output Test { field = Wrong.unknown } input Wrong { }",
    ["output-field-input"] = "output Test { field: Bad } input Bad { }",
    ["output-generic-enum-bad"] = "output Test { | Ref<Boolean.unknown> } output Ref<$type> { field: $type }",
    ["output-generic-enum-wrong"] = "output Test { | Ref<Wrong.unknown> } output Ref<$type> { field: $type } output Wrong { }",
    ["output-params-diff"] = "output Test { field(Param): Test } output Test { field(Param?): Test } input Param { }",
    ["output-params-mods-undef"] = "output Test { field(Param[Scalar]): Test } input Param { }",
    ["output-params-mods-wrong"] = "output Test { field(Param[Test]): Test } input Param { }",
    ["output-params-undef"] = "output Test { field(Param): Test }",
    ["output-parent-input"] = "output Test { :Bad } input Bad { }",
    ["parent-alt-mods"] = "object Test { :Parent } object Test { | Alt } object Parent { | Alt[] } object Alt { }",
    ["parent-alt-more"] = "object Test { :Recurse | Alt } object Recurse { :More } object More { :Parent } object Parent { | Alt[] } object Alt { }",
    ["parent-alt-recurse"] = "object Test { :Recurse | Alt } object Recurse { :Parent } object Parent { | Alt[] } object Alt { }",
    ["parent-alt-self"] = "object Test { :Alt } object Alt { | Test }",
    ["parent-alt-self-more"] = "object Test { :Alt } object Alt { | More } object More { :Recurse } object Recurse { | Test }",
    ["parent-alt-self-recurse"] = "object Test { :Alt } object Alt { | Recurse } object Recurse { :Test }",
    ["parent-fields-alias"] = "object Test { :Parent } object Test { field1[alias]: Test } object Parent { field2[alias]: Parent }",
    ["parent-fields-alias-more"] = "object Test { :Recurse field1[alias]: Test } object Recurse { :More } object More { :Parent } object Parent { field2[alias]: Parent }",
    ["parent-fields-alias-recurse"] = "object Test { :Recurse field1[alias]: Test } object Recurse { :Parent } object Parent { field2[alias]: Parent }",
    ["parent-fields-mods"] = "object Test { :Parent } object Test { field: Test } object Parent { field: Test[] }",
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

  public VerifySchemaInvalidObjectsData()
  {
    foreach (var key in Source.Keys) {
      Add(key);
    }
  }
}

public class VerifySchemaInvalidSchemasData
  : TheoryData<string>
{
  public static readonly Dictionary<string, string> Source = new() {
    ["bad-parse"] = "",
    ["category-diff-mods"] = "category { Test } category { Test? } output Test { }",
    ["category-dup-alias"] = "category [a] { Test } category [a] { Output } output Test { } output Output { }",
    ["category-duplicate"] = "category { Test } category test { Output } output Test { } output Output { }",
    ["category-output-generic"] = "category { Test } output Test<$a> { | $a }",
    ["category-output-undef"] = "category { Test }",
    ["category-output-wrong"] = "category { Test } input Test { }",
    ["directive-diff-option"] = "directive @Test { all } directive @Test { ( repeatable ) all }",
    ["directive-diff-parameter"] = "directive @Test(Test) { all } directive @Test(Test?) { all } input Test { }",
    ["directive-no-param"] = "directive @Test(Test) { all }",
    ["option-diff-name"] = "option Test { } option Schema { }",
  };

  public VerifySchemaInvalidSchemasData()
  {
    foreach (var key in Source.Keys) {
      Add(key);
    }
  }
}

public class VerifySchemaInvalidTypesData
  : TheoryData<string>
{
  public static readonly Dictionary<string, string> Source = new() {
    ["enum-dup-alias"] = "enum Test [a] { test } enum Dup [a] { dup }",
    ["enum-parent-alias-dup"] = "enum Test { :Parent test[alias] } enum Parent { parent[alias] }",
    ["enum-parent-diff"] = "enum Test { :Parent test } enum Test { test } enum Parent { parent }",
    ["enum-parent-undef"] = "enum Test { :Parent test }",
    ["enum-parent-wrong"] = "enum Test { :Parent test } output Parent { }",
    ["scalar-diff-kind"] = "scalar Test { string } scalar Test { number }",
    ["scalar-dup-alias"] = "scalar Test [a] { Boolean } scalar Dup [a] { Boolean }",
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
    ["scalar-parent-self"] = "scalar Test { :Test Boolean }",
    ["scalar-parent-self-more"] = "scalar Test { :Parent Boolean } scalar Parent { :Recurse Boolean } scalar Recurse { :More Boolean } scalar More { :Test Boolean }",
    ["scalar-parent-self-parent"] = "scalar Test { :Parent Boolean } scalar Parent { :Test Boolean }",
    ["scalar-parent-self-recurse"] = "scalar Test { :Parent Boolean } scalar Parent { :Recurse Boolean } scalar Recurse { :Test Boolean }",
    ["scalar-parent-undef"] = "scalar Test { :Parent Boolean }",
    ["scalar-parent-wrong-kind"] = "scalar Test { :Parent Boolean } scalar Parent { String }",
    ["scalar-parent-wrong-type"] = "scalar Test { :Parent Boolean } output Parent { }",
    ["scalar-string-diff"] = "scalar Test { string /a+/} scalar Test { string !/a+/ }",
    ["scalar-string-parent"] = "scalar Test { :Parent string /a+/} scalar Parent { string !/a+/ }",
    ["union-more"] = "union Test { Bad } union Bad { More } union More { Test }",
    ["union-more-parent"] = "union Test { Recurse } union Recurse { :Parent } union Parent { More } union More { :Bad } union Bad { Test }",
    ["union-parent"] = "union Test { :Parent } union Parent { Test }",
    ["union-parent-more"] = "union Test { :Parent } union Parent { More } union More { :Bad } union Bad { Test }",
    ["union-parent-recurse"] = "union Test { :Parent } union Parent { Bad } union Bad { Test }",
    ["union-recurse"] = "union Test { Bad } union Bad { Test }",
    ["union-recurse-parent"] = "union Test { Bad } union Bad { :Parent } union Parent { Test }",
    ["union-self"] = "union Test { Test }",
    ["union-undef"] = "union Test { Bad }",
    ["union-wrong"] = "union Test { Bad } input Bad { }",
    ["unique-type-alias"] = "enum Test [a] { Value } output Dup [a] { }",
    ["unique-types"] = "enum Test { Value } output Test { }",
  };

  public VerifySchemaInvalidTypesData()
  {
    foreach (var key in Source.Keys) {
      Add(key);
    }
  }
}

public class VerifySchemaValidMergesData
  : TheoryData<string>
{
  public static readonly Dictionary<string, string> Source = new() {
    ["category"] = "category { Category } category category { Category } output Category { }",
    ["category-alias"] = "category [CatA1] { CatAlias } category [CatA2] { CatAlias } output CatAlias { }",
    ["category-mods"] = "category [CatM1] { CatMods? } category [CatM2] { CatMods? } output CatMods { }",
    ["directive"] = "directive @Dir { inline } directive @Dir { spread }",
    ["directive-alias"] = "directive @DirAlias [DirA1] { variable } directive @DirAlias [DirA2] { field }",
    ["directive-params"] = "directive @DirParams(DirParamsIn) { operation } directive @DirParams { fragment } input DirParamsIn { }",
    ["enum-alias"] = "enum EnAlias [En1] { alias } enum EnAlias [En2] { alias }",
    ["enum-diff"] = "enum EnDiff { one } enum EnDiff { two }",
    ["enum-same"] = "enum EnSame { same } enum EnSame { same }",
    ["enum-same-parent"] = "enum EnSameParent { :EnParent sameP } enum EnSameParent { :EnParent sameP } enum EnParent { parent }",
    ["enum-value-alias"] = "enum EnValAlias { value [val1] } enum EnValAlias { value [val2] }",
    ["object"] = "object Obj { } object Obj { }",
    ["object-alias"] = "object ObjAlias [Obj1] { } object ObjAlias [Obj2] { }",
    ["object-alts"] = "object ObjAlts { | ObjAltsType } object ObjAlts { | ObjAltsType } object ObjAltsType { }",
    ["object-fields"] = "object ObjFields { field: ObjFields } object ObjFields { field: ObjFields }",
    ["object-fields-alias"] = "object ObjFieldAlias { field [field1]: ObjFieldAlias } object ObjFieldAlias { field [field2]: ObjFieldAlias }",
    ["object-params"] = "object ObjParams<$test> { test: $test } object ObjParams<$type> { type: $type }",
    ["object-parent"] = "object ObjPrnt { :PrntObj } object ObjPrnt { :PrntObj } object PrntObj { }",
    ["option"] = "option Option { } option Option { }",
    ["option-alias"] = "option OptAlias [Opt1] { } option OptAlias [Opt2] { }",
    ["option-setting"] = "option OptSetting { setting=true } option OptSetting { setting=[0] }",
    ["output-fields-enum-alias"] = "output FieldEnumAlias { field [field1] = Boolean.true } output FieldEnumAlias { field [field2] = true }",
    ["output-fields-enums"] = "output FieldEnums { field = Boolean.true } output FieldEnums { field = true }",
    ["output-fields-params"] = "output FieldParams { field(FieldParam1): FieldParams } output FieldParams { field(FieldParam2): FieldParams } input FieldParam1 { } input FieldParam2 { }",
    ["scalar-alias"] = "scalar NumAlias [Num1] { number } scalar NumAlias [Num2] { number }",
    ["scalar-number"] = "scalar Num { number } scalar Num { number }",
    ["scalar-number-diff"] = "scalar NumDiff { number 1~9 } scalar NumDiff { number }",
    ["scalar-number-same"] = "scalar NumSame { number 1~9 } scalar NumSame { number 1~9 }",
    ["scalar-string"] = "scalar Str { string } scalar Str { string }",
    ["scalar-string-diff"] = "scalar StrDiff { string /a+/ } scalar StrDiff { string }",
    ["scalar-string-same"] = "scalar StrSame { string /a+/ } scalar StrSame { string /a+/ }",
    ["union-diff"] = "union UnDiff { Boolean } union UnDiff { Number }",
    ["union-same"] = "union UnSame { Boolean } union UnSame { Boolean }",
  };

  public VerifySchemaValidMergesData()
  {
    foreach (var key in Source.Keys) {
      Add(key);
    }
  }
}

public class VerifySchemaValidObjectsData
  : TheoryData<string>
{
  public static readonly Dictionary<string, string> Source = new() {
    ["alts"] = "object ObjAlts { | ObjAlt } object ObjAlt { }",
    ["alts-dual"] = "object ObjAltsDual { | ObjAltDual } dual ObjAltDual { }",
    ["alts-mods-Boolean"] = "object ObjAltMods { | ObjModsAlt[^] } object ObjModsAlt { }",
    ["fields"] = "object FieldsObj { field: ObjField } object ObjField { }",
    ["fields-dual"] = "object ObjFieldsDual { field: ObjFieldDual } dual ObjFieldDual { }",
    ["fields-mods-Enum"] = "object ObjFieldMods { field: ObjFieldMods[ObjFieldEnum] } enum ObjFieldEnum { value }",
    ["generic-alt"] = "object ObjGenAlt<$type> { | $type }",
    ["generic-alt-arg"] = "object ObjGenAltArg<$type> { | ObjGenAltRef<$type> } object ObjGenAltRef<$ref> { | $ref }",
    ["generic-alt-dual"] = "object ObjGenAltDual { | ObjGenAltDualRef<ObjGenAltDualAlt> } object ObjGenAltDualRef<$ref> { | $ref } dual ObjGenAltDualAlt { }",
    ["generic-alt-param"] = "object ObjGenAltParam { | ObjGenAltParamRef<ObjGenAltParamAlt> } object ObjGenAltParamRef<$ref> { | $ref } object ObjGenAltParamAlt { }",
    ["generic-dual"] = "object ObjGenDual { field: ObjGenDualRef<ObjGenDualAlt> } object ObjGenDualRef<$ref> { | $ref } dual ObjGenDualAlt { }",
    ["generic-field"] = "object ObjGenField<$type> { field: $type }",
    ["generic-field-arg"] = "object ObjGenFieldArg<$type> { field: ObjGenFieldRef<$type> } object ObjGenFieldRef<$ref> { | $ref }",
    ["generic-field-dual"] = "object ObjGenFieldDual { field: ObjGenFieldDualRef<ObjGenFieldDualAlt> } object ObjGenFieldDualRef<$ref> { | $ref } dual ObjGenFieldDualAlt { }",
    ["generic-field-param"] = "object ObjGenFieldParam { field: ObjGenFieldParamRef<ObjGenFieldParamAlt> } object ObjGenFieldParamRef<$ref> { | $ref } object ObjGenFieldParamAlt { }",
    ["generic-param"] = "object ObjGenParam { field: ObjGenParamRef<ObjGenParamAlt> } object ObjGenParamRef<$ref> { | $ref } object ObjGenParamAlt { }",
    ["generic-parent"] = "object ObjGenPrnt<$type> { :$type }",
    ["generic-parent-arg"] = "object ObjGenPrntArg<$type> { :ObjGenPrntRef<$type> } object ObjGenPrntRef<$ref> { | $ref }",
    ["generic-parent-dual"] = "object ObjGenParentDual { :ObjGenParentDualRef<ObjGenParentDualAlt> } object ObjGenParentDualRef<$ref> { | $ref } dual ObjGenParentDualAlt { }",
    ["generic-parent-param"] = "object ObjGenParentParam { :ObjGenParentParamRef<ObjGenParentParamAlt> } object ObjGenParentParamRef<$ref> { | $ref } object ObjGenParentParamAlt { }",
    ["input-field-Enum"] = "input InFieldEnum { field: InEnumField = value } enum InEnumField { value }",
    ["input-field-null"] = "input InFieldNull { field: InFieldNull? = null }",
    ["input-field-Number"] = "input InFieldNum { field: Number = 0 }",
    ["input-field-String"] = "input InFieldStr { field: String = '' }",
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
    ["parent-dual"] = "object ObjTestPrntDual { :ObjPrntDualTest } dual ObjPrntDualTest { }",
    ["parent-fields"] = "object ObjPrntFields { :ObjFieldsParent field: Number } object ObjFieldsParent { parent: String }",
    ["parent-params-diff"] = "object ObjPrntPrmsDiff<$a> { :ObjPrmsPrntDiff<$a> field: $a } object ObjPrmsPrntDiff<$b> { | $b }",
    ["parent-params-same"] = "object ObjPrntPrmsSame<$a> { :ObjPrmsPrntSame<$a> field: $a } object ObjPrmsPrntSame<$a> { | $a }",
  };

  public VerifySchemaValidObjectsData()
  {
    foreach (var key in Source.Keys) {
      Add(key);
    }
  }
}

public class VerifySchemaValidSchemasData
  : TheoryData<string>
{
  public static readonly Dictionary<string, string> Source = new() {
    ["category-output"] = "category { Cat } output Cat { }",
    ["directive-param"] = "directive @DirParam(DirParamIn) { all } input DirParamIn { }",
    ["option-setting"] = "option Schema { setting = true }",
  };

  public VerifySchemaValidSchemasData()
  {
    foreach (var key in Source.Keys) {
      Add(key);
    }
  }
}

public class VerifySchemaValidTypesData
  : TheoryData<string>
{
  public static readonly Dictionary<string, string> Source = new() {
    ["enum-parent"] = "enum EnTestPrnt { :EnPrntTest valPrnt } enum EnPrntTest { valTest }",
    ["enum-parent-alias"] = "enum EnPrntAlias { :EnAliasPrnt valPrnt valAlias[alias] } enum EnAliasPrnt { valAlias }",
    ["enum-parent-dup"] = "enum EnPrntDup { :EnDupPrnt valPrnt  } enum EnDupPrnt { valDup[valPrnt] }",
    ["scalar-enum-all"] = "scalar ScalEnumAll { enum EnumScalAll.* } enum EnumScalAll { scal_all scal_enum_all }",
    ["scalar-enum-all-parent"] = "scalar ScalEnumAllParent { enum EnumScalAllParent.* } enum EnumScalAllParent { :EnumScalParentAll scal_all } enum EnumScalParentAll { scal_enum_all }",
    ["scalar-enum-member"] = "scalar ScalMember { enum scal_member } enum MemberScal { scal_member }",
    ["scalar-enum-parent"] = "scalar ScalEnumPrnt { :ScalPrntEnum Enum scal_enum } scalar ScalPrntEnum { Enum scal_parent } enum EnumScalPrnt { scal_enum scal_parent }",
    ["scalar-enum-unique"] = "enum EnumScalUnique { value dup } enum EnumScalDup { dup } # scalar ScalEnumUnique { enum EnumScalUnique.* !EnumScalUnique.dup EnumScalDup.dup }",
    ["scalar-enum-unique-parent"] = "enum EnumScalUniqueParent { :EnumScalParentUnique value } enum EnumScalParentUnique { dup } enum EnumScalDupParent { dup } # scalar ScalEnumUniqueParent { enum EnumScalUniqueParent.* !EnumScalUniqueParent.dup EnumScalDupParent.dup }",
    ["scalar-enum-value"] = "scalar ScalEnum { Enum EnumScal.scal_enum } enum EnumScal { scal_enum }",
    ["scalar-enum-value-parent"] = "scalar ScalEnumParent { Enum EnumScalParent.scal_enum } enum EnumScalParent { :EnumParentScal scal_parent } enum EnumParentScal { scal_enum }",
    ["scalar-number-parent"] = "scalar ScalNumPrnt { :ScalPrntNum Number 2>} scalar ScalPrntNum { Number <2 }",
    ["scalar-parent"] = "scalar ScalPrntTest { :ScalTestPrnt Boolean } scalar ScalTestPrnt { Boolean }",
    ["scalar-string-parent"] = "scalar ScalStrPrnt { :ScalPrntStr String /a+/ } scalar ScalPrntStr { String /b+/ }",
    ["union-parent"] = "union UnionPrnt { :PrntUnion String } union PrntUnion { Number }",
  };

  public VerifySchemaValidTypesData()
  {
    foreach (var key in Source.Keys) {
      Add(key);
    }
  }
}
