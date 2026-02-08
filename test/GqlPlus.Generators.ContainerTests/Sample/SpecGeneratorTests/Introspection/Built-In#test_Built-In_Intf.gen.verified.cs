//HintName: test_Built-In_Intf.gen.cs
// Generated from Built-In.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Built_In;

public interface Itest_Collections
{
  public Itest_Modifier<Itest_ModifierKind> As_Modifier { get; set; }
  public Itest_ModifierKeyed<Itest_ModifierKind> As_ModifierKeyed { get; set; }
  public Itest_ModifierKeyed<Itest_ModifierKind> As_ModifierKeyed { get; set; }
  public Itest_CollectionsObject As_Collections { get; set; }
}

public interface Itest_CollectionsObject
{
}

public interface Itest_ModifierKeyed<Tkind>
  : Itest_Modifier
{
  public Itest_ModifierKeyedObject As_ModifierKeyed { get; set; }
}

public interface Itest_ModifierKeyedObject<Tkind>
  : Itest_ModifierObject
{
  public Itest_TypeSimple By { get; set; }
  public ItestBoolean Optional { get; set; }
}

public interface Itest_Modifiers
{
  public Itest_Modifier<Itest_ModifierKind> As_Modifier { get; set; }
  public Itest_Collections As_Collections { get; set; }
  public Itest_ModifiersObject As_Modifiers { get; set; }
}

public interface Itest_ModifiersObject
{
}

public interface Itest_Modifier<Tkind>
{
  public Itest_ModifierObject As_Modifier { get; set; }
}

public interface Itest_ModifierObject<Tkind>
{
  public Tkind ModifierKind { get; set; }
}
