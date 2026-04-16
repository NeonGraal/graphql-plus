//HintName: test_parent-alt+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}parent-alt+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_alt_Dual;

internal class testPrntAltDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntAltDualObject>
{
  private readonly IEncoder<ItestRefPrntAltDualObject> _itestRefPrntAltDual = encoders.EncoderFor<ItestRefPrntAltDualObject>();
  public Structured Encode(ItestPrntAltDualObject input)
    => _itestRefPrntAltDual.Encode(input);

  internal static testPrntAltDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefPrntAltDualEncoder : IEncoder<ItestRefPrntAltDualObject>
{
  public Structured Encode(ItestRefPrntAltDualObject input)
    => Structured.Empty()
      .Add("parent", input.Parent);

  internal static testRefPrntAltDualEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_parent_alt_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_parent_alt_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestPrntAltDualObject>(testPrntAltDualEncoder.Factory)
      .AddEncoder<ItestRefPrntAltDualObject>(testRefPrntAltDualEncoder.Factory);
}
