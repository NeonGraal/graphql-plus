//HintName: test_Full_Intf.gen.cs
// Generated from {CurrentDirectory}Full.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Full;

public interface Itest_Request
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  Itest_RequestObject? As__Request { get; }
}

public interface Itest_RequestObject
  : IGqlpInterfaceBase
{
  Itest_Identifier? Category { get; }
  Itest_Identifier? Operation { get; }
  Itest_Operation Definition { get; }
  object? Parameters { get; }
}

public interface Itest_Identifier
  : IGqlpDomainString
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
  Itest_Identifier By { get; }
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
