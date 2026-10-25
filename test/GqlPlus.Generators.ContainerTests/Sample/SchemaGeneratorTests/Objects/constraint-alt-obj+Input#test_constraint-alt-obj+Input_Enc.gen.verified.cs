//HintName: test_constraint-alt-obj+Input_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-alt-obj+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_obj_Input;

internal class testCnstAltObjInpEncoder : IEncoder<ItestCnstAltObjInpObject>
{
  public IGqlpValue Encode(ItestCnstAltObjInpObject input)
    => new GqlpUnit();

  internal static testCnstAltObjInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefCnstAltObjInpEncoder<TRef> : IEncoder<ItestRefCnstAltObjInpObject<TRef>>
{
  public IGqlpValue Encode(ItestRefCnstAltObjInpObject<TRef> input)
    => new GqlpUnit();
}

internal class testPrntCnstAltObjInpEncoder : IEncoder<ItestPrntCnstAltObjInpObject>
{
  public IGqlpValue Encode(ItestPrntCnstAltObjInpObject input)
    => new GqlpUnit();

  internal static testPrntCnstAltObjInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltCnstAltObjInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstAltObjInpObject>
{
  private readonly Encoder<ItestPrntCnstAltObjInpObject> _itestPrntCnstAltObjInp = encoders.EncoderFor<ItestPrntCnstAltObjInpObject>();
  public IGqlpValue Encode(ItestAltCnstAltObjInpObject input)
    => _itestPrntCnstAltObjInp.Encode(input)
      .Add("alt", input.Alt.Encode());

  internal static testAltCnstAltObjInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal static class test_constraint_alt_obj_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_constraint_alt_obj_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestCnstAltObjInpObject>(testCnstAltObjInpEncoder.Factory)
      .AddEncoder<ItestPrntCnstAltObjInpObject>(testPrntCnstAltObjInpEncoder.Factory)
      .AddEncoder<ItestAltCnstAltObjInpObject>(testAltCnstAltObjInpEncoder.Factory);
}
