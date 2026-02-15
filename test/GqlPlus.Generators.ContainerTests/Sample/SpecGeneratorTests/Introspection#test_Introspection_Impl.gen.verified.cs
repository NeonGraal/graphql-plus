//HintName: test_Introspection_Impl.gen.cs
// Generated from Introspection.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Introspection;

public class test_Schema
  : test_Named
  , Itest_Schema
{
  public IDictionary<Itest_Name, Itest_Categories> Categories { get; set; }
  public IDictionary<Itest_Name, Itest_Directives> Directives { get; set; }
  public IDictionary<Itest_Name, Itest_Type> Types { get; set; }
  public IDictionary<Itest_Name, Itest_Setting> Settings { get; set; }
}

public class test_Name
  : GqlpDomainString
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
}

public class test_NameFilter
  : GqlpDomainString
  , Itest_NameFilter
{
}

public class test_CategoryFilter
  : test_Filter
  , Itest_CategoryFilter
{
  public ICollection<test_Resolution> Resolutions { get; set; }
}

public class test_TypeFilter
  : test_Filter
  , Itest_TypeFilter
{
  public ICollection<test_TypeKind> Kinds { get; set; }
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
  public ICollection<test_DomainKind> Description { get; set; }
}

public class test_AndType
  : test_Named
  , Itest_AndType
{
  public Itest_Type Type { get; set; }
}

public class test_Categories
  : test_AndType
  , Itest_Categories
{
  public Itest_Category Category { get; set; }
}

public class test_Category
  : test_Aliased
  , Itest_Category
{
  public test_Resolution Resolution { get; set; }
  public Itest_TypeRef<test_TypeKind> Output { get; set; }
  public ICollection<Itest_Modifiers> Modifiers { get; set; }
}

public class test_Directives
  : test_AndType
  , Itest_Directives
{
  public Itest_Directive Directive { get; set; }
}

public class test_Directive
  : test_Aliased
  , Itest_Directive
{
  public ICollection<Itest_InputParam> Parameters { get; set; }
  public test_DomainKind Repeatable { get; set; }
  public IDictionary<test_Location, GqlpUnit> Locations { get; set; }
}

public class test_Setting
  : test_Named
  , Itest_Setting
{
  public GqlpValue Value { get; set; }
}

public class test_Type
  : Itest_Type
{
}

public class test_BaseType<TKind>
  : test_Aliased
  , Itest_BaseType<TKind>
{
  public TKind TypeKind { get; set; }
}

public class test_ChildType<TKind,TParent>
  : test_BaseType<TKind>
  , Itest_ChildType<TKind,TParent>
{
  public TParent Parent { get; set; }
}

public class test_ParentType<TKind,TItem,TAllItem>
  : test_ChildType<TKind, Itest_Named>
  , Itest_ParentType<TKind,TItem,TAllItem>
{
  public ICollection<TItem> Items { get; set; }
  public ICollection<TAllItem> AllItems { get; set; }
}

public class test_TypeRef<TKind>
  : test_Named
  , Itest_TypeRef<TKind>
{
  public TKind TypeKind { get; set; }
}

public class test_TypeSimple
  : Itest_TypeSimple
{
}

public class test_Collections
  : Itest_Collections
{
}

public class test_ModifierKeyed<TKind>
  : test_Modifier<TKind>
  , Itest_ModifierKeyed<TKind>
{
  public Itest_TypeSimple By { get; set; }
  public test_DomainKind IsOptional { get; set; }
}

public class test_Modifiers
  : Itest_Modifiers
{
}

public class test_Modifier<TKind>
  : Itest_Modifier<TKind>
{
  public TKind ModifierKind { get; set; }
}

public class test_DomainRef<TKind>
  : test_TypeRef<test_TypeKind>
  , Itest_DomainRef<TKind>
{
  public TKind DomainKind { get; set; }
}

public class test_BaseDomain<TDomain,TItem,TDomainItem>
  : test_ParentType<test_TypeKind, TItem, TDomainItem>
  , Itest_BaseDomain<TDomain,TItem,TDomainItem>
{
  public TDomain DomainKind { get; set; }
}

public class test_BaseDomainItem
  : test_Described
  , Itest_BaseDomainItem
{
  public test_DomainKind Exclude { get; set; }
}

public class test_DomainItem<TItem>
  : Itest_DomainItem<TItem>
{
  public Itest_Name Domain { get; set; }
}

