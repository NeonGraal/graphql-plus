//HintName: test_Introspection_Intf.gen.cs
// Generated from {CurrentDirectory}Introspection.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Introspection;

public interface Itest_Schema
  : Itest_Named
{
  Itest_SchemaObject? As__Schema { get; }
}

public interface Itest_SchemaObject
  : Itest_NamedObject
{
  IDictionary<Itest_Name, Itest_Categories> Categories { get; }
  IDictionary<Itest_Name, Itest_Categories>? Call_Categories(Itest_CategoryFilter? parameter);
  IDictionary<Itest_Name, Itest_Directives> Directives { get; }
  IDictionary<Itest_Name, Itest_Directives>? Call_Directives(Itest_Filter? parameter);
  IDictionary<Itest_Name, Itest_Type> Types { get; }
  IDictionary<Itest_Name, Itest_Type>? Call_Types(Itest_TypeFilter? parameter);
  IDictionary<Itest_Name, Itest_Setting> Settings { get; }
  IDictionary<Itest_Name, Itest_Setting>? Call_Settings(Itest_Filter? parameter);
}

public interface Itest_Name
  : IGqlpDomainString
{
}

public interface Itest_Filter
  : IGqlpInterfaceBase
{
  ICollection<Itest_NameFilter>? As_NameFilter { get; }
  Itest_FilterObject? As__Filter { get; }
}

public interface Itest_FilterObject
  : IGqlpInterfaceBase
{
  ICollection<Itest_NameFilter> Names { get; }
  bool? MatchAliases { get; }
  ICollection<Itest_NameFilter> Aliases { get; }
  bool? ReturnByAlias { get; }
  bool? ReturnReferencedTypes { get; }
}

public interface Itest_NameFilter
  : IGqlpDomainString
{
}

public interface Itest_CategoryFilter
  : Itest_Filter
{
  Itest_CategoryFilterObject? As__CategoryFilter { get; }
}

public interface Itest_CategoryFilterObject
  : Itest_FilterObject
{
  ICollection<test_Resolution> Resolutions { get; }
}

public interface Itest_TypeFilter
  : Itest_Filter
{
  Itest_TypeFilterObject? As__TypeFilter { get; }
}

public interface Itest_TypeFilterObject
  : Itest_FilterObject
{
  ICollection<test_TypeKind> Kinds { get; }
}

public interface Itest_Aliased
  : Itest_Named
{
  Itest_AliasedObject? As__Aliased { get; }
}

public interface Itest_AliasedObject
  : Itest_NamedObject
{
  ICollection<Itest_Name> Aliases { get; }
}

public interface Itest_Named
  : Itest_Described
{
  Itest_NamedObject? As__Named { get; }
}

public interface Itest_NamedObject
  : Itest_DescribedObject
{
  Itest_Name Name { get; }
}

public interface Itest_Described
  : IGqlpInterfaceBase
{
  Itest_DescribedObject? As__Described { get; }
}

public interface Itest_DescribedObject
  : IGqlpInterfaceBase
{
  ICollection<string> Description { get; }
}

public interface Itest_AndType
  : Itest_Named
{
  Itest_Type? As_Type { get; }
  Itest_AndTypeObject? As__AndType { get; }
}

public interface Itest_AndTypeObject
  : Itest_NamedObject
{
  Itest_Type Type { get; }
}

public interface Itest_Categories
  : Itest_AndType
{
  Itest_Category? As_Category { get; }
  Itest_CategoriesObject? As__Categories { get; }
}

public interface Itest_CategoriesObject
  : Itest_AndTypeObject
{
  Itest_Category Category { get; }
}

public interface Itest_Category
  : Itest_Aliased
{
  Itest_CategoryObject? As__Category { get; }
}

public interface Itest_CategoryObject
  : Itest_AliasedObject
{
  test_Resolution Resolution { get; }
  Itest_TypeRef<test_TypeKind> Output { get; }
  ICollection<Itest_Modifiers> Modifiers { get; }
}

public enum test_Resolution
{
  Parallel,
  Sequential,
  Single,
}

public interface Itest_Directives
  : Itest_AndType
{
  Itest_Directive? As_Directive { get; }
  Itest_DirectivesObject? As__Directives { get; }
}

public interface Itest_DirectivesObject
  : Itest_AndTypeObject
{
  Itest_Directive Directive { get; }
}

public interface Itest_Directive
  : Itest_Aliased
{
  Itest_DirectiveObject? As__Directive { get; }
}

