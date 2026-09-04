//HintName: test_field-mod-Enum+Input_Enc.gen.cs
// Generated from {CurrentDirectory}field-mod-Enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_mod_Enum_Input;

internal class testFieldModEnumInpEncoder : IEncoder<ItestFieldModEnumInpObject>
{
  public Structured Encode(ItestFieldModEnumInpObject input)
    => Structured.Empty();

  internal static testFieldModEnumInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumFieldModEnumInpEncoder : IEncoder<testEnumFieldModEnumInp>
{
  public Structured Encode(testEnumFieldModEnumInp input)
    => input.EncodeEnum("EnumFieldModEnumInp");

  internal static testEnumFieldModEnumInpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_field_mod_Enum_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_field_mod_Enum_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestFieldModEnumInpObject>(testFieldModEnumInpEncoder.Factory)
      .AddEncoder<testEnumFieldModEnumInp>(testEnumFieldModEnumInpEncoder.Factory);
}
