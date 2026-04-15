//HintName: test_object-alt+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}object-alt+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_alt_Dual;

internal class testObjAltDualEncoder : IEncoder<ItestObjAltDualObject>
{
  public Structured Encode(ItestObjAltDualObject input)
    => Structured.Empty();
}

internal class testObjAltDualTypeEncoder : IEncoder<ItestObjAltDualTypeObject>
{
  public Structured Encode(ItestObjAltDualTypeObject input)
    => Structured.Empty();
}

internal static class test_object_alt_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_object_alt_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestObjAltDualObject>(_ => new testObjAltDualEncoder())
      .AddEncoder<ItestObjAltDualTypeObject>(_ => new testObjAltDualTypeEncoder());
}
