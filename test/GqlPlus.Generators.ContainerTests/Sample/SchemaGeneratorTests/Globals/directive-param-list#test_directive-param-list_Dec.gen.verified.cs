//HintName: test_directive-param-list_Dec.gen.cs
// Generated from {CurrentDirectory}directive-param-list.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_directive_param_list;

internal class testInDrctParamListDecoder
{

  internal static testInDrctParamListDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_directive_param_listDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_directive_param_listDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestInDrctParamListObject>(testInDrctParamListDecoder.Factory);
}
