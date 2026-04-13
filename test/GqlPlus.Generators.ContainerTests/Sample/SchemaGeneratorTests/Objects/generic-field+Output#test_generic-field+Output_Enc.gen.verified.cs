//HintName: test_generic-field+Output_Enc.gen.cs
// Generated from {CurrentDirectory}generic-field+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_Output;

internal class testGnrcFieldOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcFieldOutpObject<TType>>
{
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestGnrcFieldOutpObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _type);
}
