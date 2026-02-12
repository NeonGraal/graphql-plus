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
  IDictionary<Itest_Name, Itest_Categories> Categories { get; }
  IDictionary<Itest_Name, Itest_Directives> Directives { get; }
  IDictionary<Itest_Name, Itest_Type> Types { get; }
  IDictionary<Itest_Name, Itest_Setting> Settings { get; }
}

public interface Itest_Name
  : IGqlpDomainString
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
  : IGqlpDomainString
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
  IDictionary<test_Location, GqlpUnit> Locations { get; }
}

public interface Itest_Setting
  : Itest_Named
{
  Itest_SettingObject As_Setting { get; }
}

public interface Itest_SettingObject
  : Itest_NamedObject
{
  GqlpValue Value { get; }
}

public interface Itest_Type
{
  Itest_BaseType<test_TypeKind> As_TypeKindBasic { get; }
  Itest_BaseType<test_TypeKind> As_TypeKindInternal { get; }
  Itest_BaseDomain<test_DomainKind, Itest_DomainTrueFalse, Itest_DomainItemTrueFalse> As_DomainKindBoolean { get; }
  Itest_BaseDomain<test_DomainKind, Itest_DomainLabel, Itest_DomainItemLabel> As_DomainKindEnum { get; }
  Itest_BaseDomain<test_DomainKind, Itest_DomainRange, Itest_DomainItemRange> As_DomainKindNumber { get; }
  Itest_BaseDomain<test_DomainKind, Itest_DomainRegex, Itest_DomainItemRegex> As_DomainKindString { get; }
  Itest_ParentType<test_TypeKind, Itest_Aliased, Itest_EnumLabel> As_TypeKindEnum { get; }
  Itest_ParentType<test_TypeKind, Itest_UnionRef, Itest_UnionMember> As_TypeKindUnion { get; }
  Itest_TypeObject<test_TypeKind, Itest_DualField> As_TypeKindDual { get; }
  Itest_TypeObject<test_TypeKind, Itest_InputField> As_TypeKindInput { get; }
  Itest_TypeObject<test_TypeKind, Itest_OutputField> As_TypeKindOutput { get; }
  Itest_TypeObject As_Type { get; }
}

public interface Itest_TypeObject
{
}

public interface Itest_BaseType<TKind>
  : Itest_Aliased
{
  Itest_BaseTypeObject<TKind> As_BaseType { get; }
}

public interface Itest_BaseTypeObject<TKind>
  : Itest_AliasedObject
{
  TKind TypeKind { get; }
}

public interface Itest_ChildType<TKind,TParent>
  : Itest_BaseType<TKind>
{
  Itest_ChildTypeObject<TKind,TParent> As_ChildType { get; }
}

public interface Itest_ChildTypeObject<TKind,TParent>
  : Itest_BaseTypeObject<TKind>
{
  TParent Parent { get; }
}

public interface Itest_ParentType<TKind,TItem,TAllItem>
  : Itest_ChildType<TKind, Itest_Named>
{
  Itest_ParentTypeObject<TKind,TItem,TAllItem> As_ParentType { get; }
}

public interface Itest_ParentTypeObject<TKind,TItem,TAllItem>
  : Itest_ChildTypeObject<TKind, Itest_Named>
{
  ICollection<TItem> Items { get; }
  ICollection<TAllItem> AllItems { get; }
}

public interface Itest_TypeRef<TKind>
  : Itest_Named
{
  Itest_TypeRefObject<TKind> As_TypeRef { get; }
}

public interface Itest_TypeRefObject<TKind>
  : Itest_NamedObject
{
  TKind TypeKind { get; }
}

public interface Itest_TypeSimple
{
  Itest_TypeRef<test_TypeKind> As_TypeKindBasic { get; }
  Itest_TypeRef<test_TypeKind> As_TypeKindEnum { get; }
  Itest_TypeRef<test_TypeKind> As_TypeKindDomain { get; }
  Itest_TypeRef<test_TypeKind> As_TypeKindUnion { get; }
  Itest_TypeSimpleObject As_TypeSimple { get; }
}

