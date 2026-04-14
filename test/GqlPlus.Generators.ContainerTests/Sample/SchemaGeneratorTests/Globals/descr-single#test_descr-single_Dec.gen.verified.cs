//HintName: test_descr-single_Dec.gen.cs
// Generated from {CurrentDirectory}descr-single.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_descr_single;

internal class testDescrSnglDecoder
{
}

internal static class test_descr_singleDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_descr_singleDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDescrSnglObject>(_ => new testDescrSnglDecoder());
}
