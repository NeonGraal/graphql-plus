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
  public Itest_DomainKind? MatchAliases { get; set; }
  public ICollection<Itest_NameFilter> Aliases { get; set; }
  public Itest_DomainKind? ReturnByAlias { get; set; }
  public Itest_DomainKind? ReturnReferencedTypes { get; set; }
  public ICollection<Itest_NameFilter> As_NameFilter { get; set; }
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
  public ICollection<Itest_Resolution> Resolutions { get; set; }
}

public class test_TypeFilter
  : test_Filter
  , Itest_TypeFilter
{
  public ICollection<Itest_TypeKind> Kinds { get; set; }
}

public class test_Aliased
  : test_Named
  , Itest_Aliased
{
  public ICollection<Itest_Name> Aliases { get; set; }
}

public class test_Named
  : test_Described
  , Itest_Named
{
  public Itest_Name Name { get; set; }
}

public class test_Described
  : Itest_Described
{
  public ICollection<Itest_DomainKind> Description { get; set; }
}

public class test_AndType
  : test_Named
  , Itest_AndType
{
  public Itest_Type Type { get; set; }
  public Itest_Type As_Type { get; set; }
}

public class test_Categories
  : test_AndType
  , Itest_Categories
{
  public Itest_Category Category { get; set; }
  public Itest_Category As_Category { get; set; }
}

public class test_Category
  : test_Aliased
  , Itest_Category
{
  public Itest_Resolution Resolution { get; set; }
  public Itest_TypeRef<Itest_TypeKind> Output { get; set; }
  public ICollection<Itest_Modifiers> Modifiers { get; set; }
}

public class test_Directives
  : test_AndType
  , Itest_Directives
{
  public Itest_Directive Directive { get; set; }
  public Itest_Directive As_Directive { get; set; }
}

public class test_Directive
  : test_Aliased
  , Itest_Directive
{
  public ICollection<Itest_InputParam> Parameters { get; set; }
  public Itest_DomainKind Repeatable { get; set; }
  public IDictionary<test_Location, ItestUnit> Locations { get; set; }
}

public class test_Setting
  : test_Named
  , Itest_Setting
{
  public Itest_Value Value { get; set; }
}

public class test_Type
  : Itest_Type
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

public class test_BaseType<Tkind>
  : test_Aliased
  , Itest_BaseType<Tkind>
{
  public Tkind TypeKind { get; set; }
}

public class test_ChildType<Tkind,Tparent>
  : test_BaseType
  , Itest_ChildType<Tkind,Tparent>
{
  public Tparent Parent { get; set; }
}

public class test_ParentType<Tkind,Titem,TallItem>
  : test_ChildType
  , Itest_ParentType<Tkind,Titem,TallItem>
{
  public ICollection<Titem> Items { get; set; }
  public ICollection<TallItem> AllItems { get; set; }
}

public class test_TypeRef<Tkind>
  : test_Named
  , Itest_TypeRef<Tkind>
{
  public Tkind TypeKind { get; set; }
}

public class test_TypeSimple
  : Itest_TypeSimple
{
  public Itest_TypeRef<Itest_TypeKind> As_TypeRef { get; set; }
  public Itest_TypeRef<Itest_TypeKind> As_TypeRef { get; set; }
  public Itest_TypeRef<Itest_TypeKind> As_TypeRef { get; set; }
  public Itest_TypeRef<Itest_TypeKind> As_TypeRef { get; set; }
}

public class test_Collections
  : Itest_Collections
{
  public Itest_Modifier<Itest_ModifierKind> As_Modifier { get; set; }
  public Itest_ModifierKeyed<Itest_ModifierKind> As_ModifierKeyed { get; set; }
  public Itest_ModifierKeyed<Itest_ModifierKind> As_ModifierKeyed { get; set; }
}

public class test_ModifierKeyed<Tkind>
  : test_Modifier
  , Itest_ModifierKeyed<Tkind>
{
  public Itest_TypeSimple By { get; set; }
  public Itest_DomainKind Optional { get; set; }
}

public class test_Modifiers
  : Itest_Modifiers
{
  public Itest_Modifier<Itest_ModifierKind> As_Modifier { get; set; }
  public Itest_Collections As_Collections { get; set; }
}

public class test_Modifier<Tkind>
  : Itest_Modifier<Tkind>
{
  public Tkind ModifierKind { get; set; }
}

public class test_DomainRef<Tkind>
  : test_TypeRef
  , Itest_DomainRef<Tkind>
{
  public Tkind DomainKind { get; set; }
}

public class test_BaseDomain<Tdomain,Titem,TdomainItem>
  : test_ParentType
  , Itest_BaseDomain<Tdomain,Titem,TdomainItem>
{
  public Tdomain DomainKind { get; set; }
}

public class test_BaseDomainItem
  : test_Described
  , Itest_BaseDomainItem
{
  public Itest_DomainKind Exclude { get; set; }
}

public class test_DomainItem<Titem>
  : testitem
  , Itest_DomainItem<Titem>
{
  public Itest_Name Domain { get; set; }
}

