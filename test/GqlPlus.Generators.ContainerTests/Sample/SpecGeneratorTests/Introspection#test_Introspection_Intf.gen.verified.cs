//HintName: test_Introspection_Intf.gen.cs
// Generated from Introspection.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Introspection;

public interface Itest_Schema
  : Itest_Named
{
  public Itest_SchemaObject As_Schema { get; set; }
}

public interface Itest_SchemaObject
  : Itest_NamedObject
{
  public IDictionary<test_Name, Itest_Categories> Categories { get; set; }
  public IDictionary<test_Name, Itest_Directives> Directives { get; set; }
  public IDictionary<test_Name, Itest_Type> Types { get; set; }
  public IDictionary<test_Name, Itest_Setting> Settings { get; set; }
}

public interface Itest_Name
  : IDomainString
{
}

public interface Itest_Filter
{
  public ICollection<Itest_NameFilter> As_NameFilter { get; set; }
  public Itest_FilterObject As_Filter { get; set; }
}

public interface Itest_FilterObject
{
  public ICollection<Itest_NameFilter> Names { get; set; }
  public test_DomainKind? MatchAliases { get; set; }
  public ICollection<Itest_NameFilter> Aliases { get; set; }
  public test_DomainKind? ReturnByAlias { get; set; }
  public test_DomainKind? ReturnReferencedTypes { get; set; }
}

public interface Itest_NameFilter
  : IDomainString
{
}

public interface Itest_CategoryFilter
  : Itest_Filter
{
  public Itest_CategoryFilterObject As_CategoryFilter { get; set; }
}

public interface Itest_CategoryFilterObject
  : Itest_FilterObject
{
  public ICollection<test_Resolution> Resolutions { get; set; }
}

public interface Itest_TypeFilter
  : Itest_Filter
{
  public Itest_TypeFilterObject As_TypeFilter { get; set; }
}

public interface Itest_TypeFilterObject
  : Itest_FilterObject
{
  public ICollection<test_TypeKind> Kinds { get; set; }
}

public interface Itest_Aliased
  : Itest_Named
{
  public Itest_AliasedObject As_Aliased { get; set; }
}

public interface Itest_AliasedObject
  : Itest_NamedObject
{
  public ICollection<Itest_Name> Aliases { get; set; }
}

public interface Itest_Named
  : Itest_Described
{
  public Itest_NamedObject As_Named { get; set; }
}

public interface Itest_NamedObject
  : Itest_DescribedObject
{
  public Itest_Name Name { get; set; }
}

public interface Itest_Described
{
  public Itest_DescribedObject As_Described { get; set; }
}

public interface Itest_DescribedObject
{
  public ICollection<test_DomainKind> Description { get; set; }
}

public interface Itest_AndType
  : Itest_Named
{
  public Itest_Type As_Type { get; set; }
  public Itest_AndTypeObject As_AndType { get; set; }
}

public interface Itest_AndTypeObject
  : Itest_NamedObject
{
  public Itest_Type Type { get; set; }
}

public interface Itest_Categories
  : Itest_AndType
{
  public Itest_Category As_Category { get; set; }
  public Itest_CategoriesObject As_Categories { get; set; }
}

public interface Itest_CategoriesObject
  : Itest_AndTypeObject
{
  public Itest_Category Category { get; set; }
}

public interface Itest_Category
  : Itest_Aliased
{
  public Itest_CategoryObject As_Category { get; set; }
}

public interface Itest_CategoryObject
  : Itest_AliasedObject
{
  public test_Resolution Resolution { get; set; }
  public Itest_TypeRef<test_TypeKind> Output { get; set; }
  public ICollection<Itest_Modifiers> Modifiers { get; set; }
}

public interface Itest_Directives
  : Itest_AndType
{
  public Itest_Directive As_Directive { get; set; }
  public Itest_DirectivesObject As_Directives { get; set; }
}

public interface Itest_DirectivesObject
  : Itest_AndTypeObject
{
  public Itest_Directive Directive { get; set; }
}

public interface Itest_Directive
  : Itest_Aliased
{
  public Itest_DirectiveObject As_Directive { get; set; }
}

