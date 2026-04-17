//HintName: test_generic-field-arg+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}generic-field-arg+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_arg_Dual;

internal class testGnrcFieldArgDualEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcFieldArgDualObject<TType>>
{
  private readonly IEncoder<ItestRefGnrcFieldArgDual<TType>> _itestRefGnrcFieldArgDual = encoders.EncoderFor<ItestRefGnrcFieldArgDual<TType>>();
  public Structured Encode(ItestGnrcFieldArgDualObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestRefGnrcFieldArgDual);
}

internal class testRefGnrcFieldArgDualEncoder<TRef> : IEncoder<ItestRefGnrcFieldArgDualObject<TRef>>
{
  public Structured Encode(ItestRefGnrcFieldArgDualObject<TRef> input)
    => Structured.Empty();
}
