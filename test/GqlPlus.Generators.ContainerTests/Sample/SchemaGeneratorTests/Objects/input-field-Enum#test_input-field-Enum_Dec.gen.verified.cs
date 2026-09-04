//HintName: test_input-field-Enum_Dec.gen.cs
// Generated from {CurrentDirectory}input-field-Enum.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_input_field_Enum;

internal class testInpFieldEnumDecoder : NullDecoder<ItestInpFieldEnumObject>
{
  public testEnumInpFieldEnum Field { get; set; } = default!;

  internal static testInpFieldEnumDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumInpFieldEnumDecoder : NullDecoder<testEnumInpFieldEnum>
{
  public string inpFieldEnum { get; set; } = default!;

  internal static testEnumInpFieldEnumDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_input_field_EnumDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_input_field_EnumDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestInpFieldEnumObject>(testInpFieldEnumDecoder.Factory)
      .AddDecoder<testEnumInpFieldEnum>(testEnumInpFieldEnumDecoder.Factory);
}
