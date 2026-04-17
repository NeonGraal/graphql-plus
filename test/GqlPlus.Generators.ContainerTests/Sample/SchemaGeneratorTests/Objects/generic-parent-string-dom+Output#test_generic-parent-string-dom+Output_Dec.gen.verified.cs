//HintName: test_generic-parent-string-dom+Output_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-string-dom+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_string_dom_Output;

internal class testDomGnrcPrntStrDomOutpDecoder
{

  internal static testDomGnrcPrntStrDomOutpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_generic_parent_string_dom_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_parent_string_dom_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDomGnrcPrntStrDomOutp>(testDomGnrcPrntStrDomOutpDecoder.Factory);
}
