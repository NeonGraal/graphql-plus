//HintName: test_Common_Impl.gen.cs
// Generated from Common.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_Common;

public class test_Type
  : Itest_Type
{
  public _BaseType<_TypeKind> As_BaseType { get; set; }
  public _BaseType<_TypeKind> As_BaseType { get; set; }
  public _TypeDual As_TypeDual { get; set; }
  public _TypeEnum As_TypeEnum { get; set; }
  public _TypeInput As_TypeInput { get; set; }
  public _TypeOutput As_TypeOutput { get; set; }
  public _TypeDomain As_TypeDomain { get; set; }
  public _TypeUnion As_TypeUnion { get; set; }
}

public class test_BaseType<Tkind>
  : test_Aliased
  , Itest_BaseType<Tkind>
{
  public Tkind typeKind { get; set; }
}

public class test_ChildType<Tkind,Tparent>
  : test_BaseType
  , Itest_ChildType<Tkind,Tparent>
{
  public Tparent parent { get; set; }
}

public class test_ParentType<Tkind,Titem,TallItem>
  : test_ChildType
  , Itest_ParentType<Tkind,Titem,TallItem>
{
  public Titem items { get; set; }
  public TallItem allItems { get; set; }
}

public class test_TypeRef<Tkind>
  : test_Named
  , Itest_TypeRef<Tkind>
{
  public Tkind typeKind { get; set; }
}

public class test_TypeSimple
  : Itest_TypeSimple
{
  public _TypeRef<_TypeKind> As_TypeRef { get; set; }
  public _TypeRef<_TypeKind> As_TypeRef { get; set; }
  public _TypeRef<_TypeKind> As_TypeRef { get; set; }
  public _TypeRef<_TypeKind> As_TypeRef { get; set; }
}
