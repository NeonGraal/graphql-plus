//HintName: test_descr-complex_Dec.gen.cs
// Generated from {CurrentDirectory}descr-complex.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_descr_complex;

internal class testDescrCmplDecoder
{
}

internal static class test_descr_complexDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_descr_complexDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDescrCmplObject>(_ => new testDescrCmplDecoder());
}