public interface Itest_DirectiveObject
  : Itest_AliasedObject
{
  Itest_InputFieldType? Parameter { get; }
  bool Repeatable { get; }
  IDictionary<test_Location, GqlpUnit> Locations { get; }
}

public enum test_Location
{
  Operation,
  Variable,
  Field,
  Inline,
  Spread,
  Fragment,
}

public interface Itest_Setting
  : Itest_Named
{
  Itest_SettingObject? As__Setting { get; }
}

public interface Itest_SettingObject
  : Itest_NamedObject
{
  GqlpValue Value { get; }
}

public interface Itest_Type
  : IGqlpInterfaceBase
{
  Itest_BaseType<test_TypeKind>? As_TypeKindBasic { get; }
  Itest_BaseType<test_TypeKind>? As_TypeKindInternal { get; }
  Itest_BaseDomain<test_DomainKind, Itest_DomainTrueFalse, Itest_DomainItemTrueFalse>? As_DomainKindBoolean { get; }
  Itest_BaseDomain<test_DomainKind, Itest_DomainLabel, Itest_DomainItemLabel>? As_DomainKindEnum { get; }
  Itest_BaseDomain<test_DomainKind, Itest_DomainRange, Itest_DomainItemRange>? As_DomainKindNumber { get; }
  Itest_BaseDomain<test_DomainKind, Itest_DomainRegex, Itest_DomainItemRegex>? As_DomainKindString { get; }
  Itest_ParentType<test_TypeKind, Itest_Aliased, Itest_EnumLabel>? As_TypeKindEnum { get; }
  Itest_ParentType<test_TypeKind, Itest_UnionRef, Itest_UnionMember>? As_TypeKindUnion { get; }
  Itest_TypeObject<test_TypeKind, Itest_DualField>? As_TypeKindDual { get; }
  Itest_TypeObject<test_TypeKind, Itest_InputField>? As_TypeKindInput { get; }
  Itest_TypeObject<test_TypeKind, Itest_OutputField>? As_TypeKindOutput { get; }
  Itest_TypeObject? As__Type { get; }
}

public interface Itest_TypeObject
  : IGqlpInterfaceBase
{
}

public interface Itest_BaseType<TTypeKind>
  : Itest_Aliased
{
  Itest_BaseTypeObject<TTypeKind>? As__BaseType { get; }
}

public interface Itest_BaseTypeObject<TTypeKind>
  : Itest_AliasedObject
{
  TTypeKind TypeKind { get; }
}

public interface Itest_ChildType<TTypeKind,TParent>
  : Itest_BaseType<TTypeKind>
{
  Itest_ChildTypeObject<TTypeKind,TParent>? As__ChildType { get; }
}

public interface Itest_ChildTypeObject<TTypeKind,TParent>
  : Itest_BaseTypeObject<TTypeKind>
{
  TParent Parent { get; }
}

public interface Itest_ParentType<TTypeKind,TItem,TAllItem>
  : Itest_ChildType<TTypeKind, Itest_Named>
{
  Itest_ParentTypeObject<TTypeKind,TItem,TAllItem>? As__ParentType { get; }
}

public interface Itest_ParentTypeObject<TTypeKind,TItem,TAllItem>
  : Itest_ChildTypeObject<TTypeKind, Itest_Named>
{
  ICollection<TItem> Items { get; }
  ICollection<TAllItem> AllItems { get; }
}

public enum test_SimpleKind
{
  Basic,
  Enum,
  Internal,
  Domain,
  Union,
}

public enum test_TypeKind
{
  Basic = test_SimpleKind.Basic,
  Enum = test_SimpleKind.Enum,
  Internal = test_SimpleKind.Internal,
  Domain = test_SimpleKind.Domain,
  Union = test_SimpleKind.Union,
  Dual,
  Input,
  Output,
}

public interface Itest_TypeRef<TTypeKind>
  : Itest_Named
{
  Itest_TypeRefObject<TTypeKind>? As__TypeRef { get; }
}

public interface Itest_TypeRefObject<TTypeKind>
  : Itest_NamedObject
{
  TTypeKind TypeKind { get; }
}

public interface Itest_TypeSimple
  : IGqlpInterfaceBase
{
  Itest_TypeRef<test_TypeKind>? As_TypeKindBasic { get; }
  Itest_TypeRef<test_TypeKind>? As_TypeKindEnum { get; }
  Itest_TypeRef<test_TypeKind>? As_TypeKindDomain { get; }
  Itest_TypeRef<test_TypeKind>? As_TypeKindUnion { get; }
  Itest_TypeSimpleObject? As__TypeSimple { get; }
}

