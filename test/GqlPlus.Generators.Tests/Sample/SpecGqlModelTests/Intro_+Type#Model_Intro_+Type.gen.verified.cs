//HintName: Model_Intro_+Type.gen.cs
// Generated from Intro_+Type.graphql+

/*
*/

namespace GqlTest.Model_Intro__Type;

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

public interface I_Constant
{
  _Simple As_Simple { get; }
  _ConstantList As_ConstantList { get; }
  _ConstantMap As_ConstantMap { get; }
}
public class Output_Constant
  : I_Constant
{
  public _Simple As_Simple { get; set; }
  public _ConstantList As_ConstantList { get; set; }
  public _ConstantMap As_ConstantMap { get; set; }
}

public interface I_Simple
{
  Boolean AsBoolean { get; }
  _DomainValue<_DomainKind, Number> As_DomainValue { get; }
  _DomainValue<_DomainKind, String> As_DomainValue { get; }
  _EnumValue As_EnumValue { get; }
}
public class Output_Simple
  : I_Simple
{
  public Boolean AsBoolean { get; set; }
  public _DomainValue<_DomainKind, Number> As_DomainValue { get; set; }
  public _DomainValue<_DomainKind, String> As_DomainValue { get; set; }
  public _EnumValue As_EnumValue { get; set; }
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
