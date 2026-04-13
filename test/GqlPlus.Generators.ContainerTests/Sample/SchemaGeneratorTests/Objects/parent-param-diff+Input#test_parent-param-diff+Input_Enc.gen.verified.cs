//HintName: test_parent-param-diff+Input_Enc.gen.cs
// Generated from {CurrentDirectory}parent-param-diff+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_param_diff_Input;

internal class testPrntParamDiffInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntParamDiffInpObject<TA>>
{
  private readonly IEncoder<ItestRefPrntParamDiffInpObject<TA>> _itestRefPrntParamDiffInpObject<TA> = encoders.EncoderFor<ItestRefPrntParamDiffInpObject<TA>>();
  private readonly IEncoder<TA> _a = encoders.EncoderFor<TA>();
  public Structured Encode(ItestPrntParamDiffInpObject<TA> input)
    => _itestRefPrntParamDiffInpObject<TA>.Encode(input)
      .AddEncoded("field", input.Field, _a);
}

internal class testRefPrntParamDiffInpEncoder : IEncoder<ItestRefPrntParamDiffInpObject<TB>>
{
  public Structured Encode(ItestRefPrntParamDiffInpObject<TB> input)
    => Structured.Empty();
}
