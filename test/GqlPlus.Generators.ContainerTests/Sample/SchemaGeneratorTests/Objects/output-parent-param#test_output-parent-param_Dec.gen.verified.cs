//HintName: test_output-parent-param_Dec.gen.cs
// Generated from {CurrentDirectory}output-parent-param.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_parent_param;

internal class testFldOutpPrntParamDecoder : IDecoder<ItestFldOutpPrntParamObject>
{

  public IMessages Decode(IValue input, out ItestFldOutpPrntParamObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFldOutpPrntParamDecoder Factory(IDecoderRepository _) => new();
}

internal class testInOutpPrntParamDecoder : IDecoder<ItestInOutpPrntParamObject>
{
  public decimal? Param { get; set; }

  public IMessages Decode(IValue input, out ItestInOutpPrntParamObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testInOutpPrntParamDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntOutpPrntParamInDecoder : IDecoder<ItestPrntOutpPrntParamInObject>
{
  public decimal? Parent { get; set; }

  public IMessages Decode(IValue input, out ItestPrntOutpPrntParamInObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntOutpPrntParamInDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_output_parent_paramDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_output_parent_paramDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestFldOutpPrntParamObject>(testFldOutpPrntParamDecoder.Factory)
      .AddDecoder<ItestInOutpPrntParamObject>(testInOutpPrntParamDecoder.Factory)
      .AddDecoder<ItestPrntOutpPrntParamInObject>(testPrntOutpPrntParamInDecoder.Factory);
}
