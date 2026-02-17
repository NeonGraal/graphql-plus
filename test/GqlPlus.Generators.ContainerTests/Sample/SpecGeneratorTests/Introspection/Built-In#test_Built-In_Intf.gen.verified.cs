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
  Itest_Modifier<test_ModifierKind> As_ModifierKindList { get; }
  Itest_ModifierKeyed<test_ModifierKind> As_ModifierKindDictionary { get; }
  Itest_ModifierKeyed<test_ModifierKind> As_ModifierKindTypeParam { get; }
  Itest_CollectionsObject As_Collections { get; }
}

public interface Itest_CollectionsObject
{
}

public interface Itest_ModifierKeyed<TKind>
  : Itest_Modifier<TKind>
{
  Itest_ModifierKeyedObject<TKind> As_ModifierKeyed { get; }
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
  Itest_Modifier<test_ModifierKind> As_ModifierKindOptional { get; }
  Itest_Collections As_Collections { get; }
  Itest_ModifiersObject As_Modifiers { get; }
}

public interface Itest_ModifiersObject
{
}

public interface Itest_Modifier<TKind>
  : IGqlpModelImplementationBase
{
  Itest_ModifierObject<TKind> As_Modifier { get; }
}

public interface Itest_ModifierObject<TKind>
{
  TKind ModifierKind { get; }
}