public interface Itest_TypeSimpleObject
{
}

public interface Itest_Collections
{
  Itest_Modifier<test_ModifierKind> As_ModifierKindList { get; }
  Itest_ModifierKeyed<test_ModifierKind> As_ModifierKindDictionary { get; }
  Itest_ModifierKeyed<test_ModifierKind> As_ModifierKindTypeParam { get; }
  Itest_CollectionsObject As_Collections { get; }
}

public interface Itest_CollectionsObject
{
}

public interface Itest_ModifierKeyed<TKind>
  : Itest_Modifier<TKind>
{
  Itest_ModifierKeyedObject<TKind> As_ModifierKeyed { get; }
}

public interface Itest_ModifierKeyedObject<TKind>
  : Itest_ModifierObject<TKind>
{
  Itest_TypeSimple By { get; }
  test_DomainKind Optional { get; }
}

public interface Itest_Modifiers
{
  Itest_Modifier<test_ModifierKind> As_ModifierKindOptional { get; }
  Itest_Collections As_Collections { get; }
  Itest_ModifiersObject As_Modifiers { get; }
}

public interface Itest_ModifiersObject
{
}

public interface Itest_Modifier<TKind>
{
  Itest_ModifierObject<TKind> As_Modifier { get; }
}

public interface Itest_ModifierObject<TKind>
{
  TKind ModifierKind { get; }
}

public interface Itest_DomainRef<TKind>
  : Itest_TypeRef<test_TypeKind>
{
  Itest_DomainRefObject<TKind> As_DomainRef { get; }
}

public interface Itest_DomainRefObject<TKind>
  : Itest_TypeRefObject<test_TypeKind>
{
  TKind DomainKind { get; }
}

public interface Itest_BaseDomain<TDomain,TItem,TDomainItem>
  : Itest_ParentType<test_TypeKind, TItem, TDomainItem>
{
  Itest_BaseDomainObject<TDomain,TItem,TDomainItem> As_BaseDomain { get; }
}

