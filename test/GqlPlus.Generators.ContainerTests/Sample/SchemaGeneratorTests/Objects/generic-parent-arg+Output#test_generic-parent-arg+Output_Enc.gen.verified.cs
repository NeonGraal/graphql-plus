//HintName: test_generic-parent-arg+Output_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent-arg+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_arg_Output;

internal class testGnrcPrntArgOutpEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntArgOutpObject<TType>>
{
  private readonly IEncoder<ItestRefGnrcPrntArgOutpObject<TType>> _itestRefGnrcPrntArgOutp = encoders.EncoderFor<ItestRefGnrcPrntArgOutpObject<TType>>();
  public Structured Encode(ItestGnrcPrntArgOutpObject<TType> input)
    => _itestRefGnrcPrntArgOutp.Encode(input);
}

internal class testRefGnrcPrntArgOutpEncoder<TRef> : IEncoder<ItestRefGnrcPrntArgOutpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcPrntArgOutpObject<TRef> input)
    => Structured.Empty();
}
