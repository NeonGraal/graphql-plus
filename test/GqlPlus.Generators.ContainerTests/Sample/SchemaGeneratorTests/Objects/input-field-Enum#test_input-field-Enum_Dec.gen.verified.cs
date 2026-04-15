//HintName: test_input-field-Enum_Dec.gen.cs
// Generated from {CurrentDirectory}input-field-Enum.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_input_field_Enum;

internal class testInpFieldEnumDecoder
{
  public testEnumInpFieldEnum Field { get; set; }
}

internal class testEnumInpFieldEnumDecoder
{
  public string inpFieldEnum { get; set; }
}

internal static class test_input_field_EnumDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_input_field_EnumDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestInpFieldEnumObject>(_ => new testInpFieldEnumDecoder())
      .AddDecoder<testEnumInpFieldEnum>(_ => new testEnumInpFieldEnumDecoder());
}