public interface Itest_BaseDomainObject<TDomain,TItem,TDomainItem>
  : Itest_ParentTypeObject<test_TypeKind, TItem, TDomainItem>
{
  TDomain DomainKind { get; }
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

public interface Itest_DomainItem<TItem>
{
  TItem AsParent { get; }
  Itest_DomainItemObject<TItem> As_DomainItem { get; }
}

public interface Itest_DomainItemObject<TItem>
{
  Itest_Name Domain { get; }
}

public interface Itest_DomainValue<TKind,TValue>
  : Itest_DomainRef<TKind>
{
  TValue Asvalue { get; }
  Itest_DomainValueObject<TKind,TValue> As_DomainValue { get; }
}

public interface Itest_DomainValueObject<TKind,TValue>
  : Itest_DomainRefObject<TKind>
{
  TValue Value { get; }
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
  : Itest_DomainItem<Itest_DomainTrueFalse>
{
  Itest_DomainItemTrueFalseObject As_DomainItemTrueFalse { get; }
}

public interface Itest_DomainItemTrueFalseObject
  : Itest_DomainItemObject<Itest_DomainTrueFalse>
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
  : Itest_DomainItem<Itest_DomainLabel>
{
  Itest_DomainItemLabelObject As_DomainItemLabel { get; }
}

public interface Itest_DomainItemLabelObject
  : Itest_DomainItemObject<Itest_DomainLabel>
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
  : Itest_DomainItem<Itest_DomainRange>
{
  Itest_DomainItemRangeObject As_DomainItemRange { get; }
}

public interface Itest_DomainItemRangeObject
  : Itest_DomainItemObject<Itest_DomainRange>
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
  : Itest_DomainItem<Itest_DomainRegex>
{
  Itest_DomainItemRegexObject As_DomainItemRegex { get; }
}

public interface Itest_DomainItemRegexObject
  : Itest_DomainItemObject<Itest_DomainRegex>
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
  : Itest_TypeRef<test_TypeKind>
{
  Itest_EnumValueObject As_EnumValue { get; }
}

public interface Itest_EnumValueObject
  : Itest_TypeRefObject<test_TypeKind>
{
  Itest_Name Label { get; }
}

public interface Itest_UnionRef
  : Itest_TypeRef<test_SimpleKind>
{
  Itest_UnionRefObject As_UnionRef { get; }
}

public interface Itest_UnionRefObject
  : Itest_TypeRefObject<test_SimpleKind>
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
  : IGqlpDomainEnum
{
}

public interface Itest_TypeObject<TKind,TField>
  : Itest_ChildType<TKind, Itest_ObjBase>
{
  Itest_TypeObjectObject<TKind,TField> As_TypeObject { get; }
}

public interface Itest_TypeObjectObject<TKind,TField>
  : Itest_ChildTypeObject<TKind, Itest_ObjBase>
{
  ICollection<Itest_ObjTypeParam> TypeParams { get; }
  ICollection<TField> Fields { get; }
  ICollection<Itest_ObjAlternate> Alternates { get; }
  ICollection<Itest_ObjectFor<TField>> AllFields { get; }
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
  : Itest_TypeRef<test_TypeKind>
{
  Itest_TypeParam As_TypeParam { get; }
  Itest_ObjTypeArgObject As_ObjTypeArg { get; }
}

public interface Itest_ObjTypeArgObject
  : Itest_TypeRefObject<test_TypeKind>
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
  : Itest_TypeRef<test_TypeKind>
{
  Itest_ObjAlternateEnumObject As_ObjAlternateEnum { get; }
}

public interface Itest_ObjAlternateEnumObject
  : Itest_TypeRefObject<test_TypeKind>
{
  Itest_Name Label { get; }
}

public interface Itest_ObjectFor<TFor>
{
  TFor AsParent { get; }
  Itest_ObjectForObject<TFor> As_ObjectFor { get; }
}

public interface Itest_ObjectForObject<TFor>
{
  Itest_Name Object { get; }
}

public interface Itest_ObjField<TType>
  : Itest_Aliased
{
  Itest_ObjFieldObject<TType> As_ObjField { get; }
}

public interface Itest_ObjFieldObject<TType>
  : Itest_AliasedObject
{
  TType Type { get; }
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
  : Itest_TypeRef<test_TypeKind>
{
  Itest_ObjFieldEnumObject As_ObjFieldEnum { get; }
}

public interface Itest_ObjFieldEnumObject
  : Itest_TypeRefObject<test_TypeKind>
{
  Itest_Name Label { get; }
}

public interface Itest_ForParam<TType>
{
  Itest_ObjAlternate As_ObjAlternate { get; }
  Itest_ObjField<TType> As_ObjField { get; }
  Itest_ForParamObject<TType> As_ForParam { get; }
}

public interface Itest_ForParamObject<TType>
{
}

public interface Itest_DualField
  : Itest_ObjField<Itest_ObjFieldType>
{
  Itest_DualFieldObject As_DualField { get; }
}

public interface Itest_DualFieldObject
  : Itest_ObjFieldObject<Itest_ObjFieldType>
{
}

public interface Itest_InputField
  : Itest_ObjField<Itest_InputFieldType>
{
  Itest_InputFieldObject As_InputField { get; }
}

public interface Itest_InputFieldObject
  : Itest_ObjFieldObject<Itest_InputFieldType>
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
  GqlpValue? Default { get; }
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
  : Itest_ObjField<Itest_ObjFieldType>
{
  Itest_OutputFieldObject As_OutputField { get; }
}

public interface Itest_OutputFieldObject
  : Itest_ObjFieldObject<Itest_ObjFieldType>
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
