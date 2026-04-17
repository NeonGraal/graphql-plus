//HintName: test_Built-In_Intf.gen.cs
// Generated from {CurrentDirectory}Built-In.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Built_In;

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