public interface Itest_DirectiveObject
  : Itest_AliasedObject
{
  public ICollection<Itest_InputParam> Parameters { get; set; }
  public test_DomainKind Repeatable { get; set; }
  public IDictionary<test_Location, testUnit> Locations { get; set; }
}

public interface Itest_Setting
  : Itest_Named
{
  public Itest_SettingObject As_Setting { get; set; }
}

public interface Itest_SettingObject
  : Itest_NamedObject
{
  public Itest_Value Value { get; set; }
}

public interface Itest_Type
{
  public Itest_BaseType<test_TypeKind> As_BaseType { get; set; }
  public Itest_BaseType<test_TypeKind> As_BaseType { get; set; }
  public Itest_BaseDomain<test_DomainKind, Itest_DomainTrueFalse, Itest_DomainItemTrueFalse> As_BaseDomain { get; set; }
  public Itest_BaseDomain<test_DomainKind, Itest_DomainLabel, Itest_DomainItemLabel> As_BaseDomain { get; set; }
  public Itest_BaseDomain<test_DomainKind, Itest_DomainRange, Itest_DomainItemRange> As_BaseDomain { get; set; }
  public Itest_BaseDomain<test_DomainKind, Itest_DomainRegex, Itest_DomainItemRegex> As_BaseDomain { get; set; }
  public Itest_ParentType<test_TypeKind, Itest_Aliased, Itest_EnumLabel> As_ParentType { get; set; }
  public Itest_ParentType<test_TypeKind, Itest_UnionRef, Itest_UnionMember> As_ParentType { get; set; }
  public Itest_TypeObject<test_TypeKind, Itest_DualField> As_TypeObject { get; set; }
  public Itest_TypeObject<test_TypeKind, Itest_InputField> As_TypeObject { get; set; }
  public Itest_TypeObject<test_TypeKind, Itest_OutputField> As_TypeObject { get; set; }
  public Itest_TypeObject As_Type { get; set; }
}

public interface Itest_TypeObject
{
}

public interface Itest_BaseType<Tkind>
  : Itest_Aliased
{
  public Itest_BaseTypeObject As_BaseType { get; set; }
}

public interface Itest_BaseTypeObject<Tkind>
  : Itest_AliasedObject
{
  public Tkind TypeKind { get; set; }
}

public interface Itest_ChildType<Tkind,Tparent>
  : Itest_BaseType
{
  public Itest_ChildTypeObject As_ChildType { get; set; }
}

public interface Itest_ChildTypeObject<Tkind,Tparent>
  : Itest_BaseTypeObject
{
  public Tparent Parent { get; set; }
}

public interface Itest_ParentType<Tkind,Titem,TallItem>
  : Itest_ChildType
{
  public Itest_ParentTypeObject As_ParentType { get; set; }
}

public interface Itest_ParentTypeObject<Tkind,Titem,TallItem>
  : Itest_ChildTypeObject
{
  public ICollection<Titem> Items { get; set; }
  public ICollection<TallItem> AllItems { get; set; }
}

public interface Itest_TypeRef<Tkind>
  : Itest_Named
{
  public Itest_TypeRefObject As_TypeRef { get; set; }
}

public interface Itest_TypeRefObject<Tkind>
  : Itest_NamedObject
{
  public Tkind TypeKind { get; set; }
}

public interface Itest_TypeSimple
{
  public Itest_TypeRef<test_TypeKind> As_TypeRef { get; set; }
  public Itest_TypeRef<test_TypeKind> As_TypeRef { get; set; }
  public Itest_TypeRef<test_TypeKind> As_TypeRef { get; set; }
  public Itest_TypeRef<test_TypeKind> As_TypeRef { get; set; }
  public Itest_TypeSimpleObject As_TypeSimple { get; set; }
}

public interface Itest_TypeSimpleObject
{
}

public interface Itest_Collections
{
  public Itest_Modifier<test_ModifierKind> As_Modifier { get; set; }
  public Itest_ModifierKeyed<test_ModifierKind> As_ModifierKeyed { get; set; }
  public Itest_ModifierKeyed<test_ModifierKind> As_ModifierKeyed { get; set; }
  public Itest_CollectionsObject As_Collections { get; set; }
}

