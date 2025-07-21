//HintName: Gqlp_Intro_Built-In_Intf.gen.cs
// Generated from Intro_Built-In.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_Intro_Built_In;

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
