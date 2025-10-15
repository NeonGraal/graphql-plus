//HintName: test_Union_Intf.gen.cs
// Generated from Union.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_Union;

public interface Itest_TypeUnion
  : Itest_ParentType
{
}

public interface Itest_UnionRef
  : Itest_TypeRef
{
}

public interface Itest_UnionMember
  : Itest_UnionRef
{
  _Identifier union { get; }
}
