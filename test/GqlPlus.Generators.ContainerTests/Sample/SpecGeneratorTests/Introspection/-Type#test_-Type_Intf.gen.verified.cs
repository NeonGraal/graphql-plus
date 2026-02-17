//HintName: test_-Type_Intf.gen.cs
// Generated from {CurrentDirectory}-Type.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Type;

public interface Itest_Type
  : IGqlpModelImplementationBase
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
  : IGqlpModelImplementationBase
{
}

public interface Itest_BaseType<TKind>
  : Itest_Aliased
{
  Itest_BaseTypeObject<TKind>? As__BaseType { get; }
}

public interface Itest_BaseTypeObject<TKind>
  : Itest_AliasedObject
{
  TKind TypeKind { get; }
}

public interface Itest_ChildType<TKind,TParent>
  : Itest_BaseType<TKind>
{
  Itest_ChildTypeObject<TKind,TParent>? As__ChildType { get; }
}

public interface Itest_ChildTypeObject<TKind,TParent>
  : Itest_BaseTypeObject<TKind>
{
  TParent Parent { get; }
}

public interface Itest_ParentType<TKind,TItem,TAllItem>
  : Itest_ChildType<TKind, Itest_Named>
{
  Itest_ParentTypeObject<TKind,TItem,TAllItem>? As__ParentType { get; }
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
  Itest_TypeRefObject<TKind>? As__TypeRef { get; }
}

public interface Itest_TypeRefObject<TKind>
  : Itest_NamedObject
{
  TKind TypeKind { get; }
}

public interface Itest_TypeSimple
  : IGqlpModelImplementationBase
{
  Itest_TypeRef<test_TypeKind>? As_TypeKindBasic { get; }
  Itest_TypeRef<test_TypeKind>? As_TypeKindEnum { get; }
  Itest_TypeRef<test_TypeKind>? As_TypeKindDomain { get; }
  Itest_TypeRef<test_TypeKind>? As_TypeKindUnion { get; }
  Itest_TypeSimpleObject? As__TypeSimple { get; }
}

public interface Itest_TypeSimpleObject
  : IGqlpModelImplementationBase
{
}

public interface Itest_Collections
  : IGqlpModelImplementationBase
{
  Itest_Modifier<test_ModifierKind>? As_ModifierKindList { get; }
  Itest_ModifierKeyed<test_ModifierKind>? As_ModifierKindDictionary { get; }
  Itest_ModifierKeyed<test_ModifierKind>? As_ModifierKindTypeParam { get; }
  Itest_CollectionsObject? As__Collections { get; }
}

public interface Itest_CollectionsObject
  : IGqlpModelImplementationBase
{
}

public interface Itest_ModifierKeyed<TKind>
  : Itest_Modifier<TKind>
{
  Itest_ModifierKeyedObject<TKind>? As__ModifierKeyed { get; }
}

public interface Itest_ModifierKeyedObject<TKind>
  : Itest_ModifierObject<TKind>
{
  Itest_TypeSimple By { get; }
  bool IsOptional { get; }
}

public interface Itest_Modifiers
  : IGqlpModelImplementationBase
{
  Itest_Modifier<test_ModifierKind>? As_ModifierKindOptional { get; }
  Itest_Collections? As_Collections { get; }
  Itest_ModifiersObject? As__Modifiers { get; }
}

public interface Itest_ModifiersObject
  : IGqlpModelImplementationBase
{
}

public interface Itest_Modifier<TKind>
  : IGqlpModelImplementationBase
{
  Itest_ModifierObject<TKind>? As__Modifier { get; }
}

public interface Itest_ModifierObject<TKind>
  : IGqlpModelImplementationBase
{
  TKind ModifierKind { get; }
}
