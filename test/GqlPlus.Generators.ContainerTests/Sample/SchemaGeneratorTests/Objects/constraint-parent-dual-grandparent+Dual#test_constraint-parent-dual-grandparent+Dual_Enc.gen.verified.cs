//HintName: test_constraint-parent-dual-grandparent+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-parent-dual-grandparent+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_parent_dual_grandparent_Dual;

internal class testCnstPrntDualGrndDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstPrntDualGrndDualObject>
{
  private readonly IEncoder<ItestRefCnstPrntDualGrndDualObject<ItestAltCnstPrntDualGrndDual>> _itestRefCnstPrntDualGrndDual = encoders.EncoderFor<ItestRefCnstPrntDualGrndDualObject<ItestAltCnstPrntDualGrndDual>>();
  public Structured Encode(ItestCnstPrntDualGrndDualObject input)
    => _itestRefCnstPrntDualGrndDual.Encode(input);

  internal static testCnstPrntDualGrndDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefCnstPrntDualGrndDualEncoder<TRef> : IEncoder<ItestRefCnstPrntDualGrndDualObject<TRef>>
{
  public Structured Encode(ItestRefCnstPrntDualGrndDualObject<TRef> input)
    => Structured.Empty();
}

internal class testGrndCnstPrntDualGrndDualEncoder : IEncoder<ItestGrndCnstPrntDualGrndDualObject>
{
  public Structured Encode(ItestGrndCnstPrntDualGrndDualObject input)
    => Structured.Empty();

  internal static testGrndCnstPrntDualGrndDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntCnstPrntDualGrndDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntCnstPrntDualGrndDualObject>
{
  private readonly IEncoder<ItestGrndCnstPrntDualGrndDualObject> _itestGrndCnstPrntDualGrndDual = encoders.EncoderFor<ItestGrndCnstPrntDualGrndDualObject>();
  public Structured Encode(ItestPrntCnstPrntDualGrndDualObject input)
    => _itestGrndCnstPrntDualGrndDual.Encode(input);

  internal static testPrntCnstPrntDualGrndDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testAltCnstPrntDualGrndDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstPrntDualGrndDualObject>
{
  private readonly IEncoder<ItestPrntCnstPrntDualGrndDualObject> _itestPrntCnstPrntDualGrndDual = encoders.EncoderFor<ItestPrntCnstPrntDualGrndDualObject>();
  public Structured Encode(ItestAltCnstPrntDualGrndDualObject input)
    => _itestPrntCnstPrntDualGrndDual.Encode(input)
      .Add("alt", input.Alt);

  internal static testAltCnstPrntDualGrndDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal static class test_constraint_parent_dual_grandparent_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_constraint_parent_dual_grandparent_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestCnstPrntDualGrndDualObject>(testCnstPrntDualGrndDualEncoder.Factory)
      .AddEncoder<ItestGrndCnstPrntDualGrndDualObject>(testGrndCnstPrntDualGrndDualEncoder.Factory)
      .AddEncoder<ItestPrntCnstPrntDualGrndDualObject>(testPrntCnstPrntDualGrndDualEncoder.Factory)
      .AddEncoder<ItestAltCnstPrntDualGrndDualObject>(testAltCnstPrntDualGrndDualEncoder.Factory);
}
