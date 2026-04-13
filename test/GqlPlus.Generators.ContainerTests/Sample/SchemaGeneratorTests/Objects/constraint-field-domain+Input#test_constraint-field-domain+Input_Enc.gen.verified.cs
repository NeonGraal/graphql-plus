//HintName: test_constraint-field-domain+Input_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-field-domain+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_domain_Input;

internal class testCnstFieldDmnInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstFieldDmnInpObject>
{
  private readonly IEncoder<ItestRefCnstFieldDmnInpObject<ItestDomCnstFieldDmnInp>> _itestRefCnstFieldDmnInp = encoders.EncoderFor<ItestRefCnstFieldDmnInpObject<ItestDomCnstFieldDmnInp>>();
  public Structured Encode(ItestCnstFieldDmnInpObject input)
    => _itestRefCnstFieldDmnInp.Encode(input);
}

internal class testRefCnstFieldDmnInpEncoder<TRef>(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstFieldDmnInpObject<TRef>>
{
  private readonly IEncoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public Structured Encode(ItestRefCnstFieldDmnInpObject<TRef> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _ref);
}

internal class testDomCnstFieldDmnInpEncoder : IEncoder<ItestDomCnstFieldDmnInp>
{
  public Structured Encode(ItestDomCnstFieldDmnInp input)
    => new(input.Value);
}
