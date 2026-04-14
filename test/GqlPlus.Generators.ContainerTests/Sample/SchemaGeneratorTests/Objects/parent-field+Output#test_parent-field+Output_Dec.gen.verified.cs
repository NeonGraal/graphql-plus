//HintName: test_parent-field+Output_Dec.gen.cs
// Generated from {CurrentDirectory}parent-field+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_field_Output;

internal class testPrntFieldOutpDecoder
{
  public decimal Field { get; set; }
}

internal class testRefPrntFieldOutpDecoder
{
  public decimal Parent { get; set; }
}

internal static class test_parent_field_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_parent_field_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestPrntFieldOutpObject>(r => new testPrntFieldOutpDecoder(r))
      .AddDecoder<ItestRefPrntFieldOutpObject>(r => new testRefPrntFieldOutpDecoder(r));
}
