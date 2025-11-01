//HintName: test_Introspection_Impl.gen.cs
// Generated from Introspection.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_Introspection;

public class test_Schema
  : test_Named
  , Itest_Schema
{
  public IDictionary<test_Identifier, test_Categories> categories { get; set; }
  public IDictionary<test_Identifier, test_Directives> directives { get; set; }
  public IDictionary<test_Identifier, test_Type> types { get; set; }
  public IDictionary<test_Identifier, test_Setting> settings { get; set; }
  public test_Schema _Schema { get; set; }
}

public class test_Identifier
  : Itest_Identifier
{
}

public class test_Filter
  : Itest_Filter
{
  public ICollection<test_NameFilter> names { get; set; }
  public testBoolean? matchAliases { get; set; }
  public ICollection<test_NameFilter> aliases { get; set; }
  public testBoolean? returnByAlias { get; set; }
  public testBoolean? returnReferencedTypes { get; set; }
  public ICollection<test_NameFilter> As_NameFilter { get; set; }
  public test_Filter _Filter { get; set; }
}

public class test_NameFilter
  : Itest_NameFilter
{
}

public class test_CategoryFilter
  : test_Filter
  , Itest_CategoryFilter
{
  public ICollection<test_Resolution> resolutions { get; set; }
  public test_CategoryFilter _CategoryFilter { get; set; }
}

public class test_TypeFilter
  : test_Filter
  , Itest_TypeFilter
{
  public ICollection<test_TypeKind> kinds { get; set; }
  public test_TypeFilter _TypeFilter { get; set; }
}

public class test_Aliased
  : test_Named
  , Itest_Aliased
{
  public ICollection<test_Identifier> aliases { get; set; }
  public test_Aliased _Aliased { get; set; }
}

public class test_Named
  : test_Described
  , Itest_Named
{
  public test_Identifier name { get; set; }
  public test_Named _Named { get; set; }
}

public class test_Described
  : Itest_Described
{
  public ICollection<testString> description { get; set; }
  public test_Described _Described { get; set; }
}

public class test_AndType
  : test_Named
  , Itest_AndType
{
  public test_Type type { get; set; }
  public test_Type As_Type { get; set; }
  public test_AndType _AndType { get; set; }
}

public class test_Categories
  : test_AndType
  , Itest_Categories
{
  public test_Category category { get; set; }
  public test_Category As_Category { get; set; }
  public test_Categories _Categories { get; set; }
}

public class test_Category
  : test_Aliased
  , Itest_Category
{
  public test_Resolution resolution { get; set; }
  public test_TypeRef<test_TypeKind> output { get; set; }
  public ICollection<test_Modifiers> modifiers { get; set; }
  public test_Category _Category { get; set; }
}

public class test_Directives
  : test_AndType
  , Itest_Directives
{
  public test_Directive directive { get; set; }
  public test_Directive As_Directive { get; set; }
  public test_Directives _Directives { get; set; }
}

public class test_Directive
  : test_Aliased
  , Itest_Directive
{
  public ICollection<test_InputParam> parameters { get; set; }
  public testBoolean repeatable { get; set; }
  public IDictionary<test_Location, testUnit> locations { get; set; }
  public test_Directive _Directive { get; set; }
}

public class test_Setting
  : test_Named
  , Itest_Setting
{
  public test_Value value { get; set; }
  public test_Setting _Setting { get; set; }
}

public class test_Type
  : Itest_Type
{
  public test_BaseType<test_TypeKind> As_BaseType { get; set; }
  public test_BaseType<test_TypeKind> As_BaseType { get; set; }
  public test_BaseDomain<test_DomainKind, test_DomainTrueFalse, test_DomainItemTrueFalse> As_BaseDomain { get; set; }
  public test_BaseDomain<test_DomainKind, test_DomainLabel, test_DomainItemLabel> As_BaseDomain { get; set; }
  public test_BaseDomain<test_DomainKind, test_DomainRange, test_DomainItemRange> As_BaseDomain { get; set; }
  public test_BaseDomain<test_DomainKind, test_DomainRegex, test_DomainItemRegex> As_BaseDomain { get; set; }
  public test_ParentType<test_TypeKind, test_Aliased, test_EnumLabel> As_ParentType { get; set; }
  public test_ParentType<test_TypeKind, test_UnionRef, test_UnionMember> As_ParentType { get; set; }
  public test_TypeObject<test_TypeKind, test_DualField> As_TypeObject { get; set; }
  public test_TypeObject<test_TypeKind, test_InputField> As_TypeObject { get; set; }
  public test_TypeObject<test_TypeKind, test_OutputField> As_TypeObject { get; set; }
  public test_Type _Type { get; set; }
}

public class test_BaseType<Tkind>
  : test_Aliased
  , Itest_BaseType<Tkind>
{
  public Tkind typeKind { get; set; }
  public test_BaseType _BaseType { get; set; }
}

public class test_ChildType<Tkind,Tparent>
  : test_BaseType
  , Itest_ChildType<Tkind,Tparent>
{
  public Tparent parent { get; set; }
  public test_ChildType _ChildType { get; set; }
}

