//HintName: test_object-alt+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}object-alt+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_alt_Dual;

internal class testObjAltDualEncoder : IEncoder<ItestObjAltDualObject>
{
  public Structured Encode(ItestObjAltDualObject input)
    => Structured.Empty();

  internal static testObjAltDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjAltDualTypeEncoder : IEncoder<ItestObjAltDualTypeObject>
{
  public Structured Encode(ItestObjAltDualTypeObject input)
    => Structured.Empty();

  internal static testObjAltDualTypeEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_object_alt_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_object_alt_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestObjAltDualObject>(testObjAltDualEncoder.Factory)
      .AddEncoder<ItestObjAltDualTypeObject>(testObjAltDualTypeEncoder.Factory);
}
