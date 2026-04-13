//HintName: test_parent-param-same+Output_Enc.gen.cs
// Generated from {CurrentDirectory}parent-param-same+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_param_same_Output;

internal class testPrntParamSameOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntParamSameOutpObject<TA>>
{
  private readonly IEncoder<ItestRefPrntParamSameOutpObject<TA>> _itestRefPrntParamSameOutpObject<TA> = encoders.EncoderFor<ItestRefPrntParamSameOutpObject<TA>>();
  private readonly IEncoder<TA> _a = encoders.EncoderFor<TA>();
  public Structured Encode(ItestPrntParamSameOutpObject<TA> input)
    => _itestRefPrntParamSameOutpObject<TA>.Encode(input)
      .AddEncoded("field", input.Field, _a);
}

internal class testRefPrntParamSameOutpEncoder : IEncoder<ItestRefPrntParamSameOutpObject<TA>>
{
  public Structured Encode(ItestRefPrntParamSameOutpObject<TA> input)
    => Structured.Empty();
}
