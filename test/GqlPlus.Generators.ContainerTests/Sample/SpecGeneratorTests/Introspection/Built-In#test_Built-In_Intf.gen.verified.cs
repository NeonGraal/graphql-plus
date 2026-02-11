//HintName: test_Built-In_Intf.gen.cs
// Generated from Built-In.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Built_In;

public interface Itest_Collections
{
  Itest_Modifier<test_ModifierKind> As_Modifier { get; }
  Itest_ModifierKeyed<test_ModifierKind> As_ModifierKeyed { get; }
  Itest_ModifierKeyed<test_ModifierKind> As_ModifierKeyed { get; }
  Itest_CollectionsObject As_Collections { get; }
}

public interface Itest_CollectionsObject
{
}

public interface Itest_ModifierKeyed<TKind>
  : Itest_Modifier<TKind>
{
  Itest_ModifierKeyedObject As_ModifierKeyed { get; }
}

public interface Itest_ModifierKeyedObject<TKind>
  : Itest_ModifierObject<TKind>
{
  Itest_TypeSimple By { get; }
  bool Optional { get; }
}

public interface Itest_Modifiers
{
  Itest_Modifier<test_ModifierKind> As_Modifier { get; }
  Itest_Collections As_Collections { get; }
  Itest_ModifiersObject As_Modifiers { get; }
}

public interface Itest_ModifiersObject
{
}

public interface Itest_Modifier<TKind>
{
  Itest_ModifierObject As_Modifier { get; }
}

public interface Itest_ModifierObject<TKind>
{
  TKind ModifierKind { get; }
}
