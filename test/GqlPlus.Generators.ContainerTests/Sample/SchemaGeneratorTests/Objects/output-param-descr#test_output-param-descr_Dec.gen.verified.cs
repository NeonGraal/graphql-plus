//HintName: test_output-param-descr_Dec.gen.cs
// Generated from {CurrentDirectory}output-param-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_param_descr;

internal class testFldOutpParamDescrDecoder : IDecoder<ItestFldOutpParamDescrObject>
{

  public IMessages Decode(IValue input, out ItestFldOutpParamDescrObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFldOutpParamDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testInOutpParamDescrDecoder : IDecoder<ItestInOutpParamDescrObject>
{
  public decimal? Param { get; set; }

  public IMessages Decode(IValue input, out ItestInOutpParamDescrObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testInOutpParamDescrDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_output_param_descrDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_output_param_descrDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestFldOutpParamDescrObject>(testFldOutpParamDescrDecoder.Factory)
      .AddDecoder<ItestInOutpParamDescrObject>(testInOutpParamDescrDecoder.Factory);
}
