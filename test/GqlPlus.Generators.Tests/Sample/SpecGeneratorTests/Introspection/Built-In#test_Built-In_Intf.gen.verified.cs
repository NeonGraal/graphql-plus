//HintName: test_Built-In_Intf.gen.cs
// Generated from Built-In.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_Built_In;

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
