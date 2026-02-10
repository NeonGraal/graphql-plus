//HintName: test_Introspection_Impl.gen.cs
// Generated from Introspection.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Introspection;

public class test_Schema
  : test_Named
  , Itest_Schema
{
  public IDictionary<test_Name, Itest_Categories> Categories { get; set; }
  public IDictionary<test_Name, Itest_Directives> Directives { get; set; }
  public IDictionary<test_Name, Itest_Type> Types { get; set; }
  public IDictionary<test_Name, Itest_Setting> Settings { get; set; }
  public Itest_SchemaObject As_Schema { get; set; }
}

public class test_Name
  : DomainString
  , Itest_Name
{
}

public class test_Filter
  : Itest_Filter
{
  public ICollection<Itest_NameFilter> Names { get; set; }
  public test_DomainKind? MatchAliases { get; set; }
  public ICollection<Itest_NameFilter> Aliases { get; set; }
  public test_DomainKind? ReturnByAlias { get; set; }
  public test_DomainKind? ReturnReferencedTypes { get; set; }
  public ICollection<Itest_NameFilter> As_NameFilter { get; set; }
  public Itest_FilterObject As_Filter { get; set; }
}

public class test_NameFilter
  : DomainString
  , Itest_NameFilter
{
}

public class test_CategoryFilter
  : test_Filter
  , Itest_CategoryFilter
{
  public ICollection<test_Resolution> Resolutions { get; set; }
  public Itest_CategoryFilterObject As_CategoryFilter { get; set; }
}

public class test_TypeFilter
  : test_Filter
  , Itest_TypeFilter
{
  public ICollection<test_TypeKind> Kinds { get; set; }
  public Itest_TypeFilterObject As_TypeFilter { get; set; }
}

public class test_Aliased
  : test_Named
  , Itest_Aliased
{
  public ICollection<Itest_Name> Aliases { get; set; }
  public Itest_AliasedObject As_Aliased { get; set; }
}

public class test_Named
  : test_Described
  , Itest_Named
{
  public Itest_Name Name { get; set; }
  public Itest_NamedObject As_Named { get; set; }
}

public class test_Described
  : Itest_Described
{
  public ICollection<test_DomainKind> Description { get; set; }
  public Itest_DescribedObject As_Described { get; set; }
}

public class test_AndType
  : test_Named
  , Itest_AndType
{
  public Itest_Type Type { get; set; }
  public Itest_Type As_Type { get; set; }
  public Itest_AndTypeObject As_AndType { get; set; }
}

public class test_Categories
  : test_AndType
  , Itest_Categories
{
  public Itest_Category Category { get; set; }
  public Itest_Category As_Category { get; set; }
  public Itest_CategoriesObject As_Categories { get; set; }
}

public class test_Category
  : test_Aliased
  , Itest_Category
{
  public test_Resolution Resolution { get; set; }
  public Itest_TypeRef<test_TypeKind> Output { get; set; }
  public ICollection<Itest_Modifiers> Modifiers { get; set; }
  public Itest_CategoryObject As_Category { get; set; }
}

public class test_Directives
  : test_AndType
  , Itest_Directives
{
  public Itest_Directive Directive { get; set; }
  public Itest_Directive As_Directive { get; set; }
  public Itest_DirectivesObject As_Directives { get; set; }
}

public class test_Directive
  : test_Aliased
  , Itest_Directive
{
  public ICollection<Itest_InputParam> Parameters { get; set; }
  public test_DomainKind Repeatable { get; set; }
  public IDictionary<test_Location, testUnit> Locations { get; set; }
  public Itest_DirectiveObject As_Directive { get; set; }
}

public class test_Setting
  : test_Named
  , Itest_Setting
{
  public Itest_Value Value { get; set; }
  public Itest_SettingObject As_Setting { get; set; }
}

public class test_Type
  : Itest_Type
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

