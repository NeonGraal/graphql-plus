//HintName: test_generic-parent-enum-dom+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-dom+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_dom_Input;

internal class testEnumGnrcPrntEnumDomInpEncoder : IEncoder<testEnumGnrcPrntEnumDomInp>
{
  public Structured Encode(testEnumGnrcPrntEnumDomInp input)
    => new(input.ToString(), "_EnumGnrcPrntEnumDomInp");
}

internal class testDomGnrcPrntEnumDomInpEncoder : IEncoder<ItestDomGnrcPrntEnumDomInp>
{
  public Structured Encode(ItestDomGnrcPrntEnumDomInp input)
    => new((decimal?)input.Value);
}

internal static class test_generic_parent_enum_dom_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_generic_parent_enum_dom_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<testEnumGnrcPrntEnumDomInp>(_ => new testEnumGnrcPrntEnumDomInpEncoder())
      .AddEncoder<ItestDomGnrcPrntEnumDomInp>(_ => new testDomGnrcPrntEnumDomInpEncoder());
}
