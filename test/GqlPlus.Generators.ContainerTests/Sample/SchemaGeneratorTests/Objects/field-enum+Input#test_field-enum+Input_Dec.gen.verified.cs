//HintName: test_field-enum+Input_Dec.gen.cs
// Generated from {CurrentDirectory}field-enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_enum_Input;

internal class testFieldEnumInpDecoder
{
  public testEnumFieldEnumInp Field { get; set; }

  internal static testFieldEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumFieldEnumInpDecoder : IDecoder<testEnumFieldEnumInp?>
{
  public IMessages Decoder(IValue input, out testEnumFieldEnumInp? output)
    => input.DecodeEnum("EnumFieldEnumInp", out output);

  internal static testEnumFieldEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_field_enum_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_field_enum_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestFieldEnumInpObject>(testFieldEnumInpDecoder.Factory)
      .AddDecoder<testEnumFieldEnumInp?>(testEnumFieldEnumInpDecoder.Factory);
}
