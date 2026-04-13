//HintName: test_generic-alt-arg-descr+Output_Enc.gen.cs
// Generated from {CurrentDirectory}generic-alt-arg-descr+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_descr_Output;

internal class testGnrcAltArgDescrOutpEncoder : IEncoder<ItestGnrcAltArgDescrOutpObject<TType>>
{
  public Structured Encode(ItestGnrcAltArgDescrOutpObject<TType> input)
    => Structured.Empty();
}

internal class testRefGnrcAltArgDescrOutpEncoder : IEncoder<ItestRefGnrcAltArgDescrOutpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcAltArgDescrOutpObject<TRef> input)
    => Structured.Empty();
}
