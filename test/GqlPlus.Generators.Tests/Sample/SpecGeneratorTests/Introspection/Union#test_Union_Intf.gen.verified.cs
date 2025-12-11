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

public interface Itest_UnionRefField
  : Itest_TypeRefField
{
}

public interface Itest_UnionMember
  : Itest_UnionRef
{
  public test_UnionMember _UnionMember { get; set; }
}

public interface Itest_UnionMemberField
  : Itest_UnionRefField
{
  public test_Identifier union { get; set; }
}
