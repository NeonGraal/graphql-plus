//HintName: test_Introspection_Intf.gen.cs
// Generated from Introspection.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Introspection;

public interface Itest_Schema
  : Itest_Named
{
  Itest_SchemaObject As_Schema { get; }
}

public interface Itest_SchemaObject
  : Itest_NamedObject
{
  IDictionary<test_Name, Itest_Categories> Categories { get; }
  IDictionary<test_Name, Itest_Directives> Directives { get; }
  IDictionary<test_Name, Itest_Type> Types { get; }
  IDictionary<test_Name, Itest_Setting> Settings { get; }
}

public interface Itest_Name
  : IDomainString
{
}

public interface Itest_Filter
{
  ICollection<Itest_NameFilter> As_NameFilter { get; }
  Itest_FilterObject As_Filter { get; }
}

public interface Itest_FilterObject
{
  ICollection<Itest_NameFilter> Names { get; }
  test_DomainKind? MatchAliases { get; }
  ICollection<Itest_NameFilter> Aliases { get; }
  test_DomainKind? ReturnByAlias { get; }
  test_DomainKind? ReturnReferencedTypes { get; }
}

public interface Itest_NameFilter
  : IDomainString
{
}

public interface Itest_CategoryFilter
  : Itest_Filter
{
  Itest_CategoryFilterObject As_CategoryFilter { get; }
}

public interface Itest_CategoryFilterObject
  : Itest_FilterObject
{
  ICollection<test_Resolution> Resolutions { get; }
}

public interface Itest_TypeFilter
  : Itest_Filter
{
  Itest_TypeFilterObject As_TypeFilter { get; }
}

public interface Itest_TypeFilterObject
  : Itest_FilterObject
{
  ICollection<test_TypeKind> Kinds { get; }
}

public interface Itest_Aliased
  : Itest_Named
{
  Itest_AliasedObject As_Aliased { get; }
}

public interface Itest_AliasedObject
  : Itest_NamedObject
{
  ICollection<Itest_Name> Aliases { get; }
}

public interface Itest_Named
  : Itest_Described
{
  Itest_NamedObject As_Named { get; }
}

public interface Itest_NamedObject
  : Itest_DescribedObject
{
  Itest_Name Name { get; }
}

public interface Itest_Described
{
  Itest_DescribedObject As_Described { get; }
}

public interface Itest_DescribedObject
{
  ICollection<test_DomainKind> Description { get; }
}

public interface Itest_AndType
  : Itest_Named
{
  Itest_Type As_Type { get; }
  Itest_AndTypeObject As_AndType { get; }
}

public interface Itest_AndTypeObject
  : Itest_NamedObject
{
  Itest_Type Type { get; }
}

public interface Itest_Categories
  : Itest_AndType
{
  Itest_Category As_Category { get; }
  Itest_CategoriesObject As_Categories { get; }
}

public interface Itest_CategoriesObject
  : Itest_AndTypeObject
{
  Itest_Category Category { get; }
}

public interface Itest_Category
  : Itest_Aliased
{
  Itest_CategoryObject As_Category { get; }
}

public interface Itest_CategoryObject
  : Itest_AliasedObject
{
  test_Resolution Resolution { get; }
  Itest_TypeRef<test_TypeKind> Output { get; }
  ICollection<Itest_Modifiers> Modifiers { get; }
}

public interface Itest_Directives
  : Itest_AndType
{
  Itest_Directive As_Directive { get; }
  Itest_DirectivesObject As_Directives { get; }
}

public interface Itest_DirectivesObject
  : Itest_AndTypeObject
{
  Itest_Directive Directive { get; }
}

public interface Itest_Directive
  : Itest_Aliased
{
  Itest_DirectiveObject As_Directive { get; }
}

public interface Itest_DirectiveObject
  : Itest_AliasedObject
{
  ICollection<Itest_InputParam> Parameters { get; }
  test_DomainKind Repeatable { get; }
  IDictionary<test_Location, testUnit> Locations { get; }
}

public interface Itest_Setting
  : Itest_Named
{
  Itest_SettingObject As_Setting { get; }
}

public interface Itest_SettingObject
  : Itest_NamedObject
{
  Itest_Value Value { get; }
}

