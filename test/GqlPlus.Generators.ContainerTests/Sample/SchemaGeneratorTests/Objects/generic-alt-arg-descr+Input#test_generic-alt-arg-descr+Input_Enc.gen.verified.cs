//HintName: test_generic-alt-arg-descr+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-alt-arg-descr+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_descr_Input;

internal class testGnrcAltArgDescrInpEncoder<TType> : IEncoder<ItestGnrcAltArgDescrInpObject<TType>>
{
  public Structured Encode(ItestGnrcAltArgDescrInpObject<TType> input)
    => Structured.Empty();
}

internal class testRefGnrcAltArgDescrInpEncoder<TRef> : IEncoder<ItestRefGnrcAltArgDescrInpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcAltArgDescrInpObject<TRef> input)
    => Structured.Empty();
}
