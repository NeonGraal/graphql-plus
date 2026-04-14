//HintName: test_descr-backslash_Dec.gen.cs
// Generated from {CurrentDirectory}descr-backslash.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_descr_backslash;

internal class testDescrBcksDecoder
{
}

internal static class test_descr_backslashDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_descr_backslashDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDescrBcksObject>(_ => new testDescrBcksDecoder());
}
