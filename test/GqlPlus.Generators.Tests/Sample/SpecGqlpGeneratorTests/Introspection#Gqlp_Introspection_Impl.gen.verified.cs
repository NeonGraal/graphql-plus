//HintName: Gqlp_Introspection_Impl.gen.cs
// Generated from Introspection.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_Introspection;

public class Output_Schema
  : Output_Named
  , I_Schema
{
  public _Categories categories { get; set; }
  public _Directives directives { get; set; }
  public _Type types { get; set; }
  public _Setting settings { get; set; }
}

public class Domain_Identifier
  : I_Identifier
{
}

public class Input_Filter
  : I_Filter
{
  public _NameFilter names { get; set; }
  public Boolean matchAliases { get; set; }
  public _NameFilter aliases { get; set; }
  public Boolean returnByAlias { get; set; }
  public Boolean returnReferencedTypes { get; set; }
  public _NameFilter As_NameFilter { get; set; }
}

public class Domain_NameFilter
  : I_NameFilter
{
}

public class Input_CategoryFilter
  : Input_Filter
  , I_CategoryFilter
{
  public _Resolution resolutions { get; set; }
}

public class Input_TypeFilter
  : Input_Filter
  , I_TypeFilter
{
  public _TypeKind kinds { get; set; }
}

public class Dual_Aliased
  : Dual_Named
  , I_Aliased
{
  public _Identifier aliases { get; set; }
}

public class Dual_Named
  : Dual_Described
  , I_Named
{
  public _Identifier name { get; set; }
}

public class Dual_Described
  : I_Described
{
  public String description { get; set; }
}

public class Output_AndType
  : Output_Named
  , I_AndType
{
  public _Type type { get; set; }
  public _Type As_Type { get; set; }
}

public class Output_Categories
  : Output_AndType
  , I_Categories
{
  public _Category category { get; set; }
  public _Category As_Category { get; set; }
}

public class Output_Category
  : Output_Aliased
  , I_Category
{
  public _Resolution resolution { get; set; }
  public _TypeRef<_TypeKind> output { get; set; }
  public _Modifiers modifiers { get; set; }
}

public class Output_Directives
  : Output_AndType
  , I_Directives
{
  public _Directive directive { get; set; }
  public _Directive As_Directive { get; set; }
}

public class Output_Directive
  : Output_Aliased
  , I_Directive
{
  public _InputParam parameters { get; set; }
  public Boolean repeatable { get; set; }
  public Unit locations { get; set; }
}

public class Output_Setting
  : Output_Named
  , I_Setting
{
  public _Value value { get; set; }
}

public class Output_Type
  : I_Type
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

public class Output_BaseType<Tkind>
  : Output_Aliased
  , I_BaseType<Tkind>
{
  public Tkind typeKind { get; set; }
}

public class Output_ChildType<Tkind,Tparent>
  : Output_BaseType
  , I_ChildType<Tkind,Tparent>
{
  public Tparent parent { get; set; }
}

public class Output_ParentType<Tkind,Titem,TallItem>
  : Output_ChildType
  , I_ParentType<Tkind,Titem,TallItem>
{
  public Titem items { get; set; }
  public TallItem allItems { get; set; }
}

public class Dual_TypeRef<Tkind>
  : Dual_Named
  , I_TypeRef<Tkind>
{
  public Tkind typeKind { get; set; }
}

public class Dual_TypeSimple
  : I_TypeSimple
{
  public _TypeRef<_TypeKind> As_TypeRef { get; set; }
  public _TypeRef<_TypeKind> As_TypeRef { get; set; }
  public _TypeRef<_TypeKind> As_TypeRef { get; set; }
  public _TypeRef<_TypeKind> As_TypeRef { get; set; }
}

public class Dual_Collections
  : I_Collections
{
  public _Modifier<_ModifierKind> As_Modifier { get; set; }
  public _ModifierKeyed<_ModifierKind> As_ModifierKeyed { get; set; }
  public _ModifierKeyed<_ModifierKind> As_ModifierKeyed { get; set; }
}

public class Dual_ModifierKeyed<Tkind>
  : Dual_Modifier
  , I_ModifierKeyed<Tkind>
{
  public _TypeSimple by { get; set; }
  public Boolean optional { get; set; }
}

public class Dual_Modifiers
  : I_Modifiers
{
  public _Modifier<_ModifierKind> As_Modifier { get; set; }
  public _Collections As_Collections { get; set; }
}

public class Dual_Modifier<Tkind>
  : I_Modifier<Tkind>
{
  public Tkind modifierKind { get; set; }
}

public class Output_TypeDomain
  : I_TypeDomain
{
  public _BaseDomain<_DomainKind, _DomainTrueFalse, _DomainItemTrueFalse> As_BaseDomain { get; set; }
  public _BaseDomain<_DomainKind, _DomainLabel, _DomainItemLabel> As_BaseDomain { get; set; }
  public _BaseDomain<_DomainKind, _DomainRange, _DomainItemRange> As_BaseDomain { get; set; }
  public _BaseDomain<_DomainKind, _DomainRegex, _DomainItemRegex> As_BaseDomain { get; set; }
}

public class Output_DomainRef<Tkind>
  : Output_TypeRef
  , I_DomainRef<Tkind>
{
  public Tkind domainKind { get; set; }
}

public class Output_BaseDomain<Tdomain,Titem,TdomainItem>
  : Output_ParentType
  , I_BaseDomain<Tdomain,Titem,TdomainItem>
{
  public Tdomain domainKind { get; set; }
}

public class Dual_BaseDomainItem
  : Dual_Described
  , I_BaseDomainItem
{
  public Boolean exclude { get; set; }
}

