//HintName: test_Common_Impl.gen.cs
// Generated from Common.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Common;

public class test_Type
  : Itest_Type
{
  public Itest_BaseType<test_TypeKind> As_BaseType { get; set; }
  public Itest_BaseType<test_TypeKind> As_BaseType { get; set; }
  public Itest_BaseDomain<Itest_DomainKind, Itest_DomainTrueFalse, Itest_DomainItemTrueFalse> As_BaseDomain { get; set; }
  public Itest_BaseDomain<Itest_DomainKind, Itest_DomainLabel, Itest_DomainItemLabel> As_BaseDomain { get; set; }
  public Itest_BaseDomain<Itest_DomainKind, Itest_DomainRange, Itest_DomainItemRange> As_BaseDomain { get; set; }
  public Itest_BaseDomain<Itest_DomainKind, Itest_DomainRegex, Itest_DomainItemRegex> As_BaseDomain { get; set; }
  public Itest_ParentType<test_TypeKind, Itest_Aliased, Itest_EnumLabel> As_ParentType { get; set; }
  public Itest_ParentType<test_TypeKind, Itest_UnionRef, Itest_UnionMember> As_ParentType { get; set; }
  public Itest_TypeObject<test_TypeKind, Itest_DualField> As_TypeObject { get; set; }
  public Itest_TypeObject<test_TypeKind, Itest_InputField> As_TypeObject { get; set; }
  public Itest_TypeObject<test_TypeKind, Itest_OutputField> As_TypeObject { get; set; }
  public Itest_TypeObject As_Type { get; set; }
}

public class test_BaseType<Tkind>
  : test_Aliased
  , Itest_BaseType<Tkind>
{
  public Tkind TypeKind { get; set; }
  public Itest_BaseTypeObject As_BaseType { get; set; }
}

public class test_ChildType<Tkind,Tparent>
  : test_BaseType
  , Itest_ChildType<Tkind,Tparent>
{
  public Tparent Parent { get; set; }
  public Itest_ChildTypeObject As_ChildType { get; set; }
}

public class test_ParentType<Tkind,Titem,TallItem>
  : test_ChildType
  , Itest_ParentType<Tkind,Titem,TallItem>
{
  public ICollection<Titem> Items { get; set; }
  public ICollection<TallItem> AllItems { get; set; }
  public Itest_ParentTypeObject As_ParentType { get; set; }
}

public class test_TypeRef<Tkind>
  : test_Named
  , Itest_TypeRef<Tkind>
{
  public Tkind TypeKind { get; set; }
  public Itest_TypeRefObject As_TypeRef { get; set; }
}

public class test_TypeSimple
  : Itest_TypeSimple
{
  public Itest_TypeRef<test_TypeKind> As_TypeRef { get; set; }
  public Itest_TypeRef<test_TypeKind> As_TypeRef { get; set; }
  public Itest_TypeRef<test_TypeKind> As_TypeRef { get; set; }
  public Itest_TypeRef<test_TypeKind> As_TypeRef { get; set; }
  public Itest_TypeSimpleObject As_TypeSimple { get; set; }
}
