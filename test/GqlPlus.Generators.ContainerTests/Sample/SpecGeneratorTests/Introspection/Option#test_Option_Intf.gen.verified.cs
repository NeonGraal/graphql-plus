//HintName: test_Option_Intf.gen.cs
// Generated from {CurrentDirectory}Option.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Option;

public interface Itest_Setting
  : Itest_Named
{
  Itest_SettingObject? As__Setting { get; }
}

public interface Itest_SettingObject
  : Itest_NamedObject
{
  GqlpValue Value { get; }
}
