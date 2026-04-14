//HintName: test_descr-double_Dec.gen.cs
// Generated from {CurrentDirectory}descr-double.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_descr_double;

internal class testDescrDblDecoder
{
}

internal static class test_descr_doubleDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_descr_doubleDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDescrDblObject>(_ => new testDescrDblDecoder());
}
