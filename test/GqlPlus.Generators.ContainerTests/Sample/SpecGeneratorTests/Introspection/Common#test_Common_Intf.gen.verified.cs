//HintName: test_Common_Intf.gen.cs
// Generated from Common.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Common;

public interface Itest_Type
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

public interface Itest_TypeObject
{
}

public interface Itest_BaseType<Tkind>
  : Itest_Aliased
{
  public Itest_BaseTypeObject As_BaseType { get; set; }
}

public interface Itest_BaseTypeObject<Tkind>
  : Itest_AliasedObject
{
  public Tkind TypeKind { get; set; }
}

public interface Itest_ChildType<Tkind,Tparent>
  : Itest_BaseType
{
  public Itest_ChildTypeObject As_ChildType { get; set; }
}

public interface Itest_ChildTypeObject<Tkind,Tparent>
  : Itest_BaseTypeObject
{
  public Tparent Parent { get; set; }
}

public interface Itest_ParentType<Tkind,Titem,TallItem>
  : Itest_ChildType
{
  public Itest_ParentTypeObject As_ParentType { get; set; }
}

public interface Itest_ParentTypeObject<Tkind,Titem,TallItem>
  : Itest_ChildTypeObject
{
  public ICollection<Titem> Items { get; set; }
  public ICollection<TallItem> AllItems { get; set; }
}

public interface Itest_TypeRef<Tkind>
  : Itest_Named
{
  public Itest_TypeRefObject As_TypeRef { get; set; }
}

public interface Itest_TypeRefObject<Tkind>
  : Itest_NamedObject
{
  public Tkind TypeKind { get; set; }
}

public interface Itest_TypeSimple
{
  public Itest_TypeRef<test_TypeKind> As_TypeRef { get; set; }
  public Itest_TypeRef<test_TypeKind> As_TypeRef { get; set; }
  public Itest_TypeRef<test_TypeKind> As_TypeRef { get; set; }
  public Itest_TypeRef<test_TypeKind> As_TypeRef { get; set; }
  public Itest_TypeSimpleObject As_TypeSimple { get; set; }
}

public interface Itest_TypeSimpleObject
{
}
