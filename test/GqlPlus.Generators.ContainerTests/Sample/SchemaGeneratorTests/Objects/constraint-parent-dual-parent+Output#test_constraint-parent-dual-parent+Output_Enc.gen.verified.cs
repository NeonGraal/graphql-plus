//HintName: test_constraint-parent-dual-parent+Output_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-parent-dual-parent+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_parent_Output;

internal class testCnstPrntDualPrntOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstPrntDualPrntOutpObject>
{
  private readonly IEncoder<ItestRefCnstPrntDualPrntOutpObject<ItestAltCnstPrntDualPrntOutp>> _itestRefCnstPrntDualPrntOutp = encoders.EncoderFor<ItestRefCnstPrntDualPrntOutpObject<ItestAltCnstPrntDualPrntOutp>>();
  public Structured Encode(ItestCnstPrntDualPrntOutpObject input)
    => _itestRefCnstPrntDualPrntOutp.Encode(input);

  internal static testCnstPrntDualPrntOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefCnstPrntDualPrntOutpEncoder<TRef> : IEncoder<ItestRefCnstPrntDualPrntOutpObject<TRef>>
{
  public Structured Encode(ItestRefCnstPrntDualPrntOutpObject<TRef> input)
    => Structured.Empty();
}

internal class testPrntCnstPrntDualPrntOutpEncoder : IEncoder<ItestPrntCnstPrntDualPrntOutpObject>
{
  public Structured Encode(ItestPrntCnstPrntDualPrntOutpObject input)
    => Structured.Empty();

  internal static testPrntCnstPrntDualPrntOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltCnstPrntDualPrntOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstPrntDualPrntOutpObject>
{
  private readonly IEncoder<ItestPrntCnstPrntDualPrntOutpObject> _itestPrntCnstPrntDualPrntOutp = encoders.EncoderFor<ItestPrntCnstPrntDualPrntOutpObject>();
  public Structured Encode(ItestAltCnstPrntDualPrntOutpObject input)
    => _itestPrntCnstPrntDualPrntOutp.Encode(input)
      .Add("alt", input.Alt);

  internal static testAltCnstPrntDualPrntOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal static class test_constraint_parent_dual_parent_OutputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_constraint_parent_dual_parent_OutputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestCnstPrntDualPrntOutpObject>(testCnstPrntDualPrntOutpEncoder.Factory)
      .AddEncoder<ItestPrntCnstPrntDualPrntOutpObject>(testPrntCnstPrntDualPrntOutpEncoder.Factory)
      .AddEncoder<ItestAltCnstPrntDualPrntOutpObject>(testAltCnstPrntDualPrntOutpEncoder.Factory);
}
