//HintName: test_descr-between_Dec.gen.cs
// Generated from {CurrentDirectory}descr-between.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_descr_between;

internal class testDescrBtwnDecoder
{
}

internal static class test_descr_betweenDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_descr_betweenDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDescrBtwnObject>(_ => new testDescrBtwnDecoder());
}
