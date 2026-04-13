//HintName: test_parent-param-same+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}parent-param-same+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_param_same_Dual;

internal class testPrntParamSameDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntParamSameDualObject<TA>>
{
  private readonly IEncoder<ItestRefPrntParamSameDualObject<TA>> _itestRefPrntParamSameDualObject<TA> = encoders.EncoderFor<ItestRefPrntParamSameDualObject<TA>>();
  private readonly IEncoder<TA> _a = encoders.EncoderFor<TA>();
  public Structured Encode(ItestPrntParamSameDualObject<TA> input)
    => _itestRefPrntParamSameDualObject<TA>.Encode(input)
      .AddEncoded("field", input.Field, _a);
}

internal class testRefPrntParamSameDualEncoder : IEncoder<ItestRefPrntParamSameDualObject<TA>>
{
  public Structured Encode(ItestRefPrntParamSameDualObject<TA> input)
    => Structured.Empty();
}
