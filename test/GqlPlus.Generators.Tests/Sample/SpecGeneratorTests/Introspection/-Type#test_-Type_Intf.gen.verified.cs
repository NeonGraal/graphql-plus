//HintName: test_-Type_Intf.gen.cs
// Generated from -Type.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp__Type;

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
