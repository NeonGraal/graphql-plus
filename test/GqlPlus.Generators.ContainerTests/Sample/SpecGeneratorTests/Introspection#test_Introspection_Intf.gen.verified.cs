//HintName: test_Introspection_Intf.gen.cs
// Generated from Introspection.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Introspection;

public interface Itest_Schema
  : Itest_Named
{
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
}

public interface Itest_FilterObject
{
  public ICollection<Itest_NameFilter> Names { get; set; }
  public Itest_DomainKind? MatchAliases { get; set; }
  public ICollection<Itest_NameFilter> Aliases { get; set; }
  public Itest_DomainKind? ReturnByAlias { get; set; }
  public Itest_DomainKind? ReturnReferencedTypes { get; set; }
}

public interface Itest_NameFilter
  : IDomainString
{
}

public interface Itest_CategoryFilter
  : Itest_Filter
{
}

public interface Itest_CategoryFilterObject
  : Itest_FilterObject
{
  public ICollection<Itest_Resolution> Resolutions { get; set; }
}

public interface Itest_TypeFilter
  : Itest_Filter
{
}

public interface Itest_TypeFilterObject
  : Itest_FilterObject
{
  public ICollection<Itest_TypeKind> Kinds { get; set; }
}

public interface Itest_Aliased
  : Itest_Named
{
}

public interface Itest_AliasedObject
  : Itest_NamedObject
{
  public ICollection<Itest_Name> Aliases { get; set; }
}

public interface Itest_Named
  : Itest_Described
{
}

public interface Itest_NamedObject
  : Itest_DescribedObject
{
  public Itest_Name Name { get; set; }
}

public interface Itest_Described
{
}

public interface Itest_DescribedObject
{
  public ICollection<Itest_DomainKind> Description { get; set; }
}

public interface Itest_AndType
  : Itest_Named
{
  public Itest_Type As_Type { get; set; }
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
}

public interface Itest_CategoriesObject
  : Itest_AndTypeObject
{
  public Itest_Category Category { get; set; }
}

public interface Itest_Category
  : Itest_Aliased
{
}

public interface Itest_CategoryObject
  : Itest_AliasedObject
{
  public Itest_Resolution Resolution { get; set; }
  public Itest_TypeRef<Itest_TypeKind> Output { get; set; }
  public ICollection<Itest_Modifiers> Modifiers { get; set; }
}

public interface Itest_Directives
  : Itest_AndType
{
  public Itest_Directive As_Directive { get; set; }
}

public interface Itest_DirectivesObject
  : Itest_AndTypeObject
{
  public Itest_Directive Directive { get; set; }
}

public interface Itest_Directive
  : Itest_Aliased
{
}

public interface Itest_DirectiveObject
  : Itest_AliasedObject
{
  public ICollection<Itest_InputParam> Parameters { get; set; }
  public Itest_DomainKind Repeatable { get; set; }
  public IDictionary<test_Location, ItestUnit> Locations { get; set; }
}

public interface Itest_Setting
  : Itest_Named
{
}

public interface Itest_SettingObject
  : Itest_NamedObject
{
  public Itest_Value Value { get; set; }
}

public interface Itest_Type
{
  public Itest_BaseType<Itest_TypeKind> As_BaseType { get; set; }
  public Itest_BaseType<Itest_TypeKind> As_BaseType { get; set; }
  public Itest_BaseDomain<Itest_DomainKind, Itest_DomainTrueFalse, Itest_DomainItemTrueFalse> As_BaseDomain { get; set; }
  public Itest_BaseDomain<Itest_DomainKind, Itest_DomainLabel, Itest_DomainItemLabel> As_BaseDomain { get; set; }
  public Itest_BaseDomain<Itest_DomainKind, Itest_DomainRange, Itest_DomainItemRange> As_BaseDomain { get; set; }
  public Itest_BaseDomain<Itest_DomainKind, Itest_DomainRegex, Itest_DomainItemRegex> As_BaseDomain { get; set; }
  public Itest_ParentType<Itest_TypeKind, Itest_Aliased, Itest_EnumLabel> As_ParentType { get; set; }
  public Itest_ParentType<Itest_TypeKind, Itest_UnionRef, Itest_UnionMember> As_ParentType { get; set; }
  public Itest_TypeObject<Itest_TypeKind, Itest_DualField> As_TypeObject { get; set; }
  public Itest_TypeObject<Itest_TypeKind, Itest_InputField> As_TypeObject { get; set; }
  public Itest_TypeObject<Itest_TypeKind, Itest_OutputField> As_TypeObject { get; set; }
}

