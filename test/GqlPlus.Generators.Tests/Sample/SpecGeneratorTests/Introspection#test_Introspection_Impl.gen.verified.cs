//HintName: test_Introspection_Impl.gen.cs
// Generated from Introspection.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_Introspection;

public class Outputtest_Schema
  : Outputtest_Named
  , Itest_Schema
{
  public _Categories categories { get; set; }
  public _Directives directives { get; set; }
  public _Type types { get; set; }
  public _Setting settings { get; set; }
}

public class Domaintest_Identifier
  : Itest_Identifier
{
}

public class Inputtest_Filter
  : Itest_Filter
{
  public _NameFilter names { get; set; }
  public Boolean matchAliases { get; set; }
  public _NameFilter aliases { get; set; }
  public Boolean returnByAlias { get; set; }
  public Boolean returnReferencedTypes { get; set; }
  public _NameFilter As_NameFilter { get; set; }
}

public class Domaintest_NameFilter
  : Itest_NameFilter
{
}

public class Inputtest_CategoryFilter
  : Inputtest_Filter
  , Itest_CategoryFilter
{
  public _Resolution resolutions { get; set; }
}

public class Inputtest_TypeFilter
  : Inputtest_Filter
  , Itest_TypeFilter
{
  public _TypeKind kinds { get; set; }
}

public class Dualtest_Aliased
  : Dualtest_Named
  , Itest_Aliased
{
  public _Identifier aliases { get; set; }
}

public class Dualtest_Named
  : Dualtest_Described
  , Itest_Named
{
  public _Identifier name { get; set; }
}

public class Dualtest_Described
  : Itest_Described
{
  public String description { get; set; }
}

public class Outputtest_AndType
  : Outputtest_Named
  , Itest_AndType
{
  public _Type type { get; set; }
  public _Type As_Type { get; set; }
}

public class Outputtest_Categories
  : Outputtest_AndType
  , Itest_Categories
{
  public _Category category { get; set; }
  public _Category As_Category { get; set; }
}

public class Outputtest_Category
  : Outputtest_Aliased
  , Itest_Category
{
  public _Resolution resolution { get; set; }
  public _TypeRef<_TypeKind> output { get; set; }
  public _Modifiers modifiers { get; set; }
}

public class Outputtest_Directives
  : Outputtest_AndType
  , Itest_Directives
{
  public _Directive directive { get; set; }
  public _Directive As_Directive { get; set; }
}

public class Outputtest_Directive
  : Outputtest_Aliased
  , Itest_Directive
{
  public _InputParam parameters { get; set; }
  public Boolean repeatable { get; set; }
  public Unit locations { get; set; }
}

public class Outputtest_Setting
  : Outputtest_Named
  , Itest_Setting
{
  public _Value value { get; set; }
}

public class Outputtest_Type
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

public class Outputtest_BaseType<Tkind>
  : Outputtest_Aliased
  , Itest_BaseType<Tkind>
{
  public Tkind typeKind { get; set; }
}

public class Outputtest_ChildType<Tkind,Tparent>
  : Outputtest_BaseType
  , Itest_ChildType<Tkind,Tparent>
{
  public Tparent parent { get; set; }
}

public class Outputtest_ParentType<Tkind,Titem,TallItem>
  : Outputtest_ChildType
  , Itest_ParentType<Tkind,Titem,TallItem>
{
  public Titem items { get; set; }
  public TallItem allItems { get; set; }
}

public class Dualtest_TypeRef<Tkind>
  : Dualtest_Named
  , Itest_TypeRef<Tkind>
{
  public Tkind typeKind { get; set; }
}

public class Dualtest_TypeSimple
  : Itest_TypeSimple
{
  public _TypeRef<_TypeKind> As_TypeRef { get; set; }
  public _TypeRef<_TypeKind> As_TypeRef { get; set; }
  public _TypeRef<_TypeKind> As_TypeRef { get; set; }
  public _TypeRef<_TypeKind> As_TypeRef { get; set; }
}

public class Dualtest_Collections
  : Itest_Collections
{
  public _Modifier<_ModifierKind> As_Modifier { get; set; }
  public _ModifierKeyed<_ModifierKind> As_ModifierKeyed { get; set; }
  public _ModifierKeyed<_ModifierKind> As_ModifierKeyed { get; set; }
}

