//HintName: test_directive-param-dict_Dec.gen.cs
// Generated from {CurrentDirectory}directive-param-dict.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_directive_param_dict;

internal class testInDrctParamDictDecoder
{
}

internal static class test_directive_param_dictDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_directive_param_dictDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestInDrctParamDictObject>(_ => new testInDrctParamDictDecoder());
}
