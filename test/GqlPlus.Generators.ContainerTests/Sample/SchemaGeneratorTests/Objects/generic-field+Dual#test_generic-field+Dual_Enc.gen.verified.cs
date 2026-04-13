//HintName: test_generic-field+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}generic-field+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_Dual;

internal class testGnrcFieldDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcFieldDualObject<TType>>
{
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestGnrcFieldDualObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _type);
}
