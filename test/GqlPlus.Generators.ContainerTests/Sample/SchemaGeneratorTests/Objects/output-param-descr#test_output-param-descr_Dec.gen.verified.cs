//HintName: test_output-param-descr_Dec.gen.cs
// Generated from {CurrentDirectory}output-param-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param_descr;

internal class testOutpParamDescrDecoder
{
  public ItestFldOutpParamDescr? Field(ItestInOutpParamDescr parameter)
    => null;
  public ItestFldOutpParamDescr? Field()
    => null;
}

internal class testFldOutpParamDescrDecoder
{
}

internal class testInOutpParamDescrDecoder
{
  public decimal Param { get; set; }
}

internal static class test_output_param_descrDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_output_param_descrDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestOutpParamDescrObject>(r => new testOutpParamDescrDecoder(r))
      .AddDecoder<ItestFldOutpParamDescrObject>(_ => new testFldOutpParamDescrDecoder())
      .AddDecoder<ItestInOutpParamDescrObject>(r => new testInOutpParamDescrDecoder(r));
}
