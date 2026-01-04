//HintName: test_Introspection_Intf.gen.cs
// Generated from Introspection.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Introspection;

public interface Itest_Schema
  : Itest_Named
{
  public test_Schema _Schema { get; set; }
}

public interface Itest_SchemaField
  : Itest_NamedField
{
  public IDictionary<test_Name, test_Categories> categories { get; set; }
  public IDictionary<test_Name, test_Directives> directives { get; set; }
  public IDictionary<test_Name, test_Type> types { get; set; }
  public IDictionary<test_Name, test_Setting> settings { get; set; }
}

public interface Itest_Name
  : IDomainString
{
}

public interface Itest_Filter
{
  public ICollection<test_NameFilter> As_NameFilter { get; set; }
  public test_Filter _Filter { get; set; }
}

public interface Itest_FilterField
{
  public ICollection<test_NameFilter> names { get; set; }
  public test_DomainKind? matchAliases { get; set; }
  public ICollection<test_NameFilter> aliases { get; set; }
  public test_DomainKind? returnByAlias { get; set; }
  public test_DomainKind? returnReferencedTypes { get; set; }
}

public interface Itest_NameFilter
  : IDomainString
{
}

public interface Itest_CategoryFilter
  : Itest_Filter
{
  public test_CategoryFilter _CategoryFilter { get; set; }
}

public interface Itest_CategoryFilterField
  : Itest_FilterField
{
  public ICollection<test_Resolution> resolutions { get; set; }
}

public interface Itest_TypeFilter
  : Itest_Filter
{
  public test_TypeFilter _TypeFilter { get; set; }
}

public interface Itest_TypeFilterField
  : Itest_FilterField
{
  public ICollection<test_TypeKind> kinds { get; set; }
}

public interface Itest_Aliased
  : Itest_Named
{
  public test_Aliased _Aliased { get; set; }
}

public interface Itest_AliasedField
  : Itest_NamedField
{
  public ICollection<test_Name> aliases { get; set; }
}

public interface Itest_Named
  : Itest_Described
{
  public test_Named _Named { get; set; }
}

public interface Itest_NamedField
  : Itest_DescribedField
{
  public test_Name name { get; set; }
}

public interface Itest_Described
{
  public test_Described _Described { get; set; }
}

public interface Itest_DescribedField
{
  public ICollection<test_DomainKind> description { get; set; }
}

public interface Itest_AndType
  : Itest_Named
{
  public test_Type As_Type { get; set; }
  public test_AndType _AndType { get; set; }
}

public interface Itest_AndTypeField
  : Itest_NamedField
{
  public test_Type type { get; set; }
}

public interface Itest_Categories
  : Itest_AndType
{
  public test_Category As_Category { get; set; }
  public test_Categories _Categories { get; set; }
}

public interface Itest_CategoriesField
  : Itest_AndTypeField
{
  public test_Category category { get; set; }
}

public interface Itest_Category
  : Itest_Aliased
{
  public test_Category _Category { get; set; }
}

public interface Itest_CategoryField
  : Itest_AliasedField
{
  public test_Resolution resolution { get; set; }
  public test_TypeRef<test_TypeKind> output { get; set; }
  public ICollection<test_Modifiers> modifiers { get; set; }
}

public interface Itest_Directives
  : Itest_AndType
{
  public test_Directive As_Directive { get; set; }
  public test_Directives _Directives { get; set; }
}

public interface Itest_DirectivesField
  : Itest_AndTypeField
{
  public test_Directive directive { get; set; }
}

public interface Itest_Directive
  : Itest_Aliased
{
  public test_Directive _Directive { get; set; }
}

public interface Itest_DirectiveField
  : Itest_AliasedField
{
  public ICollection<test_InputParam> parameters { get; set; }
  public test_DomainKind repeatable { get; set; }
  public IDictionary<test_Location, testUnit> locations { get; set; }
}

public interface Itest_Setting
  : Itest_Named
{
  public test_Setting _Setting { get; set; }
}

public interface Itest_SettingField
  : Itest_NamedField
{
  public test_Value value { get; set; }
}

public interface Itest_Type
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

public interface Itest_TypeField
{
}

public interface Itest_BaseType<Tkind>
  : Itest_Aliased
{
  public test_BaseType _BaseType { get; set; }
}

public interface Itest_BaseTypeField<Tkind>
  : Itest_AliasedField
{
  public Tkind typeKind { get; set; }
}