public interface Itest_Type
{
  Itest_BaseType<test_TypeKind> As_BaseType { get; }
  Itest_BaseType<test_TypeKind> As_BaseType { get; }
  Itest_BaseDomain<test_DomainKind, Itest_DomainTrueFalse, Itest_DomainItemTrueFalse> As_BaseDomain { get; }
  Itest_BaseDomain<test_DomainKind, Itest_DomainLabel, Itest_DomainItemLabel> As_BaseDomain { get; }
  Itest_BaseDomain<test_DomainKind, Itest_DomainRange, Itest_DomainItemRange> As_BaseDomain { get; }
  Itest_BaseDomain<test_DomainKind, Itest_DomainRegex, Itest_DomainItemRegex> As_BaseDomain { get; }
  Itest_ParentType<test_TypeKind, Itest_Aliased, Itest_EnumLabel> As_ParentType { get; }
  Itest_ParentType<test_TypeKind, Itest_UnionRef, Itest_UnionMember> As_ParentType { get; }
  Itest_TypeObject<test_TypeKind, Itest_DualField> As_TypeObject { get; }
  Itest_TypeObject<test_TypeKind, Itest_InputField> As_TypeObject { get; }
  Itest_TypeObject<test_TypeKind, Itest_OutputField> As_TypeObject { get; }
  Itest_TypeObject As_Type { get; }
}

public interface Itest_TypeObject
{
}

public interface Itest_BaseType<Tkind>
  : Itest_Aliased
{
  Itest_BaseTypeObject As_BaseType { get; }
}

public interface Itest_BaseTypeObject<Tkind>
  : Itest_AliasedObject
{
  Tkind TypeKind { get; }
}

public interface Itest_ChildType<Tkind,Tparent>
  : Itest_BaseType
{
  Itest_ChildTypeObject As_ChildType { get; }
}

public interface Itest_ChildTypeObject<Tkind,Tparent>
  : Itest_BaseTypeObject
{
  Tparent Parent { get; }
}

public interface Itest_ParentType<Tkind,Titem,TallItem>
  : Itest_ChildType
{
  Itest_ParentTypeObject As_ParentType { get; }
}

public interface Itest_ParentTypeObject<Tkind,Titem,TallItem>
  : Itest_ChildTypeObject
{
  ICollection<Titem> Items { get; }
  ICollection<TallItem> AllItems { get; }
}

public interface Itest_TypeRef<Tkind>
  : Itest_Named
{
  Itest_TypeRefObject As_TypeRef { get; }
}

public interface Itest_TypeRefObject<Tkind>
  : Itest_NamedObject
{
  Tkind TypeKind { get; }
}

public interface Itest_TypeSimple
{
  Itest_TypeRef<test_TypeKind> As_TypeRef { get; }
  Itest_TypeRef<test_TypeKind> As_TypeRef { get; }
  Itest_TypeRef<test_TypeKind> As_TypeRef { get; }
  Itest_TypeRef<test_TypeKind> As_TypeRef { get; }
  Itest_TypeSimpleObject As_TypeSimple { get; }
}

public interface Itest_TypeSimpleObject
{
}

public interface Itest_Collections
{
  Itest_Modifier<test_ModifierKind> As_Modifier { get; }
  Itest_ModifierKeyed<test_ModifierKind> As_ModifierKeyed { get; }
  Itest_ModifierKeyed<test_ModifierKind> As_ModifierKeyed { get; }
  Itest_CollectionsObject As_Collections { get; }
}

public interface Itest_CollectionsObject
{
}

public interface Itest_ModifierKeyed<Tkind>
  : Itest_Modifier
{
  Itest_ModifierKeyedObject As_ModifierKeyed { get; }
}

public interface Itest_ModifierKeyedObject<Tkind>
  : Itest_ModifierObject
{
  Itest_TypeSimple By { get; }
  test_DomainKind Optional { get; }
}

public interface Itest_Modifiers
{
  Itest_Modifier<test_ModifierKind> As_Modifier { get; }
  Itest_Collections As_Collections { get; }
  Itest_ModifiersObject As_Modifiers { get; }
}

public interface Itest_ModifiersObject
{
}

public interface Itest_Modifier<Tkind>
{
  Itest_ModifierObject As_Modifier { get; }
}

public interface Itest_ModifierObject<Tkind>
{
  Tkind ModifierKind { get; }
}

public interface Itest_DomainRef<Tkind>
  : Itest_TypeRef
{
  Itest_DomainRefObject As_DomainRef { get; }
}

public interface Itest_DomainRefObject<Tkind>
  : Itest_TypeRefObject
{
  Tkind DomainKind { get; }
}

public interface Itest_BaseDomain<Tdomain,Titem,TdomainItem>
  : Itest_ParentType
{
  Itest_BaseDomainObject As_BaseDomain { get; }
}

public interface Itest_BaseDomainObject<Tdomain,Titem,TdomainItem>
  : Itest_ParentTypeObject
{
  Tdomain DomainKind { get; }
}

public interface Itest_BaseDomainItem
  : Itest_Described
{
  Itest_BaseDomainItemObject As_BaseDomainItem { get; }
}

public interface Itest_BaseDomainItemObject
  : Itest_DescribedObject
{
  test_DomainKind Exclude { get; }
}

public interface Itest_DomainItem<Titem>
  : Itestitem
{
  Itest_DomainItemObject As_DomainItem { get; }
}