public interface Itest_CollectionsObject
{
}

public interface Itest_ModifierKeyed<Tkind>
  : Itest_Modifier
{
  public Itest_ModifierKeyedObject As_ModifierKeyed { get; set; }
}

public interface Itest_ModifierKeyedObject<Tkind>
  : Itest_ModifierObject
{
  public Itest_TypeSimple By { get; set; }
  public test_DomainKind Optional { get; set; }
}

public interface Itest_Modifiers
{
  public Itest_Modifier<test_ModifierKind> As_Modifier { get; set; }
  public Itest_Collections As_Collections { get; set; }
  public Itest_ModifiersObject As_Modifiers { get; set; }
}

public interface Itest_ModifiersObject
{
}

public interface Itest_Modifier<Tkind>
{
  public Itest_ModifierObject As_Modifier { get; set; }
}

public interface Itest_ModifierObject<Tkind>
{
  public Tkind ModifierKind { get; set; }
}

public interface Itest_DomainRef<Tkind>
  : Itest_TypeRef
{
  public Itest_DomainRefObject As_DomainRef { get; set; }
}

public interface Itest_DomainRefObject<Tkind>
  : Itest_TypeRefObject
{
  public Tkind DomainKind { get; set; }
}

public interface Itest_BaseDomain<Tdomain,Titem,TdomainItem>
  : Itest_ParentType
{
  public Itest_BaseDomainObject As_BaseDomain { get; set; }
}

public interface Itest_BaseDomainObject<Tdomain,Titem,TdomainItem>
  : Itest_ParentTypeObject
{
  public Tdomain DomainKind { get; set; }
}

public interface Itest_BaseDomainItem
  : Itest_Described
{
  public Itest_BaseDomainItemObject As_BaseDomainItem { get; set; }
}

public interface Itest_BaseDomainItemObject
  : Itest_DescribedObject
{
  public test_DomainKind Exclude { get; set; }
}

public interface Itest_DomainItem<Titem>
  : Itestitem
{
  public Itest_DomainItemObject As_DomainItem { get; set; }
}

public interface Itest_DomainItemObject<Titem>
  : ItestitemObject
{
  public Itest_Name Domain { get; set; }
}

public interface Itest_DomainValue<Tkind,Tvalue>
  : Itest_DomainRef
{
  public Tvalue Asvalue { get; set; }
  public Itest_DomainValueObject As_DomainValue { get; set; }
}

public interface Itest_DomainValueObject<Tkind,Tvalue>
  : Itest_DomainRefObject
{
  public Tvalue Value { get; set; }
}

public interface Itest_BasicValue
{
  public test_DomainKind As_DomainKindBoolean { get; set; }
  public Itest_EnumValue As_EnumValue { get; set; }
  public test_DomainKind As_DomainKindNumber { get; set; }
  public test_DomainKind As_DomainKindString { get; set; }
  public Itest_BasicValueObject As_BasicValue { get; set; }
}

public interface Itest_BasicValueObject
{
}

public interface Itest_DomainTrueFalse
  : Itest_BaseDomainItem
{
  public Itest_DomainTrueFalseObject As_DomainTrueFalse { get; set; }
}

public interface Itest_DomainTrueFalseObject
  : Itest_BaseDomainItemObject
{
  public test_DomainKind Value { get; set; }
}

public interface Itest_DomainItemTrueFalse
  : Itest_DomainItem
{
  public Itest_DomainItemTrueFalseObject As_DomainItemTrueFalse { get; set; }
}

public interface Itest_DomainItemTrueFalseObject
  : Itest_DomainItemObject
{
}

public interface Itest_DomainLabel
  : Itest_BaseDomainItem
{
  public Itest_DomainLabelObject As_DomainLabel { get; set; }
}

public interface Itest_DomainLabelObject
  : Itest_BaseDomainItemObject
{
  public Itest_EnumValue Label { get; set; }
}

public interface Itest_DomainItemLabel
  : Itest_DomainItem
{
  public Itest_DomainItemLabelObject As_DomainItemLabel { get; set; }
}

