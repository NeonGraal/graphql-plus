//HintName: test_generic-field-arg+Output_Enc.gen.cs
// Generated from {CurrentDirectory}generic-field-arg+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_arg_Output;

internal class testGnrcFieldArgOutpEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcFieldArgOutpObject<TType>>
{
  private readonly Encoder<ItestRefGnrcFieldArgOutp<TType>> _itestRefGnrcFieldArgOutp = encoders.EncoderFor<ItestRefGnrcFieldArgOutp<TType>>();
  public IGqlpValue Encode(ItestGnrcFieldArgOutpObject<TType> input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _itestRefGnrcFieldArgOutp);
}

internal class testRefGnrcFieldArgOutpEncoder<TRef> : IEncoder<ItestRefGnrcFieldArgOutpObject<TRef>>
{
  public IGqlpValue Encode(ItestRefGnrcFieldArgOutpObject<TRef> input)
    => new GqlpUnit();
}