public interface Itest_TypeSimpleObject
  : IGqlpInterfaceBase
{
}

public interface Itest_Collections
  : IGqlpInterfaceBase
{
  Itest_Modifier<test_ModifierKind>? As_ModifierKindList { get; }
  Itest_ModifierKeyed<test_ModifierKind>? As_ModifierKindDictionary { get; }
  Itest_ModifierKeyed<test_ModifierKind>? As_ModifierKindTypeParam { get; }
  Itest_CollectionsObject? As__Collections { get; }
}

public interface Itest_CollectionsObject
  : IGqlpInterfaceBase
{
}

public interface Itest_ModifierKeyed<TModifierKind>
  : Itest_Modifier<TModifierKind>
{
  Itest_ModifierKeyedObject<TModifierKind>? As__ModifierKeyed { get; }
}

public interface Itest_ModifierKeyedObject<TModifierKind>
  : Itest_ModifierObject<TModifierKind>
{
  Itest_TypeSimple By { get; }
  bool IsOptional { get; }
}

public interface Itest_Modifiers
  : IGqlpInterfaceBase
{
  Itest_Modifier<test_ModifierKind>? As_ModifierKindOptional { get; }
  Itest_Collections? As_Collections { get; }
  Itest_ModifiersObject? As__Modifiers { get; }
}

public interface Itest_ModifiersObject
  : IGqlpInterfaceBase
{
}

public enum test_ModifierKind
{
  Opt,
  Optional = Opt,
  List,
  Dict,
  Dictionary = Dict,
  Param,
  TypeParam = Param,
}

public interface Itest_Modifier<TModifierKind>
  : IGqlpInterfaceBase
{
  Itest_ModifierObject<TModifierKind>? As__Modifier { get; }
}

public interface Itest_ModifierObject<TModifierKind>
  : IGqlpInterfaceBase
{
  TModifierKind ModifierKind { get; }
}

public enum test_DomainKind
{
  Boolean,
  Enum,
  Number,
  String,
}

public interface Itest_DomainRef<TDomainKind>
  : Itest_TypeRef<test_TypeKind>
{
  Itest_DomainRefObject<TDomainKind>? As__DomainRef { get; }
}

public interface Itest_DomainRefObject<TDomainKind>
  : Itest_TypeRefObject<test_TypeKind>
{
  TDomainKind DomainKind { get; }
}

public interface Itest_BaseDomain<TDomainKind,TItem,TDomainItem>
  : Itest_ParentType<test_TypeKind, TItem, TDomainItem>
{
  Itest_BaseDomainObject<TDomainKind,TItem,TDomainItem>? As__BaseDomain { get; }
}

public interface Itest_BaseDomainObject<TDomainKind,TItem,TDomainItem>
  : Itest_ParentTypeObject<test_TypeKind, TItem, TDomainItem>
{
  TDomainKind DomainKind { get; }
}

public interface Itest_BaseDomainItem
  : Itest_Described
{
  Itest_BaseDomainItemObject? As__BaseDomainItem { get; }
}

public interface Itest_BaseDomainItemObject
  : Itest_DescribedObject
{
  bool Exclude { get; }
}

public interface Itest_DomainItem<TItem>
  : IGqlpInterfaceBase
{
  TItem? As_Parent { get; }
  Itest_DomainItemObject<TItem>? As__DomainItem { get; }
}

public interface Itest_DomainItemObject<TItem>
  : IGqlpInterfaceBase
{
  Itest_Name Domain { get; }
}

public interface Itest_DomainValue<TDomainKind,TValue>
  : Itest_DomainRef<TDomainKind>
{
  TValue? Asvalue { get; }
  Itest_DomainValueObject<TDomainKind,TValue>? As__DomainValue { get; }
}

public interface Itest_DomainValueObject<TDomainKind,TValue>
  : Itest_DomainRefObject<TDomainKind>
{
  TValue Value { get; }
}

public interface Itest_BasicValue
  : IGqlpInterfaceBase
{
  bool? AsBoolean { get; }
  Itest_EnumValue? As_EnumValue { get; }
  decimal? AsNumber { get; }
  string? AsString { get; }
  Itest_BasicValueObject? As__BasicValue { get; }
}

public interface Itest_BasicValueObject
  : IGqlpInterfaceBase
{
}

public interface Itest_DomainTrueFalse
  : Itest_BaseDomainItem
{
  Itest_DomainTrueFalseObject? As__DomainTrueFalse { get; }
}

