//HintName: test_generic-field-arg+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-field-arg+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_arg_Input;

internal class testGnrcFieldArgInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcFieldArgInpObject<TType>>
{
  private readonly IEncoder<ItestRefGnrcFieldArgInp<TType>> _itestRefGnrcFieldArgInp<TType> = encoders.EncoderFor<ItestRefGnrcFieldArgInp<TType>>();
  public Structured Encode(ItestGnrcFieldArgInpObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestRefGnrcFieldArgInp<TType>);
}

internal class testRefGnrcFieldArgInpEncoder : IEncoder<ItestRefGnrcFieldArgInpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcFieldArgInpObject<TRef> input)
    => Structured.Empty();
}
