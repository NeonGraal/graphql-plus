//HintName: test_parent+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}parent+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_Dual;

internal class testPrntDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntDualObject>
{
  private readonly IEncoder<ItestRefPrntDualObject> _itestRefPrntDual = encoders.EncoderFor<ItestRefPrntDualObject>();
  public Structured Encode(ItestPrntDualObject input)
    => _itestRefPrntDual.Encode(input);

  internal static testPrntDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefPrntDualEncoder : IEncoder<ItestRefPrntDualObject>
{
  public Structured Encode(ItestRefPrntDualObject input)
    => Structured.Empty()
      .Add("parent", input.Parent);

  internal static testRefPrntDualEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_parent_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_parent_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestPrntDualObject>(testPrntDualEncoder.Factory)
      .AddEncoder<ItestRefPrntDualObject>(testRefPrntDualEncoder.Factory);
}
