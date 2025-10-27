//HintName: test_Common_Intf.gen.cs
// Generated from Common.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_Common;

public interface Itest_Type
{
  _BaseType<_TypeKind> As_BaseType { get; }
  _BaseType<_TypeKind> As_BaseType { get; }
  _BaseDomain<_DomainKind, _DomainTrueFalse, _DomainItemTrueFalse> As_BaseDomain { get; }
  _BaseDomain<_DomainKind, _DomainLabel, _DomainItemLabel> As_BaseDomain { get; }
  _BaseDomain<_DomainKind, _DomainRange, _DomainItemRange> As_BaseDomain { get; }
  _BaseDomain<_DomainKind, _DomainRegex, _DomainItemRegex> As_BaseDomain { get; }
  _ParentType<_TypeKind, _Aliased, _EnumLabel> As_ParentType { get; }
  _ParentType<_TypeKind, _UnionRef, _UnionMember> As_ParentType { get; }
  _TypeObject<_TypeKind, _DualField> As_TypeObject { get; }
  _TypeObject<_TypeKind, _InputField> As_TypeObject { get; }
  _TypeObject<_TypeKind, _OutputField> As_TypeObject { get; }
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
