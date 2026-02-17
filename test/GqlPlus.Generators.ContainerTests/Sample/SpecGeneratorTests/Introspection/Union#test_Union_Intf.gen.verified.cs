//HintName: test_Union_Intf.gen.cs
// Generated from {CurrentDirectory}Union.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Union;

public interface Itest_UnionRef
  : Itest_TypeRef<Itest_SimpleKind>
{
  Itest_UnionRefObject? As__UnionRef { get; }
}

public interface Itest_UnionRefObject
  : Itest_TypeRefObject<Itest_SimpleKind>
{
}

public interface Itest_UnionMember
  : Itest_UnionRef
{
  Itest_UnionMemberObject? As__UnionMember { get; }
}

public interface Itest_UnionMemberObject
  : Itest_UnionRefObject
{
  Itest_Name Union { get; }
}
