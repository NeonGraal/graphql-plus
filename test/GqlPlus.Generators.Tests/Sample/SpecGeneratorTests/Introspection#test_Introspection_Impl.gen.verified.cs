//HintName: test_Introspection_Impl.gen.cs
// Generated from Introspection.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_Introspection;

public class test_Schema
  : test_Named
  , Itest_Schema
{
  public _Categories categories { get; set; }
  public _Directives directives { get; set; }
  public _Type types { get; set; }
  public _Setting settings { get; set; }
}

public class test_Identifier
  : Itest_Identifier
{
}

public class test_Filter
  : Itest_Filter
{
  public _NameFilter names { get; set; }
  public Boolean matchAliases { get; set; }
  public _NameFilter aliases { get; set; }
  public Boolean returnByAlias { get; set; }
  public Boolean returnReferencedTypes { get; set; }
  public _NameFilter As_NameFilter { get; set; }
}

public class test_NameFilter
  : Itest_NameFilter
{
}

public class test_CategoryFilter
  : test_Filter
  , Itest_CategoryFilter
{
  public _Resolution resolutions { get; set; }
}

public class test_TypeFilter
  : test_Filter
  , Itest_TypeFilter
{
  public _TypeKind kinds { get; set; }
}

public class test_Aliased
  : test_Named
  , Itest_Aliased
{
  public _Identifier aliases { get; set; }
}

public class test_Named
  : test_Described
  , Itest_Named
{
  public _Identifier name { get; set; }
}

public class test_Described
  : Itest_Described
{
  public String description { get; set; }
}

public class test_AndType
  : test_Named
  , Itest_AndType
{
  public _Type type { get; set; }
  public _Type As_Type { get; set; }
}

public class test_Categories
  : test_AndType
  , Itest_Categories
{
  public _Category category { get; set; }
  public _Category As_Category { get; set; }
}

public class test_Category
  : test_Aliased
  , Itest_Category
{
  public _Resolution resolution { get; set; }
  public _TypeRef<_TypeKind> output { get; set; }
  public _Modifiers modifiers { get; set; }
}

public class test_Directives
  : test_AndType
  , Itest_Directives
{
  public _Directive directive { get; set; }
  public _Directive As_Directive { get; set; }
}

public class test_Directive
  : test_Aliased
  , Itest_Directive
{
  public _InputParam parameters { get; set; }
  public Boolean repeatable { get; set; }
  public Unit locations { get; set; }
}

public class test_Setting
  : test_Named
  , Itest_Setting
{
  public _Value value { get; set; }
}

public class test_Type
  : Itest_Type
{
  public _BaseType<_TypeKind> As_BaseType { get; set; }
  public _BaseType<_TypeKind> As_BaseType { get; set; }
  public _TypeDual As_TypeDual { get; set; }
  public _TypeEnum As_TypeEnum { get; set; }
  public _TypeInput As_TypeInput { get; set; }
  public _TypeOutput As_TypeOutput { get; set; }
  public _TypeDomain As_TypeDomain { get; set; }
  public _TypeUnion As_TypeUnion { get; set; }
}

public class test_BaseType<Tkind>
  : test_Aliased
  , Itest_BaseType<Tkind>
{
  public Tkind typeKind { get; set; }
}

public class test_ChildType<Tkind,Tparent>
  : test_BaseType
  , Itest_ChildType<Tkind,Tparent>
{
  public Tparent parent { get; set; }
}

public class test_ParentType<Tkind,Titem,TallItem>
  : test_ChildType
  , Itest_ParentType<Tkind,Titem,TallItem>
{
  public Titem items { get; set; }
  public TallItem allItems { get; set; }
}

public class test_TypeRef<Tkind>
  : test_Named
  , Itest_TypeRef<Tkind>
{
  public Tkind typeKind { get; set; }
}

public class test_TypeSimple
  : Itest_TypeSimple
{
  public _TypeRef<_TypeKind> As_TypeRef { get; set; }
  public _TypeRef<_TypeKind> As_TypeRef { get; set; }
  public _TypeRef<_TypeKind> As_TypeRef { get; set; }
  public _TypeRef<_TypeKind> As_TypeRef { get; set; }
}

public class test_Collections
  : Itest_Collections
{
  public _Modifier<_ModifierKind> As_Modifier { get; set; }
  public _ModifierKeyed<_ModifierKind> As_ModifierKeyed { get; set; }
  public _ModifierKeyed<_ModifierKind> As_ModifierKeyed { get; set; }
}

public class test_ModifierKeyed<Tkind>
  : test_Modifier
  , Itest_ModifierKeyed<Tkind>
{
  public _TypeSimple by { get; set; }
  public Boolean optional { get; set; }
}

public class test_Modifiers
  : Itest_Modifiers
{
  public _Modifier<_ModifierKind> As_Modifier { get; set; }
  public _Collections As_Collections { get; set; }
}

public class test_Modifier<Tkind>
  : Itest_Modifier<Tkind>
{
  public Tkind modifierKind { get; set; }
}

public class test_TypeDomain
  : Itest_TypeDomain
{
  public _BaseDomain<_DomainKind, _DomainTrueFalse, _DomainItemTrueFalse> As_BaseDomain { get; set; }
  public _BaseDomain<_DomainKind, _DomainLabel, _DomainItemLabel> As_BaseDomain { get; set; }
  public _BaseDomain<_DomainKind, _DomainRange, _DomainItemRange> As_BaseDomain { get; set; }
  public _BaseDomain<_DomainKind, _DomainRegex, _DomainItemRegex> As_BaseDomain { get; set; }
}

