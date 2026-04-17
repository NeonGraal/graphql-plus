//HintName: test_parent-param-diff+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}parent-param-diff+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_param_diff_Dual;

internal class testPrntParamDiffDualEncoder<TA>(
  IEncoderRepository encoders
) : IEncoder<ItestPrntParamDiffDualObject<TA>>
{
  private readonly IEncoder<ItestRefPrntParamDiffDualObject<TA>> _itestRefPrntParamDiffDual = encoders.EncoderFor<ItestRefPrntParamDiffDualObject<TA>>();
  private readonly IEncoder<TA> _a = encoders.EncoderFor<TA>();
  public Structured Encode(ItestPrntParamDiffDualObject<TA> input)
    => _itestRefPrntParamDiffDual.Encode(input)
      .AddEncoded("field", input.Field, _a);
}

internal class testRefPrntParamDiffDualEncoder<TB> : IEncoder<ItestRefPrntParamDiffDualObject<TB>>
{
  public Structured Encode(ItestRefPrntParamDiffDualObject<TB> input)
    => Structured.Empty();
}
