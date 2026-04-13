//HintName: test_constraint-field-dual+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-field-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_dual_Dual;

internal class testCnstFieldDualDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstFieldDualDualObject>
{
  private readonly IEncoder<ItestRefCnstFieldDualDualObject<ItestAltCnstFieldDualDual>> _itestRefCnstFieldDualDualObject<ItestAltCnstFieldDualDual> = encoders.EncoderFor<ItestRefCnstFieldDualDualObject<ItestAltCnstFieldDualDual>>();
  public Structured Encode(ItestCnstFieldDualDualObject input)
    => _itestRefCnstFieldDualDualObject<ItestAltCnstFieldDualDual>.Encode(input);
}

internal class testRefCnstFieldDualDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstFieldDualDualObject<TRef>>
{
  private readonly IEncoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public Structured Encode(ItestRefCnstFieldDualDualObject<TRef> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _ref);
}

internal class testPrntCnstFieldDualDualEncoder : IEncoder<ItestPrntCnstFieldDualDualObject>
{
  public Structured Encode(ItestPrntCnstFieldDualDualObject input)
    => Structured.Empty();
}

internal class testAltCnstFieldDualDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstFieldDualDualObject>
{
  private readonly IEncoder<ItestPrntCnstFieldDualDualObject> _itestPrntCnstFieldDualDual = encoders.EncoderFor<ItestPrntCnstFieldDualDualObject>();
  public Structured Encode(ItestAltCnstFieldDualDualObject input)
    => _itestPrntCnstFieldDualDual.Encode(input)
      .Add("alt", input.Alt);
}
