//HintName: test_generic-descr+Output_Enc.gen.cs
// Generated from {CurrentDirectory}generic-descr+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_descr_Output;

internal class testGnrcDescrOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcDescrOutpObject<TType>>
{
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestGnrcDescrOutpObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _type);
}