public class Dualtest_ModifierKeyed<Tkind>
  : Dualtest_Modifier
  , Itest_ModifierKeyed<Tkind>
{
  public _TypeSimple by { get; set; }
  public Boolean optional { get; set; }
}

public class Dualtest_Modifiers
  : Itest_Modifiers
{
  public _Modifier<_ModifierKind> As_Modifier { get; set; }
  public _Collections As_Collections { get; set; }
}

public class Dualtest_Modifier<Tkind>
  : Itest_Modifier<Tkind>
{
  public Tkind modifierKind { get; set; }
}

public class Outputtest_TypeDomain
  : Itest_TypeDomain
{
  public _BaseDomain<_DomainKind, _DomainTrueFalse, _DomainItemTrueFalse> As_BaseDomain { get; set; }
  public _BaseDomain<_DomainKind, _DomainLabel, _DomainItemLabel> As_BaseDomain { get; set; }
  public _BaseDomain<_DomainKind, _DomainRange, _DomainItemRange> As_BaseDomain { get; set; }
  public _BaseDomain<_DomainKind, _DomainRegex, _DomainItemRegex> As_BaseDomain { get; set; }
}

public class Outputtest_DomainRef<Tkind>
  : Outputtest_TypeRef
  , Itest_DomainRef<Tkind>
{
  public Tkind domainKind { get; set; }
}

public class Outputtest_BaseDomain<Tdomain,Titem,TdomainItem>
  : Outputtest_ParentType
  , Itest_BaseDomain<Tdomain,Titem,TdomainItem>
{
  public Tdomain domainKind { get; set; }
}

public class Dualtest_BaseDomainItem
  : Dualtest_Described
  , Itest_BaseDomainItem
{
  public Boolean exclude { get; set; }
}

public class Outputtest_DomainItem<Titem>
  : Outputtestitem
  , Itest_DomainItem<Titem>
{
  public _Identifier domain { get; set; }
}

public class Outputtest_DomainValue<Tkind,Tvalue>
  : Outputtest_DomainRef
  , Itest_DomainValue<Tkind,Tvalue>
{
  public Tvalue value { get; set; }
  public Tvalue Asvalue { get; set; }
}

public class Outputtest_BasicValue
  : Itest_BasicValue
{
  public _DomainKind As_DomainKind { get; set; }
  public _EnumValue As_EnumValue { get; set; }
  public _DomainKind As_DomainKind { get; set; }
  public _DomainKind As_DomainKind { get; set; }
}

public class Dualtest_DomainTrueFalse
  : Dualtest_BaseDomainItem
  , Itest_DomainTrueFalse
{
  public Boolean value { get; set; }
}

public class Outputtest_DomainItemTrueFalse
  : Outputtest_DomainItem
  , Itest_DomainItemTrueFalse
{
}

public class Outputtest_DomainLabel
  : Outputtest_BaseDomainItem
  , Itest_DomainLabel
{
  public _EnumValue label { get; set; }
}

public class Outputtest_DomainItemLabel
  : Outputtest_DomainItem
  , Itest_DomainItemLabel
{
}

public class Dualtest_DomainRange
  : Dualtest_BaseDomainItem
  , Itest_DomainRange
{
  public Number lower { get; set; }
  public Number upper { get; set; }
}

public class Outputtest_DomainItemRange
  : Outputtest_DomainItem
  , Itest_DomainItemRange
{
}

public class Dualtest_DomainRegex
  : Dualtest_BaseDomainItem
  , Itest_DomainRegex
{
  public String pattern { get; set; }
}

public class Outputtest_DomainItemRegex
  : Outputtest_DomainItem
  , Itest_DomainItemRegex
{
}

public class Outputtest_TypeEnum
  : Outputtest_ParentType
  , Itest_TypeEnum
{
}

public class Dualtest_EnumLabel
  : Dualtest_Aliased
  , Itest_EnumLabel
{
  public _Identifier enum { get; set; }
}

public class Outputtest_EnumValue
  : Outputtest_TypeRef
  , Itest_EnumValue
{
  public _Identifier label { get; set; }
}

