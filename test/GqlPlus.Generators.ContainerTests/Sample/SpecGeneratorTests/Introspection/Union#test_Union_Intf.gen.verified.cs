//HintName: test_Union_Intf.gen.cs
// Generated from Union.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Union;

public interface Itest_UnionRef
  : Itest_TypeRef<Itest_SimpleKind>
{
  Itest_UnionRefObject As_UnionRef { get; }
}

public interface Itest_UnionRefObject
  : Itest_TypeRefObject<Itest_SimpleKind>
{
}

public interface Itest_UnionMember
  : Itest_UnionRef
{
  Itest_UnionMemberObject As_UnionMember { get; }
}

public interface Itest_UnionMemberObject
  : Itest_UnionRefObject
{
  Itest_Name Union { get; }
}
