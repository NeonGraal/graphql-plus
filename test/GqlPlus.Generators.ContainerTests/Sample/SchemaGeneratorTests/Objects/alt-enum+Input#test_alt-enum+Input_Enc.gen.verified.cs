//HintName: test_alt-enum+Input_Enc.gen.cs
// Generated from {CurrentDirectory}alt-enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_enum_Input;

internal class testAltEnumInpEncoder : IEncoder<ItestAltEnumInpObject>
{
  public Structured Encode(ItestAltEnumInpObject input)
    => Structured.Empty();

  internal static testAltEnumInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumAltEnumInpEncoder : IEncoder<testEnumAltEnumInp>
{
  public Structured Encode(testEnumAltEnumInp input)
    => input.EncodeEnum("EnumAltEnumInp");

  internal static testEnumAltEnumInpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_alt_enum_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_alt_enum_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestAltEnumInpObject>(testAltEnumInpEncoder.Factory)
      .AddEncoder<testEnumAltEnumInp>(testEnumAltEnumInpEncoder.Factory);
}
