//HintName: Gqlp_Intro_+Type_Intf.gen.cs
// Generated from Intro_+Type.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_Intro__Type;

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

public interface I_Constant
{
  _SimpleValue As_SimpleValue { get; }
  _ConstantList As_ConstantList { get; }
  _ConstantMap As_ConstantMap { get; }
}

public interface I_SimpleValue
{
  _DomainValue<_DomainKind, Boolean> As_DomainValue { get; }
  _DomainValue<_DomainKind, _EnumValue> As_DomainValue { get; }
  _DomainValue<_DomainKind, Number> As_DomainValue { get; }
  _DomainValue<_DomainKind, String> As_DomainValue { get; }
}

public interface I_ConstantList
{
  _Constant As_Constant { get; }
}

public interface I_ConstantMap
{
  _Constant As_Constant { get; }
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
