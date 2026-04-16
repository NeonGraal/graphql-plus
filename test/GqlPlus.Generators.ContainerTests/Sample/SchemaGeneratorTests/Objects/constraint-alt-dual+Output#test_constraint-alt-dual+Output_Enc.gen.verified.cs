//HintName: test_constraint-alt-dual+Output_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-alt-dual+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_dual_Output;

internal class testCnstAltDualOutpEncoder : IEncoder<ItestCnstAltDualOutpObject>
{
  public Structured Encode(ItestCnstAltDualOutpObject input)
    => Structured.Empty();

  internal static testCnstAltDualOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefCnstAltDualOutpEncoder<TRef> : IEncoder<ItestRefCnstAltDualOutpObject<TRef>>
{
  public Structured Encode(ItestRefCnstAltDualOutpObject<TRef> input)
    => Structured.Empty();
}

internal class testPrntCnstAltDualOutpEncoder : IEncoder<ItestPrntCnstAltDualOutpObject>
{
  public Structured Encode(ItestPrntCnstAltDualOutpObject input)
    => Structured.Empty();

  internal static testPrntCnstAltDualOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltCnstAltDualOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstAltDualOutpObject>
{
  private readonly IEncoder<ItestPrntCnstAltDualOutpObject> _itestPrntCnstAltDualOutp = encoders.EncoderFor<ItestPrntCnstAltDualOutpObject>();
  public Structured Encode(ItestAltCnstAltDualOutpObject input)
    => _itestPrntCnstAltDualOutp.Encode(input)
      .Add("alt", input.Alt);

  internal static testAltCnstAltDualOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal static class test_constraint_alt_dual_OutputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_constraint_alt_dual_OutputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestCnstAltDualOutpObject>(testCnstAltDualOutpEncoder.Factory)
      .AddEncoder<ItestPrntCnstAltDualOutpObject>(testPrntCnstAltDualOutpEncoder.Factory)
      .AddEncoder<ItestAltCnstAltDualOutpObject>(testAltCnstAltDualOutpEncoder.Factory);
}
