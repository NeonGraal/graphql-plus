//HintName: Model_Intro_Complete.gen.cs
// Generated from Intro_Complete.graphql+

/*
*/

namespace GqlTest.Model_Intro_Complete;

public interface I_Schema
{
  _Categories categories { get; }
  _Directives directives { get; }
  _Type types { get; }
  _Setting settings { get; }
}
public class Output_Schema
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
{
  _Resolution resolutions { get; }
}
public class Input_CategoryFilter
{
  public _Resolution resolutions { get; set; }
}

public interface I_TypeFilter
{
  _TypeKind kinds { get; }
}
public class Input_TypeFilter
{
  public _TypeKind kinds { get; set; }
}

public interface I_Aliased
{
  _Identifier aliases { get; }
}
public class Dual_Aliased
{
  public _Identifier aliases { get; set; }
}

public interface I_Named
{
  _Identifier name { get; }
}
public class Dual_Named
{
  public _Identifier name { get; set; }
}

public interface I_Described
{
  String description { get; }
}
public class Dual_Described
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
{
  public _Category category { get; set; }
  public _Type type { get; set; }
  public _Category As_Category { get; set; }
  public _Type As_Type { get; set; }
}

public interface I_Category
{
  _Resolution resolution { get; }
  _TypeRef < I@026/0055 _TypeKind.Output > output { get; }
  _Modifiers modifiers { get; }
}
public class Output_Category
{
  public _Resolution resolution { get; set; }
  public _TypeRef < I@026/0055 _TypeKind.Output > output { get; set; }
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
{
  public _Directive directive { get; set; }
  public _Type type { get; set; }
  public _Directive As_Directive { get; set; }
  public _Type As_Type { get; set; }
}

public interface I_Directive
{
  _InputParam parameters { get; }
  Boolean repeatable { get; }
  Unit locations { get; }
}
public class Output_Directive
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
{
  _Constant value { get; }
}
public class Output_Setting
{
  public _Constant value { get; set; }
}

public interface I_Type
{
  _BaseType < I@017/0081 _TypeKind.Basic > As_BaseType { get; }
  _BaseType < I@017/0082 _TypeKind.Internal > As_BaseType { get; }
  _TypeDual As_TypeDual { get; }
  _TypeEnum As_TypeEnum { get; }
  _TypeInput As_TypeInput { get; }
  _TypeOutput As_TypeOutput { get; }
  _TypeDomain As_TypeDomain { get; }
  _TypeUnion As_TypeUnion { get; }
}
public class Output_Type
{
  public _BaseType < I@017/0081 _TypeKind.Basic > As_BaseType { get; set; }
  public _BaseType < I@017/0082 _TypeKind.Internal > As_BaseType { get; set; }
  public _TypeDual As_TypeDual { get; set; }
  public _TypeEnum As_TypeEnum { get; set; }
  public _TypeInput As_TypeInput { get; set; }
  public _TypeOutput As_TypeOutput { get; set; }
  public _TypeDomain As_TypeDomain { get; set; }
  public _TypeUnion As_TypeUnion { get; set; }
}

public interface I_BaseType
{
  $kind typeKind { get; }
}
public class Output_BaseType
{
  public $kind typeKind { get; set; }
}

public interface I_ChildType
{
  $parent parent { get; }
}
public class Output_ChildType
{
  public $parent parent { get; set; }
}

public interface I_ParentType
{
  $item items { get; }
  $allItem allItems { get; }
}
public class Output_ParentType
{
  public $item items { get; set; }
  public $allItem allItems { get; set; }
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

public interface I_TypeRef
{
  $kind typeKind { get; }
  _Identifier name { get; }
}
public class Output_TypeRef
{
  public $kind typeKind { get; set; }
  public _Identifier name { get; set; }
}

public interface I_TypeSimple
{
  _TypeRef < I@016/0118 _TypeKind.Basic > As_TypeRef { get; }
  _TypeRef < I@016/0119 _TypeKind.Enum > As_TypeRef { get; }
  _TypeRef < I@016/0120 _TypeKind.Domain > As_TypeRef { get; }
  _TypeRef < I@016/0121 _TypeKind.Union > As_TypeRef { get; }
}
public class Output_TypeSimple
{
  public _TypeRef < I@016/0118 _TypeKind.Basic > As_TypeRef { get; set; }
  public _TypeRef < I@016/0119 _TypeKind.Enum > As_TypeRef { get; set; }
  public _TypeRef < I@016/0120 _TypeKind.Domain > As_TypeRef { get; set; }
  public _TypeRef < I@016/0121 _TypeKind.Union > As_TypeRef { get; set; }
}

public interface I_Constant
{
  _Simple As_Simple { get; }
  _ConstantList As_ConstantList { get; }
  _ConstantMap As_ConstantMap { get; }
}
public class Output_Constant
{
  public _Simple As_Simple { get; set; }
  public _ConstantList As_ConstantList { get; set; }
  public _ConstantMap As_ConstantMap { get; set; }
}

public interface I_Simple
{
  Boolean AsBoolean { get; }
  _DomainValue < I@020/0131 _DomainKind.Number I@039/0131 Number > As_DomainValue { get; }
  _DomainValue < I@020/0132 _DomainKind.String I@039/0132 String > As_DomainValue { get; }
  _EnumValue As_EnumValue { get; }
}
public class Output_Simple
{
  public Boolean AsBoolean { get; set; }
  public _DomainValue < I@020/0131 _DomainKind.Number I@039/0131 Number > As_DomainValue { get; set; }
  public _DomainValue < I@020/0132 _DomainKind.String I@039/0132 String > As_DomainValue { get; set; }
  public _EnumValue As_EnumValue { get; set; }
}

public interface I_ConstantList
{
  _Constant As_Constant { get; }
}
public class Output_ConstantList
{
  public _Constant As_Constant { get; set; }
}

public interface I_ConstantMap
{
  _Constant As_Constant { get; }
}
public class Output_ConstantMap
{
  public _Constant As_Constant { get; set; }
}

public interface I_Collections
{
  _Modifier < I@017/0145 _ModifierKind.List > As_Modifier { get; }
  _ModifierKeyed < I@022/0146 _ModifierKind.Dictionary > As_ModifierKeyed { get; }
  _ModifierKeyed < I@022/0147 _ModifierKind.TypeParam > As_ModifierKeyed { get; }
}
public class Output_Collections
{
  public _Modifier < I@017/0145 _ModifierKind.List > As_Modifier { get; set; }
  public _ModifierKeyed < I@022/0146 _ModifierKind.Dictionary > As_ModifierKeyed { get; set; }
  public _ModifierKeyed < I@022/0147 _ModifierKind.TypeParam > As_ModifierKeyed { get; set; }
}

public interface I_ModifierKeyed
{
  _TypeSimple by { get; }
  Boolean optional { get; }
}
public class Output_ModifierKeyed
{
  public _TypeSimple by { get; set; }
  public Boolean optional { get; set; }
}

public interface I_Modifiers
{
  _Modifier < I@017/0157 _ModifierKind.Optional > As_Modifier { get; }
  _Collections As_Collections { get; }
}
public class Output_Modifiers
{
  public _Modifier < I@017/0157 _ModifierKind.Optional > As_Modifier { get; set; }
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

public interface I_Modifier
{
  $kind modifierKind { get; }
}
public class Output_Modifier
{
  public $kind modifierKind { get; set; }
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
  _BaseDomain < I@019/0169 _DomainKind.Boolean I@039/0169 _DomainTrueFalse I@056/0169 _DomainItemTrueFalse > As_BaseDomain { get; }
  _BaseDomain < I@019/0170 _DomainKind.Enum I@036/0170 _DomainLabel I@049/0170 _DomainItemLabel > As_BaseDomain { get; }
  _BaseDomain < I@019/0171 _DomainKind.Number I@038/0171 _DomainRange I@051/0171 _DomainItemRange > As_BaseDomain { get; }
  _BaseDomain < I@019/0172 _DomainKind.String I@038/0172 _DomainRegex I@051/0172 _DomainItemRegex > As_BaseDomain { get; }
}
public class Output_TypeDomain
{
  public _BaseDomain < I@019/0169 _DomainKind.Boolean I@039/0169 _DomainTrueFalse I@056/0169 _DomainItemTrueFalse > As_BaseDomain { get; set; }
  public _BaseDomain < I@019/0170 _DomainKind.Enum I@036/0170 _DomainLabel I@049/0170 _DomainItemLabel > As_BaseDomain { get; set; }
  public _BaseDomain < I@019/0171 _DomainKind.Number I@038/0171 _DomainRange I@051/0171 _DomainItemRange > As_BaseDomain { get; set; }
  public _BaseDomain < I@019/0172 _DomainKind.String I@038/0172 _DomainRegex I@051/0172 _DomainItemRegex > As_BaseDomain { get; set; }
}

public interface I_DomainRef
{
  $kind domainKind { get; }
}
public class Output_DomainRef
{
  public $kind domainKind { get; set; }
}

public interface I_BaseDomain
{
  $domain domainKind { get; }
}
public class Output_BaseDomain
{
  public $domain domainKind { get; set; }
}

public interface I_BaseDomainItem
{
  Boolean exclude { get; }
}
public class Dual_BaseDomainItem
{
  public Boolean exclude { get; set; }
}

public interface I_DomainItem
{
  _Identifier domain { get; }
}
public class Output_DomainItem
{
  public _Identifier domain { get; set; }
}

public interface I_DomainValue
{
  $value value { get; }
}
public class Output_DomainValue
{
  public $value value { get; set; }
}

public interface I_DomainTrueFalse
{
  Boolean value { get; }
}
public class Dual_DomainTrueFalse
{
  public Boolean value { get; set; }
}

public interface I_DomainItemTrueFalse
{
}
public class Output_DomainItemTrueFalse
{
}

public interface I_DomainLabel
{
  _EnumValue label { get; }
}
public class Output_DomainLabel
{
  public _EnumValue label { get; set; }
}

public interface I_DomainItemLabel
{
}
public class Output_DomainItemLabel
{
}

public interface I_DomainRange
{
  Number lower { get; }
  Number upper { get; }
}
public class Dual_DomainRange
{
  public Number lower { get; set; }
  public Number upper { get; set; }
}

public interface I_DomainItemRange
{
}
public class Output_DomainItemRange
{
}

public interface I_DomainRegex
{
  String pattern { get; }
}
public class Dual_DomainRegex
{
  public String pattern { get; set; }
}

public interface I_DomainItemRegex
{
}
public class Output_DomainItemRegex
{
}

public interface I_TypeEnum
{
}
public class Output_TypeEnum
{
}

public interface I_EnumLabel
{
  _Identifier enum { get; }
}
public class Dual_EnumLabel
{
  public _Identifier enum { get; set; }
}

public interface I_EnumValue
{
  _Identifier label { get; }
}
public class Output_EnumValue
{
  public _Identifier label { get; set; }
}

public interface I_TypeUnion
{
}
public class Output_TypeUnion
{
}

public interface I_UnionRef
{
}
public class Output_UnionRef
{
}

public interface I_UnionMember
{
  _Identifier union { get; }
}
public class Output_UnionMember
{
  public _Identifier union { get; set; }
}

public interface I_TypeObject
{
  _ObjTypeParam typeParams { get; }
  $field fields { get; }
  $alternate alternates { get; }
  _ObjectFor < I@032/0262 $field > allFields { get; }
  _ObjectFor < I@036/0263 $alternate > allAlternates { get; }
}
public class Output_TypeObject
{
  public _ObjTypeParam typeParams { get; set; }
  public $field fields { get; set; }
  public $alternate alternates { get; set; }
  public _ObjectFor < I@032/0262 $field > allFields { get; set; }
  public _ObjectFor < I@036/0263 $alternate > allAlternates { get; set; }
}

public interface I_ObjConstraint
{
  _TypeSimple As_TypeSimple { get; }
  $base Asbase { get; }
}
public class Output_ObjConstraint
{
  public _TypeSimple As_TypeSimple { get; set; }
  public $base Asbase { get; set; }
}

public interface I_ObjType
{
  _BaseType < I@017/0271 _TypeKind.Internal > As_BaseType { get; }
  _ObjConstraint < I@023/0272 $base > As_ObjConstraint { get; }
}
public class Output_ObjType
{
  public _BaseType < I@017/0271 _TypeKind.Internal > As_BaseType { get; set; }
  public _ObjConstraint < I@023/0272 $base > As_ObjConstraint { get; set; }
}

public interface I_ObjBase
{
  $arg typeArgs { get; }
  _ObjTypeParam As_ObjTypeParam { get; }
}
public class Output_ObjBase
{
  public $arg typeArgs { get; set; }
  public _ObjTypeParam As_ObjTypeParam { get; set; }
}

public interface I_ObjTypeArg
{
  _ObjTypeParam As_ObjTypeParam { get; }
}
public class Output_ObjTypeArg
{
  public _ObjTypeParam As_ObjTypeParam { get; set; }
}

public interface I_TypeParam
  : I_TypeParam
{
}
public class Domain_TypeParam
  : Domain_Identifier
  , I_TypeParam
{
}

public interface I_ObjTypeParam
{
  _TypeParam typeParam { get; }
}
public class Output_ObjTypeParam
{
  public _TypeParam typeParam { get; set; }
}

public interface I_Alternate
{
  _Collections collections { get; }
}
public class Output_Alternate
{
  public _Collections collections { get; set; }
}

public interface I_ObjectFor
{
  _Identifier object { get; }
}
public class Output_ObjectFor
{
  public _Identifier object { get; set; }
}

public interface I_Field
{
  $base type { get; }
  _Modifiers modifiers { get; }
}
public class Output_Field
{
  public $base type { get; set; }
  public _Modifiers modifiers { get; set; }
}

public interface I_TypeDual
{
}
public class Output_TypeDual
{
}

public interface I_DualBase
{
  _Identifier dual { get; }
}
public class Output_DualBase
{
  public _Identifier dual { get; set; }
}

public interface I_DualField
{
}
public class Output_DualField
{
}

public interface I_DualAlternate
{
  _Identifier dual { get; }
}
public class Output_DualAlternate
{
  public _Identifier dual { get; set; }
}

public interface I_DualTypeArg
{
  _Identifier dual { get; }
}
public class Output_DualTypeArg
{
  public _Identifier dual { get; set; }
}

public interface I_TypeInput
{
}
public class Output_TypeInput
{
}

public interface I_InputBase
{
  _Identifier input { get; }
  _DualBase As_DualBase { get; }
}
public class Output_InputBase
{
  public _Identifier input { get; set; }
  public _DualBase As_DualBase { get; set; }
}

public interface I_InputField
{
  _Constant default { get; }
}
public class Output_InputField
{
  public _Constant default { get; set; }
}

public interface I_InputAlternate
{
  _Identifier input { get; }
}
public class Output_InputAlternate
{
  public _Identifier input { get; set; }
}

public interface I_InputTypeArg
{
  _Identifier input { get; }
}
public class Output_InputTypeArg
{
  public _Identifier input { get; set; }
}

public interface I_InputParam
{
  _Modifiers modifiers { get; }
  _Constant default { get; }
}
public class Output_InputParam
{
  public _Modifiers modifiers { get; set; }
  public _Constant default { get; set; }
}

public interface I_TypeOutput
{
}
public class Output_TypeOutput
{
}

public interface I_OutputBase
{
  _Identifier output { get; }
  _DualBase As_DualBase { get; }
}
public class Output_OutputBase
{
  public _Identifier output { get; set; }
  public _DualBase As_DualBase { get; set; }
}

public interface I_OutputField
{
  _InputParam parameters { get; }
  _OutputEnum As_OutputEnum { get; }
}
public class Output_OutputField
{
  public _InputParam parameters { get; set; }
  public _OutputEnum As_OutputEnum { get; set; }
}

public interface I_OutputAlternate
{
  _Identifier output { get; }
}
public class Output_OutputAlternate
{
  public _Identifier output { get; set; }
}

public interface I_OutputTypeArg
{
  _Identifier output { get; }
  _Identifier label { get; }
}
public class Output_OutputTypeArg
{
  public _Identifier output { get; set; }
  public _Identifier label { get; set; }
}

public interface I_OutputEnum
{
  _Identifier field { get; }
  _Identifier label { get; }
}
public class Output_OutputEnum
{
  public _Identifier field { get; set; }
  public _Identifier label { get; set; }
}
