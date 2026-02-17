//HintName: test_Built-In_Impl.gen.cs
// Generated from {CurrentDirectory}Built-In.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Built_In;

public class test_Collections
  : Itest_Collections
{
}

public class test_ModifierKeyed<TKind>
  : test_Modifier<TKind>
  , Itest_ModifierKeyed<TKind>
{
  public Itest_TypeSimple By { get; set; }
  public bool IsOptional { get; set; }
}

public class test_Modifiers
  : Itest_Modifiers
{
}

public class test_Modifier<TKind>
  : Itest_Modifier<TKind>
{
  public TKind ModifierKind { get; set; }
}
