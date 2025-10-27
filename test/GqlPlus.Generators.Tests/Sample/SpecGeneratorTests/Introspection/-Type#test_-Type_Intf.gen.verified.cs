//HintName: test_-Type_Intf.gen.cs
// Generated from -Type.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp__Type;

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

public interface Itest_Collections
{
  _Modifier<_ModifierKind> As_Modifier { get; }
  _ModifierKeyed<_ModifierKind> As_ModifierKeyed { get; }
  _ModifierKeyed<_ModifierKind> As_ModifierKeyed { get; }
}

public interface Itest_ModifierKeyed<Tkind>
  : Itest_Modifier
{
  _TypeSimple by { get; }
  Boolean optional { get; }
}

public interface Itest_Modifiers
{
  _Modifier<_ModifierKind> As_Modifier { get; }
  _Collections As_Collections { get; }
}

public interface Itest_Modifier<Tkind>
{
  Tkind modifierKind { get; }
}
