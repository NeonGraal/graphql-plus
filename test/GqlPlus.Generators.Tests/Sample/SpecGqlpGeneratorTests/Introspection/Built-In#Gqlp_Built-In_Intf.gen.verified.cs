//HintName: Gqlp_Built-In_Intf.gen.cs
// Generated from Built-In.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_Built_In;

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
