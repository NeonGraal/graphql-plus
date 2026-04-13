//HintName: test_constraint-field-obj+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-field-obj+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_obj_Dual;

internal class testCnstFieldObjDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstFieldObjDualObject>
{
  private readonly IEncoder<ItestRefCnstFieldObjDualObject<ItestAltCnstFieldObjDual>> _itestRefCnstFieldObjDualObject<ItestAltCnstFieldObjDual> = encoders.EncoderFor<ItestRefCnstFieldObjDualObject<ItestAltCnstFieldObjDual>>();
  public Structured Encode(ItestCnstFieldObjDualObject input)
    => _itestRefCnstFieldObjDualObject<ItestAltCnstFieldObjDual>.Encode(input);
}

internal class testRefCnstFieldObjDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstFieldObjDualObject<TRef>>
{
  private readonly IEncoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public Structured Encode(ItestRefCnstFieldObjDualObject<TRef> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _ref);
}

internal class testPrntCnstFieldObjDualEncoder : IEncoder<ItestPrntCnstFieldObjDualObject>
{
  public Structured Encode(ItestPrntCnstFieldObjDualObject input)
    => Structured.Empty();
}

internal class testAltCnstFieldObjDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstFieldObjDualObject>
{
  private readonly IEncoder<ItestPrntCnstFieldObjDualObject> _itestPrntCnstFieldObjDual = encoders.EncoderFor<ItestPrntCnstFieldObjDualObject>();
  public Structured Encode(ItestAltCnstFieldObjDualObject input)
    => _itestPrntCnstFieldObjDual.Encode(input)
      .Add("alt", input.Alt);
}
