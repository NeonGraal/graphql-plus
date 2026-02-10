//HintName: test_Built-In_Impl.gen.cs
// Generated from Built-In.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Built_In;

public class test_Collections
  : Itest_Collections
{
  public Itest_Modifier<Itest_ModifierKind> As_Modifier { get; set; }
  public Itest_ModifierKeyed<Itest_ModifierKind> As_ModifierKeyed { get; set; }
  public Itest_ModifierKeyed<Itest_ModifierKind> As_ModifierKeyed { get; set; }
  public Itest_CollectionsObject As_Collections { get; set; }
}

public class test_ModifierKeyed<Tkind>
  : test_Modifier
  , Itest_ModifierKeyed<Tkind>
{
  public Itest_TypeSimple By { get; set; }
  public bool Optional { get; set; }
  public Itest_ModifierKeyedObject As_ModifierKeyed { get; set; }
}

public class test_Modifiers
  : Itest_Modifiers
{
  public Itest_Modifier<Itest_ModifierKind> As_Modifier { get; set; }
  public Itest_Collections As_Collections { get; set; }
  public Itest_ModifiersObject As_Modifiers { get; set; }
}

public class test_Modifier<Tkind>
  : Itest_Modifier<Tkind>
{
  public Tkind ModifierKind { get; set; }
  public Itest_ModifierObject As_Modifier { get; set; }
}
