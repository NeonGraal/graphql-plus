//HintName: test_Option_Dec.gen.cs
// Generated from {CurrentDirectory}Option.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Option;

internal class test_SettingDecoder
{
  public GqlpValue Value { get; set; }
}

internal static class test_OptionDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_OptionDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<Itest_SettingObject>(r => new test_SettingDecoder(r));
}
