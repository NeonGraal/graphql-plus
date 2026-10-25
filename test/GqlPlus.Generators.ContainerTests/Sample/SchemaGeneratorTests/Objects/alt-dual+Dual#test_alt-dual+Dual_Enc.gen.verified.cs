//HintName: test_alt-dual+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}alt-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_dual_Dual;

internal class testAltDualDualEncoder : IEncoder<ItestAltDualDualObject>
{
  public IGqlpValue Encode(ItestAltDualDualObject input)
    => new GqlpUnit();

  internal static testAltDualDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjDualAltDualDualEncoder : IEncoder<ItestObjDualAltDualDualObject>
{
  public IGqlpValue Encode(ItestObjDualAltDualDualObject input)
    => new GqlpUnit()
      .Add("alt", input.Alt.Encode());

  internal static testObjDualAltDualDualEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_alt_dual_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_alt_dual_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestAltDualDualObject>(testAltDualDualEncoder.Factory)
      .AddEncoder<ItestObjDualAltDualDualObject>(testObjDualAltDualDualEncoder.Factory);
}