public interface Itest_ChildType<Tkind,Tparent>
  : Itest_BaseType
{
  public test_ChildType _ChildType { get; set; }
}

public interface Itest_ChildTypeField<Tkind,Tparent>
  : Itest_BaseTypeField
{
  public Tparent parent { get; set; }
}

public interface Itest_ParentType<Tkind,Titem,TallItem>
  : Itest_ChildType
{
  public test_ParentType _ParentType { get; set; }
}

public interface Itest_ParentTypeField<Tkind,Titem,TallItem>
  : Itest_ChildTypeField
{
  public ICollection<Titem> items { get; set; }
  public ICollection<TallItem> allItems { get; set; }
}

public interface Itest_TypeRef<Tkind>
  : Itest_Named
{
  public test_TypeRef _TypeRef { get; set; }
}

public interface Itest_TypeRefField<Tkind>
  : Itest_NamedField
{
  public Tkind typeKind { get; set; }
}

public interface Itest_TypeSimple
{
  public test_TypeRef<test_TypeKind> As_TypeRef { get; set; }
  public test_TypeRef<test_TypeKind> As_TypeRef { get; set; }
  public test_TypeRef<test_TypeKind> As_TypeRef { get; set; }
  public test_TypeRef<test_TypeKind> As_TypeRef { get; set; }
  public test_TypeSimple _TypeSimple { get; set; }
}

public interface Itest_TypeSimpleField
{
}

public interface Itest_Collections
{
  public test_Modifier<test_ModifierKind> As_Modifier { get; set; }
  public test_ModifierKeyed<test_ModifierKind> As_ModifierKeyed { get; set; }
  public test_ModifierKeyed<test_ModifierKind> As_ModifierKeyed { get; set; }
  public test_Collections _Collections { get; set; }
}

public interface Itest_CollectionsField
{
}

public interface Itest_ModifierKeyed<Tkind>
  : Itest_Modifier
{
  public test_ModifierKeyed _ModifierKeyed { get; set; }
}

public interface Itest_ModifierKeyedField<Tkind>
  : Itest_ModifierField
{
  public test_TypeSimple by { get; set; }
  public test_DomainKind optional { get; set; }
}

public interface Itest_Modifiers
{
  public test_Modifier<test_ModifierKind> As_Modifier { get; set; }
  public test_Collections As_Collections { get; set; }
  public test_Modifiers _Modifiers { get; set; }
}

public interface Itest_ModifiersField
{
}

public interface Itest_Modifier<Tkind>
{
  public test_Modifier _Modifier { get; set; }
}

public interface Itest_ModifierField<Tkind>
{
  public Tkind modifierKind { get; set; }
}

public interface Itest_DomainRef<Tkind>
  : Itest_TypeRef
{
  public test_DomainRef _DomainRef { get; set; }
}

public interface Itest_DomainRefField<Tkind>
  : Itest_TypeRefField
{
  public Tkind domainKind { get; set; }
}

public interface Itest_BaseDomain<Tdomain,Titem,TdomainItem>
  : Itest_ParentType
{
  public test_BaseDomain _BaseDomain { get; set; }
}

public interface Itest_BaseDomainField<Tdomain,Titem,TdomainItem>
  : Itest_ParentTypeField
{
  public Tdomain domainKind { get; set; }
}

public interface Itest_BaseDomainItem
  : Itest_Described
{
  public test_BaseDomainItem _BaseDomainItem { get; set; }
}

public interface Itest_BaseDomainItemField
  : Itest_DescribedField
{
  public test_DomainKind exclude { get; set; }
}

public interface Itest_DomainItem<Titem>
  : Itestitem
{
  public test_DomainItem _DomainItem { get; set; }
}

public interface Itest_DomainItemField<Titem>
  : ItestitemField
{
  public test_Name domain { get; set; }
}

public interface Itest_DomainValue<Tkind,Tvalue>
  : Itest_DomainRef
{
  public Tvalue Asvalue { get; set; }
  public test_DomainValue _DomainValue { get; set; }
}

public interface Itest_DomainValueField<Tkind,Tvalue>
  : Itest_DomainRefField
{
  public Tvalue value { get; set; }
}

