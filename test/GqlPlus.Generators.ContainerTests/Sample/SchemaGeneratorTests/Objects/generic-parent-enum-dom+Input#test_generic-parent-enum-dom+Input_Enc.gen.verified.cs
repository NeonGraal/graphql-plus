//HintName: test_generic-parent-enum-dom+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-dom+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_dom_Input;

internal class testEnumGnrcPrntEnumDomInpEncoder : IEncoder<testEnumGnrcPrntEnumDomInp>
{
  public Structured Encode(testEnumGnrcPrntEnumDomInp input)
    => input.EncodeEnum("EnumGnrcPrntEnumDomInp");

  internal static testEnumGnrcPrntEnumDomInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testDomGnrcPrntEnumDomInpEncoder : IEncoder<ItestDomGnrcPrntEnumDomInp>
{
  public Structured Encode(ItestDomGnrcPrntEnumDomInp input)
    => input.Value?.EncodeEnum("testEnumGnrcPrntEnumDomInp") ?? Structured.Empty("testEnumGnrcPrntEnumDomInp");

  internal static testDomGnrcPrntEnumDomInpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_generic_parent_enum_dom_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_generic_parent_enum_dom_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<testEnumGnrcPrntEnumDomInp>(testEnumGnrcPrntEnumDomInpEncoder.Factory)
      .AddEncoder<ItestDomGnrcPrntEnumDomInp>(testDomGnrcPrntEnumDomInpEncoder.Factory);
}
