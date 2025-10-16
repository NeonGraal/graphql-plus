//HintName: test_Union_Impl.gen.cs
// Generated from Union.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_Union;

public class test_TypeUnion
  : test_ParentType
  , Itest_TypeUnion
{
}

public class test_UnionRef
  : test_TypeRef
  , Itest_UnionRef
{
}

public class test_UnionMember
  : test_UnionRef
  , Itest_UnionMember
{
  public _Identifier union { get; set; }
}
