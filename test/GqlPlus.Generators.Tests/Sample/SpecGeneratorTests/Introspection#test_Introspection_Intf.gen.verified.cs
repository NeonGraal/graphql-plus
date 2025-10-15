//HintName: test_Introspection_Intf.gen.cs
// Generated from Introspection.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_Introspection;

public interface Itest_Schema
  : Itest_Named
{
  _Categories categories { get; }
  _Directives directives { get; }
  _Type types { get; }
  _Setting settings { get; }
}

public interface Itest_Identifier
{
}

public interface Itest_Filter
{
  _NameFilter names { get; }
  Boolean matchAliases { get; }
  _NameFilter aliases { get; }
  Boolean returnByAlias { get; }
  Boolean returnReferencedTypes { get; }
  _NameFilter As_NameFilter { get; }
}

public interface Itest_NameFilter
{
}

public interface Itest_CategoryFilter
  : Itest_Filter
{
  _Resolution resolutions { get; }
}

public interface Itest_TypeFilter
  : Itest_Filter
{
  _TypeKind kinds { get; }
}

public interface Itest_Aliased
  : Itest_Named
{
  _Identifier aliases { get; }
}

public interface Itest_Named
  : Itest_Described
{
  _Identifier name { get; }
}

public interface Itest_Described
{
  String description { get; }
}

public interface Itest_AndType
  : Itest_Named
{
  _Type type { get; }
  _Type As_Type { get; }
}

public interface Itest_Categories
  : Itest_AndType
{
  _Category category { get; }
  _Category As_Category { get; }
}

public interface Itest_Category
  : Itest_Aliased
{
  _Resolution resolution { get; }
  _TypeRef<_TypeKind> output { get; }
  _Modifiers modifiers { get; }
}

public interface Itest_Directives
  : Itest_AndType
{
  _Directive directive { get; }
  _Directive As_Directive { get; }
}

public interface Itest_Directive
  : Itest_Aliased
{
  _InputParam parameters { get; }
  Boolean repeatable { get; }
  Unit locations { get; }
}

public interface Itest_Setting
  : Itest_Named
{
  _Value value { get; }
}

public interface Itest_Type
{
  _BaseType<_TypeKind> As_BaseType { get; }
  _BaseType<_TypeKind> As_BaseType { get; }
  _TypeDual As_TypeDual { get; }
  _TypeEnum As_TypeEnum { get; }
  _TypeInput As_TypeInput { get; }
  _TypeOutput As_TypeOutput { get; }
  _TypeDomain As_TypeDomain { get; }
  _TypeUnion As_TypeUnion { get; }
}

public interface Itest_BaseType<Tkind>
  : Itest_Aliased
{
  Tkind typeKind { get; }
}

public interface Itest_ChildType<Tkind,Tparent>
  : Itest_BaseType
{
  Tparent parent { get; }
}

public interface Itest_ParentType<Tkind,Titem,TallItem>
  : Itest_ChildType
{
  Titem items { get; }
  TallItem allItems { get; }
}

public interface Itest_TypeRef<Tkind>
  : Itest_Named
{
  Tkind typeKind { get; }
}

public interface Itest_TypeSimple
{
  _TypeRef<_TypeKind> As_TypeRef { get; }
  _TypeRef<_TypeKind> As_TypeRef { get; }
  _TypeRef<_TypeKind> As_TypeRef { get; }
  _TypeRef<_TypeKind> As_TypeRef { get; }
}

public interface Itest_Collections
{
  _Modifier<_ModifierKind> As_Modifier { get; }
  _ModifierKeyed<_ModifierKind> As_ModifierKeyed { get; }
  _ModifierKeyed<_ModifierKind> As_ModifierKeyed { get; }
}

public interface Itest_ModifierKeyed<Tkind>
  : Itest_Modifier
{
  _TypeSimple by { get; }
  Boolean optional { get; }
}

public interface Itest_Modifiers
{
  _Modifier<_ModifierKind> As_Modifier { get; }
  _Collections As_Collections { get; }
}

public interface Itest_Modifier<Tkind>
{
  Tkind modifierKind { get; }
}

public interface Itest_TypeDomain
{
  _BaseDomain<_DomainKind, _DomainTrueFalse, _DomainItemTrueFalse> As_BaseDomain { get; }
  _BaseDomain<_DomainKind, _DomainLabel, _DomainItemLabel> As_BaseDomain { get; }
  _BaseDomain<_DomainKind, _DomainRange, _DomainItemRange> As_BaseDomain { get; }
  _BaseDomain<_DomainKind, _DomainRegex, _DomainItemRegex> As_BaseDomain { get; }
}

public interface Itest_DomainRef<Tkind>
  : Itest_TypeRef
{
  Tkind domainKind { get; }
}

