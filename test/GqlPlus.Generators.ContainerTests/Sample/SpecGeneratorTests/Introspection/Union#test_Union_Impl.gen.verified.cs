//HintName: test_Union_Impl.gen.cs
// Generated from Union.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Union;

public class test_UnionRef
  : test_TypeRef<Itest_SimpleKind>
  , Itest_UnionRef
{
  public Itest_UnionRefObject As_UnionRef { get; set; }
}

public class test_UnionMember
  : test_UnionRef
  , Itest_UnionMember
{
  public Itest_Name Union { get; set; }
  public Itest_UnionMemberObject As_UnionMember { get; set; }
}
