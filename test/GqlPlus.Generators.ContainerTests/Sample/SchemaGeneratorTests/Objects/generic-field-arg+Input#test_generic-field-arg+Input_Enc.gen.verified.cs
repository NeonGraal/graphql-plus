//HintName: test_generic-field-arg+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-field-arg+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_arg_Input;

internal class testGnrcFieldArgInpEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcFieldArgInpObject<TType>>
{
  private readonly IEncoder<ItestRefGnrcFieldArgInp<TType>> _itestRefGnrcFieldArgInp = encoders.EncoderFor<ItestRefGnrcFieldArgInp<TType>>();
  public Structured Encode(ItestGnrcFieldArgInpObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestRefGnrcFieldArgInp);
}

internal class testRefGnrcFieldArgInpEncoder<TRef> : IEncoder<ItestRefGnrcFieldArgInpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcFieldArgInpObject<TRef> input)
    => Structured.Empty();
}
