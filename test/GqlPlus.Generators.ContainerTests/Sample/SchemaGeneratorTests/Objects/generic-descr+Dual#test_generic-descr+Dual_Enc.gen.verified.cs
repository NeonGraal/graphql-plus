//HintName: test_generic-descr+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}generic-descr+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_descr_Dual;

internal class testGnrcDescrDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcDescrDualObject<TType>>
{
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestGnrcDescrDualObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _type);
}
