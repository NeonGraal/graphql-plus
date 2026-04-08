//HintName: test_Option_Dec.gen.cs
// Generated from {CurrentDirectory}Option.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
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
