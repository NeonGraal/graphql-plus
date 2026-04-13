//HintName: test_generic-field-arg+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}generic-field-arg+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_arg_Dual;

internal class testGnrcFieldArgDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcFieldArgDualObject<TType>>
{
  private readonly IEncoder<ItestRefGnrcFieldArgDual<TType>> _itestRefGnrcFieldArgDual<TType> = encoders.EncoderFor<ItestRefGnrcFieldArgDual<TType>>();
  public Structured Encode(ItestGnrcFieldArgDualObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestRefGnrcFieldArgDual<TType>);
}

internal class testRefGnrcFieldArgDualEncoder : IEncoder<ItestRefGnrcFieldArgDualObject<TRef>>
{
  public Structured Encode(ItestRefGnrcFieldArgDualObject<TRef> input)
    => Structured.Empty();
}