public interface Itest_DomainItemObject<Titem>
  : ItestitemObject
{
  Itest_Name Domain { get; }
}

public interface Itest_DomainValue<Tkind,Tvalue>
  : Itest_DomainRef
{
  Tvalue Asvalue { get; }
  Itest_DomainValueObject As_DomainValue { get; }
}

public interface Itest_DomainValueObject<Tkind,Tvalue>
  : Itest_DomainRefObject
{
  Tvalue Value { get; }
}

public interface Itest_BasicValue
{
  test_DomainKind As_DomainKindBoolean { get; }
  Itest_EnumValue As_EnumValue { get; }
  test_DomainKind As_DomainKindNumber { get; }
  test_DomainKind As_DomainKindString { get; }
  Itest_BasicValueObject As_BasicValue { get; }
}

public interface Itest_BasicValueObject
{
}

public interface Itest_DomainTrueFalse
  : Itest_BaseDomainItem
{
  Itest_DomainTrueFalseObject As_DomainTrueFalse { get; }
}

public interface Itest_DomainTrueFalseObject
  : Itest_BaseDomainItemObject
{
  test_DomainKind Value { get; }
}

public interface Itest_DomainItemTrueFalse
  : Itest_DomainItem
{
  Itest_DomainItemTrueFalseObject As_DomainItemTrueFalse { get; }
}

public interface Itest_DomainItemTrueFalseObject
  : Itest_DomainItemObject
{
}

public interface Itest_DomainLabel
  : Itest_BaseDomainItem
{
  Itest_DomainLabelObject As_DomainLabel { get; }
}

public interface Itest_DomainLabelObject
  : Itest_BaseDomainItemObject
{
  Itest_EnumValue Label { get; }
}

public interface Itest_DomainItemLabel
  : Itest_DomainItem
{
  Itest_DomainItemLabelObject As_DomainItemLabel { get; }
}

public interface Itest_DomainItemLabelObject
  : Itest_DomainItemObject
{
}

public interface Itest_DomainRange
  : Itest_BaseDomainItem
{
  Itest_DomainRangeObject As_DomainRange { get; }
}

public interface Itest_DomainRangeObject
  : Itest_BaseDomainItemObject
{
  test_DomainKind? Lower { get; }
  test_DomainKind? Upper { get; }
}

public interface Itest_DomainItemRange
  : Itest_DomainItem
{
  Itest_DomainItemRangeObject As_DomainItemRange { get; }
}

public interface Itest_DomainItemRangeObject
  : Itest_DomainItemObject
{
}

public interface Itest_DomainRegex
  : Itest_BaseDomainItem
{
  Itest_DomainRegexObject As_DomainRegex { get; }
}

public interface Itest_DomainRegexObject
  : Itest_BaseDomainItemObject
{
  test_DomainKind Pattern { get; }
}

public interface Itest_DomainItemRegex
  : Itest_DomainItem
{
  Itest_DomainItemRegexObject As_DomainItemRegex { get; }
}

public interface Itest_DomainItemRegexObject
  : Itest_DomainItemObject
{
}

public interface Itest_EnumLabel
  : Itest_Aliased
{
  Itest_EnumLabelObject As_EnumLabel { get; }
}

public interface Itest_EnumLabelObject
  : Itest_AliasedObject
{
  Itest_Name Enum { get; }
}

public interface Itest_EnumValue
  : Itest_TypeRef
{
  Itest_EnumValueObject As_EnumValue { get; }
}

public interface Itest_EnumValueObject
  : Itest_TypeRefObject
{
  Itest_Name Label { get; }
}

public interface Itest_UnionRef
  : Itest_TypeRef
{
  Itest_UnionRefObject As_UnionRef { get; }
}

public interface Itest_UnionRefObject
  : Itest_TypeRefObject
{
}

public interface Itest_UnionMember
  : Itest_UnionRef
{
  Itest_UnionMemberObject As_UnionMember { get; }
}

public interface Itest_UnionMemberObject
  : Itest_UnionRefObject
{
  Itest_Name Union { get; }
}

public interface Itest_ObjectKind
  : IDomainEnum
{
}

public interface Itest_TypeObject<Tkind,Tfield>
  : Itest_ChildType
{
  Itest_TypeObjectObject As_TypeObject { get; }
}

public interface Itest_TypeObjectObject<Tkind,Tfield>
  : Itest_ChildTypeObject
{
  ICollection<Itest_ObjTypeParam> TypeParams { get; }
  ICollection<Tfield> Fields { get; }
  ICollection<Itest_ObjAlternate> Alternates { get; }
  ICollection<Itest_ObjectFor<Tfield>> AllFields { get; }
  ICollection<Itest_ObjectFor<Itest_ObjAlternate>> AllAlternates { get; }
}

