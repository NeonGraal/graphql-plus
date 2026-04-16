//HintName: test_constraint-field-dual+Output_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-field-dual+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_dual_Output;

internal class testCnstFieldDualOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstFieldDualOutpObject>
{
  private readonly IEncoder<ItestRefCnstFieldDualOutpObject<ItestAltCnstFieldDualOutp>> _itestRefCnstFieldDualOutp = encoders.EncoderFor<ItestRefCnstFieldDualOutpObject<ItestAltCnstFieldDualOutp>>();
  public Structured Encode(ItestCnstFieldDualOutpObject input)
    => _itestRefCnstFieldDualOutp.Encode(input);

  internal static testCnstFieldDualOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefCnstFieldDualOutpEncoder<TRef>(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstFieldDualOutpObject<TRef>>
{
  private readonly IEncoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public Structured Encode(ItestRefCnstFieldDualOutpObject<TRef> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _ref);
}

internal class testPrntCnstFieldDualOutpEncoder : IEncoder<ItestPrntCnstFieldDualOutpObject>
{
  public Structured Encode(ItestPrntCnstFieldDualOutpObject input)
    => Structured.Empty();

  internal static testPrntCnstFieldDualOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltCnstFieldDualOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstFieldDualOutpObject>
{
  private readonly IEncoder<ItestPrntCnstFieldDualOutpObject> _itestPrntCnstFieldDualOutp = encoders.EncoderFor<ItestPrntCnstFieldDualOutpObject>();
  public Structured Encode(ItestAltCnstFieldDualOutpObject input)
    => _itestPrntCnstFieldDualOutp.Encode(input)
      .Add("alt", input.Alt);

  internal static testAltCnstFieldDualOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal static class test_constraint_field_dual_OutputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_constraint_field_dual_OutputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestCnstFieldDualOutpObject>(testCnstFieldDualOutpEncoder.Factory)
      .AddEncoder<ItestPrntCnstFieldDualOutpObject>(testPrntCnstFieldDualOutpEncoder.Factory)
      .AddEncoder<ItestAltCnstFieldDualOutpObject>(testAltCnstFieldDualOutpEncoder.Factory);
}
