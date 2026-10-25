//HintName: test_constraint-field-obj+Input_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-field-obj+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_obj_Input;

internal class testCnstFieldObjInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstFieldObjInpObject>
{
  private readonly Encoder<ItestRefCnstFieldObjInpObject<ItestAltCnstFieldObjInp>> _itestRefCnstFieldObjInp = encoders.EncoderFor<ItestRefCnstFieldObjInpObject<ItestAltCnstFieldObjInp>>();
  public IGqlpValue Encode(ItestCnstFieldObjInpObject input)
    => _itestRefCnstFieldObjInp.Encode(input);

  internal static testCnstFieldObjInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefCnstFieldObjInpEncoder<TRef>(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstFieldObjInpObject<TRef>>
{
  private readonly Encoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public IGqlpValue Encode(ItestRefCnstFieldObjInpObject<TRef> input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _ref);
}

internal class testPrntCnstFieldObjInpEncoder : IEncoder<ItestPrntCnstFieldObjInpObject>
{
  public IGqlpValue Encode(ItestPrntCnstFieldObjInpObject input)
    => new GqlpUnit();

  internal static testPrntCnstFieldObjInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltCnstFieldObjInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstFieldObjInpObject>
{
  private readonly Encoder<ItestPrntCnstFieldObjInpObject> _itestPrntCnstFieldObjInp = encoders.EncoderFor<ItestPrntCnstFieldObjInpObject>();
  public IGqlpValue Encode(ItestAltCnstFieldObjInpObject input)
    => _itestPrntCnstFieldObjInp.Encode(input)
      .Add("alt", input.Alt.Encode());

  internal static testAltCnstFieldObjInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal static class test_constraint_field_obj_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_constraint_field_obj_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestCnstFieldObjInpObject>(testCnstFieldObjInpEncoder.Factory)
      .AddEncoder<ItestPrntCnstFieldObjInpObject>(testPrntCnstFieldObjInpEncoder.Factory)
      .AddEncoder<ItestAltCnstFieldObjInpObject>(testAltCnstFieldObjInpEncoder.Factory);
}
