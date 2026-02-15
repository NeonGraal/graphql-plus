//HintName: test_Common_Intf.gen.cs
// Generated from Common.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Common;

public interface Itest_Type
{
  Itest_BaseType<test_TypeKind> As_TypeKindBasic { get; }
  Itest_BaseType<test_TypeKind> As_TypeKindInternal { get; }
  Itest_BaseDomain<Itest_DomainKind, Itest_DomainTrueFalse, Itest_DomainItemTrueFalse> As_DomainKindBoolean { get; }
  Itest_BaseDomain<Itest_DomainKind, Itest_DomainLabel, Itest_DomainItemLabel> As_DomainKindEnum { get; }
  Itest_BaseDomain<Itest_DomainKind, Itest_DomainRange, Itest_DomainItemRange> As_DomainKindNumber { get; }
  Itest_BaseDomain<Itest_DomainKind, Itest_DomainRegex, Itest_DomainItemRegex> As_DomainKindString { get; }
  Itest_ParentType<test_TypeKind, Itest_Aliased, Itest_EnumLabel> As_TypeKindEnum { get; }
  Itest_ParentType<test_TypeKind, Itest_UnionRef, Itest_UnionMember> As_TypeKindUnion { get; }
  Itest_TypeObject<test_TypeKind, Itest_DualField> As_TypeKindDual { get; }
  Itest_TypeObject<test_TypeKind, Itest_InputField> As_TypeKindInput { get; }
  Itest_TypeObject<test_TypeKind, Itest_OutputField> As_TypeKindOutput { get; }
  Itest_TypeObject As_Type { get; }
}

public interface Itest_TypeObject
{
}

public interface Itest_BaseType<TKind>
  : Itest_Aliased
{
  Itest_BaseTypeObject<TKind> As_BaseType { get; }
}

public interface Itest_BaseTypeObject<TKind>
  : Itest_AliasedObject
{
  TKind TypeKind { get; }
}

public interface Itest_ChildType<TKind,TParent>
  : Itest_BaseType<TKind>
{
  Itest_ChildTypeObject<TKind,TParent> As_ChildType { get; }
}

public interface Itest_ChildTypeObject<TKind,TParent>
  : Itest_BaseTypeObject<TKind>
{
  TParent Parent { get; }
}

public interface Itest_ParentType<TKind,TItem,TAllItem>
  : Itest_ChildType<TKind, Itest_Named>
{
  Itest_ParentTypeObject<TKind,TItem,TAllItem> As_ParentType { get; }
}

public interface Itest_ParentTypeObject<TKind,TItem,TAllItem>
  : Itest_ChildTypeObject<TKind, Itest_Named>
{
  ICollection<TItem> Items { get; }
  ICollection<TAllItem> AllItems { get; }
}

public interface Itest_TypeRef<TKind>
  : Itest_Named
{
  Itest_TypeRefObject<TKind> As_TypeRef { get; }
}

public interface Itest_TypeRefObject<TKind>
  : Itest_NamedObject
{
  TKind TypeKind { get; }
}

public interface Itest_TypeSimple
{
  Itest_TypeRef<test_TypeKind> As_TypeKindBasic { get; }
  Itest_TypeRef<test_TypeKind> As_TypeKindEnum { get; }
  Itest_TypeRef<test_TypeKind> As_TypeKindDomain { get; }
  Itest_TypeRef<test_TypeKind> As_TypeKindUnion { get; }
  Itest_TypeSimpleObject As_TypeSimple { get; }
}

public interface Itest_TypeSimpleObject
{
}
