//HintName: test_Built-In_Impl.gen.cs
// Generated from Built-In.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Built_In;

public class test_Collections
  : Itest_Collections
{
  public Itest_Modifier<test_ModifierKind> As_ModifierKindList { get; set; }
  public Itest_ModifierKeyed<test_ModifierKind> As_ModifierKindDictionary { get; set; }
  public Itest_ModifierKeyed<test_ModifierKind> As_ModifierKindTypeParam { get; set; }
  public Itest_CollectionsObject As_Collections { get; set; }
}

public class test_ModifierKeyed<TKind>
  : test_Modifier<TKind>
  , Itest_ModifierKeyed<TKind>
{
  public Itest_TypeSimple By { get; set; }
  public bool Optional { get; set; }
  public Itest_ModifierKeyedObject As_ModifierKeyed { get; set; }
}

public class test_Modifiers
  : Itest_Modifiers
{
  public Itest_Modifier<test_ModifierKind> As_ModifierKindOptional { get; set; }
  public Itest_Collections As_Collections { get; set; }
  public Itest_ModifiersObject As_Modifiers { get; set; }
}

public class test_Modifier<TKind>
  : Itest_Modifier<TKind>
{
  public TKind ModifierKind { get; set; }
  public Itest_ModifierObject As_Modifier { get; set; }
}
