//HintName: test_generic-parent-arg+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent-arg+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_arg_Input;

internal class testGnrcPrntArgInpEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntArgInpObject<TType>>
{
  private readonly IEncoder<ItestRefGnrcPrntArgInpObject<TType>> _itestRefGnrcPrntArgInp = encoders.EncoderFor<ItestRefGnrcPrntArgInpObject<TType>>();
  public Structured Encode(ItestGnrcPrntArgInpObject<TType> input)
    => _itestRefGnrcPrntArgInp.Encode(input);
}

internal class testRefGnrcPrntArgInpEncoder<TRef> : IEncoder<ItestRefGnrcPrntArgInpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcPrntArgInpObject<TRef> input)
    => Structured.Empty();
}
