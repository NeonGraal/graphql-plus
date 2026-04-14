//HintName: test_descr_Dec.gen.cs
// Generated from {CurrentDirectory}descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_descr;

internal class testDescrDecoder
{
}

internal static class test_descrDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_descrDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDescrObject>(_ => new testDescrDecoder());
}
