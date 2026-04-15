//HintName: test_object-parent+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}object-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_parent_Dual;

internal class testObjPrntDualDecoder
{
}

internal class testRefObjPrntDualDecoder
{
}

internal static class test_object_parent_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_object_parent_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestObjPrntDualObject>(_ => new testObjPrntDualDecoder())
      .AddDecoder<ItestRefObjPrntDualObject>(_ => new testRefObjPrntDualDecoder());
}