public class test_BaseType<Tkind>
  : test_Aliased
  , Itest_BaseType<Tkind>
{
  public Tkind TypeKind { get; set; }
  public Itest_BaseTypeObject As_BaseType { get; set; }
}

public class test_ChildType<Tkind,Tparent>
  : test_BaseType
  , Itest_ChildType<Tkind,Tparent>
{
  public Tparent Parent { get; set; }
  public Itest_ChildTypeObject As_ChildType { get; set; }
}

public class test_ParentType<Tkind,Titem,TallItem>
  : test_ChildType
  , Itest_ParentType<Tkind,Titem,TallItem>
{
  public ICollection<Titem> Items { get; set; }
  public ICollection<TallItem> AllItems { get; set; }
  public Itest_ParentTypeObject As_ParentType { get; set; }
}

public class test_TypeRef<Tkind>
  : test_Named
  , Itest_TypeRef<Tkind>
{
  public Tkind TypeKind { get; set; }
  public Itest_TypeRefObject As_TypeRef { get; set; }
}

public class test_TypeSimple
  : Itest_TypeSimple
{
  public Itest_TypeRef<test_TypeKind> As_TypeRef { get; set; }
  public Itest_TypeRef<test_TypeKind> As_TypeRef { get; set; }
  public Itest_TypeRef<test_TypeKind> As_TypeRef { get; set; }
  public Itest_TypeRef<test_TypeKind> As_TypeRef { get; set; }
  public Itest_TypeSimpleObject As_TypeSimple { get; set; }
}

public class test_Collections
  : Itest_Collections
{
  public Itest_Modifier<test_ModifierKind> As_Modifier { get; set; }
  public Itest_ModifierKeyed<test_ModifierKind> As_ModifierKeyed { get; set; }
  public Itest_ModifierKeyed<test_ModifierKind> As_ModifierKeyed { get; set; }
  public Itest_CollectionsObject As_Collections { get; set; }
}

public class test_ModifierKeyed<Tkind>
  : test_Modifier
  , Itest_ModifierKeyed<Tkind>
{
  public Itest_TypeSimple By { get; set; }
  public test_DomainKind Optional { get; set; }
  public Itest_ModifierKeyedObject As_ModifierKeyed { get; set; }
}

public class test_Modifiers
  : Itest_Modifiers
{
  public Itest_Modifier<test_ModifierKind> As_Modifier { get; set; }
  public Itest_Collections As_Collections { get; set; }
  public Itest_ModifiersObject As_Modifiers { get; set; }
}

public class test_Modifier<Tkind>
  : Itest_Modifier<Tkind>
{
  public Tkind ModifierKind { get; set; }
  public Itest_ModifierObject As_Modifier { get; set; }
}

public class test_DomainRef<Tkind>
  : test_TypeRef
  , Itest_DomainRef<Tkind>
{
  public Tkind DomainKind { get; set; }
  public Itest_DomainRefObject As_DomainRef { get; set; }
}

public class test_BaseDomain<Tdomain,Titem,TdomainItem>
  : test_ParentType
  , Itest_BaseDomain<Tdomain,Titem,TdomainItem>
{
  public Tdomain DomainKind { get; set; }
  public Itest_BaseDomainObject As_BaseDomain { get; set; }
}

public class test_BaseDomainItem
  : test_Described
  , Itest_BaseDomainItem
{
  public test_DomainKind Exclude { get; set; }
  public Itest_BaseDomainItemObject As_BaseDomainItem { get; set; }
}

public class test_DomainItem<Titem>
  : testitem
  , Itest_DomainItem<Titem>
{
  public Itest_Name Domain { get; set; }
  public Itest_DomainItemObject As_DomainItem { get; set; }
}

public class test_DomainValue<Tkind,Tvalue>
  : test_DomainRef
  , Itest_DomainValue<Tkind,Tvalue>
{
  public Tvalue Value { get; set; }
  public Tvalue Asvalue { get; set; }
  public Itest_DomainValueObject As_DomainValue { get; set; }
}

