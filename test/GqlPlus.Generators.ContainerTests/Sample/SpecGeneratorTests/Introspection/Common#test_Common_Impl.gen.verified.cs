//HintName: test_Common_Impl.gen.cs
// Generated from Common.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Common;

public class test_Type
  : Itest_Type
{
  public Itest_BaseType<test_TypeKind> As_TypeKindBasic { get; set; }
  public Itest_BaseType<test_TypeKind> As_TypeKindInternal { get; set; }
  public Itest_BaseDomain<Itest_DomainKind, Itest_DomainTrueFalse, Itest_DomainItemTrueFalse> As_DomainKindBoolean { get; set; }
  public Itest_BaseDomain<Itest_DomainKind, Itest_DomainLabel, Itest_DomainItemLabel> As_DomainKindEnum { get; set; }
  public Itest_BaseDomain<Itest_DomainKind, Itest_DomainRange, Itest_DomainItemRange> As_DomainKindNumber { get; set; }
  public Itest_BaseDomain<Itest_DomainKind, Itest_DomainRegex, Itest_DomainItemRegex> As_DomainKindString { get; set; }
  public Itest_ParentType<test_TypeKind, Itest_Aliased, Itest_EnumLabel> As_TypeKindEnum { get; set; }
  public Itest_ParentType<test_TypeKind, Itest_UnionRef, Itest_UnionMember> As_TypeKindUnion { get; set; }
  public Itest_TypeObject<test_TypeKind, Itest_DualField> As_TypeKindDual { get; set; }
  public Itest_TypeObject<test_TypeKind, Itest_InputField> As_TypeKindInput { get; set; }
  public Itest_TypeObject<test_TypeKind, Itest_OutputField> As_TypeKindOutput { get; set; }
  public Itest_TypeObject As_Type { get; set; }
}

public class test_BaseType<TKind>
  : test_Aliased
  , Itest_BaseType<TKind>
{
  public TKind TypeKind { get; set; }
  public Itest_BaseTypeObject<TKind> As_BaseType { get; set; }
}

public class test_ChildType<TKind,TParent>
  : test_BaseType<TKind>
  , Itest_ChildType<TKind,TParent>
{
  public TParent Parent { get; set; }
  public Itest_ChildTypeObject<TKind,TParent> As_ChildType { get; set; }
}

public class test_ParentType<TKind,TItem,TAllItem>
  : test_ChildType<TKind, Itest_Named>
  , Itest_ParentType<TKind,TItem,TAllItem>
{
  public ICollection<TItem> Items { get; set; }
  public ICollection<TAllItem> AllItems { get; set; }
  public Itest_ParentTypeObject<TKind,TItem,TAllItem> As_ParentType { get; set; }
}

public class test_TypeRef<TKind>
  : test_Named
  , Itest_TypeRef<TKind>
{
  public TKind TypeKind { get; set; }
  public Itest_TypeRefObject<TKind> As_TypeRef { get; set; }
}

public class test_TypeSimple
  : Itest_TypeSimple
{
  public Itest_TypeRef<test_TypeKind> As_TypeKindBasic { get; set; }
  public Itest_TypeRef<test_TypeKind> As_TypeKindEnum { get; set; }
  public Itest_TypeRef<test_TypeKind> As_TypeKindDomain { get; set; }
  public Itest_TypeRef<test_TypeKind> As_TypeKindUnion { get; set; }
  public Itest_TypeSimpleObject As_TypeSimple { get; set; }
}
