//HintName: test_field-mod-Enum+Output_Dec.gen.cs
// Generated from {CurrentDirectory}field-mod-Enum+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_mod_Enum_Output;

internal class testEnumFieldModEnumOutpDecoder : IDecoder<testEnumFieldModEnumOutp?>
{
  public IMessages Decoder(IValue input, out testEnumFieldModEnumOutp? output)
    => input.DecodeEnum("EnumFieldModEnumOutp", out output);

  internal static testEnumFieldModEnumOutpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_field_mod_Enum_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_field_mod_Enum_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<testEnumFieldModEnumOutp?>(testEnumFieldModEnumOutpDecoder.Factory);
}
