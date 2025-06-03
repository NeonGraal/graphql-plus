﻿//HintName: Model_Intro_-Complete.gen.cs
// Generated from Intro_-Complete.graphql+

/*
*/

namespace GqlTest.Model_Intro__Complete;

public interface I_Schema
  : I_Named
{
  _Categories categories { get; }
  _Directives directives { get; }
  _Type types { get; }
  _Setting settings { get; }
}
public class Output_Schema
  : Output_Named
  , I_Schema
{
  public _Categories categories { get; set; }
  public _Directives directives { get; set; }
  public _Type types { get; set; }
  public _Setting settings { get; set; }
}

public interface I_Identifier
{
}
public class Domain_Identifier
  : I_Identifier
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

public interface I_NameFilter
{
}
public class Domain_NameFilter
  : I_NameFilter
{
}

public interface I_CategoryFilter
  : I_Filter
{
  _Resolution resolutions { get; }
}
public class Input_CategoryFilter
  : Input_Filter
  , I_CategoryFilter
{
  public _Resolution resolutions { get; set; }
}

public interface I_TypeFilter
  : I_Filter
{
  _TypeKind kinds { get; }
}
public class Input_TypeFilter
  : Input_Filter
  , I_TypeFilter
{
  public _TypeKind kinds { get; set; }
}

public interface I_Aliased
  : I_Named
{
  _Identifier aliases { get; }
}
public class Dual_Aliased
  : Dual_Named
  , I_Aliased
{
  public _Identifier aliases { get; set; }
}

public interface I_Named
  : I_Described
{
  _Identifier name { get; }
}
public class Dual_Named
  : Dual_Described
  , I_Named
{
  public _Identifier name { get; set; }
}

public interface I_Described
{
  String description { get; }
}
public class Dual_Described
  : I_Described
{
  public String description { get; set; }
}

public interface I_Categories
{
  _Category category { get; }
  _Type type { get; }
  _Category As_Category { get; }
  _Type As_Type { get; }
}
public class Output_Categories
  : I_Categories
{
  public _Category category { get; set; }
  public _Type type { get; set; }
  public _Category As_Category { get; set; }
  public _Type As_Type { get; set; }
}

public interface I_Category
  : I_Aliased
{
  _Resolution resolution { get; }
  _TypeRef<_TypeKind> output { get; }
  _Modifiers modifiers { get; }
}
public class Output_Category
  : Output_Aliased
  , I_Category
{
  public _Resolution resolution { get; set; }
  public _TypeRef<_TypeKind> output { get; set; }
  public _Modifiers modifiers { get; set; }
}

public enum _Resolution
{
  Parallel,
  Sequential,
  Single,
}

public interface I_Directives
{
  _Directive directive { get; }
  _Type type { get; }
  _Directive As_Directive { get; }
  _Type As_Type { get; }
}
public class Output_Directives
  : I_Directives
{
  public _Directive directive { get; set; }
  public _Type type { get; set; }
  public _Directive As_Directive { get; set; }
  public _Type As_Type { get; set; }
}

public interface I_Directive
  : I_Aliased
{
  _InputParam parameters { get; }
  Boolean repeatable { get; }
  Unit locations { get; }
}
public class Output_Directive
  : Output_Aliased
  , I_Directive
{
  public _InputParam parameters { get; set; }
  public Boolean repeatable { get; set; }
  public Unit locations { get; set; }
}

public enum _Location
{
  Operation,
  Variable,
  Field,
  Inline,
  Spread,
  Fragment,
}