public class test_ParentType<Tkind,Titem,TallItem>
  : test_ChildType
  , Itest_ParentType<Tkind,Titem,TallItem>
{
  public ICollection<Titem> items { get; set; }
  public ICollection<TallItem> allItems { get; set; }
  public test_ParentType _ParentType { get; set; }
}

public class test_TypeRef<Tkind>
  : test_Named
  , Itest_TypeRef<Tkind>
{
  public Tkind typeKind { get; set; }
  public test_TypeRef _TypeRef { get; set; }
}

public class test_TypeSimple
  : Itest_TypeSimple
{
  public test_TypeRef<test_TypeKind> As_TypeRef { get; set; }
  public test_TypeRef<test_TypeKind> As_TypeRef { get; set; }
  public test_TypeRef<test_TypeKind> As_TypeRef { get; set; }
  public test_TypeRef<test_TypeKind> As_TypeRef { get; set; }
  public test_TypeSimple _TypeSimple { get; set; }
}

public class test_Collections
  : Itest_Collections
{
  public test_Modifier<test_ModifierKind> As_Modifier { get; set; }
  public test_ModifierKeyed<test_ModifierKind> As_ModifierKeyed { get; set; }
  public test_ModifierKeyed<test_ModifierKind> As_ModifierKeyed { get; set; }
  public test_Collections _Collections { get; set; }
}

public class test_ModifierKeyed<Tkind>
  : test_Modifier
  , Itest_ModifierKeyed<Tkind>
{
  public test_TypeSimple by { get; set; }
  public testBoolean optional { get; set; }
  public test_ModifierKeyed _ModifierKeyed { get; set; }
}

public class test_Modifiers
  : Itest_Modifiers
{
  public test_Modifier<test_ModifierKind> As_Modifier { get; set; }
  public test_Collections As_Collections { get; set; }
  public test_Modifiers _Modifiers { get; set; }
}

public class test_Modifier<Tkind>
  : Itest_Modifier<Tkind>
{
  public Tkind modifierKind { get; set; }
  public test_Modifier _Modifier { get; set; }
}

public class test_DomainRef<Tkind>
  : test_TypeRef
  , Itest_DomainRef<Tkind>
{
  public Tkind domainKind { get; set; }
  public test_DomainRef _DomainRef { get; set; }
}

public class test_BaseDomain<Tdomain,Titem,TdomainItem>
  : test_ParentType
  , Itest_BaseDomain<Tdomain,Titem,TdomainItem>
{
  public Tdomain domainKind { get; set; }
  public test_BaseDomain _BaseDomain { get; set; }
}

public class test_BaseDomainItem
  : test_Described
  , Itest_BaseDomainItem
{
  public testBoolean exclude { get; set; }
  public test_BaseDomainItem _BaseDomainItem { get; set; }
}

public class test_DomainItem<Titem>
  : testitem
  , Itest_DomainItem<Titem>
{
  public test_Identifier domain { get; set; }
  public test_DomainItem _DomainItem { get; set; }
}

public class test_DomainValue<Tkind,Tvalue>
  : test_DomainRef
  , Itest_DomainValue<Tkind,Tvalue>
{
  public Tvalue value { get; set; }
  public Tvalue Asvalue { get; set; }
  public test_DomainValue _DomainValue { get; set; }
}

public class test_BasicValue
  : Itest_BasicValue
{
  public test_DomainKind As_DomainKind { get; set; }
  public test_EnumValue As_EnumValue { get; set; }
  public test_DomainKind As_DomainKind { get; set; }
  public test_DomainKind As_DomainKind { get; set; }
  public test_BasicValue _BasicValue { get; set; }
}

public class test_DomainTrueFalse
  : test_BaseDomainItem
  , Itest_DomainTrueFalse
{
  public testBoolean value { get; set; }
  public test_DomainTrueFalse _DomainTrueFalse { get; set; }
}

public class test_DomainItemTrueFalse
  : test_DomainItem
  , Itest_DomainItemTrueFalse
{
  public test_DomainItemTrueFalse _DomainItemTrueFalse { get; set; }
}

public class test_DomainLabel
  : test_BaseDomainItem
  , Itest_DomainLabel
{
  public test_EnumValue label { get; set; }
  public test_DomainLabel _DomainLabel { get; set; }
}

public class test_DomainItemLabel
  : test_DomainItem
  , Itest_DomainItemLabel
{
  public test_DomainItemLabel _DomainItemLabel { get; set; }
}

public class test_DomainRange
  : test_BaseDomainItem
  , Itest_DomainRange
{
  public testNumber? lower { get; set; }
  public testNumber? upper { get; set; }
  public test_DomainRange _DomainRange { get; set; }
}

public class test_DomainItemRange
  : test_DomainItem
  , Itest_DomainItemRange
{
  public test_DomainItemRange _DomainItemRange { get; set; }
}

public class test_DomainRegex
  : test_BaseDomainItem
  , Itest_DomainRegex
{
  public testString pattern { get; set; }
  public test_DomainRegex _DomainRegex { get; set; }
}

public class test_DomainItemRegex
  : test_DomainItem
  , Itest_DomainItemRegex
{
  public test_DomainItemRegex _DomainItemRegex { get; set; }
}

