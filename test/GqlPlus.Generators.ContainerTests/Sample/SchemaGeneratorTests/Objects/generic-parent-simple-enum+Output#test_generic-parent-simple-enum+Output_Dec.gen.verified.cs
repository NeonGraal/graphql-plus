//HintName: test_generic-parent-simple-enum+Output_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-simple-enum+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_simple_enum_Output;

internal class testEnumGnrcPrntSmplEnumOutpDecoder
{
  public string gnrcPrntSmplEnumOutp { get; set; }

  internal static testEnumGnrcPrntSmplEnumOutpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_generic_parent_simple_enum_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_parent_simple_enum_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<testEnumGnrcPrntSmplEnumOutp>(testEnumGnrcPrntSmplEnumOutpDecoder.Factory);
}