public class test_DomainValue<Tkind,Tvalue>
  : test_DomainRef
  , Itest_DomainValue<Tkind,Tvalue>
{
  public Tvalue Value { get; set; }
  public Tvalue Asvalue { get; set; }
}

public class test_BasicValue
  : Itest_BasicValue
{
  public Itest_DomainKind As_DomainKindBoolean { get; set; }
  public Itest_EnumValue As_EnumValue { get; set; }
  public Itest_DomainKind As_DomainKindNumber { get; set; }
  public Itest_DomainKind As_DomainKindString { get; set; }
}

public class test_DomainTrueFalse
  : test_BaseDomainItem
  , Itest_DomainTrueFalse
{
  public Itest_DomainKind Value { get; set; }
}

public class test_DomainItemTrueFalse
  : test_DomainItem
  , Itest_DomainItemTrueFalse
{
}

public class test_DomainLabel
  : test_BaseDomainItem
  , Itest_DomainLabel
{
  public Itest_EnumValue Label { get; set; }
}

public class test_DomainItemLabel
  : test_DomainItem
  , Itest_DomainItemLabel
{
}

public class test_DomainRange
  : test_BaseDomainItem
  , Itest_DomainRange
{
  public Itest_DomainKind? Lower { get; set; }
  public Itest_DomainKind? Upper { get; set; }
}

public class test_DomainItemRange
  : test_DomainItem
  , Itest_DomainItemRange
{
}

public class test_DomainRegex
  : test_BaseDomainItem
  , Itest_DomainRegex
{
  public Itest_DomainKind Pattern { get; set; }
}

public class test_DomainItemRegex
  : test_DomainItem
  , Itest_DomainItemRegex
{
}

public class test_EnumLabel
  : test_Aliased
  , Itest_EnumLabel
{
  public Itest_Name Enum { get; set; }
}

public class test_EnumValue
  : test_TypeRef
  , Itest_EnumValue
{
  public Itest_Name Label { get; set; }
}

public class test_UnionRef
  : test_TypeRef
  , Itest_UnionRef
{
}

public class test_UnionMember
  : test_UnionRef
  , Itest_UnionMember
{
  public Itest_Name Union { get; set; }
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
}

public class test_ObjTypeParam
  : test_Named
  , Itest_ObjTypeParam
{
  public Itest_TypeRef<Itest_TypeKind> Constraint { get; set; }
}

public class test_ObjBase
  : test_Named
  , Itest_ObjBase
{
  public ICollection<Itest_ObjTypeArg> TypeArgs { get; set; }
  public Itest_TypeParam As_TypeParam { get; set; }
}

public class test_ObjTypeArg
  : test_TypeRef
  , Itest_ObjTypeArg
{
  public Itest_Name? Label { get; set; }
  public Itest_TypeParam As_TypeParam { get; set; }
}

public class test_TypeParam
  : test_Described
  , Itest_TypeParam
{
  public Itest_Name TypeParam { get; set; }
}

public class test_ObjAlternate
  : Itest_ObjAlternate
{
  public Itest_ObjBase Type { get; set; }
  public ICollection<Itest_Collections> Collections { get; set; }
  public Itest_ObjAlternateEnum As_ObjAlternateEnum { get; set; }
}

public class test_ObjAlternateEnum
  : test_TypeRef
  , Itest_ObjAlternateEnum
{
  public Itest_Name Label { get; set; }
}

public class test_ObjectFor<Tfor>
  : testfor
  , Itest_ObjectFor<Tfor>
{
  public Itest_Name Object { get; set; }
}

public class test_ObjField<Ttype>
  : test_Aliased
  , Itest_ObjField<Ttype>
{
  public Ttype Type { get; set; }
}

public class test_ObjFieldType
  : test_ObjBase
  , Itest_ObjFieldType
{
  public ICollection<Itest_Modifiers> Modifiers { get; set; }
  public Itest_ObjFieldEnum As_ObjFieldEnum { get; set; }
}

public class test_ObjFieldEnum
  : test_TypeRef
  , Itest_ObjFieldEnum
{
  public Itest_Name Label { get; set; }
}

public class test_ForParam<Ttype>
  : Itest_ForParam<Ttype>
{
  public Itest_ObjAlternate As_ObjAlternate { get; set; }
  public Itest_ObjField<Ttype> As_ObjField { get; set; }
}

public class test_DualField
  : test_ObjField
  , Itest_DualField
{
}

public class test_InputField
  : test_ObjField
  , Itest_InputField
{
}

public class test_InputFieldType
  : test_ObjFieldType
  , Itest_InputFieldType
{
  public Itest_Value? Default { get; set; }
}

public class test_InputParam
  : test_InputFieldType
  , Itest_InputParam
{
}

public class test_OutputField
  : test_ObjField
  , Itest_OutputField
{
}

public class test_OutputFieldType
  : test_ObjFieldType
  , Itest_OutputFieldType
{
  public ICollection<Itest_InputParam> Parameters { get; set; }
}