public interface Itest_BaseDomain<Tdomain,Titem,TdomainItem>
  : Itest_ParentType
{
  Tdomain domainKind { get; }
}

public interface Itest_BaseDomainItem
  : Itest_Described
{
  Boolean exclude { get; }
}

public interface Itest_DomainItem<Titem>
  : Itestitem
{
  _Identifier domain { get; }
}

public interface Itest_DomainValue<Tkind,Tvalue>
  : Itest_DomainRef
{
  Tvalue value { get; }
  Tvalue Asvalue { get; }
}

public interface Itest_BasicValue
{
  _DomainKind As_DomainKind { get; }
  _EnumValue As_EnumValue { get; }
  _DomainKind As_DomainKind { get; }
  _DomainKind As_DomainKind { get; }
}

public interface Itest_DomainTrueFalse
  : Itest_BaseDomainItem
{
  Boolean value { get; }
}

public interface Itest_DomainItemTrueFalse
  : Itest_DomainItem
{
}

public interface Itest_DomainLabel
  : Itest_BaseDomainItem
{
  _EnumValue label { get; }
}

public interface Itest_DomainItemLabel
  : Itest_DomainItem
{
}

public interface Itest_DomainRange
  : Itest_BaseDomainItem
{
  Number lower { get; }
  Number upper { get; }
}

public interface Itest_DomainItemRange
  : Itest_DomainItem
{
}

public interface Itest_DomainRegex
  : Itest_BaseDomainItem
{
  String pattern { get; }
}

public interface Itest_DomainItemRegex
  : Itest_DomainItem
{
}

public interface Itest_TypeEnum
  : Itest_ParentType
{
}

public interface Itest_EnumLabel
  : Itest_Aliased
{
  _Identifier enum { get; }
}

public interface Itest_EnumValue
  : Itest_TypeRef
{
  _Identifier label { get; }
}

public interface Itest_TypeUnion
  : Itest_ParentType
{
}

public interface Itest_UnionRef
  : Itest_TypeRef
{
}

public interface Itest_UnionMember
  : Itest_UnionRef
{
  _Identifier union { get; }
}

public interface Itest_ObjectKind
{
}

public interface Itest_TypeObject<Tkind,Tfield>
  : Itest_ChildType
{
  _ObjTypeParam typeParams { get; }
  Tfield fields { get; }
  _ObjAlternate alternates { get; }
  _ObjectFor<Tfield> allFields { get; }
  _ObjectFor<_ObjAlternate> allAlternates { get; }
}

public interface Itest_ObjTypeParam
  : Itest_Named
{
  _TypeRef<_TypeKind> constraint { get; }
}

public interface Itest_ObjBase
  : Itest_Named
{
  _ObjTypeArg typeArgs { get; }
  _TypeParam As_TypeParam { get; }
}

public interface Itest_ObjTypeArg
  : Itest_TypeRef
{
  _Identifier label { get; }
  _TypeParam As_TypeParam { get; }
}

public interface Itest_TypeParam
  : Itest_Described
{
  _Identifier typeParam { get; }
}

public interface Itest_ObjAlternate
{
  _ObjBase type { get; }
  _Collections collections { get; }
  _ObjAlternateEnum As_ObjAlternateEnum { get; }
}

public interface Itest_ObjAlternateEnum
  : Itest_TypeRef
{
  _Identifier label { get; }
}

public interface Itest_ObjectFor<Tfor>
  : Itestfor
{
  _Identifier object { get; }
}

public interface Itest_ObjField<Ttype>
  : Itest_Aliased
{
  Ttype type { get; }
}

public interface Itest_ObjFieldType
  : Itest_ObjBase
{
  _Modifiers modifiers { get; }
  _ObjFieldEnum As_ObjFieldEnum { get; }
}

public interface Itest_ObjFieldEnum
  : Itest_TypeRef
{
  _Identifier label { get; }
}

public interface Itest_ForParam<Ttype>
{
  _ObjAlternate As_ObjAlternate { get; }
  _ObjField<Ttype> As_ObjField { get; }
}

public interface Itest_TypeDual
  : Itest_TypeObject
{
}

public interface Itest_DualField
  : Itest_ObjField
{
}

public interface Itest_TypeInput
  : Itest_TypeObject
{
}

public interface Itest_InputField
  : Itest_ObjField
{
}

public interface Itest_InputFieldType
  : Itest_ObjFieldType
{
  _Value default { get; }
}

public interface Itest_InputParam
  : Itest_InputFieldType
{
}

public interface Itest_TypeOutput
  : Itest_TypeObject
{
}

public interface Itest_OutputField
  : Itest_ObjField
{
}

public interface Itest_OutputFieldType
  : Itest_ObjFieldType
{
  _InputParam parameters { get; }
}
