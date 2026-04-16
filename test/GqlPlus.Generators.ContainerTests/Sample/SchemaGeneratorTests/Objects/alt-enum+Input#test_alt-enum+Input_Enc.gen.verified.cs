//HintName: test_alt-enum+Input_Enc.gen.cs
// Generated from {CurrentDirectory}alt-enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_enum_Input;

internal class testEnumAltEnumInpEncoder : IEncoder<testEnumAltEnumInp>
{
  public Structured Encode(testEnumAltEnumInp input)
    => new(input.ToString(), "_EnumAltEnumInp");

  internal static testEnumAltEnumInpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_alt_enum_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_alt_enum_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<testEnumAltEnumInp>(testEnumAltEnumInpEncoder.Factory);
}
