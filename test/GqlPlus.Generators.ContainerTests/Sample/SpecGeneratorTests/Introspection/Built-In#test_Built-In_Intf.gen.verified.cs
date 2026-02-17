//HintName: test_Built-In_Intf.gen.cs
// Generated from {CurrentDirectory}Built-In.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Built_In;

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