public interface Itest_DomainTrueFalseObject
  : Itest_BaseDomainItemObject
{
  bool Value { get; }
}

public interface Itest_DomainItemTrueFalse
  : Itest_DomainItem<Itest_DomainTrueFalse>
{
  Itest_DomainItemTrueFalseObject? As__DomainItemTrueFalse { get; }
}

public interface Itest_DomainItemTrueFalseObject
  : Itest_DomainItemObject<Itest_DomainTrueFalse>
{
}

public interface Itest_DomainLabel
  : Itest_BaseDomainItem
{
  Itest_DomainLabelObject? As__DomainLabel { get; }
}

public interface Itest_DomainLabelObject
  : Itest_BaseDomainItemObject
{
  Itest_EnumValue Label { get; }
}

public interface Itest_DomainItemLabel
  : Itest_DomainItem<Itest_DomainLabel>
{
  Itest_DomainItemLabelObject? As__DomainItemLabel { get; }
}

public interface Itest_DomainItemLabelObject
  : Itest_DomainItemObject<Itest_DomainLabel>
{
}

public interface Itest_DomainRange
  : Itest_BaseDomainItem
{
  Itest_DomainRangeObject? As__DomainRange { get; }
}

public interface Itest_DomainRangeObject
  : Itest_BaseDomainItemObject
{
  decimal? Lower { get; }
  decimal? Upper { get; }
}

public interface Itest_DomainItemRange
  : Itest_DomainItem<Itest_DomainRange>
{
  Itest_DomainItemRangeObject? As__DomainItemRange { get; }
}

public interface Itest_DomainItemRangeObject
  : Itest_DomainItemObject<Itest_DomainRange>
{
}

public interface Itest_DomainRegex
  : Itest_BaseDomainItem
{
  Itest_DomainRegexObject? As__DomainRegex { get; }
}

public interface Itest_DomainRegexObject
  : Itest_BaseDomainItemObject
{
  string Pattern { get; }
}

public interface Itest_DomainItemRegex
  : Itest_DomainItem<Itest_DomainRegex>
{
  Itest_DomainItemRegexObject? As__DomainItemRegex { get; }
}

public interface Itest_DomainItemRegexObject
  : Itest_DomainItemObject<Itest_DomainRegex>
{
}

public interface Itest_EnumLabel
  : Itest_Aliased
{
  Itest_EnumLabelObject? As__EnumLabel { get; }
}

public interface Itest_EnumLabelObject
  : Itest_AliasedObject
{
  Itest_Name EnumType { get; }
}

public interface Itest_EnumValue
  : Itest_TypeRef<test_TypeKind>
{
  Itest_EnumValueObject? As__EnumValue { get; }
}

public interface Itest_EnumValueObject
  : Itest_TypeRefObject<test_TypeKind>
{
  Itest_Name Label { get; }
}

public interface Itest_UnionRef
  : Itest_TypeRef<test_SimpleKind>
{
  Itest_UnionRefObject? As__UnionRef { get; }
}

public interface Itest_UnionRefObject
  : Itest_TypeRefObject<test_SimpleKind>
{
}

public interface Itest_UnionMember
  : Itest_UnionRef
{
  Itest_UnionMemberObject? As__UnionMember { get; }
}

public interface Itest_UnionMemberObject
  : Itest_UnionRefObject
{
  Itest_Name Union { get; }
}

public interface Itest_ObjectKind
  : IGqlpDomainEnum
{
  new test_TypeKind? Value { get; }
}

public interface Itest_TypeObject<TObjectKind,TField>
  : Itest_ChildType<TObjectKind, Itest_ObjBase>
{
  Itest_TypeObjectObject<TObjectKind,TField>? As__TypeObject { get; }
}

public interface Itest_TypeObjectObject<TObjectKind,TField>
  : Itest_ChildTypeObject<TObjectKind, Itest_ObjBase>
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
  Itest_ObjTypeParamObject? As__ObjTypeParam { get; }
}

public interface Itest_ObjTypeParamObject
  : Itest_NamedObject
{
  Itest_TypeRef<test_TypeKind> Constraint { get; }
}

public interface Itest_ObjBase
  : Itest_Named
{
  Itest_TypeParam? As_TypeParam { get; }
  Itest_ObjBaseObject? As__ObjBase { get; }
}

public interface Itest_ObjBaseObject
  : Itest_NamedObject
{
  ICollection<Itest_ObjTypeArg> TypeArgs { get; }
}