public class Output_DomainItem<Titem>
  : Outputitem
  , I_DomainItem<Titem>
{
  public _Identifier domain { get; set; }
}

public class Output_DomainValue<Tkind,Tvalue>
  : Output_DomainRef
  , I_DomainValue<Tkind,Tvalue>
{
  public Tvalue value { get; set; }
  public Tvalue Asvalue { get; set; }
}

public class Output_BasicValue
  : I_BasicValue
{
  public _DomainKind As_DomainKind { get; set; }
  public _EnumValue As_EnumValue { get; set; }
  public _DomainKind As_DomainKind { get; set; }
  public _DomainKind As_DomainKind { get; set; }
}

public class Dual_DomainTrueFalse
  : Dual_BaseDomainItem
  , I_DomainTrueFalse
{
  public Boolean value { get; set; }
}

public class Output_DomainItemTrueFalse
  : Output_DomainItem
  , I_DomainItemTrueFalse
{
}

public class Output_DomainLabel
  : Output_BaseDomainItem
  , I_DomainLabel
{
  public _EnumValue label { get; set; }
}

public class Output_DomainItemLabel
  : Output_DomainItem
  , I_DomainItemLabel
{
}

public class Dual_DomainRange
  : Dual_BaseDomainItem
  , I_DomainRange
{
  public Number lower { get; set; }
  public Number upper { get; set; }
}

public class Output_DomainItemRange
  : Output_DomainItem
  , I_DomainItemRange
{
}

public class Dual_DomainRegex
  : Dual_BaseDomainItem
  , I_DomainRegex
{
  public String pattern { get; set; }
}

public class Output_DomainItemRegex
  : Output_DomainItem
  , I_DomainItemRegex
{
}

public class Output_TypeEnum
  : Output_ParentType
  , I_TypeEnum
{
}

public class Dual_EnumLabel
  : Dual_Aliased
  , I_EnumLabel
{
  public _Identifier enum { get; set; }
}

public class Output_EnumValue
  : Output_TypeRef
  , I_EnumValue
{
  public _Identifier label { get; set; }
}

public class Output_TypeUnion
  : Output_ParentType
  , I_TypeUnion
{
}

public class Output_UnionRef
  : Output_TypeRef
  , I_UnionRef
{
}

public class Output_UnionMember
  : Output_UnionRef
  , I_UnionMember
{
  public _Identifier union { get; set; }
}

public class Domain_ObjectKind
  : I_ObjectKind
{
}

public class Output_TypeObject<Tkind,Tfield>
  : Output_ChildType
  , I_TypeObject<Tkind,Tfield>
{
  public _ObjTypeParam typeParams { get; set; }
  public Tfield fields { get; set; }
  public _ObjAlternate alternates { get; set; }
  public _ObjectFor<Tfield> allFields { get; set; }
  public _ObjectFor<_ObjAlternate> allAlternates { get; set; }
}

public class Output_ObjTypeParam
  : Output_Named
  , I_ObjTypeParam
{
  public _TypeRef<_TypeKind> constraint { get; set; }
}

public class Output_ObjBase
  : Output_Named
  , I_ObjBase
{
  public _ObjTypeArg typeArgs { get; set; }
  public _TypeParam As_TypeParam { get; set; }
}

public class Output_ObjTypeArg
  : Output_TypeRef
  , I_ObjTypeArg
{
  public _Identifier label { get; set; }
  public _TypeParam As_TypeParam { get; set; }
}

public class Output_TypeParam
  : Output_Described
  , I_TypeParam
{
  public _Identifier typeParam { get; set; }
}

public class Output_ObjAlternate
  : I_ObjAlternate
{
  public _ObjBase type { get; set; }
  public _Collections collections { get; set; }
  public _ObjAlternateEnum As_ObjAlternateEnum { get; set; }
}

public class Output_ObjAlternateEnum
  : Output_TypeRef
  , I_ObjAlternateEnum
{
  public _Identifier label { get; set; }
}

public class Output_ObjectFor<Tfor>
  : Outputfor
  , I_ObjectFor<Tfor>
{
  public _Identifier object { get; set; }
}

public class Output_ObjField<Ttype>
  : Output_Aliased
  , I_ObjField<Ttype>
{
  public Ttype type { get; set; }
}

public class Output_ObjFieldType
  : Output_ObjBase
  , I_ObjFieldType
{
  public _Modifiers modifiers { get; set; }
  public _ObjFieldEnum As_ObjFieldEnum { get; set; }
}

public class Output_ObjFieldEnum
  : Output_TypeRef
  , I_ObjFieldEnum
{
  public _Identifier label { get; set; }
}

public class Output_ForParam<Ttype>
  : I_ForParam<Ttype>
{
  public _ObjAlternate As_ObjAlternate { get; set; }
  public _ObjField<Ttype> As_ObjField { get; set; }
}

public class Output_TypeDual
  : Output_TypeObject
  , I_TypeDual
{
}

public class Output_DualField
  : Output_ObjField
  , I_DualField
{
}

public class Output_TypeInput
  : Output_TypeObject
  , I_TypeInput
{
}

public class Output_InputField
  : Output_ObjField
  , I_InputField
{
}

public class Output_InputFieldType
  : Output_ObjFieldType
  , I_InputFieldType
{
  public _Value default { get; set; }
}

public class Output_InputParam
  : Output_InputFieldType
  , I_InputParam
{
}

public class Output_TypeOutput
  : Output_TypeObject
  , I_TypeOutput
{
}

public class Output_OutputField
  : Output_ObjField
  , I_OutputField
{
}

public class Output_OutputFieldType
  : Output_ObjFieldType
  , I_OutputFieldType
{
  public _InputParam parameters { get; set; }
}
