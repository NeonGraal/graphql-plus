//HintName: test_parent-param-same+Input_Enc.gen.cs
// Generated from {CurrentDirectory}parent-param-same+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_param_same_Input;

internal class testPrntParamSameInpEncoder<TA>(
  IEncoderRepository encoders
) : IEncoder<ItestPrntParamSameInpObject<TA>>
{
  private readonly IEncoder<ItestRefPrntParamSameInpObject<TA>> _itestRefPrntParamSameInp = encoders.EncoderFor<ItestRefPrntParamSameInpObject<TA>>();
  private readonly IEncoder<TA> _a = encoders.EncoderFor<TA>();
  public Structured Encode(ItestPrntParamSameInpObject<TA> input)
    => _itestRefPrntParamSameInp.Encode(input)
      .AddEncoded("field", input.Field, _a);
}

internal class testRefPrntParamSameInpEncoder<TA> : IEncoder<ItestRefPrntParamSameInpObject<TA>>
{
  public Structured Encode(ItestRefPrntParamSameInpObject<TA> input)
    => Structured.Empty();
}