public interface Itest_ObjTypeArg
  : Itest_TypeRef<test_TypeKind>
{
  Itest_TypeParam? As_TypeParam { get; }
  Itest_ObjTypeArgObject? As__ObjTypeArg { get; }
}

public interface Itest_ObjTypeArgObject
  : Itest_TypeRefObject<test_TypeKind>
{
  Itest_Name? Label { get; }
}

public interface Itest_TypeParam
  : Itest_Described
{
  Itest_TypeParamObject? As__TypeParam { get; }
}

public interface Itest_TypeParamObject
  : Itest_DescribedObject
{
  Itest_Name TypeParam { get; }
}

public interface Itest_ObjAlternate
  : IGqlpInterfaceBase
{
  Itest_ObjAlternateEnum? As_ObjAlternateEnum { get; }
  Itest_ObjAlternateObject? As__ObjAlternate { get; }
}

public interface Itest_ObjAlternateObject
  : IGqlpInterfaceBase
{
  Itest_ObjBase Type { get; }
  ICollection<Itest_Collections> Collections { get; }
}

public interface Itest_ObjAlternateEnum
  : Itest_TypeRef<test_TypeKind>
{
  Itest_ObjAlternateEnumObject? As__ObjAlternateEnum { get; }
}

public interface Itest_ObjAlternateEnumObject
  : Itest_TypeRefObject<test_TypeKind>
{
  Itest_Name Label { get; }
}

public interface Itest_ObjectFor<TFor>
  : IGqlpInterfaceBase
{
  TFor? As_Parent { get; }
  Itest_ObjectForObject<TFor>? As__ObjectFor { get; }
}

public interface Itest_ObjectForObject<TFor>
  : IGqlpInterfaceBase
{
  Itest_Name ObjectType { get; }
}

public interface Itest_ObjField<TType>
  : Itest_Aliased
{
  Itest_ObjFieldObject<TType>? As__ObjField { get; }
}

public interface Itest_ObjFieldObject<TType>
  : Itest_AliasedObject
{
  TType Type { get; }
}

public interface Itest_ObjFieldType
  : Itest_ObjBase
{
  Itest_ObjFieldEnum? As_ObjFieldEnum { get; }
  Itest_ObjFieldTypeObject? As__ObjFieldType { get; }
}

public interface Itest_ObjFieldTypeObject
  : Itest_ObjBaseObject
{
  ICollection<Itest_Modifiers> Modifiers { get; }
}

public interface Itest_ObjFieldEnum
  : Itest_TypeRef<test_TypeKind>
{
  Itest_ObjFieldEnumObject? As__ObjFieldEnum { get; }
}

public interface Itest_ObjFieldEnumObject
  : Itest_TypeRefObject<test_TypeKind>
{
  Itest_Name Label { get; }
}

public interface Itest_ForParam<TType>
  : IGqlpInterfaceBase
{
  Itest_ObjAlternate? As_ObjAlternate { get; }
  Itest_ObjField<TType>? As_ObjField { get; }
  Itest_ForParamObject<TType>? As__ForParam { get; }
}

public interface Itest_ForParamObject<TType>
  : IGqlpInterfaceBase
{
}

public interface Itest_DualField
  : Itest_ObjField<Itest_ObjFieldType>
{
  Itest_DualFieldObject? As__DualField { get; }
}

public interface Itest_DualFieldObject
  : Itest_ObjFieldObject<Itest_ObjFieldType>
{
}

public interface Itest_InputField
  : Itest_ObjField<Itest_InputFieldType>
{
  Itest_InputFieldObject? As__InputField { get; }
}

public interface Itest_InputFieldObject
  : Itest_ObjFieldObject<Itest_InputFieldType>
{
}

public interface Itest_InputFieldType
  : Itest_ObjFieldType
{
  Itest_InputFieldTypeObject? As__InputFieldType { get; }
}

public interface Itest_InputFieldTypeObject
  : Itest_ObjFieldTypeObject
{
  GqlpValue? DefaultValue { get; }
}

public interface Itest_OutputField
  : Itest_ObjField<Itest_ObjFieldType>
{
  Itest_OutputFieldObject? As__OutputField { get; }
}

public interface Itest_OutputFieldObject
  : Itest_ObjFieldObject<Itest_ObjFieldType>
{
}

public interface Itest_OutputFieldType
  : Itest_ObjFieldType
{
  Itest_OutputFieldTypeObject? As__OutputFieldType { get; }
}

public interface Itest_OutputFieldTypeObject
  : Itest_ObjFieldTypeObject
{
  Itest_InputFieldType? Parameter { get; }
}
