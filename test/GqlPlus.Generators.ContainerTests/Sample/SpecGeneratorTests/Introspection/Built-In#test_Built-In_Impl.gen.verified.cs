//HintName: test_Built-In_Impl.gen.cs
// Generated from Built-In.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Built_In;

public class test_Collections
  : Itest_Collections
{
  public test_Modifier<test_ModifierKind> As_Modifier { get; set; }
  public test_ModifierKeyed<test_ModifierKind> As_ModifierKeyed { get; set; }
  public test_ModifierKeyed<test_ModifierKind> As_ModifierKeyed { get; set; }
  public test_Collections _Collections { get; set; }
}

public class test_ModifierKeyed<Tkind>
  : test_Modifier
  , Itest_ModifierKeyed<Tkind>
{
  public test_TypeSimple by { get; set; }
  public testBoolean optional { get; set; }
  public test_ModifierKeyed _ModifierKeyed { get; set; }
}

public class test_Modifiers
  : Itest_Modifiers
{
  public test_Modifier<test_ModifierKind> As_Modifier { get; set; }
  public test_Collections As_Collections { get; set; }
  public test_Modifiers _Modifiers { get; set; }
}

public class test_Modifier<Tkind>
  : Itest_Modifier<Tkind>
{
  public Tkind modifierKind { get; set; }
  public test_Modifier _Modifier { get; set; }
}
