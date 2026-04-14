//HintName: test_object-alias+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}object-alias+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_alias_Dual;

internal class testObjAliasDualEncoder : IEncoder<ItestObjAliasDualObject>
{
  public Structured Encode(ItestObjAliasDualObject input)
    => Structured.Empty();
}

internal static class test_object_alias_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_object_alias_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestObjAliasDualObject>(_ => new testObjAliasDualEncoder());
}
