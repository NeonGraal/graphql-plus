//HintName: test_field-enum+Input_Dec.gen.cs
// Generated from {CurrentDirectory}field-enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_enum_Input;

internal class testFieldEnumInpDecoder
{
  public testEnumFieldEnumInp Field { get; set; }
}

internal class testEnumFieldEnumInpDecoder
{
  public string fieldEnumInp { get; set; }
}

internal static class test_field_enum_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_field_enum_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestFieldEnumInpObject>(r => new testFieldEnumInpDecoder(r))
      .AddDecoder<testEnumFieldEnumInp>(_ => new testEnumFieldEnumInpDecoder());
}
