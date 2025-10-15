//HintName: test_Common_Intf.gen.cs
// Generated from Common.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_Common;

public interface Itest_Type
{
  _BaseType<_TypeKind> As_BaseType { get; }
  _BaseType<_TypeKind> As_BaseType { get; }
  _TypeDual As_TypeDual { get; }
  _TypeEnum As_TypeEnum { get; }
  _TypeInput As_TypeInput { get; }
  _TypeOutput As_TypeOutput { get; }
  _TypeDomain As_TypeDomain { get; }
  _TypeUnion As_TypeUnion { get; }
}

public interface Itest_BaseType<Tkind>
  : Itest_Aliased
{
  Tkind typeKind { get; }
}

public interface Itest_ChildType<Tkind,Tparent>
  : Itest_BaseType
{
  Tparent parent { get; }
}

public interface Itest_ParentType<Tkind,Titem,TallItem>
  : Itest_ChildType
{
  Titem items { get; }
  TallItem allItems { get; }
}

public interface Itest_TypeRef<Tkind>
  : Itest_Named
{
  Tkind typeKind { get; }
}

public interface Itest_TypeSimple
{
  _TypeRef<_TypeKind> As_TypeRef { get; }
  _TypeRef<_TypeKind> As_TypeRef { get; }
  _TypeRef<_TypeKind> As_TypeRef { get; }
  _TypeRef<_TypeKind> As_TypeRef { get; }
}
