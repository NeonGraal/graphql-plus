﻿// Generated from .\test\GqlPlus.ComponentTestBase\Schema

namespace GqlPlus;

public class SchemaInvalidGlobalsData
  : TheoryData<string>
{
  public static readonly Dictionary<string, string> Source = new() {
    ["bad-parse"] = "",
    ["category-diff-mods"] = "category { Test } category { Test? } output Test { }",
    ["category-dup-alias"] = "category [a] { Test } category [a] { Output } output Test { } output Output { }",
    ["category-duplicate"] = "category { Test } category test { Output } output Test { } output Output { }",
    ["category-output-generic"] = "category { Test } output Test<$a> { | $a }",
    ["category-output-mod-param"] = "category { Test[$a] } output Test { }",
    ["category-output-undef"] = "category { Test }",
    ["category-output-wrong"] = "category { Test } input Test { }",
    ["directive-diff-option"] = "directive @Test { all } directive @Test { ( repeatable ) all }",
    ["directive-diff-param"] = "directive @Test(Test) { all } directive @Test(Test?) { all } input Test { }",
    ["directive-no-param"] = "directive @Test(Test) { all }",
    ["directive-param-mod-param"] = "directive @Test(TestIn[$a]) { all } input TestIn { }",
    ["option-diff-name"] = "option Test { } option Schema { }",
  };

  public SchemaInvalidGlobalsData()
  {
    foreach (string key in Source.Keys) {
      Add(key);
    }
  }
}

public class SchemaInvalidObjectsData
  : TheoryData<string>
{
  public static readonly Dictionary<string, string> Source = new() {
    ["alts-diff-mods"] = "object Test { | Test1 } object Test { | Test1[] } object Test1 { }",
    ["alts-mods-undef"] = "object Test { | Alt[Domain] } object Alt { }",
    ["alts-mods-undef-param"] = "object Test { | Alt[$a] } object Alt { }",
    ["alts-mods-wrong"] = "object Test { | Alt[Test] } object Alt { }",
    ["alts-more"] = "object Test { | Recurse } object Recurse { | More } object More { | Test }",
    ["alts-recurse"] = "object Test { | Recurse } object Recurse { | Test }",
    ["alts-self"] = "object Test { | Test }",
    ["alts-simple-param"] = "object Test { | Number<String> }",
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
    ["fields-mods-undef-param"] = "object Test { field: Test[$a] }",
    ["fields-mods-wrong"] = "object Test { field: Test[Test] }",
    ["fields-simple-param"] = "object Test { field: String<0> }",
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
    ["output-params-mods-undef"] = "output Test { field(Param[Domain]): Test } input Param { }",
    ["output-params-mods-undef-param"] = "output Test { field(Param[$a]): Test } input Param { }",
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
    ["parent-simple"] = "object Test { :String }",
    ["parent-undef"] = "object Test { :Parent }",
    ["unique-alias"] = "object Test [a] { } object Dup [a] { }",
  };

  public SchemaInvalidObjectsData()
  {
    foreach (string key in Source.Keys) {
      Add(key);
    }
  }
}

