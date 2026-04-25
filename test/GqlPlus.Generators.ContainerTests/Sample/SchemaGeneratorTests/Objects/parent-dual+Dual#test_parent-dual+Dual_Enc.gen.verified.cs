//HintName: test_parent-dual+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}parent-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_dual_Dual;

internal class testPrntDualDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntDualDualObject>
{
  private readonly IEncoder<ItestRefPrntDualDualObject> _itestRefPrntDualDual = encoders.EncoderFor<ItestRefPrntDualDualObject>();
  public Structured Encode(ItestPrntDualDualObject input)
    => _itestRefPrntDualDual.Encode(input);

  internal static testPrntDualDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefPrntDualDualEncoder : IEncoder<ItestRefPrntDualDualObject>
{
  public Structured Encode(ItestRefPrntDualDualObject input)
    => Structured.Empty()
      .Add("parent", input.Parent.Encode());

  internal static testRefPrntDualDualEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_parent_dual_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_parent_dual_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestPrntDualDualObject>(testPrntDualDualEncoder.Factory)
      .AddEncoder<ItestRefPrntDualDualObject>(testRefPrntDualDualEncoder.Factory);
}
