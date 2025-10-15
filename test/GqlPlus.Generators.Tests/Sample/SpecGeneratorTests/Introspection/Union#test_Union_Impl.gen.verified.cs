//HintName: test_Union_Impl.gen.cs
// Generated from Union.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_Union;

public class Outputtest_TypeUnion
  : Outputtest_ParentType
  , Itest_TypeUnion
{
}

public class Outputtest_UnionRef
  : Outputtest_TypeRef
  , Itest_UnionRef
{
}

public class Outputtest_UnionMember
  : Outputtest_UnionRef
  , Itest_UnionMember
{
  public _Identifier union { get; set; }
}
