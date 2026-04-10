//HintName: test_-Type_Intf.gen.cs
// Generated from {CurrentDirectory}-Type.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Type;

public interface Itest_Type
  : IGqlpInterfaceBase
{
  Itest_BaseType<test_TypeKind>? As_TypeKindBasic { get; }
  Itest_BaseType<test_TypeKind>? As_TypeKindInternal { get; }
  Itest_BaseDomain<Itest_DomainKind, Itest_DomainTrueFalse, Itest_DomainItemTrueFalse>? As_DomainKindBoolean { get; }
  Itest_BaseDomain<Itest_DomainKind, Itest_DomainLabel, Itest_DomainItemLabel>? As_DomainKindEnum { get; }
  Itest_BaseDomain<Itest_DomainKind, Itest_DomainRange, Itest_DomainItemRange>? As_DomainKindNumber { get; }
  Itest_BaseDomain<Itest_DomainKind, Itest_DomainRegex, Itest_DomainItemRegex>? As_DomainKindString { get; }
  Itest_ParentType<test_TypeKind, Itest_Aliased, Itest_EnumLabel>? As_TypeKindEnum { get; }
  Itest_ParentType<test_TypeKind, Itest_UnionRef, Itest_UnionMember>? As_TypeKindUnion { get; }
  Itest_TypeObject<test_TypeKind, Itest_DualField>? As_TypeKindDual { get; }
  Itest_TypeObject<test_TypeKind, Itest_InputField>? As_TypeKindInput { get; }
  Itest_TypeObject<test_TypeKind, Itest_OutputField>? As_TypeKindOutput { get; }
  Itest_TypeObject? As__Type { get; }
}

public interface Itest_TypeObject
  : IGqlpInterfaceBase
{
}

public interface Itest_BaseType<TTypeKind>
  : Itest_Aliased
{
  Itest_BaseTypeObject<TTypeKind>? As__BaseType { get; }
}

public interface Itest_BaseTypeObject<TTypeKind>
  : Itest_AliasedObject
{
  TTypeKind TypeKind { get; }
}

public interface Itest_ChildType<TTypeKind,TParent>
  : Itest_BaseType<TTypeKind>
{
  Itest_ChildTypeObject<TTypeKind,TParent>? As__ChildType { get; }
}

public interface Itest_ChildTypeObject<TTypeKind,TParent>
  : Itest_BaseTypeObject<TTypeKind>
{
  TParent Parent { get; }
}

public interface Itest_ParentType<TTypeKind,TItem,TAllItem>
  : Itest_ChildType<TTypeKind, Itest_Named>
{
  Itest_ParentTypeObject<TTypeKind,TItem,TAllItem>? As__ParentType { get; }
}

public interface Itest_ParentTypeObject<TTypeKind,TItem,TAllItem>
  : Itest_ChildTypeObject<TTypeKind, Itest_Named>
{
  ICollection<TItem> Items { get; }
  ICollection<TAllItem> AllItems { get; }
}

public enum test_SimpleKind
{
  Basic,
  Enum,
  Internal,
  Domain,
  Union,
}

public enum test_TypeKind
{
  Basic = test_SimpleKind.Basic,
  Enum = test_SimpleKind.Enum,
  Internal = test_SimpleKind.Internal,
  Domain = test_SimpleKind.Domain,
  Union = test_SimpleKind.Union,
  Dual,
  Input,
  Output,
}

public interface Itest_TypeRef<TTypeKind>
  : Itest_Named
{
  Itest_TypeRefObject<TTypeKind>? As__TypeRef { get; }
}

public interface Itest_TypeRefObject<TTypeKind>
  : Itest_NamedObject
{
  TTypeKind TypeKind { get; }
}

public interface Itest_TypeSimple
  : IGqlpInterfaceBase
{
  Itest_TypeRef<test_TypeKind>? As_TypeKindBasic { get; }
  Itest_TypeRef<test_TypeKind>? As_TypeKindEnum { get; }
  Itest_TypeRef<test_TypeKind>? As_TypeKindDomain { get; }
  Itest_TypeRef<test_TypeKind>? As_TypeKindUnion { get; }
  Itest_TypeSimpleObject? As__TypeSimple { get; }
}

public interface Itest_TypeSimpleObject
  : IGqlpInterfaceBase
{
}

public interface Itest_Collections
  : IGqlpInterfaceBase
{
  Itest_Modifier<test_ModifierKind>? As_ModifierKindList { get; }
  Itest_ModifierKeyed<test_ModifierKind>? As_ModifierKindDictionary { get; }
  Itest_ModifierKeyed<test_ModifierKind>? As_ModifierKindTypeParam { get; }
  Itest_CollectionsObject? As__Collections { get; }
}

public interface Itest_CollectionsObject
  : IGqlpInterfaceBase
{
}

public interface Itest_ModifierKeyed<TModifierKind>
  : Itest_Modifier<TModifierKind>
{
  Itest_ModifierKeyedObject<TModifierKind>? As__ModifierKeyed { get; }
}

public interface Itest_ModifierKeyedObject<TModifierKind>
  : Itest_ModifierObject<TModifierKind>
{
  Itest_TypeSimple By { get; }
  bool IsOptional { get; }
}

public interface Itest_Modifiers
  : IGqlpInterfaceBase
{
  Itest_Modifier<test_ModifierKind>? As_ModifierKindOptional { get; }
  Itest_Collections? As_Collections { get; }
  Itest_ModifiersObject? As__Modifiers { get; }
}

public interface Itest_ModifiersObject
  : IGqlpInterfaceBase
{
}

public enum test_ModifierKind
{
  Opt,
  Optional = Opt,
  List,
  Dict,
  Dictionary = Dict,
  Param,
  TypeParam = Param,
}

public interface Itest_Modifier<TModifierKind>
  : IGqlpInterfaceBase
{
  Itest_ModifierObject<TModifierKind>? As__Modifier { get; }
}

public interface Itest_ModifierObject<TModifierKind>
  : IGqlpInterfaceBase
{
  TModifierKind ModifierKind { get; }
}