public interface I_Setting
  : I_Named
{
  _Constant value { get; }
}
public class Output_Setting
  : Output_Named
  , I_Setting
{
  public _Constant value { get; set; }
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

public interface I_BaseType<Tkind>
  : I_Aliased
{
  Tkind typeKind { get; }
}
public class Output_BaseType<Tkind>
  : Output_Aliased
  , I_BaseType<Tkind>
{
  public Tkind typeKind { get; set; }
}

public interface I_ChildType<Tkind,Tparent>
  : I_BaseType
{
  Tparent parent { get; }
}
public class Output_ChildType<Tkind,Tparent>
  : Output_BaseType
  , I_ChildType<Tkind,Tparent>
{
  public Tparent parent { get; set; }
}

public interface I_ParentType<Tkind,Titem,TallItem>
  : I_ChildType
{
  Titem items { get; }
  TallItem allItems { get; }
}
public class Output_ParentType<Tkind,Titem,TallItem>
  : Output_ChildType
  , I_ParentType<Tkind,Titem,TallItem>
{
  public Titem items { get; set; }
  public TallItem allItems { get; set; }
}

public enum _SimpleKind
{
  Basic,
  Enum,
  Internal,
  Domain,
  Union,
}

public enum _TypeKind
{
  Basic = _SimpleKind.Basic,,
  Enum = _SimpleKind.Enum,,
  Internal = _SimpleKind.Internal,,
  Domain = _SimpleKind.Domain,,
  Union = _SimpleKind.Union,,
  Dual,
  Input,
  Output,
}

public interface I_TypeRef<Tkind>
  : I_Described
{
  Tkind typeKind { get; }
  _Identifier typeName { get; }
}
public class Output_TypeRef<Tkind>
  : Output_Described
  , I_TypeRef<Tkind>
{
  public Tkind typeKind { get; set; }
  public _Identifier typeName { get; set; }
}

public interface I_TypeSimple
{
  _TypeRef<_TypeKind> As_TypeRef { get; }
  _TypeRef<_TypeKind> As_TypeRef { get; }
  _TypeRef<_TypeKind> As_TypeRef { get; }
  _TypeRef<_TypeKind> As_TypeRef { get; }
}
public class Output_TypeSimple
  : I_TypeSimple
{
  public _TypeRef<_TypeKind> As_TypeRef { get; set; }
  public _TypeRef<_TypeKind> As_TypeRef { get; set; }
  public _TypeRef<_TypeKind> As_TypeRef { get; set; }
  public _TypeRef<_TypeKind> As_TypeRef { get; set; }
}

public interface I_Internal
{
  Null AsNull { get; }
  Object AsObject { get; }
  Void AsVoid { get; }
}
public class Output_Internal
  : I_Internal
{
  public Null AsNull { get; set; }
  public Object AsObject { get; set; }
  public Void AsVoid { get; set; }
}

public interface I_Constant
{
  _SimpleValue As_SimpleValue { get; }
  _ConstantList As_ConstantList { get; }
  _ConstantMap As_ConstantMap { get; }
}
public class Output_Constant
  : I_Constant
{
  public _SimpleValue As_SimpleValue { get; set; }
  public _ConstantList As_ConstantList { get; set; }
  public _ConstantMap As_ConstantMap { get; set; }
}

public interface I_SimpleValue
{
  _DomainValue<_DomainKind, Boolean> As_DomainValue { get; }
  _DomainValue<_DomainKind, _EnumValue> As_DomainValue { get; }
  _DomainValue<_DomainKind, Number> As_DomainValue { get; }
  _DomainValue<_DomainKind, String> As_DomainValue { get; }
}
public class Output_SimpleValue
  : I_SimpleValue
{
  public _DomainValue<_DomainKind, Boolean> As_DomainValue { get; set; }
  public _DomainValue<_DomainKind, _EnumValue> As_DomainValue { get; set; }
  public _DomainValue<_DomainKind, Number> As_DomainValue { get; set; }
  public _DomainValue<_DomainKind, String> As_DomainValue { get; set; }
}

public interface I_ConstantList
{
  _Constant As_Constant { get; }
}
public class Output_ConstantList
  : I_ConstantList
{
  public _Constant As_Constant { get; set; }
}

public interface I_ConstantMap
{
  _Constant As_Constant { get; }
}
public class Output_ConstantMap
  : I_ConstantMap
{
  public _Constant As_Constant { get; set; }
}

public interface I_Collections
{
  _Modifier<_ModifierKind> As_Modifier { get; }
  _ModifierKeyed<_ModifierKind> As_ModifierKeyed { get; }
  _ModifierKeyed<_ModifierKind> As_ModifierKeyed { get; }
}
public class Output_Collections
  : I_Collections
{
  public _Modifier<_ModifierKind> As_Modifier { get; set; }
  public _ModifierKeyed<_ModifierKind> As_ModifierKeyed { get; set; }
  public _ModifierKeyed<_ModifierKind> As_ModifierKeyed { get; set; }
}

public interface I_ModifierKeyed<Tkind>
  : I_Modifier
{
  _TypeSimple by { get; }
  Boolean optional { get; }
}
public class Output_ModifierKeyed<Tkind>
  : Output_Modifier
  , I_ModifierKeyed<Tkind>
{
  public _TypeSimple by { get; set; }
  public Boolean optional { get; set; }
}

public interface I_Modifiers
{
  _Modifier<_ModifierKind> As_Modifier { get; }
  _Collections As_Collections { get; }
}
public class Output_Modifiers
  : I_Modifiers
{
  public _Modifier<_ModifierKind> As_Modifier { get; set; }
  public _Collections As_Collections { get; set; }
}

public enum _ModifierKind
{
  Opt,
  Optional = Opt,
  List,
  Dict,
  Dictionary = Dict,
  Param,
  TypeParam = Param,
}

public interface I_Modifier<Tkind>
{
  Tkind modifierKind { get; }
}
public class Output_Modifier<Tkind>
  : I_Modifier<Tkind>
{
  public Tkind modifierKind { get; set; }
}

public enum _DomainKind
{
  Boolean,
  Enum,
  Number,
  String,
}

public interface I_TypeDomain
{
  _BaseDomain<_DomainKind, _DomainTrueFalse, _DomainItemTrueFalse> As_BaseDomain { get; }
  _BaseDomain<_DomainKind, _DomainLabel, _DomainItemLabel> As_BaseDomain { get; }
  _BaseDomain<_DomainKind, _DomainRange, _DomainItemRange> As_BaseDomain { get; }
  _BaseDomain<_DomainKind, _DomainRegex, _DomainItemRegex> As_BaseDomain { get; }
}
public class Output_TypeDomain
  : I_TypeDomain
{
  public _BaseDomain<_DomainKind, _DomainTrueFalse, _DomainItemTrueFalse> As_BaseDomain { get; set; }
  public _BaseDomain<_DomainKind, _DomainLabel, _DomainItemLabel> As_BaseDomain { get; set; }
  public _BaseDomain<_DomainKind, _DomainRange, _DomainItemRange> As_BaseDomain { get; set; }
  public _BaseDomain<_DomainKind, _DomainRegex, _DomainItemRegex> As_BaseDomain { get; set; }
}

public interface I_DomainRef<Tkind>
  : I_TypeRef
{
  Tkind domainKind { get; }
}
public class Output_DomainRef<Tkind>
  : Output_TypeRef
  , I_DomainRef<Tkind>
{
  public Tkind domainKind { get; set; }
}

public interface I_BaseDomain<Tdomain,Titem,TdomainItem>
  : I_ParentType
{
  Tdomain domainKind { get; }
}
public class Output_BaseDomain<Tdomain,Titem,TdomainItem>
  : Output_ParentType
  , I_BaseDomain<Tdomain,Titem,TdomainItem>
{
  public Tdomain domainKind { get; set; }
}

public interface I_BaseDomainItem
  : I_Described
{
  Boolean exclude { get; }
}
public class Dual_BaseDomainItem
  : Dual_Described
  , I_BaseDomainItem
{
  public Boolean exclude { get; set; }
}

public interface I_DomainItem<Titem>
  : Iitem
{
  _Identifier domain { get; }
}
public class Output_DomainItem<Titem>
  : Outputitem
  , I_DomainItem<Titem>
{
  public _Identifier domain { get; set; }
}

public interface I_DomainValue<Tkind,Tvalue>
  : I_DomainRef
{
  Tvalue value { get; }
}
public class Output_DomainValue<Tkind,Tvalue>
  : Output_DomainRef
  , I_DomainValue<Tkind,Tvalue>
{
  public Tvalue value { get; set; }
}

public interface I_BasicValue
{
  Boolean AsBoolean { get; }
  _EnumValue As_EnumValue { get; }
  Number AsNumber { get; }
  String AsString { get; }
}
public class Output_BasicValue
  : I_BasicValue
{
  public Boolean AsBoolean { get; set; }
  public _EnumValue As_EnumValue { get; set; }
  public Number AsNumber { get; set; }
  public String AsString { get; set; }
}

public interface I_DomainTrueFalse
  : I_BaseDomainItem
{
  Boolean value { get; }
}
public class Dual_DomainTrueFalse
  : Dual_BaseDomainItem
  , I_DomainTrueFalse
{
  public Boolean value { get; set; }
}

public interface I_DomainItemTrueFalse
  : I_DomainItem
{
}
public class Output_DomainItemTrueFalse
  : Output_DomainItem
  , I_DomainItemTrueFalse
{
}

public interface I_DomainLabel
  : I_BaseDomainItem
{
  _EnumValue label { get; }
}
public class Output_DomainLabel
  : Output_BaseDomainItem
  , I_DomainLabel
{
  public _EnumValue label { get; set; }
}

public interface I_DomainItemLabel
  : I_DomainItem
{
}
public class Output_DomainItemLabel
  : Output_DomainItem
  , I_DomainItemLabel
{
}

public interface I_DomainRange
  : I_BaseDomainItem
{
  Number lower { get; }
  Number upper { get; }
}
public class Dual_DomainRange
  : Dual_BaseDomainItem
  , I_DomainRange
{
  public Number lower { get; set; }
  public Number upper { get; set; }
}

public interface I_DomainItemRange
  : I_DomainItem
{
}
public class Output_DomainItemRange
  : Output_DomainItem
  , I_DomainItemRange
{
}

public interface I_DomainRegex
  : I_BaseDomainItem
{
  String pattern { get; }
}
public class Dual_DomainRegex
  : Dual_BaseDomainItem
  , I_DomainRegex
{
  public String pattern { get; set; }
}

public interface I_DomainItemRegex
  : I_DomainItem
{
}
public class Output_DomainItemRegex
  : Output_DomainItem
  , I_DomainItemRegex
{
}

public interface I_TypeEnum
  : I_ParentType
{
}
public class Output_TypeEnum
  : Output_ParentType
  , I_TypeEnum
{
}

public interface I_EnumLabel
  : I_Aliased
{
  _Identifier enum { get; }
}
public class Dual_EnumLabel
  : Dual_Aliased
  , I_EnumLabel
{
  public _Identifier enum { get; set; }
}

public interface I_EnumValue
  : I_TypeRef
{
  _Identifier label { get; }
}
public class Output_EnumValue
  : Output_TypeRef
  , I_EnumValue
{
  public _Identifier label { get; set; }
}

public interface I_TypeUnion
  : I_ParentType
{
}
public class Output_TypeUnion
  : Output_ParentType
  , I_TypeUnion
{
}

public interface I_UnionRef
  : I_TypeRef
{
}
public class Output_UnionRef
  : Output_TypeRef
  , I_UnionRef
{
}

public interface I_UnionMember
  : I_UnionRef
{
  _Identifier union { get; }
}
public class Output_UnionMember
  : Output_UnionRef
  , I_UnionMember
{
  public _Identifier union { get; set; }
}

public interface I_ObjectKind
{
}
public class Domain_ObjectKind
  : I_ObjectKind
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
public class Output_TypeObject<Tkind,Tparent,TtypeParam,Tfield,Talternate>
  : Output_ChildType
  , I_TypeObject<Tkind,Tparent,TtypeParam,Tfield,Talternate>
{
  public TtypeParam typeParams { get; set; }
  public Tfield fields { get; set; }
  public Talternate alternates { get; set; }
  public _ObjectFor<Tfield> allFields { get; set; }
  public _ObjectFor<Talternate> allAlternates { get; set; }
}

public interface I_ObjTypeParam<Tkind>
  : I_Named
{
  _ObjConstraint<Tkind> constraint { get; }
}
public class Output_ObjTypeParam<Tkind>
  : Output_Named
  , I_ObjTypeParam<Tkind>
{
  public _ObjConstraint<Tkind> constraint { get; set; }
}

public interface I_ObjConstraint<Tkind>
  : I_TypeRef
{
}
public class Output_ObjConstraint<Tkind>
  : Output_TypeRef
  , I_ObjConstraint<Tkind>
{
}

public interface I_ObjBase<Targ>
  : I_Described
{
  Targ typeArgs { get; }
  _TypeParam As_TypeParam { get; }
}
public class Output_ObjBase<Targ>
  : Output_Described
  , I_ObjBase<Targ>
{
  public Targ typeArgs { get; set; }
  public _TypeParam As_TypeParam { get; set; }
}

public interface I_ObjTypeArg
  : I_TypeRef
{
  _TypeParam As_TypeParam { get; }
}
public class Output_ObjTypeArg
  : Output_TypeRef
  , I_ObjTypeArg
{
  public _TypeParam As_TypeParam { get; set; }
}

public interface I_TypeParam
  : I_Described
{
  _Identifier typeParam { get; }
}
public class Output_TypeParam
  : Output_Described
  , I_TypeParam
{
  public _Identifier typeParam { get; set; }
}

public interface I_Alternate<Tbase>
{
  Tbase type { get; }
  _Collections collections { get; }
}
public class Output_Alternate<Tbase>
  : I_Alternate<Tbase>
{
  public Tbase type { get; set; }
  public _Collections collections { get; set; }
}

public interface I_ObjectFor<Tfor>
  : Ifor
{
  _Identifier object { get; }
}
public class Output_ObjectFor<Tfor>
  : Outputfor
  , I_ObjectFor<Tfor>
{
  public _Identifier object { get; set; }
}

public interface I_Field<Tbase>
  : I_Aliased
{
  Tbase type { get; }
  _Modifiers modifiers { get; }
}
public class Output_Field<Tbase>
  : Output_Aliased
  , I_Field<Tbase>
{
  public Tbase type { get; set; }
  public _Modifiers modifiers { get; set; }
}

public interface I_ForParam<Tbase>
{
  _Alternate<Tbase> As_Alternate { get; }
  _Field<Tbase> As_Field { get; }
}
public class Output_ForParam<Tbase>
  : I_ForParam<Tbase>
{
  public _Alternate<Tbase> As_Alternate { get; set; }
  public _Field<Tbase> As_Field { get; set; }
}

public interface I_TypeDual
  : I_TypeObject
{
}
public class Output_TypeDual
  : Output_TypeObject
  , I_TypeDual
{
}

public interface I_DualBase
  : I_ObjBase
{
  _Identifier dual { get; }
}
public class Output_DualBase
  : Output_ObjBase
  , I_DualBase
{
  public _Identifier dual { get; set; }
}

public interface I_DualTypeParam
  : I_ObjTypeParam
{
}
public class Output_DualTypeParam
  : Output_ObjTypeParam
  , I_DualTypeParam
{
}

public interface I_DualField
  : I_Field
{
}
public class Output_DualField
  : Output_Field
  , I_DualField
{
}

public interface I_DualAlternate
  : I_Alternate
{
}
public class Output_DualAlternate
  : Output_Alternate
  , I_DualAlternate
{
}

public interface I_DualTypeArg
  : I_ObjTypeArg
{
  _Identifier dual { get; }
}
public class Output_DualTypeArg
  : Output_ObjTypeArg
  , I_DualTypeArg
{
  public _Identifier dual { get; set; }
}

public interface I_TypeInput
  : I_TypeObject
{
}
public class Output_TypeInput
  : Output_TypeObject
  , I_TypeInput
{
}

public interface I_InputBase
  : I_ObjBase
{
  _Identifier input { get; }
  _DualBase As_DualBase { get; }
}
public class Output_InputBase
  : Output_ObjBase
  , I_InputBase
{
  public _Identifier input { get; set; }
  public _DualBase As_DualBase { get; set; }
}

public interface I_InputTypeParam
  : I_ObjTypeParam
{
  _TypeRef<_TypeKind> As_TypeRef { get; }
}
public class Output_InputTypeParam
  : Output_ObjTypeParam
  , I_InputTypeParam
{
  public _TypeRef<_TypeKind> As_TypeRef { get; set; }
}

public interface I_InputField
  : I_Field
{
  _Constant default { get; }
}
public class Output_InputField
  : Output_Field
  , I_InputField
{
  public _Constant default { get; set; }
}

public interface I_InputAlternate
  : I_Alternate
{
}
public class Output_InputAlternate
  : Output_Alternate
  , I_InputAlternate
{
}

public interface I_InputTypeArg
  : I_ObjTypeArg
{
  _Identifier input { get; }
}
public class Output_InputTypeArg
  : Output_ObjTypeArg
  , I_InputTypeArg
{
  public _Identifier input { get; set; }
}

public interface I_InputParam
  : I_InputBase
{
  _Modifiers modifiers { get; }
  _Constant default { get; }
}
public class Output_InputParam
  : Output_InputBase
  , I_InputParam
{
  public _Modifiers modifiers { get; set; }
  public _Constant default { get; set; }
}

public interface I_TypeOutput
  : I_TypeObject
{
}
public class Output_TypeOutput
  : Output_TypeObject
  , I_TypeOutput
{
}

public interface I_OutputBase
  : I_ObjBase
{
  _Identifier output { get; }
  _DualBase As_DualBase { get; }
}
public class Output_OutputBase
  : Output_ObjBase
  , I_OutputBase
{
  public _Identifier output { get; set; }
  public _DualBase As_DualBase { get; set; }
}

public interface I_OutputTypeParam
  : I_ObjTypeParam
{
  _TypeRef<_TypeKind> As_TypeRef { get; }
  _TypeRef<_TypeKind> As_TypeRef { get; }
}
public class Output_OutputTypeParam
  : Output_ObjTypeParam
  , I_OutputTypeParam
{
  public _TypeRef<_TypeKind> As_TypeRef { get; set; }
  public _TypeRef<_TypeKind> As_TypeRef { get; set; }
}

public interface I_OutputField
  : I_Field
{
  _InputParam parameters { get; }
  _OutputEnum As_OutputEnum { get; }
}
public class Output_OutputField
  : Output_Field
  , I_OutputField
{
  public _InputParam parameters { get; set; }
  public _OutputEnum As_OutputEnum { get; set; }
}

public interface I_OutputAlternate
  : I_Alternate
{
}
public class Output_OutputAlternate
  : Output_Alternate
  , I_OutputAlternate
{
}

public interface I_OutputTypeArg
  : I_ObjTypeArg
{
  _Identifier output { get; }
  _Identifier label { get; }
}
public class Output_OutputTypeArg
  : Output_ObjTypeArg
  , I_OutputTypeArg
{
  public _Identifier output { get; set; }
  public _Identifier label { get; set; }
}

public interface I_OutputEnum
  : I_TypeRef
{
  _Identifier field { get; }
  _Identifier label { get; }
}
public class Output_OutputEnum
  : Output_TypeRef
  , I_OutputEnum
{
  public _Identifier field { get; set; }
  public _Identifier label { get; set; }
}
