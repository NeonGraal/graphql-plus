//HintName: test_generic-parent-simple-enum+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent-simple-enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_simple_enum_Input;

internal class testEnumGnrcPrntSmplEnumInpEncoder : IEncoder<testEnumGnrcPrntSmplEnumInp>
{
  public Structured Encode(testEnumGnrcPrntSmplEnumInp input)
    => new(input.ToString(), "_EnumGnrcPrntSmplEnumInp");

  internal static testEnumGnrcPrntSmplEnumInpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_generic_parent_simple_enum_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_generic_parent_simple_enum_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<testEnumGnrcPrntSmplEnumInp>(testEnumGnrcPrntSmplEnumInpEncoder.Factory);
}