public interface Itest_DomainItemLabelObject
  : Itest_DomainItemObject
{
}

public interface Itest_DomainRange
  : Itest_BaseDomainItem
{
  public Itest_DomainRangeObject As_DomainRange { get; set; }
}

public interface Itest_DomainRangeObject
  : Itest_BaseDomainItemObject
{
  public test_DomainKind? Lower { get; set; }
  public test_DomainKind? Upper { get; set; }
}

public interface Itest_DomainItemRange
  : Itest_DomainItem
{
  public Itest_DomainItemRangeObject As_DomainItemRange { get; set; }
}

public interface Itest_DomainItemRangeObject
  : Itest_DomainItemObject
{
}

public interface Itest_DomainRegex
  : Itest_BaseDomainItem
{
  public Itest_DomainRegexObject As_DomainRegex { get; set; }
}

public interface Itest_DomainRegexObject
  : Itest_BaseDomainItemObject
{
  public test_DomainKind Pattern { get; set; }
}

public interface Itest_DomainItemRegex
  : Itest_DomainItem
{
  public Itest_DomainItemRegexObject As_DomainItemRegex { get; set; }
}

public interface Itest_DomainItemRegexObject
  : Itest_DomainItemObject
{
}

public interface Itest_EnumLabel
  : Itest_Aliased
{
  public Itest_EnumLabelObject As_EnumLabel { get; set; }
}

public interface Itest_EnumLabelObject
  : Itest_AliasedObject
{
  public Itest_Name Enum { get; set; }
}

public interface Itest_EnumValue
  : Itest_TypeRef
{
  public Itest_EnumValueObject As_EnumValue { get; set; }
}

public interface Itest_EnumValueObject
  : Itest_TypeRefObject
{
  public Itest_Name Label { get; set; }
}

public interface Itest_UnionRef
  : Itest_TypeRef
{
  public Itest_UnionRefObject As_UnionRef { get; set; }
}

public interface Itest_UnionRefObject
  : Itest_TypeRefObject
{
}

public interface Itest_UnionMember
  : Itest_UnionRef
{
  public Itest_UnionMemberObject As_UnionMember { get; set; }
}

public interface Itest_UnionMemberObject
  : Itest_UnionRefObject
{
  public Itest_Name Union { get; set; }
}

public interface Itest_ObjectKind
  : IDomainEnum
{
}

public interface Itest_TypeObject<Tkind,Tfield>
  : Itest_ChildType
{
  public Itest_TypeObjectObject As_TypeObject { get; set; }
}

public interface Itest_TypeObjectObject<Tkind,Tfield>
  : Itest_ChildTypeObject
{
  public ICollection<Itest_ObjTypeParam> TypeParams { get; set; }
  public ICollection<Tfield> Fields { get; set; }
  public ICollection<Itest_ObjAlternate> Alternates { get; set; }
  public ICollection<Itest_ObjectFor<Tfield>> AllFields { get; set; }
  public ICollection<Itest_ObjectFor<Itest_ObjAlternate>> AllAlternates { get; set; }
}

public interface Itest_ObjTypeParam
  : Itest_Named
{
  public Itest_ObjTypeParamObject As_ObjTypeParam { get; set; }
}

public interface Itest_ObjTypeParamObject
  : Itest_NamedObject
{
  public Itest_TypeRef<test_TypeKind> Constraint { get; set; }
}

public interface Itest_ObjBase
  : Itest_Named
{
  public Itest_TypeParam As_TypeParam { get; set; }
  public Itest_ObjBaseObject As_ObjBase { get; set; }
}

public interface Itest_ObjBaseObject
  : Itest_NamedObject
{
  public ICollection<Itest_ObjTypeArg> TypeArgs { get; set; }
}

public interface Itest_ObjTypeArg
  : Itest_TypeRef
{
  public Itest_TypeParam As_TypeParam { get; set; }
  public Itest_ObjTypeArgObject As_ObjTypeArg { get; set; }
}

public interface Itest_ObjTypeArgObject
  : Itest_TypeRefObject
{
  public Itest_Name? Label { get; set; }
}

