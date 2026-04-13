//HintName: test_generic-field+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-field+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_Input;

internal class testGnrcFieldInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcFieldInpObject<TType>>
{
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestGnrcFieldInpObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _type);
}
