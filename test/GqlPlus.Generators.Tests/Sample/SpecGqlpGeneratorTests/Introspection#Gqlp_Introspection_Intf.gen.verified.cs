//HintName: Gqlp_Introspection_Intf.gen.cs
// Generated from Introspection.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_Introspection;

public interface I_Schema
  : I_Named
{
  _Categories categories { get; }
  _Directives directives { get; }
  _Type types { get; }
  _Setting settings { get; }
}

public interface I_Identifier
{
}

public interface I_Filter
{
  _NameFilter names { get; }
  Boolean matchAliases { get; }
  _NameFilter aliases { get; }
  Boolean returnByAlias { get; }
  Boolean returnReferencedTypes { get; }
  _NameFilter As_NameFilter { get; }
}

public interface I_NameFilter
{
}

public interface I_CategoryFilter
  : I_Filter
{
  _Resolution resolutions { get; }
}

public interface I_TypeFilter
  : I_Filter
{
  _TypeKind kinds { get; }
}

public interface I_Aliased
  : I_Named
{
  _Identifier aliases { get; }
}

public interface I_Named
  : I_Described
{
  _Identifier name { get; }
}

public interface I_Described
{
  String description { get; }
}

public interface I_AndType
  : I_Named
{
  _Type type { get; }
  _Type As_Type { get; }
}

public interface I_Categories
  : I_AndType
{
  _Category category { get; }
  _Category As_Category { get; }
}

public interface I_Category
  : I_Aliased
{
  _Resolution resolution { get; }
  _TypeRef<_TypeKind> output { get; }
  _Modifiers modifiers { get; }
}

public interface I_Directives
  : I_AndType
{
  _Directive directive { get; }
  _Directive As_Directive { get; }
}

public interface I_Directive
  : I_Aliased
{
  _InputParam parameters { get; }
  Boolean repeatable { get; }
  Unit locations { get; }
}

public interface I_Setting
  : I_Named
{
  _Value value { get; }
}

public interface I_Type
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

public interface I_BaseType<Tkind>
  : I_Aliased
{
  Tkind typeKind { get; }
}

public interface I_ChildType<Tkind,Tparent>
  : I_BaseType
{
  Tparent parent { get; }
}

public interface I_ParentType<Tkind,Titem,TallItem>
  : I_ChildType
{
  Titem items { get; }
  TallItem allItems { get; }
}

public interface I_TypeRef<Tkind>
  : I_Named
{
  Tkind typeKind { get; }
}

public interface I_TypeSimple
{
  _TypeRef<_TypeKind> As_TypeRef { get; }
  _TypeRef<_TypeKind> As_TypeRef { get; }
  _TypeRef<_TypeKind> As_TypeRef { get; }
  _TypeRef<_TypeKind> As_TypeRef { get; }
}

public interface I_Collections
{
  _Modifier<_ModifierKind> As_Modifier { get; }
  _ModifierKeyed<_ModifierKind> As_ModifierKeyed { get; }
  _ModifierKeyed<_ModifierKind> As_ModifierKeyed { get; }
}

public interface I_ModifierKeyed<Tkind>
  : I_Modifier
{
  _TypeSimple by { get; }
  Boolean optional { get; }
}

public interface I_Modifiers
{
  _Modifier<_ModifierKind> As_Modifier { get; }
  _Collections As_Collections { get; }
}

public interface I_Modifier<Tkind>
{
  Tkind modifierKind { get; }
}

public interface I_TypeDomain
{
  _BaseDomain<_DomainKind, _DomainTrueFalse, _DomainItemTrueFalse> As_BaseDomain { get; }
  _BaseDomain<_DomainKind, _DomainLabel, _DomainItemLabel> As_BaseDomain { get; }
  _BaseDomain<_DomainKind, _DomainRange, _DomainItemRange> As_BaseDomain { get; }
  _BaseDomain<_DomainKind, _DomainRegex, _DomainItemRegex> As_BaseDomain { get; }
}

public interface I_DomainRef<Tkind>
  : I_TypeRef
{
  Tkind domainKind { get; }
}

public interface I_BaseDomain<Tdomain,Titem,TdomainItem>
  : I_ParentType
{
  Tdomain domainKind { get; }
}

public interface I_BaseDomainItem
  : I_Described
{
  Boolean exclude { get; }
}

public interface I_DomainItem<Titem>
  : Iitem
{
  _Identifier domain { get; }
}

public interface I_DomainValue<Tkind,Tvalue>
  : I_DomainRef
{
  Tvalue value { get; }
  Tvalue Asvalue { get; }
}