public interface Itest_ObjTypeParam
  : Itest_Named
{
  Itest_ObjTypeParamObject As_ObjTypeParam { get; }
}

public interface Itest_ObjTypeParamObject
  : Itest_NamedObject
{
  Itest_TypeRef<test_TypeKind> Constraint { get; }
}

public interface Itest_ObjBase
  : Itest_Named
{
  Itest_TypeParam As_TypeParam { get; }
  Itest_ObjBaseObject As_ObjBase { get; }
}

public interface Itest_ObjBaseObject
  : Itest_NamedObject
{
  ICollection<Itest_ObjTypeArg> TypeArgs { get; }
}

public interface Itest_ObjTypeArg
  : Itest_TypeRef
{
  Itest_TypeParam As_TypeParam { get; }
  Itest_ObjTypeArgObject As_ObjTypeArg { get; }
}

public interface Itest_ObjTypeArgObject
  : Itest_TypeRefObject
{
  Itest_Name? Label { get; }
}

public interface Itest_TypeParam
  : Itest_Described
{
  Itest_TypeParamObject As_TypeParam { get; }
}

public interface Itest_TypeParamObject
  : Itest_DescribedObject
{
  Itest_Name TypeParam { get; }
}

public interface Itest_ObjAlternate
{
  Itest_ObjAlternateEnum As_ObjAlternateEnum { get; }
  Itest_ObjAlternateObject As_ObjAlternate { get; }
}

public interface Itest_ObjAlternateObject
{
  Itest_ObjBase Type { get; }
  ICollection<Itest_Collections> Collections { get; }
}

public interface Itest_ObjAlternateEnum
  : Itest_TypeRef
{
  Itest_ObjAlternateEnumObject As_ObjAlternateEnum { get; }
}

public interface Itest_ObjAlternateEnumObject
  : Itest_TypeRefObject
{
  Itest_Name Label { get; }
}

public interface Itest_ObjectFor<Tfor>
  : Itestfor
{
  Itest_ObjectForObject As_ObjectFor { get; }
}

public interface Itest_ObjectForObject<Tfor>
  : ItestforObject
{
  Itest_Name Object { get; }
}

public interface Itest_ObjField<Ttype>
  : Itest_Aliased
{
  Itest_ObjFieldObject As_ObjField { get; }
}

public interface Itest_ObjFieldObject<Ttype>
  : Itest_AliasedObject
{
  Ttype Type { get; }
}

public interface Itest_ObjFieldType
  : Itest_ObjBase
{
  Itest_ObjFieldEnum As_ObjFieldEnum { get; }
  Itest_ObjFieldTypeObject As_ObjFieldType { get; }
}

public interface Itest_ObjFieldTypeObject
  : Itest_ObjBaseObject
{
  ICollection<Itest_Modifiers> Modifiers { get; }
}

public interface Itest_ObjFieldEnum
  : Itest_TypeRef
{
  Itest_ObjFieldEnumObject As_ObjFieldEnum { get; }
}

public interface Itest_ObjFieldEnumObject
  : Itest_TypeRefObject
{
  Itest_Name Label { get; }
}

public interface Itest_ForParam<Ttype>
{
  Itest_ObjAlternate As_ObjAlternate { get; }
  Itest_ObjField<Ttype> As_ObjField { get; }
  Itest_ForParamObject As_ForParam { get; }
}

public interface Itest_ForParamObject<Ttype>
{
}

public interface Itest_DualField
  : Itest_ObjField
{
  Itest_DualFieldObject As_DualField { get; }
}

public interface Itest_DualFieldObject
  : Itest_ObjFieldObject
{
}

public interface Itest_InputField
  : Itest_ObjField
{
  Itest_InputFieldObject As_InputField { get; }
}

public interface Itest_InputFieldObject
  : Itest_ObjFieldObject
{
}

public interface Itest_InputFieldType
  : Itest_ObjFieldType
{
  Itest_InputFieldTypeObject As_InputFieldType { get; }
}

public interface Itest_InputFieldTypeObject
  : Itest_ObjFieldTypeObject
{
  Itest_Value? Default { get; }
}

public interface Itest_InputParam
  : Itest_InputFieldType
{
  Itest_InputParamObject As_InputParam { get; }
}

public interface Itest_InputParamObject
  : Itest_InputFieldTypeObject
{
}

public interface Itest_OutputField
  : Itest_ObjField
{
  Itest_OutputFieldObject As_OutputField { get; }
}

public interface Itest_OutputFieldObject
  : Itest_ObjFieldObject
{
}

public interface Itest_OutputFieldType
  : Itest_ObjFieldType
{
  Itest_OutputFieldTypeObject As_OutputFieldType { get; }
}

public interface Itest_OutputFieldTypeObject
  : Itest_ObjFieldTypeObject
{
  ICollection<Itest_InputParam> Parameters { get; }
}
