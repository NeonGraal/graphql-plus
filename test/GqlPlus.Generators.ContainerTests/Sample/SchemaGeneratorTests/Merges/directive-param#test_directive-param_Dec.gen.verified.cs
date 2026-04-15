//HintName: test_directive-param_Dec.gen.cs
// Generated from {CurrentDirectory}directive-param.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_directive_param;

internal class testInDrctParamDecoder
{
}

internal static class test_directive_paramDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_directive_paramDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestInDrctParamObject>(_ => new testInDrctParamDecoder());
}
