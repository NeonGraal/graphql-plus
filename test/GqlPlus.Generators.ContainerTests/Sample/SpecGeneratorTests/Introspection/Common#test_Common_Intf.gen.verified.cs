//HintName: test_Common_Intf.gen.cs
// Generated from Common.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Common;

public interface Itest_Type
{
  Itest_BaseType<test_TypeKind> As_BaseType { get; }
  Itest_BaseType<test_TypeKind> As_BaseType { get; }
  Itest_BaseDomain<Itest_DomainKind, Itest_DomainTrueFalse, Itest_DomainItemTrueFalse> As_BaseDomain { get; }
  Itest_BaseDomain<Itest_DomainKind, Itest_DomainLabel, Itest_DomainItemLabel> As_BaseDomain { get; }
  Itest_BaseDomain<Itest_DomainKind, Itest_DomainRange, Itest_DomainItemRange> As_BaseDomain { get; }
  Itest_BaseDomain<Itest_DomainKind, Itest_DomainRegex, Itest_DomainItemRegex> As_BaseDomain { get; }
  Itest_ParentType<test_TypeKind, Itest_Aliased, Itest_EnumLabel> As_ParentType { get; }
  Itest_ParentType<test_TypeKind, Itest_UnionRef, Itest_UnionMember> As_ParentType { get; }
  Itest_TypeObject<test_TypeKind, Itest_DualField> As_TypeObject { get; }
  Itest_TypeObject<test_TypeKind, Itest_InputField> As_TypeObject { get; }
  Itest_TypeObject<test_TypeKind, Itest_OutputField> As_TypeObject { get; }
  Itest_TypeObject As_Type { get; }
}

public interface Itest_TypeObject
{
}

public interface Itest_BaseType<Tkind>
  : Itest_Aliased
{
  Itest_BaseTypeObject As_BaseType { get; }
}

public interface Itest_BaseTypeObject<Tkind>
  : Itest_AliasedObject
{
  Tkind TypeKind { get; }
}

public interface Itest_ChildType<Tkind,Tparent>
  : Itest_BaseType
{
  Itest_ChildTypeObject As_ChildType { get; }
}

public interface Itest_ChildTypeObject<Tkind,Tparent>
  : Itest_BaseTypeObject
{
  Tparent Parent { get; }
}

public interface Itest_ParentType<Tkind,Titem,TallItem>
  : Itest_ChildType
{
  Itest_ParentTypeObject As_ParentType { get; }
}

public interface Itest_ParentTypeObject<Tkind,Titem,TallItem>
  : Itest_ChildTypeObject
{
  ICollection<Titem> Items { get; }
  ICollection<TallItem> AllItems { get; }
}

public interface Itest_TypeRef<Tkind>
  : Itest_Named
{
  Itest_TypeRefObject As_TypeRef { get; }
}

public interface Itest_TypeRefObject<Tkind>
  : Itest_NamedObject
{
  Tkind TypeKind { get; }
}

public interface Itest_TypeSimple
{
  Itest_TypeRef<test_TypeKind> As_TypeRef { get; }
  Itest_TypeRef<test_TypeKind> As_TypeRef { get; }
  Itest_TypeRef<test_TypeKind> As_TypeRef { get; }
  Itest_TypeRef<test_TypeKind> As_TypeRef { get; }
  Itest_TypeSimpleObject As_TypeSimple { get; }
}

public interface Itest_TypeSimpleObject
{
}
