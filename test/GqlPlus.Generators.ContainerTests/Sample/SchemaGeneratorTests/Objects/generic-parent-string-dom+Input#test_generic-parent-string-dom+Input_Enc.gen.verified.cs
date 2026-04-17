//HintName: test_generic-parent-string-dom+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent-string-dom+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_string_dom_Input;

internal class testDomGnrcPrntStrDomInpEncoder : IEncoder<ItestDomGnrcPrntStrDomInp>
{
  public Structured Encode(ItestDomGnrcPrntStrDomInp input)
    => new(input.Value);

  internal static testDomGnrcPrntStrDomInpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_generic_parent_string_dom_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_generic_parent_string_dom_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestDomGnrcPrntStrDomInp>(testDomGnrcPrntStrDomInpEncoder.Factory);
}
