//HintName: test_constraint-alt-dual+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-alt-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_dual_Dual;

internal class testCnstAltDualDualEncoder : IEncoder<ItestCnstAltDualDualObject>
{
  public Structured Encode(ItestCnstAltDualDualObject input)
    => Structured.Empty();

  internal static testCnstAltDualDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefCnstAltDualDualEncoder<TRef> : IEncoder<ItestRefCnstAltDualDualObject<TRef>>
{
  public Structured Encode(ItestRefCnstAltDualDualObject<TRef> input)
    => Structured.Empty();
}

internal class testPrntCnstAltDualDualEncoder : IEncoder<ItestPrntCnstAltDualDualObject>
{
  public Structured Encode(ItestPrntCnstAltDualDualObject input)
    => Structured.Empty();

  internal static testPrntCnstAltDualDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltCnstAltDualDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstAltDualDualObject>
{
  private readonly IEncoder<ItestPrntCnstAltDualDualObject> _itestPrntCnstAltDualDual = encoders.EncoderFor<ItestPrntCnstAltDualDualObject>();
  public Structured Encode(ItestAltCnstAltDualDualObject input)
    => _itestPrntCnstAltDualDual.Encode(input)
      .Add("alt", input.Alt);

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