public interface I_BasicValue
{
  Boolean AsBoolean { get; }
  _EnumValue As_EnumValue { get; }
  Number AsNumber { get; }
  String AsString { get; }
}

public interface I_DomainTrueFalse
  : I_BaseDomainItem
{
  Boolean value { get; }
}

public interface I_DomainItemTrueFalse
  : I_DomainItem
{
}

public interface I_DomainLabel
  : I_BaseDomainItem
{
  _EnumValue label { get; }
}

public interface I_DomainItemLabel
  : I_DomainItem
{
}

public interface I_DomainRange
  : I_BaseDomainItem
{
  Number lower { get; }
  Number upper { get; }
}

public interface I_DomainItemRange
  : I_DomainItem
{
}

public interface I_DomainRegex
  : I_BaseDomainItem
{
  String pattern { get; }
}

public interface I_DomainItemRegex
  : I_DomainItem
{
}

public interface I_TypeEnum
  : I_ParentType
{
}

public interface I_EnumLabel
  : I_Aliased
{
  _Identifier enum { get; }
}

public interface I_EnumValue
  : I_TypeRef
{
  _Identifier label { get; }
}

public interface I_TypeUnion
  : I_ParentType
{
}

public interface I_UnionRef
  : I_TypeRef
{
}

public interface I_UnionMember
  : I_UnionRef
{
  _Identifier union { get; }
}

public interface I_ObjectKind
{
}

public interface I_TypeObject<Tkind,Tparent,TtypeParam,Tfield,Talternate>
  : I_ChildType
{
  TtypeParam typeParams { get; }
  Tfield fields { get; }
  Talternate alternates { get; }
  _ObjectFor<Tfield> allFields { get; }
  _ObjectFor<Talternate> allAlternates { get; }
}

public interface I_ObjTypeParam<Tkind>
  : I_Named
{
  _ObjConstraint<Tkind> constraint { get; }
}

public interface I_ObjConstraint<Tkind>
  : I_TypeRef
{
}

public interface I_ObjBase<Targ>
  : I_Named
{
  Targ typeArgs { get; }
  _TypeParam As_TypeParam { get; }
}

public interface I_ObjTypeArg
  : I_TypeRef
{
  _TypeParam As_TypeParam { get; }
}

public interface I_TypeParam
  : I_Named
{
  _Identifier typeParam { get; }
}

public interface I_Alternate<Tbase>
{
  Tbase type { get; }
  _Collections collections { get; }
}

public interface I_ObjectFor<Tfor>
  : Ifor
{
  _Identifier object { get; }
}

public interface I_Field<Tbase>
  : I_Aliased
{
  Tbase type { get; }
  _Modifiers modifiers { get; }
}

public interface I_ForParam<Tbase>
{
  _Alternate<Tbase> As_Alternate { get; }
  _Field<Tbase> As_Field { get; }
}

public interface I_TypeDual
  : I_TypeObject
{
}

public interface I_DualBase
  : I_ObjBase
{
}

public interface I_DualTypeParam
  : I_ObjTypeParam
{
}

public interface I_DualField
  : I_Field
{
}

public interface I_DualAlternate
  : I_Alternate
{
}

public interface I_DualTypeArg
  : I_ObjTypeArg
{
}

public interface I_TypeInput
  : I_TypeObject
{
}

public interface I_InputBase
  : I_ObjBase
{
  _DualBase As_DualBase { get; }
}

public interface I_InputTypeParam
  : I_ObjTypeParam
{
  _TypeRef<_TypeKind> As_TypeRef { get; }
}

public interface I_InputField
  : I_Field
{
  _Value default { get; }
}

public interface I_InputAlternate
  : I_Alternate
{
}

public interface I_InputTypeArg
  : I_ObjTypeArg
{
}

public interface I_InputParam
  : I_InputBase
{
  _Modifiers modifiers { get; }
  _Value default { get; }
}

public interface I_TypeOutput
  : I_TypeObject
{
}

public interface I_OutputBase
  : I_ObjBase
{
  _DualBase As_DualBase { get; }
}

public interface I_OutputTypeParam
  : I_ObjTypeParam
{
  _TypeRef<_TypeKind> As_TypeRef { get; }
  _TypeRef<_TypeKind> As_TypeRef { get; }
}

public interface I_OutputField
  : I_Field
{
  _InputParam parameters { get; }
  _OutputEnum As_OutputEnum { get; }
}

public interface I_OutputAlternate
  : I_Alternate
{
}

public interface I_OutputTypeArg
  : I_ObjTypeArg
{
  _Identifier label { get; }
}

public interface I_OutputEnum
  : I_TypeRef
{
  _Identifier field { get; }
  _Identifier label { get; }
}
