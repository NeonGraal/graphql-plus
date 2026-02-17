//HintName: test_Union_Impl.gen.cs
// Generated from {CurrentDirectory}Union.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Union;

public class test_UnionRef
  : test_TypeRef<Itest_SimpleKind>
  , Itest_UnionRef
{
}

public class test_UnionMember
  : test_UnionRef
  , Itest_UnionMember
{
  public Itest_Name Union { get; set; }
}
