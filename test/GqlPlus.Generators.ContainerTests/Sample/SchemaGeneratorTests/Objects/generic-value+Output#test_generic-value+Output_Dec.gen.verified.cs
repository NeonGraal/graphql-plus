//HintName: test_generic-value+Output_Dec.gen.cs
// Generated from {CurrentDirectory}generic-value+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_value_Output;

internal class testEnumGnrcValueOutpDecoder
{
  public string gnrcValueOutp { get; set; }

  internal static testEnumGnrcValueOutpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_generic_value_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_value_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<testEnumGnrcValueOutp>(testEnumGnrcValueOutpDecoder.Factory);
}