public class test_EnumLabel
  : test_Aliased
  , Itest_EnumLabel
{
  public test_Identifier enum { get; set; }
  public test_EnumLabel _EnumLabel { get; set; }
}

public class test_EnumValue
  : test_TypeRef
  , Itest_EnumValue
{
  public test_Identifier label { get; set; }
  public test_EnumValue _EnumValue { get; set; }
}

public class test_UnionRef
  : test_TypeRef
  , Itest_UnionRef
{
  public test_UnionRef _UnionRef { get; set; }
}

public class test_UnionMember
  : test_UnionRef
  , Itest_UnionMember
{
  public test_Identifier union { get; set; }
  public test_UnionMember _UnionMember { get; set; }
}

public class test_ObjectKind
  : Itest_ObjectKind
{
}

public class test_TypeObject<Tkind,Tfield>
  : test_ChildType
  , Itest_TypeObject<Tkind,Tfield>
{
  public ICollection<test_ObjTypeParam> typeParams { get; set; }
  public ICollection<Tfield> fields { get; set; }
  public ICollection<test_ObjAlternate> alternates { get; set; }
  public ICollection<test_ObjectFor<Tfield>> allFields { get; set; }
  public ICollection<test_ObjectFor<test_ObjAlternate>> allAlternates { get; set; }
  public test_TypeObject _TypeObject { get; set; }
}

public class test_ObjTypeParam
  : test_Named
  , Itest_ObjTypeParam
{
  public test_TypeRef<test_TypeKind> constraint { get; set; }
  public test_ObjTypeParam _ObjTypeParam { get; set; }
}

public class test_ObjBase
  : test_Named
  , Itest_ObjBase
{
  public ICollection<test_ObjTypeArg> typeArgs { get; set; }
  public test_TypeParam As_TypeParam { get; set; }
  public test_ObjBase _ObjBase { get; set; }
}

public class test_ObjTypeArg
  : test_TypeRef
  , Itest_ObjTypeArg
{
  public test_Identifier? label { get; set; }
  public test_TypeParam As_TypeParam { get; set; }
  public test_ObjTypeArg _ObjTypeArg { get; set; }
}

public class test_TypeParam
  : test_Described
  , Itest_TypeParam
{
  public test_Identifier typeParam { get; set; }
  public test_TypeParam _TypeParam { get; set; }
}

public class test_ObjAlternate
  : Itest_ObjAlternate
{
  public test_ObjBase type { get; set; }
  public ICollection<test_Collections> collections { get; set; }
  public test_ObjAlternateEnum As_ObjAlternateEnum { get; set; }
  public test_ObjAlternate _ObjAlternate { get; set; }
}

public class test_ObjAlternateEnum
  : test_TypeRef
  , Itest_ObjAlternateEnum
{
  public test_Identifier label { get; set; }
  public test_ObjAlternateEnum _ObjAlternateEnum { get; set; }
}

public class test_ObjectFor<Tfor>
  : testfor
  , Itest_ObjectFor<Tfor>
{
  public test_Identifier object { get; set; }
  public test_ObjectFor _ObjectFor { get; set; }
}

public class test_ObjField<Ttype>
  : test_Aliased
  , Itest_ObjField<Ttype>
{
  public Ttype type { get; set; }
  public test_ObjField _ObjField { get; set; }
}

public class test_ObjFieldType
  : test_ObjBase
  , Itest_ObjFieldType
{
  public ICollection<test_Modifiers> modifiers { get; set; }
  public test_ObjFieldEnum As_ObjFieldEnum { get; set; }
  public test_ObjFieldType _ObjFieldType { get; set; }
}

public class test_ObjFieldEnum
  : test_TypeRef
  , Itest_ObjFieldEnum
{
  public test_Identifier label { get; set; }
  public test_ObjFieldEnum _ObjFieldEnum { get; set; }
}

public class test_ForParam<Ttype>
  : Itest_ForParam<Ttype>
{
  public test_ObjAlternate As_ObjAlternate { get; set; }
  public test_ObjField<Ttype> As_ObjField { get; set; }
  public test_ForParam _ForParam { get; set; }
}

public class test_DualField
  : test_ObjField
  , Itest_DualField
{
  public test_DualField _DualField { get; set; }
}

public class test_InputField
  : test_ObjField
  , Itest_InputField
{
  public test_InputField _InputField { get; set; }
}

public class test_InputFieldType
  : test_ObjFieldType
  , Itest_InputFieldType
{
  public test_Value? default { get; set; }
  public test_InputFieldType _InputFieldType { get; set; }
}

public class test_InputParam
  : test_InputFieldType
  , Itest_InputParam
{
  public test_InputParam _InputParam { get; set; }
}

public class test_OutputField
  : test_ObjField
  , Itest_OutputField
{
  public test_OutputField _OutputField { get; set; }
}

public class test_OutputFieldType
  : test_ObjFieldType
  , Itest_OutputFieldType
{
  public ICollection<test_InputParam> parameters { get; set; }
  public test_OutputFieldType _OutputFieldType { get; set; }
}
