//HintName: test_constraint-field-obj+Output_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-field-obj+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_obj_Output;

internal class testCnstFieldObjOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstFieldObjOutpObject>
{
  private readonly IEncoder<ItestRefCnstFieldObjOutpObject<ItestAltCnstFieldObjOutp>> _itestRefCnstFieldObjOutp = encoders.EncoderFor<ItestRefCnstFieldObjOutpObject<ItestAltCnstFieldObjOutp>>();
  public Structured Encode(ItestCnstFieldObjOutpObject input)
    => _itestRefCnstFieldObjOutp.Encode(input);

  internal static testCnstFieldObjOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefCnstFieldObjOutpEncoder<TRef>(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstFieldObjOutpObject<TRef>>
{
  private readonly IEncoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public Structured Encode(ItestRefCnstFieldObjOutpObject<TRef> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _ref);
}

internal class testPrntCnstFieldObjOutpEncoder : IEncoder<ItestPrntCnstFieldObjOutpObject>
{
  public Structured Encode(ItestPrntCnstFieldObjOutpObject input)
    => Structured.Empty();

  internal static testPrntCnstFieldObjOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltCnstFieldObjOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstFieldObjOutpObject>
{
  private readonly IEncoder<ItestPrntCnstFieldObjOutpObject> _itestPrntCnstFieldObjOutp = encoders.EncoderFor<ItestPrntCnstFieldObjOutpObject>();
  public Structured Encode(ItestAltCnstFieldObjOutpObject input)
    => _itestPrntCnstFieldObjOutp.Encode(input)
      .Add("alt", input.Alt);

  internal static testAltCnstFieldObjOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal static class test_constraint_field_obj_OutputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_constraint_field_obj_OutputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestCnstFieldObjOutpObject>(testCnstFieldObjOutpEncoder.Factory)
      .AddEncoder<ItestPrntCnstFieldObjOutpObject>(testPrntCnstFieldObjOutpEncoder.Factory)
      .AddEncoder<ItestAltCnstFieldObjOutpObject>(testAltCnstFieldObjOutpEncoder.Factory);
}
