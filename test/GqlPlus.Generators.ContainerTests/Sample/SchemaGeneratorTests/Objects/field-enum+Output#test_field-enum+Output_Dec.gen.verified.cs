//HintName: test_field-enum+Output_Dec.gen.cs
// Generated from {CurrentDirectory}field-enum+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_enum_Output;

internal class testEnumFieldEnumOutpDecoder
{
  public string fieldEnumOutp { get; set; }
}

internal static class test_field_enum_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_field_enum_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<testEnumFieldEnumOutp>(_ => new testEnumFieldEnumOutpDecoder());
}