public interface Itest_TypeParam
  : Itest_Described
{
  public Itest_TypeParamObject As_TypeParam { get; set; }
}

public interface Itest_TypeParamObject
  : Itest_DescribedObject
{
  public Itest_Name TypeParam { get; set; }
}

public interface Itest_ObjAlternate
{
  public Itest_ObjAlternateEnum As_ObjAlternateEnum { get; set; }
  public Itest_ObjAlternateObject As_ObjAlternate { get; set; }
}

public interface Itest_ObjAlternateObject
{
  public Itest_ObjBase Type { get; set; }
  public ICollection<Itest_Collections> Collections { get; set; }
}

public interface Itest_ObjAlternateEnum
  : Itest_TypeRef
{
  public Itest_ObjAlternateEnumObject As_ObjAlternateEnum { get; set; }
}

public interface Itest_ObjAlternateEnumObject
  : Itest_TypeRefObject
{
  public Itest_Name Label { get; set; }
}

public interface Itest_ObjectFor<Tfor>
  : Itestfor
{
  public Itest_ObjectForObject As_ObjectFor { get; set; }
}

public interface Itest_ObjectForObject<Tfor>
  : ItestforObject
{
  public Itest_Name Object { get; set; }
}

public interface Itest_ObjField<Ttype>
  : Itest_Aliased
{
  public Itest_ObjFieldObject As_ObjField { get; set; }
}

public interface Itest_ObjFieldObject<Ttype>
  : Itest_AliasedObject
{
  public Ttype Type { get; set; }
}

public interface Itest_ObjFieldType
  : Itest_ObjBase
{
  public Itest_ObjFieldEnum As_ObjFieldEnum { get; set; }
  public Itest_ObjFieldTypeObject As_ObjFieldType { get; set; }
}

public interface Itest_ObjFieldTypeObject
  : Itest_ObjBaseObject
{
  public ICollection<Itest_Modifiers> Modifiers { get; set; }
}

public interface Itest_ObjFieldEnum
  : Itest_TypeRef
{
  public Itest_ObjFieldEnumObject As_ObjFieldEnum { get; set; }
}

public interface Itest_ObjFieldEnumObject
  : Itest_TypeRefObject
{
  public Itest_Name Label { get; set; }
}

public interface Itest_ForParam<Ttype>
{
  public Itest_ObjAlternate As_ObjAlternate { get; set; }
  public Itest_ObjField<Ttype> As_ObjField { get; set; }
  public Itest_ForParamObject As_ForParam { get; set; }
}

public interface Itest_ForParamObject<Ttype>
{
}

public interface Itest_DualField
  : Itest_ObjField
{
  public Itest_DualFieldObject As_DualField { get; set; }
}

public interface Itest_DualFieldObject
  : Itest_ObjFieldObject
{
}

public interface Itest_InputField
  : Itest_ObjField
{
  public Itest_InputFieldObject As_InputField { get; set; }
}

public interface Itest_InputFieldObject
  : Itest_ObjFieldObject
{
}

public interface Itest_InputFieldType
  : Itest_ObjFieldType
{
  public Itest_InputFieldTypeObject As_InputFieldType { get; set; }
}

public interface Itest_InputFieldTypeObject
  : Itest_ObjFieldTypeObject
{
  public Itest_Value? Default { get; set; }
}

public interface Itest_InputParam
  : Itest_InputFieldType
{
  public Itest_InputParamObject As_InputParam { get; set; }
}

public interface Itest_InputParamObject
  : Itest_InputFieldTypeObject
{
}

public interface Itest_OutputField
  : Itest_ObjField
{
  public Itest_OutputFieldObject As_OutputField { get; set; }
}

public interface Itest_OutputFieldObject
  : Itest_ObjFieldObject
{
}

public interface Itest_OutputFieldType
  : Itest_ObjFieldType
{
  public Itest_OutputFieldTypeObject As_OutputFieldType { get; set; }
}

public interface Itest_OutputFieldTypeObject
  : Itest_ObjFieldTypeObject
{
  public ICollection<Itest_InputParam> Parameters { get; set; }
}