public interface Itest_TypeObject
{
}

public interface Itest_BaseType<Tkind>
  : Itest_Aliased
{
}

public interface Itest_BaseTypeObject<Tkind>
  : Itest_AliasedObject
{
  public Tkind TypeKind { get; set; }
}

public interface Itest_ChildType<Tkind,Tparent>
  : Itest_BaseType
{
}

public interface Itest_ChildTypeObject<Tkind,Tparent>
  : Itest_BaseTypeObject
{
  public Tparent Parent { get; set; }
}

public interface Itest_ParentType<Tkind,Titem,TallItem>
  : Itest_ChildType
{
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
}

public interface Itest_TypeRefObject<Tkind>
  : Itest_NamedObject
{
  public Tkind TypeKind { get; set; }
}

public interface Itest_TypeSimple
{
  public Itest_TypeRef<Itest_TypeKind> As_TypeRef { get; set; }
  public Itest_TypeRef<Itest_TypeKind> As_TypeRef { get; set; }
  public Itest_TypeRef<Itest_TypeKind> As_TypeRef { get; set; }
  public Itest_TypeRef<Itest_TypeKind> As_TypeRef { get; set; }
}

public interface Itest_TypeSimpleObject
{
}

public interface Itest_Collections
{
  public Itest_Modifier<Itest_ModifierKind> As_Modifier { get; set; }
  public Itest_ModifierKeyed<Itest_ModifierKind> As_ModifierKeyed { get; set; }
  public Itest_ModifierKeyed<Itest_ModifierKind> As_ModifierKeyed { get; set; }
}

public interface Itest_CollectionsObject
{
}

public interface Itest_ModifierKeyed<Tkind>
  : Itest_Modifier
{
}

public interface Itest_ModifierKeyedObject<Tkind>
  : Itest_ModifierObject
{
  public Itest_TypeSimple By { get; set; }
  public Itest_DomainKind Optional { get; set; }
}

public interface Itest_Modifiers
{
  public Itest_Modifier<Itest_ModifierKind> As_Modifier { get; set; }
  public Itest_Collections As_Collections { get; set; }
}

public interface Itest_ModifiersObject
{
}

public interface Itest_Modifier<Tkind>
{
}

public interface Itest_ModifierObject<Tkind>
{
  public Tkind ModifierKind { get; set; }
}

public interface Itest_DomainRef<Tkind>
  : Itest_TypeRef
{
}

public interface Itest_DomainRefObject<Tkind>
  : Itest_TypeRefObject
{
  public Tkind DomainKind { get; set; }
}

public interface Itest_BaseDomain<Tdomain,Titem,TdomainItem>
  : Itest_ParentType
{
}

public interface Itest_BaseDomainObject<Tdomain,Titem,TdomainItem>
  : Itest_ParentTypeObject
{
  public Tdomain DomainKind { get; set; }
}

public interface Itest_BaseDomainItem
  : Itest_Described
{
}

public interface Itest_BaseDomainItemObject
  : Itest_DescribedObject
{
  public Itest_DomainKind Exclude { get; set; }
}

public interface Itest_DomainItem<Titem>
  : Itestitem
{
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
}

public interface Itest_DomainValueObject<Tkind,Tvalue>
  : Itest_DomainRefObject
{
  public Tvalue Value { get; set; }
}

public interface Itest_BasicValue
{
  public Itest_DomainKind As_DomainKindBoolean { get; set; }
  public Itest_EnumValue As_EnumValue { get; set; }
  public Itest_DomainKind As_DomainKindNumber { get; set; }
  public Itest_DomainKind As_DomainKindString { get; set; }
}

public interface Itest_BasicValueObject
{
}

public interface Itest_DomainTrueFalse
  : Itest_BaseDomainItem
{
}

public interface Itest_DomainTrueFalseObject
  : Itest_BaseDomainItemObject
{
  public Itest_DomainKind Value { get; set; }
}

public interface Itest_DomainItemTrueFalse
  : Itest_DomainItem
{
}

public interface Itest_DomainItemTrueFalseObject
  : Itest_DomainItemObject
{
}

public interface Itest_DomainLabel
  : Itest_BaseDomainItem
{
}

public interface Itest_DomainLabelObject
  : Itest_BaseDomainItemObject
{
  public Itest_EnumValue Label { get; set; }
}

public interface Itest_DomainItemLabel
  : Itest_DomainItem
{
}

