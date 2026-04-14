//HintName: test_output-parent-generic_Dec.gen.cs
// Generated from {CurrentDirectory}output-parent-generic.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_parent_generic;

internal class testOutpPrntGnrcDecoder
{
}

internal class testRefOutpPrntGnrcDecoder<TType>
{
  public TType Field { get; set; }
}

internal class testEnumOutpPrntGnrcDecoder
{
  public string prnt_outpPrntGnrc { get; set; }
  public string outpPrntGnrc { get; set; }
}

internal class testPrntOutpPrntGnrcDecoder
{
  public string prnt_outpPrntGnrc { get; set; }
}

internal static class test_output_parent_genericDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_output_parent_genericDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestOutpPrntGnrcObject>(_ => new testOutpPrntGnrcDecoder())
      .AddDecoder<testEnumOutpPrntGnrc>(_ => new testEnumOutpPrntGnrcDecoder())
      .AddDecoder<testPrntOutpPrntGnrc>(_ => new testPrntOutpPrntGnrcDecoder());
}