public interface Itest_BasicValue
{
  public test_DomainKind As_DomainKindBoolean { get; set; }
  public test_EnumValue As_EnumValue { get; set; }
  public test_DomainKind As_DomainKindNumber { get; set; }
  public test_DomainKind As_DomainKindString { get; set; }
  public test_BasicValue _BasicValue { get; set; }
}

public interface Itest_BasicValueField
{
}

public interface Itest_DomainTrueFalse
  : Itest_BaseDomainItem
{
  public test_DomainTrueFalse _DomainTrueFalse { get; set; }
}

public interface Itest_DomainTrueFalseField
  : Itest_BaseDomainItemField
{
  public test_DomainKind value { get; set; }
}

public interface Itest_DomainItemTrueFalse
  : Itest_DomainItem
{
  public test_DomainItemTrueFalse _DomainItemTrueFalse { get; set; }
}

public interface Itest_DomainItemTrueFalseField
  : Itest_DomainItemField
{
}

public interface Itest_DomainLabel
  : Itest_BaseDomainItem
{
  public test_DomainLabel _DomainLabel { get; set; }
}

public interface Itest_DomainLabelField
  : Itest_BaseDomainItemField
{
  public test_EnumValue label { get; set; }
}

public interface Itest_DomainItemLabel
  : Itest_DomainItem
{
  public test_DomainItemLabel _DomainItemLabel { get; set; }
}

public interface Itest_DomainItemLabelField
  : Itest_DomainItemField
{
}

public interface Itest_DomainRange
  : Itest_BaseDomainItem
{
  public test_DomainRange _DomainRange { get; set; }
}

public interface Itest_DomainRangeField
  : Itest_BaseDomainItemField
{
  public test_DomainKind? lower { get; set; }
  public test_DomainKind? upper { get; set; }
}

public interface Itest_DomainItemRange
  : Itest_DomainItem
{
  public test_DomainItemRange _DomainItemRange { get; set; }
}

public interface Itest_DomainItemRangeField
  : Itest_DomainItemField
{
}

public interface Itest_DomainRegex
  : Itest_BaseDomainItem
{
  public test_DomainRegex _DomainRegex { get; set; }
}

public interface Itest_DomainRegexField
  : Itest_BaseDomainItemField
{
  public test_DomainKind pattern { get; set; }
}

public interface Itest_DomainItemRegex
  : Itest_DomainItem
{
  public test_DomainItemRegex _DomainItemRegex { get; set; }
}

public interface Itest_DomainItemRegexField
  : Itest_DomainItemField
{
}

public interface Itest_EnumLabel
  : Itest_Aliased
{
  public test_EnumLabel _EnumLabel { get; set; }
}

public interface Itest_EnumLabelField
  : Itest_AliasedField
{
  public test_Name enum { get; set; }
}

public interface Itest_EnumValue
  : Itest_TypeRef
{
  public test_EnumValue _EnumValue { get; set; }
}

public interface Itest_EnumValueField
  : Itest_TypeRefField
{
  public test_Name label { get; set; }
}

public interface Itest_UnionRef
  : Itest_TypeRef
{
  public test_UnionRef _UnionRef { get; set; }
}

public interface Itest_UnionRefField
  : Itest_TypeRefField
{
}

public interface Itest_UnionMember
  : Itest_UnionRef
{
  public test_UnionMember _UnionMember { get; set; }
}

public interface Itest_UnionMemberField
  : Itest_UnionRefField
{
  public test_Name union { get; set; }
}

public interface Itest_ObjectKind
  : IDomainEnum
{
}

public interface Itest_TypeObject<Tkind,Tfield>
  : Itest_ChildType
{
  public test_TypeObject _TypeObject { get; set; }
}

public interface Itest_TypeObjectField<Tkind,Tfield>
  : Itest_ChildTypeField
{
  public ICollection<test_ObjTypeParam> typeParams { get; set; }
  public ICollection<Tfield> fields { get; set; }
  public ICollection<test_ObjAlternate> alternates { get; set; }
  public ICollection<test_ObjectFor<Tfield>> allFields { get; set; }
  public ICollection<test_ObjectFor<test_ObjAlternate>> allAlternates { get; set; }
}

public interface Itest_ObjTypeParam
  : Itest_Named
{
  public test_ObjTypeParam _ObjTypeParam { get; set; }
}

public interface Itest_ObjTypeParamField
  : Itest_NamedField
{
  public test_TypeRef<test_TypeKind> constraint { get; set; }
}

