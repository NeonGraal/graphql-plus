//HintName: test_constraint-alt-dual+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-alt-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_dual_Dual;

internal class testCnstAltDualDualEncoder : IEncoder<ItestCnstAltDualDualObject>
{
  public IGqlpValue Encode(ItestCnstAltDualDualObject input)
    => new GqlpUnit();

  internal static testCnstAltDualDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefCnstAltDualDualEncoder<TRef> : IEncoder<ItestRefCnstAltDualDualObject<TRef>>
{
  public IGqlpValue Encode(ItestRefCnstAltDualDualObject<TRef> input)
    => new GqlpUnit();
}

internal class testPrntCnstAltDualDualEncoder : IEncoder<ItestPrntCnstAltDualDualObject>
{
  public IGqlpValue Encode(ItestPrntCnstAltDualDualObject input)
    => new GqlpUnit();

  internal static testPrntCnstAltDualDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltCnstAltDualDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstAltDualDualObject>
{
  private readonly Encoder<ItestPrntCnstAltDualDualObject> _itestPrntCnstAltDualDual = encoders.EncoderFor<ItestPrntCnstAltDualDualObject>();
  public IGqlpValue Encode(ItestAltCnstAltDualDualObject input)
    => _itestPrntCnstAltDualDual.Encode(input)
      .Add("alt", input.Alt.Encode());

  internal static testAltCnstAltDualDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal static class test_constraint_alt_dual_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_constraint_alt_dual_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestCnstAltDualDualObject>(testCnstAltDualDualEncoder.Factory)
      .AddEncoder<ItestPrntCnstAltDualDualObject>(testPrntCnstAltDualDualEncoder.Factory)
      .AddEncoder<ItestAltCnstAltDualDualObject>(testAltCnstAltDualDualEncoder.Factory);
}