public class test_BasicValue
  : Itest_BasicValue
{
  public test_DomainKind As_DomainKindBoolean { get; set; }
  public Itest_EnumValue As_EnumValue { get; set; }
  public test_DomainKind As_DomainKindNumber { get; set; }
  public test_DomainKind As_DomainKindString { get; set; }
  public Itest_BasicValueObject As_BasicValue { get; set; }
}

public class test_DomainTrueFalse
  : test_BaseDomainItem
  , Itest_DomainTrueFalse
{
  public test_DomainKind Value { get; set; }
  public Itest_DomainTrueFalseObject As_DomainTrueFalse { get; set; }
}

public class test_DomainItemTrueFalse
  : test_DomainItem
  , Itest_DomainItemTrueFalse
{
  public Itest_DomainItemTrueFalseObject As_DomainItemTrueFalse { get; set; }
}

public class test_DomainLabel
  : test_BaseDomainItem
  , Itest_DomainLabel
{
  public Itest_EnumValue Label { get; set; }
  public Itest_DomainLabelObject As_DomainLabel { get; set; }
}

public class test_DomainItemLabel
  : test_DomainItem
  , Itest_DomainItemLabel
{
  public Itest_DomainItemLabelObject As_DomainItemLabel { get; set; }
}

public class test_DomainRange
  : test_BaseDomainItem
  , Itest_DomainRange
{
  public test_DomainKind? Lower { get; set; }
  public test_DomainKind? Upper { get; set; }
  public Itest_DomainRangeObject As_DomainRange { get; set; }
}

public class test_DomainItemRange
  : test_DomainItem
  , Itest_DomainItemRange
{
  public Itest_DomainItemRangeObject As_DomainItemRange { get; set; }
}

public class test_DomainRegex
  : test_BaseDomainItem
  , Itest_DomainRegex
{
  public test_DomainKind Pattern { get; set; }
  public Itest_DomainRegexObject As_DomainRegex { get; set; }
}

public class test_DomainItemRegex
  : test_DomainItem
  , Itest_DomainItemRegex
{
  public Itest_DomainItemRegexObject As_DomainItemRegex { get; set; }
}

public class test_EnumLabel
  : test_Aliased
  , Itest_EnumLabel
{
  public Itest_Name Enum { get; set; }
  public Itest_EnumLabelObject As_EnumLabel { get; set; }
}

public class test_EnumValue
  : test_TypeRef
  , Itest_EnumValue
{
  public Itest_Name Label { get; set; }
  public Itest_EnumValueObject As_EnumValue { get; set; }
}

public class test_UnionRef
  : test_TypeRef
  , Itest_UnionRef
{
  public Itest_UnionRefObject As_UnionRef { get; set; }
}

public class test_UnionMember
  : test_UnionRef
  , Itest_UnionMember
{
  public Itest_Name Union { get; set; }
  public Itest_UnionMemberObject As_UnionMember { get; set; }
}

public class test_ObjectKind
  : DomainEnum
  , Itest_ObjectKind
{
}

public class test_TypeObject<Tkind,Tfield>
  : test_ChildType
  , Itest_TypeObject<Tkind,Tfield>
{
  public ICollection<Itest_ObjTypeParam> TypeParams { get; set; }
  public ICollection<Tfield> Fields { get; set; }
  public ICollection<Itest_ObjAlternate> Alternates { get; set; }
  public ICollection<Itest_ObjectFor<Tfield>> AllFields { get; set; }
  public ICollection<Itest_ObjectFor<Itest_ObjAlternate>> AllAlternates { get; set; }
  public Itest_TypeObjectObject As_TypeObject { get; set; }
}

public class test_ObjTypeParam
  : test_Named
  , Itest_ObjTypeParam
{
  public Itest_TypeRef<test_TypeKind> Constraint { get; set; }
  public Itest_ObjTypeParamObject As_ObjTypeParam { get; set; }
}

