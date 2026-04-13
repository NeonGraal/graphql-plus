//HintName: test_parent-param-diff+Output_Enc.gen.cs
// Generated from {CurrentDirectory}parent-param-diff+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_param_diff_Output;

internal class testPrntParamDiffOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntParamDiffOutpObject<TA>>
{
  private readonly IEncoder<ItestRefPrntParamDiffOutpObject<TA>> _itestRefPrntParamDiffOutpObject<TA> = encoders.EncoderFor<ItestRefPrntParamDiffOutpObject<TA>>();
  private readonly IEncoder<TA> _a = encoders.EncoderFor<TA>();
  public Structured Encode(ItestPrntParamDiffOutpObject<TA> input)
    => _itestRefPrntParamDiffOutpObject<TA>.Encode(input)
      .AddEncoded("field", input.Field, _a);
}

internal class testRefPrntParamDiffOutpEncoder : IEncoder<ItestRefPrntParamDiffOutpObject<TB>>
{
  public Structured Encode(ItestRefPrntParamDiffOutpObject<TB> input)
    => Structured.Empty();
}
