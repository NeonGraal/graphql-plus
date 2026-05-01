//HintName: test_output-param-type-descr_Dec.gen.cs
// Generated from {CurrentDirectory}output-param-type-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param_type_descr;

internal class testFldOutpParamTypeDescrDecoder : IDecoder<ItestFldOutpParamTypeDescrObject>
{

  public IMessages Decode(IValue input, out ItestFldOutpParamTypeDescrObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFldOutpParamTypeDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testInOutpParamTypeDescrDecoder : IDecoder<ItestInOutpParamTypeDescrObject>
{
  public decimal? Param { get; set; }

  public IMessages Decode(IValue input, out ItestInOutpParamTypeDescrObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testInOutpParamTypeDescrDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_output_param_type_descrDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_output_param_type_descrDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestFldOutpParamTypeDescrObject>(testFldOutpParamTypeDescrDecoder.Factory)
      .AddDecoder<ItestInOutpParamTypeDescrObject>(testInOutpParamTypeDescrDecoder.Factory);
}
