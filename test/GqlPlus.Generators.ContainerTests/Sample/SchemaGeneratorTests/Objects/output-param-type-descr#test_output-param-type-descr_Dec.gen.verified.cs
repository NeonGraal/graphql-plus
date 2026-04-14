//HintName: test_output-param-type-descr_Dec.gen.cs
// Generated from {CurrentDirectory}output-param-type-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param_type_descr;

internal class testOutpParamTypeDescrDecoder
{
  public ItestFldOutpParamTypeDescr? Field(ItestInOutpParamTypeDescr parameter)
    => null;
  public ItestFldOutpParamTypeDescr? Field()
    => null;
}

internal class testFldOutpParamTypeDescrDecoder
{
}

internal class testInOutpParamTypeDescrDecoder
{
  public decimal Param { get; set; }
}

internal static class test_output_param_type_descrDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_output_param_type_descrDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestOutpParamTypeDescrObject>(r => new testOutpParamTypeDescrDecoder(r))
      .AddDecoder<ItestFldOutpParamTypeDescrObject>(_ => new testFldOutpParamTypeDescrDecoder())
      .AddDecoder<ItestInOutpParamTypeDescrObject>(r => new testInOutpParamTypeDescrDecoder(r));
}