public class test_ObjBase
  : test_Named
  , Itest_ObjBase
{
  public ICollection<Itest_ObjTypeArg> TypeArgs { get; set; }
  public Itest_TypeParam As_TypeParam { get; set; }
  public Itest_ObjBaseObject As_ObjBase { get; set; }
}

public class test_ObjTypeArg
  : test_TypeRef
  , Itest_ObjTypeArg
{
  public Itest_Name? Label { get; set; }
  public Itest_TypeParam As_TypeParam { get; set; }
  public Itest_ObjTypeArgObject As_ObjTypeArg { get; set; }
}

public class test_TypeParam
  : test_Described
  , Itest_TypeParam
{
  public Itest_Name TypeParam { get; set; }
  public Itest_TypeParamObject As_TypeParam { get; set; }
}

public class test_ObjAlternate
  : Itest_ObjAlternate
{
  public Itest_ObjBase Type { get; set; }
  public ICollection<Itest_Collections> Collections { get; set; }
  public Itest_ObjAlternateEnum As_ObjAlternateEnum { get; set; }
  public Itest_ObjAlternateObject As_ObjAlternate { get; set; }
}

public class test_ObjAlternateEnum
  : test_TypeRef
  , Itest_ObjAlternateEnum
{
  public Itest_Name Label { get; set; }
  public Itest_ObjAlternateEnumObject As_ObjAlternateEnum { get; set; }
}

public class test_ObjectFor<Tfor>
  : testfor
  , Itest_ObjectFor<Tfor>
{
  public Itest_Name Object { get; set; }
  public Itest_ObjectForObject As_ObjectFor { get; set; }
}

public class test_ObjField<Ttype>
  : test_Aliased
  , Itest_ObjField<Ttype>
{
  public Ttype Type { get; set; }
  public Itest_ObjFieldObject As_ObjField { get; set; }
}

public class test_ObjFieldType
  : test_ObjBase
  , Itest_ObjFieldType
{
  public ICollection<Itest_Modifiers> Modifiers { get; set; }
  public Itest_ObjFieldEnum As_ObjFieldEnum { get; set; }
  public Itest_ObjFieldTypeObject As_ObjFieldType { get; set; }
}

public class test_ObjFieldEnum
  : test_TypeRef
  , Itest_ObjFieldEnum
{
  public Itest_Name Label { get; set; }
  public Itest_ObjFieldEnumObject As_ObjFieldEnum { get; set; }
}

public class test_ForParam<Ttype>
  : Itest_ForParam<Ttype>
{
  public Itest_ObjAlternate As_ObjAlternate { get; set; }
  public Itest_ObjField<Ttype> As_ObjField { get; set; }
  public Itest_ForParamObject As_ForParam { get; set; }
}

public class test_DualField
  : test_ObjField
  , Itest_DualField
{
  public Itest_DualFieldObject As_DualField { get; set; }
}

public class test_InputField
  : test_ObjField
  , Itest_InputField
{
  public Itest_InputFieldObject As_InputField { get; set; }
}

public class test_InputFieldType
  : test_ObjFieldType
  , Itest_InputFieldType
{
  public Itest_Value? Default { get; set; }
  public Itest_InputFieldTypeObject As_InputFieldType { get; set; }
}

public class test_InputParam
  : test_InputFieldType
  , Itest_InputParam
{
  public Itest_InputParamObject As_InputParam { get; set; }
}

public class test_OutputField
  : test_ObjField
  , Itest_OutputField
{
  public Itest_OutputFieldObject As_OutputField { get; set; }
}

public class test_OutputFieldType
  : test_ObjFieldType
  , Itest_OutputFieldType
{
  public ICollection<Itest_InputParam> Parameters { get; set; }
  public Itest_OutputFieldTypeObject As_OutputFieldType { get; set; }
}