public class Outputtest_TypeUnion
  : Outputtest_ParentType
  , Itest_TypeUnion
{
}

public class Outputtest_UnionRef
  : Outputtest_TypeRef
  , Itest_UnionRef
{
}

public class Outputtest_UnionMember
  : Outputtest_UnionRef
  , Itest_UnionMember
{
  public _Identifier union { get; set; }
}

public class Domaintest_ObjectKind
  : Itest_ObjectKind
{
}

public class Outputtest_TypeObject<Tkind,Tfield>
  : Outputtest_ChildType
  , Itest_TypeObject<Tkind,Tfield>
{
  public _ObjTypeParam typeParams { get; set; }
  public Tfield fields { get; set; }
  public _ObjAlternate alternates { get; set; }
  public _ObjectFor<Tfield> allFields { get; set; }
  public _ObjectFor<_ObjAlternate> allAlternates { get; set; }
}

public class Outputtest_ObjTypeParam
  : Outputtest_Named
  , Itest_ObjTypeParam
{
  public _TypeRef<_TypeKind> constraint { get; set; }
}

public class Outputtest_ObjBase
  : Outputtest_Named
  , Itest_ObjBase
{
  public _ObjTypeArg typeArgs { get; set; }
  public _TypeParam As_TypeParam { get; set; }
}

public class Outputtest_ObjTypeArg
  : Outputtest_TypeRef
  , Itest_ObjTypeArg
{
  public _Identifier label { get; set; }
  public _TypeParam As_TypeParam { get; set; }
}

public class Outputtest_TypeParam
  : Outputtest_Described
  , Itest_TypeParam
{
  public _Identifier typeParam { get; set; }
}

public class Outputtest_ObjAlternate
  : Itest_ObjAlternate
{
  public _ObjBase type { get; set; }
  public _Collections collections { get; set; }
  public _ObjAlternateEnum As_ObjAlternateEnum { get; set; }
}

public class Outputtest_ObjAlternateEnum
  : Outputtest_TypeRef
  , Itest_ObjAlternateEnum
{
  public _Identifier label { get; set; }
}

public class Outputtest_ObjectFor<Tfor>
  : Outputtestfor
  , Itest_ObjectFor<Tfor>
{
  public _Identifier object { get; set; }
}

public class Outputtest_ObjField<Ttype>
  : Outputtest_Aliased
  , Itest_ObjField<Ttype>
{
  public Ttype type { get; set; }
}

public class Outputtest_ObjFieldType
  : Outputtest_ObjBase
  , Itest_ObjFieldType
{
  public _Modifiers modifiers { get; set; }
  public _ObjFieldEnum As_ObjFieldEnum { get; set; }
}

public class Outputtest_ObjFieldEnum
  : Outputtest_TypeRef
  , Itest_ObjFieldEnum
{
  public _Identifier label { get; set; }
}

public class Outputtest_ForParam<Ttype>
  : Itest_ForParam<Ttype>
{
  public _ObjAlternate As_ObjAlternate { get; set; }
  public _ObjField<Ttype> As_ObjField { get; set; }
}

public class Outputtest_TypeDual
  : Outputtest_TypeObject
  , Itest_TypeDual
{
}

public class Outputtest_DualField
  : Outputtest_ObjField
  , Itest_DualField
{
}

public class Outputtest_TypeInput
  : Outputtest_TypeObject
  , Itest_TypeInput
{
}

public class Outputtest_InputField
  : Outputtest_ObjField
  , Itest_InputField
{
}

public class Outputtest_InputFieldType
  : Outputtest_ObjFieldType
  , Itest_InputFieldType
{
  public _Value default { get; set; }
}

public class Outputtest_InputParam
  : Outputtest_InputFieldType
  , Itest_InputParam
{
}

public class Outputtest_TypeOutput
  : Outputtest_TypeObject
  , Itest_TypeOutput
{
}

public class Outputtest_OutputField
  : Outputtest_ObjField
  , Itest_OutputField
{
}

public class Outputtest_OutputFieldType
  : Outputtest_ObjFieldType
  , Itest_OutputFieldType
{
  public _InputParam parameters { get; set; }
}
