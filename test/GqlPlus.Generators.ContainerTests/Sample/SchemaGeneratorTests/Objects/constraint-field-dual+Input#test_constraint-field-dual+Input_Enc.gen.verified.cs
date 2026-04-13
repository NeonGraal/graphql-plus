//HintName: test_constraint-field-dual+Input_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-field-dual+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_dual_Input;

internal class testCnstFieldDualInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstFieldDualInpObject>
{
  private readonly IEncoder<ItestRefCnstFieldDualInpObject<ItestAltCnstFieldDualInp>> _itestRefCnstFieldDualInp = encoders.EncoderFor<ItestRefCnstFieldDualInpObject<ItestAltCnstFieldDualInp>>();
  public Structured Encode(ItestCnstFieldDualInpObject input)
    => _itestRefCnstFieldDualInp.Encode(input);
}

internal class testRefCnstFieldDualInpEncoder<TRef>(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstFieldDualInpObject<TRef>>
{
  private readonly IEncoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public Structured Encode(ItestRefCnstFieldDualInpObject<TRef> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _ref);
}

internal class testPrntCnstFieldDualInpEncoder : IEncoder<ItestPrntCnstFieldDualInpObject>
{
  public Structured Encode(ItestPrntCnstFieldDualInpObject input)
    => Structured.Empty();
}

internal class testAltCnstFieldDualInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstFieldDualInpObject>
{
  private readonly IEncoder<ItestPrntCnstFieldDualInpObject> _itestPrntCnstFieldDualInp = encoders.EncoderFor<ItestPrntCnstFieldDualInpObject>();
  public Structured Encode(ItestAltCnstFieldDualInpObject input)
    => _itestPrntCnstFieldDualInp.Encode(input)
      .Add("alt", input.Alt);
}
