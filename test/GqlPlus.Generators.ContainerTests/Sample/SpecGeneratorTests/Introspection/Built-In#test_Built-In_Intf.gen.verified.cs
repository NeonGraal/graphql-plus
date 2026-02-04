//HintName: test_Built-In_Intf.gen.cs
// Generated from Built-In.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Built_In;

public interface Itest_Collections
{
  public test_Modifier<test_ModifierKind> As_Modifier { get; set; }
  public test_ModifierKeyed<test_ModifierKind> As_ModifierKeyed { get; set; }
  public test_ModifierKeyed<test_ModifierKind> As_ModifierKeyed { get; set; }
  public test_Collections _Collections { get; set; }
}

public interface Itest_CollectionsObject
{
}

public interface Itest_ModifierKeyed<Tkind>
  : Itest_Modifier
{
  public test_ModifierKeyed _ModifierKeyed { get; set; }
}

public interface Itest_ModifierKeyedObject<Tkind>
  : Itest_ModifierObject
{
  public test_TypeSimple by { get; set; }
  public testBoolean optional { get; set; }
}

public interface Itest_Modifiers
{
  public test_Modifier<test_ModifierKind> As_Modifier { get; set; }
  public test_Collections As_Collections { get; set; }
  public test_Modifiers _Modifiers { get; set; }
}

public interface Itest_ModifiersObject
{
}

public interface Itest_Modifier<Tkind>
{
  public test_Modifier _Modifier { get; set; }
}

public interface Itest_ModifierObject<Tkind>
{
  public Tkind modifierKind { get; set; }
}