public interface Itest_DomainItemLabelObject
  : Itest_DomainItemObject
{
}

public interface Itest_DomainRange
  : Itest_BaseDomainItem
{
}

public interface Itest_DomainRangeObject
  : Itest_BaseDomainItemObject
{
  public Itest_DomainKind? Lower { get; set; }
  public Itest_DomainKind? Upper { get; set; }
}

public interface Itest_DomainItemRange
  : Itest_DomainItem
{
}

public interface Itest_DomainItemRangeObject
  : Itest_DomainItemObject
{
}

public interface Itest_DomainRegex
  : Itest_BaseDomainItem
{
}

public interface Itest_DomainRegexObject
  : Itest_BaseDomainItemObject
{
  public Itest_DomainKind Pattern { get; set; }
}

public interface Itest_DomainItemRegex
  : Itest_DomainItem
{
}

public interface Itest_DomainItemRegexObject
  : Itest_DomainItemObject
{
}

public interface Itest_EnumLabel
  : Itest_Aliased
{
}

public interface Itest_EnumLabelObject
  : Itest_AliasedObject
{
  public Itest_Name Enum { get; set; }
}

public interface Itest_EnumValue
  : Itest_TypeRef
{
}

public interface Itest_EnumValueObject
  : Itest_TypeRefObject
{
  public Itest_Name Label { get; set; }
}

public interface Itest_UnionRef
  : Itest_TypeRef
{
}

public interface Itest_UnionRefObject
  : Itest_TypeRefObject
{
}

public interface Itest_UnionMember
  : Itest_UnionRef
{
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
}

public interface Itest_ObjTypeParamObject
  : Itest_NamedObject
{
  public Itest_TypeRef<Itest_TypeKind> Constraint { get; set; }
}

public interface Itest_ObjBase
  : Itest_Named
{
  public Itest_TypeParam As_TypeParam { get; set; }
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
}

public interface Itest_ObjTypeArgObject
  : Itest_TypeRefObject
{
  public Itest_Name? Label { get; set; }
}

public interface Itest_TypeParam
  : Itest_Described
{
}

public interface Itest_TypeParamObject
  : Itest_DescribedObject
{
  public Itest_Name TypeParam { get; set; }
}

public interface Itest_ObjAlternate
{
  public Itest_ObjAlternateEnum As_ObjAlternateEnum { get; set; }
}

public interface Itest_ObjAlternateObject
{
  public Itest_ObjBase Type { get; set; }
  public ICollection<Itest_Collections> Collections { get; set; }
}

public interface Itest_ObjAlternateEnum
  : Itest_TypeRef
{
}

public interface Itest_ObjAlternateEnumObject
  : Itest_TypeRefObject
{
  public Itest_Name Label { get; set; }
}

public interface Itest_ObjectFor<Tfor>
  : Itestfor
{
}

public interface Itest_ObjectForObject<Tfor>
  : ItestforObject
{
  public Itest_Name Object { get; set; }
}

public interface Itest_ObjField<Ttype>
  : Itest_Aliased
{
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
}

public interface Itest_ObjFieldTypeObject
  : Itest_ObjBaseObject
{
  public ICollection<Itest_Modifiers> Modifiers { get; set; }
}

public interface Itest_ObjFieldEnum
  : Itest_TypeRef
{
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
}

public interface Itest_ForParamObject<Ttype>
{
}

public interface Itest_DualField
  : Itest_ObjField
{
}

public interface Itest_DualFieldObject
  : Itest_ObjFieldObject
{
}

public interface Itest_InputField
  : Itest_ObjField
{
}

public interface Itest_InputFieldObject
  : Itest_ObjFieldObject
{
}

public interface Itest_InputFieldType
  : Itest_ObjFieldType
{
}

public interface Itest_InputFieldTypeObject
  : Itest_ObjFieldTypeObject
{
  public Itest_Value? Default { get; set; }
}

public interface Itest_InputParam
  : Itest_InputFieldType
{
}

public interface Itest_InputParamObject
  : Itest_InputFieldTypeObject
{
}

public interface Itest_OutputField
  : Itest_ObjField
{
}

public interface Itest_OutputFieldObject
  : Itest_ObjFieldObject
{
}

public interface Itest_OutputFieldType
  : Itest_ObjFieldType
{
}

public interface Itest_OutputFieldTypeObject
  : Itest_ObjFieldTypeObject
{
  public ICollection<Itest_InputParam> Parameters { get; set; }
}
