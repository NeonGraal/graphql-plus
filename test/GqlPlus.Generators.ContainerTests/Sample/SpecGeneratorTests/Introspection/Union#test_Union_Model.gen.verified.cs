//HintName: test_Union_Model.gen.cs
// Generated from {CurrentDirectory}Union.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Union;

public class test_UnionRef
  : test_TypeRef<Itest_SimpleKind>
  , Itest_UnionRef
{
  public Itest_UnionRefObject? As__UnionRef { get; set; }
}

public class test_UnionRefObject
  : test_TypeRefObject<Itest_SimpleKind>
  , Itest_UnionRefObject
{
}

public class test_UnionMember
  : test_UnionRef
  , Itest_UnionMember
{
  public Itest_UnionMemberObject? As__UnionMember { get; set; }
}

public class test_UnionMemberObject
  : test_UnionRefObject
  , Itest_UnionMemberObject
{
  public Itest_Name Union { get; set; }

  public test_UnionMemberObject
    ( Itest_Name union
    )
  {
    Union = union;
  }
}
