//HintName: test_constraint-parent-dual-parent+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-parent-dual-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_parent_Dual;

internal class testCnstPrntDualPrntDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstPrntDualPrntDualObject>
{
  private readonly IEncoder<ItestRefCnstPrntDualPrntDualObject<ItestAltCnstPrntDualPrntDual>> _itestRefCnstPrntDualPrntDual = encoders.EncoderFor<ItestRefCnstPrntDualPrntDualObject<ItestAltCnstPrntDualPrntDual>>();
  public Structured Encode(ItestCnstPrntDualPrntDualObject input)
    => _itestRefCnstPrntDualPrntDual.Encode(input);

  internal static testCnstPrntDualPrntDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefCnstPrntDualPrntDualEncoder<TRef> : IEncoder<ItestRefCnstPrntDualPrntDualObject<TRef>>
{
  public Structured Encode(ItestRefCnstPrntDualPrntDualObject<TRef> input)
    => Structured.Empty();
}

internal class testPrntCnstPrntDualPrntDualEncoder : IEncoder<ItestPrntCnstPrntDualPrntDualObject>
{
  public Structured Encode(ItestPrntCnstPrntDualPrntDualObject input)
    => Structured.Empty();

  internal static testPrntCnstPrntDualPrntDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltCnstPrntDualPrntDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstPrntDualPrntDualObject>
{
  private readonly IEncoder<ItestPrntCnstPrntDualPrntDualObject> _itestPrntCnstPrntDualPrntDual = encoders.EncoderFor<ItestPrntCnstPrntDualPrntDualObject>();
  public Structured Encode(ItestAltCnstPrntDualPrntDualObject input)
    => _itestPrntCnstPrntDualPrntDual.Encode(input)
      .Add("alt", input.Alt);

  internal static testAltCnstPrntDualPrntDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal static class test_constraint_parent_dual_parent_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_constraint_parent_dual_parent_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestCnstPrntDualPrntDualObject>(testCnstPrntDualPrntDualEncoder.Factory)
      .AddEncoder<ItestPrntCnstPrntDualPrntDualObject>(testPrntCnstPrntDualPrntDualEncoder.Factory)
      .AddEncoder<ItestAltCnstPrntDualPrntDualObject>(testAltCnstPrntDualPrntDualEncoder.Factory);
}
