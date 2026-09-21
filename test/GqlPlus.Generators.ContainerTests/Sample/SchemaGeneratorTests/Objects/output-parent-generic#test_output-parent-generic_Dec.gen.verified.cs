//HintName: test_output-parent-generic_Dec.gen.cs
// Generated from {CurrentDirectory}output-parent-generic.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_parent_generic;

internal class testEnumOutpPrntGnrcDecoder : NullDecoder<testEnumOutpPrntGnrc>
{
  public string prnt_outpPrntGnrc { get; set; } = default!;
  public string outpPrntGnrc { get; set; } = default!;

  internal static testEnumOutpPrntGnrcDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntOutpPrntGnrcDecoder : NullDecoder<testPrntOutpPrntGnrc>
{
  public string prnt_outpPrntGnrc { get; set; } = default!;

  internal static testPrntOutpPrntGnrcDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_output_parent_genericDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_output_parent_genericDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<testEnumOutpPrntGnrc>(testEnumOutpPrntGnrcDecoder.Factory)
      .AddDecoder<testPrntOutpPrntGnrc>(testPrntOutpPrntGnrcDecoder.Factory);
}
