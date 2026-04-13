//HintName: test_parent-param-diff+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}parent-param-diff+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_param_diff_Dual;

internal class testPrntParamDiffDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntParamDiffDualObject<TA>>
{
  private readonly IEncoder<ItestRefPrntParamDiffDualObject<TA>> _itestRefPrntParamDiffDualObject<TA> = encoders.EncoderFor<ItestRefPrntParamDiffDualObject<TA>>();
  private readonly IEncoder<TA> _a = encoders.EncoderFor<TA>();
  public Structured Encode(ItestPrntParamDiffDualObject<TA> input)
    => _itestRefPrntParamDiffDualObject<TA>.Encode(input)
      .AddEncoded("field", input.Field, _a);
}

internal class testRefPrntParamDiffDualEncoder : IEncoder<ItestRefPrntParamDiffDualObject<TB>>
{
  public Structured Encode(ItestRefPrntParamDiffDualObject<TB> input)
    => Structured.Empty();
}