public interface Itest_ObjBase
  : Itest_Named
{
  public test_TypeParam As_TypeParam { get; set; }
  public test_ObjBase _ObjBase { get; set; }
}

public interface Itest_ObjBaseField
  : Itest_NamedField
{
  public ICollection<test_ObjTypeArg> typeArgs { get; set; }
}

public interface Itest_ObjTypeArg
  : Itest_TypeRef
{
  public test_TypeParam As_TypeParam { get; set; }
  public test_ObjTypeArg _ObjTypeArg { get; set; }
}

public interface Itest_ObjTypeArgField
  : Itest_TypeRefField
{
  public test_Name? label { get; set; }
}

public interface Itest_TypeParam
  : Itest_Described
{
  public test_TypeParam _TypeParam { get; set; }
}

public interface Itest_TypeParamField
  : Itest_DescribedField
{
  public test_Name typeParam { get; set; }
}

public interface Itest_ObjAlternate
{
  public test_ObjAlternateEnum As_ObjAlternateEnum { get; set; }
  public test_ObjAlternate _ObjAlternate { get; set; }
}

public interface Itest_ObjAlternateField
{
  public test_ObjBase type { get; set; }
  public ICollection<test_Collections> collections { get; set; }
}

public interface Itest_ObjAlternateEnum
  : Itest_TypeRef
{
  public test_ObjAlternateEnum _ObjAlternateEnum { get; set; }
}

public interface Itest_ObjAlternateEnumField
  : Itest_TypeRefField
{
  public test_Name label { get; set; }
}

public interface Itest_ObjectFor<Tfor>
  : Itestfor
{
  public test_ObjectFor _ObjectFor { get; set; }
}

public interface Itest_ObjectForField<Tfor>
  : ItestforField
{
  public test_Name object { get; set; }
}

public interface Itest_ObjField<Ttype>
  : Itest_Aliased
{
  public test_ObjField _ObjField { get; set; }
}

public interface Itest_ObjFieldField<Ttype>
  : Itest_AliasedField
{
  public Ttype type { get; set; }
}

public interface Itest_ObjFieldType
  : Itest_ObjBase
{
  public test_ObjFieldEnum As_ObjFieldEnum { get; set; }
  public test_ObjFieldType _ObjFieldType { get; set; }
}

public interface Itest_ObjFieldTypeField
  : Itest_ObjBaseField
{
  public ICollection<test_Modifiers> modifiers { get; set; }
}

public interface Itest_ObjFieldEnum
  : Itest_TypeRef
{
  public test_ObjFieldEnum _ObjFieldEnum { get; set; }
}

public interface Itest_ObjFieldEnumField
  : Itest_TypeRefField
{
  public test_Name label { get; set; }
}

public interface Itest_ForParam<Ttype>
{
  public test_ObjAlternate As_ObjAlternate { get; set; }
  public test_ObjField<Ttype> As_ObjField { get; set; }
  public test_ForParam _ForParam { get; set; }
}

public interface Itest_ForParamField<Ttype>
{
}

public interface Itest_DualField
  : Itest_ObjField
{
  public test_DualField _DualField { get; set; }
}

public interface Itest_DualFieldField
  : Itest_ObjFieldField
{
}

public interface Itest_InputField
  : Itest_ObjField
{
  public test_InputField _InputField { get; set; }
}

public interface Itest_InputFieldField
  : Itest_ObjFieldField
{
}

public interface Itest_InputFieldType
  : Itest_ObjFieldType
{
  public test_InputFieldType _InputFieldType { get; set; }
}

public interface Itest_InputFieldTypeField
  : Itest_ObjFieldTypeField
{
  public test_Value? default { get; set; }
}

public interface Itest_InputParam
  : Itest_InputFieldType
{
  public test_InputParam _InputParam { get; set; }
}

public interface Itest_InputParamField
  : Itest_InputFieldTypeField
{
}

public interface Itest_OutputField
  : Itest_ObjField
{
  public test_OutputField _OutputField { get; set; }
}

public interface Itest_OutputFieldField
  : Itest_ObjFieldField
{
}

public interface Itest_OutputFieldType
  : Itest_ObjFieldType
{
  public test_OutputFieldType _OutputFieldType { get; set; }
}

public interface Itest_OutputFieldTypeField
  : Itest_ObjFieldTypeField
{
  public ICollection<test_InputParam> parameters { get; set; }
}
