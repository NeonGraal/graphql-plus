//HintName: test_directive-param-in_Dec.gen.cs
// Generated from {CurrentDirectory}directive-param-in.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_directive_param_in;

internal class testInDrctParamInDecoder
{
}

internal static class test_directive_param_inDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_directive_param_inDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestInDrctParamInObject>(_ => new testInDrctParamInDecoder());
}