public class SchemaInvalidSimpleData
  : TheoryData<string>
{
  public static readonly Dictionary<string, string> Source = new() {
    ["domain-diff-kind"] = "domain Test { string } domain Test { number }",
    ["domain-dup-alias"] = "domain Test [a] { Boolean } domain Dup [a] { Boolean }",
    ["domain-enum-none"] = "domain Test { Enum }",
    ["domain-enum-parent-unique"] = "domain Test { :Parent Enum Enum.value } domain Parent { Enum Dup.value } enum Enum { value } enum Dup { value }",
    ["domain-enum-undef"] = "domain Test { enum undef }",
    ["domain-enum-undef-all"] = "domain Test { enum Undef.* }",
    ["domain-enum-undef-member"] = "domain Test { enum Enum.undef } enum Enum { value }",
    ["domain-enum-undef-value"] = "domain Test { enum Undef.value }",
    ["domain-enum-unique"] = "domain Test { enum Enum.value Dup.value } enum Enum { value } enum Dup { value }",
    ["domain-enum-unique-all"] = "domain Test { enum Enum.* Dup.* } enum Enum { value } enum Dup { value }",
    ["domain-enum-unique-member"] = "domain Test { enum Enum.value Dup.* } enum Enum { value } enum Dup { value }",
    ["domain-enum-wrong"] = "domain Test { enum Bad.value } output Bad { }",
    ["domain-number-parent"] = "domain Test { :Parent number 1> } domain Parent { number !1> }",
    ["domain-parent-self"] = "domain Test { :Test Boolean }",
    ["domain-parent-self-more"] = "domain Test { :Parent Boolean } domain Parent { :Recurse Boolean } domain Recurse { :More Boolean } domain More { :Test Boolean }",
    ["domain-parent-self-parent"] = "domain Test { :Parent Boolean } domain Parent { :Test Boolean }",
    ["domain-parent-self-recurse"] = "domain Test { :Parent Boolean } domain Parent { :Recurse Boolean } domain Recurse { :Test Boolean }",
    ["domain-parent-undef"] = "domain Test { :Parent Boolean }",
    ["domain-parent-wrong-kind"] = "domain Test { :Parent Boolean } domain Parent { String }",
    ["domain-parent-wrong-type"] = "domain Test { :Parent Boolean } output Parent { }",
    ["domain-string-diff"] = "domain Test { string /a+/} domain Test { string !/a+/ }",
    ["domain-string-parent"] = "domain Test { :Parent string /a+/} domain Parent { string !/a+/ }",
    ["enum-dup-alias"] = "enum Test [a] { test } enum Dup [a] { dup }",
    ["enum-parent-alias-dup"] = "enum Test { :Parent test[alias] } enum Parent { parent[alias] }",
    ["enum-parent-diff"] = "enum Test { :Parent test } enum Test { test } enum Parent { parent }",
    ["enum-parent-undef"] = "enum Test { :Parent test }",
    ["enum-parent-wrong"] = "enum Test { :Parent test } output Parent { }",
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

  public SchemaInvalidSimpleData()
  {
    foreach (string key in Source.Keys) {
      Add(key);
    }
  }
}

public class SchemaValidGlobalsData
  : TheoryData<string>
{
  public static readonly Dictionary<string, string> Source = new() {
    ["category-output"] = "category { Cat } output Cat { }",
    ["category-output-dict"] = "category { CatDict[*] } output CatDict { }",
    ["category-output-list"] = "category { CatList[] } output CatList { }",
    ["category-output-optional"] = "category { CatOpt? } output CatOpt { }",
    ["description"] = "\"A simple description\" output Descr { }",
    ["description-backslash"] = "'A backslash (\"\\\\\") description' output DescrBackslash { }",
    ["description-between"] = "category { DescrBetween } \"A description between\" output DescrBetween { }",
    ["description-complex"] = "\"A \\\"more\\\" 'Complicated' \\\\ description\" output DescrComplex { }",
    ["description-double"] = "\"A 'double-quoted' description\" output DescrDouble { }",
    ["description-single"] = "'A \"single-quoted\" description' output DescrSingle { }",
    ["directive-param"] = "directive @DirParam(DirParamIn) { all } input DirParamIn { }",
    ["directive-param-dict"] = "directive @DirParamDict(DirParamIn[String]) { all } input DirParamIn { }",
    ["directive-param-list"] = "directive @DirParamList(DirParamIn[]) { all } input DirParamIn { }",
    ["directive-param-opt"] = "directive @DirParamOpt(DirParamIn?) { all } input DirParamIn { }",
    ["option-setting"] = "option Schema { setting = true }",
  };

  public SchemaValidGlobalsData()
  {
    foreach (string key in Source.Keys) {
      Add(key);
    }
  }
}

public class SchemaValidMergesData
  : TheoryData<string>
{
  public static readonly Dictionary<string, string> Source = new() {
    ["category"] = "category { Category } category category { Category } output Category { }",
    ["category-alias"] = "category [CatA1] { CatAlias } category [CatA2] { CatAlias } output CatAlias { }",
    ["category-mods"] = "category [CatM1] { CatMods? } category [CatM2] { CatMods? } output CatMods { }",
    ["directive"] = "directive @Dir { inline } directive @Dir { spread }",
    ["directive-alias"] = "directive @DirAlias [DirA1] { variable } directive @DirAlias [DirA2] { field }",
    ["directive-params"] = "directive @DirParams(DirParamsIn) { operation } directive @DirParams { fragment } input DirParamsIn { }",
    ["domain-alias"] = "domain NumAlias [Num1] { number } domain NumAlias [Num2] { number }",
    ["domain-boolean"] = "domain Bool { boolean } domain Bool { boolean }",
    ["domain-boolean-diff"] = "domain BoolDiff { boolean true } domain BoolDiff { boolean false }",
    ["domain-boolean-same"] = "domain BoolSame { boolean true } domain BoolSame { boolean true }",
    ["domain-enum-diff"] = "domain EnumDiff { enum true } domain EnumDiff { enum false }",
    ["domain-enum-same"] = "domain EnumSame { enum true } domain EnumSame { enum true }",
    ["domain-number"] = "domain Num { number } domain Num { number }",
    ["domain-number-diff"] = "domain NumDiff { number 1~9 } domain NumDiff { number }",
    ["domain-number-same"] = "domain NumSame { number 1~9 } domain NumSame { number 1~9 }",
    ["domain-string"] = "domain Str { string } domain Str { string }",
    ["domain-string-diff"] = "domain StrDiff { string /a+/ } domain StrDiff { string }",
    ["domain-string-same"] = "domain StrSame { string /a+/ } domain StrSame { string /a+/ }",
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
    ["option"] = "option Schema { } option Schema { }",
    ["option-alias"] = "option Schema [Opt1] { } option Schema [Opt2] { }",
    ["option-value"] = "option Schema { setting=true } option Schema { setting=[0] }",
    ["output-fields-enum-alias"] = "output FieldEnumAlias { field [field1] = Boolean.true } output FieldEnumAlias { field [field2] = true }",
    ["output-fields-enums"] = "output FieldEnums { field = Boolean.true } output FieldEnums { field = true }",
    ["output-fields-params"] = "output FieldParams { field(FieldParam1): FieldParams } output FieldParams { field(FieldParam2): FieldParams } input FieldParam1 { } input FieldParam2 { }",
    ["union-diff"] = "union UnDiff { Boolean } union UnDiff { Number }",
    ["union-same"] = "union UnSame { Boolean } union UnSame { Boolean }",
  };

  public SchemaValidMergesData()
  {
    foreach (string key in Source.Keys) {
      Add(key);
    }
  }
}

public class SchemaValidObjectsData
  : TheoryData<string>
{
  public static readonly Dictionary<string, string> Source = new() {
    ["alts"] = "object ObjAlts { | ObjAlt } object ObjAlt { alt: Number | String }",
    ["alts-dual"] = "object ObjAltsDual { | ObjAltDual } dual ObjAltDual { alt: Number | String }",
    ["alts-mods-Boolean"] = "object ObjAltMods { | ObjModsAlt[^] } object ObjModsAlt { alt: Number | String }",
    ["alts-mods-param"] = "object ObjAltModsParam<$mod> { | ObjModsParamAlt[$mod] } object ObjModsParamAlt { alt: Number | String }",
    ["alts-simple"] = "object ObjAltsSimple { | String }",
    ["fields"] = "object ObjFieldsStr { field: * }",
    ["fields-dual"] = "object ObjFieldsDual { field: ObjFieldDual } dual ObjFieldDual { field: Number | String }",
    ["fields-mods-Enum"] = "object ObjFieldMods { field: ObjFieldMods[ObjFieldEnum] } enum ObjFieldEnum { value }",
    ["fields-mods-param"] = "object ObjFieldModsParam<$mod> { field: ObjFieldParamMods[$mod] } object ObjFieldParamMods { field: Number | String }",
    ["fields-object"] = "object FieldsObj { field: ObjField } object ObjField { field: Number | String }",
    ["fields-simple"] = "object ObjFieldsSimple { field: Number }",
    ["generic-alt"] = "object ObjGenAlt<$type> { | $type }",
    ["generic-alt-arg"] = "object ObjGenAltArg<$type> { | ObjGenAltRef<$type> } object ObjGenAltRef<$ref> { | $ref }",
    ["generic-alt-dual"] = "object ObjGenAltDual { | ObjGenAltDualRef<ObjGenAltDualAlt> } object ObjGenAltDualRef<$ref> { | $ref } dual ObjGenAltDualAlt { alt: Number | String }",
    ["generic-alt-param"] = "object ObjGenAltParam { | ObjGenAltParamRef<ObjGenAltParamAlt> } object ObjGenAltParamRef<$ref> { | $ref } object ObjGenAltParamAlt { alt: Number | String }",
    ["generic-dual"] = "object ObjGenDual { field: ObjGenDualRef<ObjGenDualAlt> } object ObjGenDualRef<$ref> { | $ref } dual ObjGenDualAlt { alt: Number | String }",
    ["generic-field"] = "object ObjGenField<$type> { field: $type }",
    ["generic-field-arg"] = "object ObjGenFieldArg<$type> { field: ObjGenFieldRef<$type> } object ObjGenFieldRef<$ref> { | $ref }",
    ["generic-field-dual"] = "object ObjGenFieldDual { field: ObjGenFieldDualRef<ObjGenFieldDualAlt> } object ObjGenFieldDualRef<$ref> { | $ref } dual ObjGenFieldDualAlt { alt: Number | String }",
    ["generic-field-param"] = "object ObjGenFieldParam { field: ObjGenFieldParamRef<ObjGenFieldParamAlt> } object ObjGenFieldParamRef<$ref> { | $ref } object ObjGenFieldParamAlt { alt: Number | String }",
    ["generic-param"] = "object ObjGenParam { field: ObjGenParamRef<ObjGenParamAlt> } object ObjGenParamRef<$ref> { | $ref } object ObjGenParamAlt { alt: Number | String }",
    ["generic-parent"] = "object ObjGenPrnt<$type> { :$type }",
    ["generic-parent-arg"] = "object ObjGenPrntArg<$type> { :ObjGenPrntRef<$type> } object ObjGenPrntRef<$ref> { | $ref }",
    ["generic-parent-dual"] = "object ObjGenParentDual { :ObjGenParentDualRef<ObjGenParentDualAlt> } object ObjGenParentDualRef<$ref> { | $ref } dual ObjGenParentDualAlt { alt: Number | String }",
    ["generic-parent-param"] = "object ObjGenParentParam { :ObjGenParentParamRef<ObjGenParentParamAlt> } object ObjGenParentParamRef<$ref> { | $ref } object ObjGenParentParamAlt { alt: Number | String }",
    ["input-field-Enum"] = "input InFieldEnum { field: InEnumField = value } enum InEnumField { value }",
    ["input-field-null"] = "input InFieldNull { field: InFieldNull? = null }",
    ["input-field-Number"] = "input InFieldNum { field: Number = 0 }",
    ["input-field-String"] = "input InFieldStr { field: String = '' }",
    ["output-field-enum"] = "output OutFieldEnum { field = OutEnumField.outEnumField } enum OutEnumField { outEnumField }",
    ["output-field-enum-parent"] = "output OutFieldParent { field = OutEnumParented.outEnumParent } enum OutEnumParented { :OutEnumParent outParent ed } enum OutEnumParent { outEnumParent }",
    ["output-field-value"] = "output OutFieldValue { field = outEnumValue } enum OutEnumValue { outEnumValue }",
    ["output-generic-enum"] = "output OutGenEnum { | OutGenEnumRef<OutEnumGen.outEnumGen> } output OutGenEnumRef<$type> { field: $type } enum OutEnumGen { outEnumGen }",
    ["output-generic-value"] = "output OutGenValue { | OutGenValueRef<outValueGen> } output OutGenValueRef<$type> { field: $type } enum OutValueGen { outValueGen }",
    ["output-params"] = "output OutParams { field(OutParam): OutParams } input OutParam { param: Number | String }",
    ["output-params-mods-Domain"] = "output OutParamsDomain { field(OutParamDomain[OutDomainParam]): OutDomainParam } input OutParamDomain { param: Number | String } domain OutDomainParam { number 1 ~ 10 }",
    ["output-params-mods-param"] = "output OutParamsDomainParam<$mod> { field(OutParamDomainParam[$mod]): OutDomainsParam } input OutParamDomainParam { param: Number | String } domain OutDomainsParam { number 1 ~ 10 }",
    ["output-parent-generic"] = "output OutGenParent { | OutGenParentRef<OutParentGen.outGenParent> } output OutGenParentRef<$type> { field: $type } enum OutParentGen { :OutPrntendedGen outGenPrntended } enum OutPrntendedGen { outGenParent }",
    ["output-parent-params"] = "output OutPrntParams { :OutParamsParent field(OutPrntParam): OutPrntParams } output OutParamsParent { field(OutParamParent): OutPrntParams } input OutPrntParam { param: Number | String } input OutParamParent { parent: Number | String }",
    ["parent"] = "object ObjTestParent { :ObjParentTest } object ObjParentTest { parent: Number | String }",
    ["parent-alts"] = "object ObjPrntAlt { :ObjAltPrnt | Number } object ObjAltPrnt {  parent: Number | String }",
    ["parent-dual"] = "object ObjTestPrntDual { :ObjPrntDualTest } dual ObjPrntDualTest { parent: Number | String }",
    ["parent-fields"] = "object ObjPrntFields { :ObjFieldsParent field: Number } object ObjFieldsParent { parent: Number | String }",
    ["parent-params-diff"] = "object ObjPrntPrmsDiff<$a> { :ObjPrmsPrntDiff<$a> field: $a } object ObjPrmsPrntDiff<$b> { | $b }",
    ["parent-params-same"] = "object ObjPrntPrmsSame<$a> { :ObjPrmsPrntSame<$a> field: $a } object ObjPrmsPrntSame<$a> { | $a }",
  };

  public SchemaValidObjectsData()
  {
    foreach (string key in Source.Keys) {
      Add(key);
    }
  }
}

public class SchemaValidSimpleData
  : TheoryData<string>
{
  public static readonly Dictionary<string, string> Source = new() {
    ["domain-enum-all"] = "domain DomEnumAll { enum EnumDomAll.* } enum EnumDomAll { dom_all dom_enum_all }",
    ["domain-enum-all-parent"] = "domain DomEnumAllParent { enum EnumDomAllParent.* } enum EnumDomAllParent { :EnumDomParentAll dom_all_parent } enum EnumDomParentAll { dom_enum_all_parent }",
    ["domain-enum-member"] = "domain DomMember { enum dom_member } enum MemberDom { dom_member }",
    ["domain-enum-parent"] = "domain DomEnumPrnt { :DomPrntEnum Enum both_enum } domain DomPrntEnum { Enum both_parent } enum EnumDomBoth { both_enum both_parent }",
    ["domain-enum-unique"] = "enum EnumDomUnique { eum_dom_value eum_dom_dup } enum EnumDomDup { eum_dom_dup } # domain DomEnumUnique { enum EnumDomUnique.* !EnumDomUnique.eum_dom_dup EnumDomDup.eum_dom_dup }",
    ["domain-enum-unique-parent"] = "enum EnumDomUniqueParent { :EnumDomParentUnique value } enum EnumDomParentUnique { enum_dom_parent_dup } enum EnumDomDupParent { enum_dom_parent_dup } # domain DomEnumUniqueParent { enum EnumDomUniqueParent.* !EnumDomUniqueParent.enum_dom_parent_dup EnumDomDupParent.enum_dom_parent_dup }",
    ["domain-enum-value"] = "domain DomEnum { Enum EnumDom.dom_enum } enum EnumDom { dom_enum }",
    ["domain-enum-value-parent"] = "domain DomEnumParent { Enum EnumDomParent.dom_enum_parent } enum EnumDomParent { :EnumParentDom dom_parent_enum } enum EnumParentDom { dom_enum_parent }",
    ["domain-number-parent"] = "domain DomNumPrnt { :DomPrntNum Number 2>} domain DomPrntNum { Number <2 }",
    ["domain-parent"] = "domain DomPrntTest { :DomTestPrnt Boolean false } domain DomTestPrnt { Boolean true }",
    ["domain-string-parent"] = "domain DomStrPrnt { :DomPrntStr String /a+/ } domain DomPrntStr { String /b+/ }",
    ["enum-parent"] = "enum EnTestPrnt { :EnPrntTest val_prnt } enum EnPrntTest { val_test }",
    ["enum-parent-alias"] = "enum EnPrntAlias { :EnAliasPrnt val_prnt_alias val_alias[alias_val] } enum EnAliasPrnt { val_alias }",
    ["enum-parent-dup"] = "enum EnPrntDup { :EnDupPrnt val_prnt_dup  } enum EnDupPrnt { val_dup[val_prnt_dup] }",
    ["union-parent"] = "union UnionPrnt { :PrntUnion String } union PrntUnion { Number }",
  };

  public SchemaValidSimpleData()
  {
    foreach (string key in Source.Keys) {
      Add(key);
    }
  }
}
