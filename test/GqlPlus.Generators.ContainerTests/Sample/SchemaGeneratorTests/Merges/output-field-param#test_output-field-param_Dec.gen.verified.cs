//HintName: test_output-field-param_Dec.gen.cs
// Generated from {CurrentDirectory}output-field-param.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_field_param;

internal class testOutpFieldParamDecoder
{
  public ItestFldOutpFieldParam? Field(ItestOutpFieldParam1 parameter)
    => null;
  public ItestFldOutpFieldParam? Field()
    => null;
}

internal class testOutpFieldParam1Decoder
{
}

internal class testOutpFieldParam2Decoder
{
}

internal class testFldOutpFieldParamDecoder
{
}

internal static class test_output_field_paramDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_output_field_paramDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestOutpFieldParamObject>(r => new testOutpFieldParamDecoder(r))
      .AddDecoder<ItestOutpFieldParam1Object>(_ => new testOutpFieldParam1Decoder())
      .AddDecoder<ItestOutpFieldParam2Object>(_ => new testOutpFieldParam2Decoder())
      .AddDecoder<ItestFldOutpFieldParamObject>(_ => new testFldOutpFieldParamDecoder());
}
