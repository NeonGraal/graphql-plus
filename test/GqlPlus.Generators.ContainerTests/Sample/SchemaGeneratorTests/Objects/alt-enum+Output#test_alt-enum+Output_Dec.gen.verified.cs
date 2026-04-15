//HintName: test_alt-enum+Output_Dec.gen.cs
// Generated from {CurrentDirectory}alt-enum+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_enum_Output;

internal class testEnumAltEnumOutpDecoder
{
  public string altEnumOutp { get; set; }

  internal static testEnumAltEnumOutpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_alt_enum_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_alt_enum_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<testEnumAltEnumOutp>(testEnumAltEnumOutpDecoder.Factory);
}
