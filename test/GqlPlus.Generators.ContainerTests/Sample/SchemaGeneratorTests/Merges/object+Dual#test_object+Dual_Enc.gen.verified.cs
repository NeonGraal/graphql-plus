//HintName: test_object+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}object+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_Dual;

internal class testObjDualEncoder : IEncoder<ItestObjDualObject>
{
  public Structured Encode(ItestObjDualObject input)
    => Structured.Empty();
}

internal static class test_object_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_object_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestObjDualObject>(_ => new testObjDualEncoder());
}
