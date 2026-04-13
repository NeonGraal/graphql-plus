//HintName: test_constraint-field-domain+Output_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-field-domain+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_domain_Output;

internal class testCnstFieldDmnOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstFieldDmnOutpObject>
{
  private readonly IEncoder<ItestRefCnstFieldDmnOutpObject<ItestDomCnstFieldDmnOutp>> _itestRefCnstFieldDmnOutpObject<ItestDomCnstFieldDmnOutp> = encoders.EncoderFor<ItestRefCnstFieldDmnOutpObject<ItestDomCnstFieldDmnOutp>>();
  public Structured Encode(ItestCnstFieldDmnOutpObject input)
    => _itestRefCnstFieldDmnOutpObject<ItestDomCnstFieldDmnOutp>.Encode(input);
}

internal class testRefCnstFieldDmnOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstFieldDmnOutpObject<TRef>>
{
  private readonly IEncoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public Structured Encode(ItestRefCnstFieldDmnOutpObject<TRef> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _ref);
}

internal class testDomCnstFieldDmnOutpEncoder : IEncoder<ItestDomCnstFieldDmnOutp>
{
  public Structured Encode(ItestDomCnstFieldDmnOutp input)
    => new(input.Value);
}
