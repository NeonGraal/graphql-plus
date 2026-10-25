//HintName: test_constraint-alt-dual+Output_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-alt-dual+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_dual_Output;

internal class testCnstAltDualOutpEncoder : IEncoder<ItestCnstAltDualOutpObject>
{
  public IGqlpValue Encode(ItestCnstAltDualOutpObject input)
    => new GqlpUnit();

  internal static testCnstAltDualOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefCnstAltDualOutpEncoder<TRef> : IEncoder<ItestRefCnstAltDualOutpObject<TRef>>
{
  public IGqlpValue Encode(ItestRefCnstAltDualOutpObject<TRef> input)
    => new GqlpUnit();
}

internal class testPrntCnstAltDualOutpEncoder : IEncoder<ItestPrntCnstAltDualOutpObject>
{
  public IGqlpValue Encode(ItestPrntCnstAltDualOutpObject input)
    => new GqlpUnit();

  internal static testPrntCnstAltDualOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltCnstAltDualOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstAltDualOutpObject>
{
  private readonly Encoder<ItestPrntCnstAltDualOutpObject> _itestPrntCnstAltDualOutp = encoders.EncoderFor<ItestPrntCnstAltDualOutpObject>();
  public IGqlpValue Encode(ItestAltCnstAltDualOutpObject input)
    => _itestPrntCnstAltDualOutp.Encode(input)
      .Add("alt", input.Alt.Encode());

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
