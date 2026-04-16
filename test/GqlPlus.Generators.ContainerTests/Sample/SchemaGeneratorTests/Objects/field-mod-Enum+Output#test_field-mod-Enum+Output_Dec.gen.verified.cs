//HintName: test_field-mod-Enum+Output_Dec.gen.cs
// Generated from {CurrentDirectory}field-mod-Enum+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_mod_Enum_Output;

internal class testEnumFieldModEnumOutpDecoder
{
  public string value { get; set; }

  internal static testEnumFieldModEnumOutpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_field_mod_Enum_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_field_mod_Enum_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<testEnumFieldModEnumOutp>(testEnumFieldModEnumOutpDecoder.Factory);
}
