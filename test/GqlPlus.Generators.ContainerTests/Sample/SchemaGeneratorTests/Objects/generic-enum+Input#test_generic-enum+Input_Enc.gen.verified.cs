//HintName: test_generic-enum+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_enum_Input;

internal class testEnumGnrcEnumInpEncoder : IEncoder<testEnumGnrcEnumInp>
{
  public Structured Encode(testEnumGnrcEnumInp input)
    => new(input.ToString(), "_EnumGnrcEnumInp");
}

internal static class test_generic_enum_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_generic_enum_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<testEnumGnrcEnumInp>(_ => new testEnumGnrcEnumInpEncoder());
}
