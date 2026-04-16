//HintName: test_object-parent+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}object-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_parent_Dual;

internal class testObjPrntDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestObjPrntDualObject>
{
  private readonly IEncoder<ItestRefObjPrntDualObject> _itestRefObjPrntDual = encoders.EncoderFor<ItestRefObjPrntDualObject>();
  public Structured Encode(ItestObjPrntDualObject input)
    => _itestRefObjPrntDual.Encode(input);

  internal static testObjPrntDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefObjPrntDualEncoder : IEncoder<ItestRefObjPrntDualObject>
{
  public Structured Encode(ItestRefObjPrntDualObject input)
    => Structured.Empty();

  internal static testRefObjPrntDualEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_object_parent_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_object_parent_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestObjPrntDualObject>(testObjPrntDualEncoder.Factory)
      .AddEncoder<ItestRefObjPrntDualObject>(testRefObjPrntDualEncoder.Factory);
}
