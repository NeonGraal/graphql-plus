//HintName: test_Option_Intf.gen.cs
// Generated from {CurrentDirectory}Option.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Option;

public interface Itest_Setting
  : Itest_Named
{
  Itest_SettingObject As_Setting { get; }
}

public interface Itest_SettingObject
  : Itest_NamedObject
{
  GqlpValue Value { get; }
}
