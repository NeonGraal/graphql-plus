//HintName: test_Union_Impl.gen.cs
// Generated from Union.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Union;

public class test_UnionRef
  : test_TypeRef
  , Itest_UnionRef
{
  public test_UnionRef _UnionRef { get; set; }
}

public class test_UnionMember
  : test_UnionRef
  , Itest_UnionMember
{
  public test_Identifier union { get; set; }
  public test_UnionMember _UnionMember { get; set; }
}
