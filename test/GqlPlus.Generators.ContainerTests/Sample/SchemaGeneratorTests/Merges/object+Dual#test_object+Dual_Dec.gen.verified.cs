//HintName: test_object+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}object+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_Dual;

internal class testObjDualDecoder
{
}

internal static class test_object_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_object_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestObjDualObject>(_ => new testObjDualDecoder());
}