public class test_DomainRef<Tkind>
  : test_TypeRef
  , Itest_DomainRef<Tkind>
{
  public Tkind domainKind { get; set; }
}

public class test_BaseDomain<Tdomain,Titem,TdomainItem>
  : test_ParentType
  , Itest_BaseDomain<Tdomain,Titem,TdomainItem>
{
  public Tdomain domainKind { get; set; }
}

public class test_BaseDomainItem
  : test_Described
  , Itest_BaseDomainItem
{
  public Boolean exclude { get; set; }
}

public class test_DomainItem<Titem>
  : testitem
  , Itest_DomainItem<Titem>
{
  public _Identifier domain { get; set; }
}

public class test_DomainValue<Tkind,Tvalue>
  : test_DomainRef
  , Itest_DomainValue<Tkind,Tvalue>
{
  public Tvalue value { get; set; }
  public Tvalue Asvalue { get; set; }
}

public class test_BasicValue
  : Itest_BasicValue
{
  public _DomainKind As_DomainKind { get; set; }
  public _EnumValue As_EnumValue { get; set; }
  public _DomainKind As_DomainKind { get; set; }
  public _DomainKind As_DomainKind { get; set; }
}

public class test_DomainTrueFalse
  : test_BaseDomainItem
  , Itest_DomainTrueFalse
{
  public Boolean value { get; set; }
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
  public _EnumValue label { get; set; }
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
  public Number lower { get; set; }
  public Number upper { get; set; }
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
  public String pattern { get; set; }
}

public class test_DomainItemRegex
  : test_DomainItem
  , Itest_DomainItemRegex
{
}

public class test_TypeEnum
  : test_ParentType
  , Itest_TypeEnum
{
}

public class test_EnumLabel
  : test_Aliased
  , Itest_EnumLabel
{
  public _Identifier enum { get; set; }
}

public class test_EnumValue
  : test_TypeRef
  , Itest_EnumValue
{
  public _Identifier label { get; set; }
}

public class test_TypeUnion
  : test_ParentType
  , Itest_TypeUnion
{
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
  public _Identifier union { get; set; }
}

public class test_ObjectKind
  : Itest_ObjectKind
{
}

public class test_TypeObject<Tkind,Tfield>
  : test_ChildType
  , Itest_TypeObject<Tkind,Tfield>
{
  public _ObjTypeParam typeParams { get; set; }
  public Tfield fields { get; set; }
  public _ObjAlternate alternates { get; set; }
  public _ObjectFor<Tfield> allFields { get; set; }
  public _ObjectFor<_ObjAlternate> allAlternates { get; set; }
}

public class test_ObjTypeParam
  : test_Named
  , Itest_ObjTypeParam
{
  public _TypeRef<_TypeKind> constraint { get; set; }
}

public class test_ObjBase
  : test_Named
  , Itest_ObjBase
{
  public _ObjTypeArg typeArgs { get; set; }
  public _TypeParam As_TypeParam { get; set; }
}

public class test_ObjTypeArg
  : test_TypeRef
  , Itest_ObjTypeArg
{
  public _Identifier label { get; set; }
  public _TypeParam As_TypeParam { get; set; }
}

public class test_TypeParam
  : test_Described
  , Itest_TypeParam
{
  public _Identifier typeParam { get; set; }
}

public class test_ObjAlternate
  : Itest_ObjAlternate
{
  public _ObjBase type { get; set; }
  public _Collections collections { get; set; }
  public _ObjAlternateEnum As_ObjAlternateEnum { get; set; }
}

public class test_ObjAlternateEnum
  : test_TypeRef
  , Itest_ObjAlternateEnum
{
  public _Identifier label { get; set; }
}

public class test_ObjectFor<Tfor>
  : testfor
  , Itest_ObjectFor<Tfor>
{
  public _Identifier object { get; set; }
}

public class test_ObjField<Ttype>
  : test_Aliased
  , Itest_ObjField<Ttype>
{
  public Ttype type { get; set; }
}

public class test_ObjFieldType
  : test_ObjBase
  , Itest_ObjFieldType
{
  public _Modifiers modifiers { get; set; }
  public _ObjFieldEnum As_ObjFieldEnum { get; set; }
}

public class test_ObjFieldEnum
  : test_TypeRef
  , Itest_ObjFieldEnum
{
  public _Identifier label { get; set; }
}

public class test_ForParam<Ttype>
  : Itest_ForParam<Ttype>
{
  public _ObjAlternate As_ObjAlternate { get; set; }
  public _ObjField<Ttype> As_ObjField { get; set; }
}

public class test_TypeDual
  : test_TypeObject
  , Itest_TypeDual
{
}

public class test_DualField
  : test_ObjField
  , Itest_DualField
{
}

public class test_TypeInput
  : test_TypeObject
  , Itest_TypeInput
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
  public _Value default { get; set; }
}

public class test_InputParam
  : test_InputFieldType
  , Itest_InputParam
{
}

public class test_TypeOutput
  : test_TypeObject
  , Itest_TypeOutput
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
  public _InputParam parameters { get; set; }
}