public class test_DomainValue<TKind,TValue>
  : test_DomainRef<TKind>
  , Itest_DomainValue<TKind,TValue>
{
  public TValue Value { get; set; }
}

public class test_BasicValue
  : Itest_BasicValue
{
}

public class test_DomainTrueFalse
  : test_BaseDomainItem
  , Itest_DomainTrueFalse
{
  public test_DomainKind Value { get; set; }
}

public class test_DomainItemTrueFalse
  : test_DomainItem<Itest_DomainTrueFalse>
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
  : test_DomainItem<Itest_DomainLabel>
  , Itest_DomainItemLabel
{
}

public class test_DomainRange
  : test_BaseDomainItem
  , Itest_DomainRange
{
  public test_DomainKind? Lower { get; set; }
  public test_DomainKind? Upper { get; set; }
}

public class test_DomainItemRange
  : test_DomainItem<Itest_DomainRange>
  , Itest_DomainItemRange
{
}

public class test_DomainRegex
  : test_BaseDomainItem
  , Itest_DomainRegex
{
  public test_DomainKind Pattern { get; set; }
}

public class test_DomainItemRegex
  : test_DomainItem<Itest_DomainRegex>
  , Itest_DomainItemRegex
{
}

public class test_EnumLabel
  : test_Aliased
  , Itest_EnumLabel
{
  public Itest_Name EnumType { get; set; }
}

public class test_EnumValue
  : test_TypeRef<test_TypeKind>
  , Itest_EnumValue
{
  public Itest_Name Label { get; set; }
}

public class test_UnionRef
  : test_TypeRef<test_SimpleKind>
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
  : GqlpDomainEnum
  , Itest_ObjectKind
{
}

public class test_TypeObject<TKind,TField>
  : test_ChildType<TKind, Itest_ObjBase>
  , Itest_TypeObject<TKind,TField>
{
  public ICollection<Itest_ObjTypeParam> TypeParams { get; set; }
  public ICollection<TField> Fields { get; set; }
  public ICollection<Itest_ObjAlternate> Alternates { get; set; }
  public ICollection<Itest_ObjectFor<TField>> AllFields { get; set; }
  public ICollection<Itest_ObjectFor<Itest_ObjAlternate>> AllAlternates { get; set; }
}

public class test_ObjTypeParam
  : test_Named
  , Itest_ObjTypeParam
{
  public Itest_TypeRef<test_TypeKind> Constraint { get; set; }
}

public class test_ObjBase
  : test_Named
  , Itest_ObjBase
{
  public ICollection<Itest_ObjTypeArg> TypeArgs { get; set; }
}

public class test_ObjTypeArg
  : test_TypeRef<test_TypeKind>
  , Itest_ObjTypeArg
{
  public Itest_Name? Label { get; set; }
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
}

public class test_ObjAlternateEnum
  : test_TypeRef<test_TypeKind>
  , Itest_ObjAlternateEnum
{
  public Itest_Name Label { get; set; }
}

public class test_ObjectFor<TFor>
  : Itest_ObjectFor<TFor>
{
  public Itest_Name ObjectType { get; set; }
}

public class test_ObjField<TType>
  : test_Aliased
  , Itest_ObjField<TType>
{
  public TType Type { get; set; }
}

public class test_ObjFieldType
  : test_ObjBase
  , Itest_ObjFieldType
{
  public ICollection<Itest_Modifiers> Modifiers { get; set; }
}

public class test_ObjFieldEnum
  : test_TypeRef<test_TypeKind>
  , Itest_ObjFieldEnum
{
  public Itest_Name Label { get; set; }
}

public class test_ForParam<TType>
  : Itest_ForParam<TType>
{
}

public class test_DualField
  : test_ObjField<Itest_ObjFieldType>
  , Itest_DualField
{
}

public class test_InputField
  : test_ObjField<Itest_InputFieldType>
  , Itest_InputField
{
}

public class test_InputFieldType
  : test_ObjFieldType
  , Itest_InputFieldType
{
  public GqlpValue? DefaultValue { get; set; }
}

public class test_InputParam
  : test_InputFieldType
  , Itest_InputParam
{
}

public class test_OutputField
  : test_ObjField<Itest_ObjFieldType>
  , Itest_OutputField
{
}

public class test_OutputFieldType
  : test_ObjFieldType
  , Itest_OutputFieldType
{
  public ICollection<Itest_InputParam> Parameters { get; set; }
}
