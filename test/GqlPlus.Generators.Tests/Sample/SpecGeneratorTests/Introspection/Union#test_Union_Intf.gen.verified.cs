//HintName: test_Union_Intf.gen.cs
// Generated from Union.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Union;

public interface Itest_UnionRef
  : Itest_TypeRef
{
  public test_UnionRef _UnionRef { get; set; }
}

public interface Itest_UnionRefObject
  : Itest_TypeRefObject
{
}

public interface Itest_UnionMember
  : Itest_UnionRef
{
  public test_UnionMember _UnionMember { get; set; }
}

public interface Itest_UnionMemberObject
  : Itest_UnionRefObject
{
  public test_Name union { get; set; }
}
