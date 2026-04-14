//HintName: test_field-value+Input_Dec.gen.cs
// Generated from {CurrentDirectory}field-value+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_value_Input;

internal class testFieldValueInpDecoder
{
  public testEnumFieldValueInp Field { get; set; }
}

internal class testEnumFieldValueInpDecoder
{
  public string fieldValueInp { get; set; }
}

internal static class test_field_value_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_field_value_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestFieldValueInpObject>(r => new testFieldValueInpDecoder(r))
      .AddDecoder<testEnumFieldValueInp>(_ => new testEnumFieldValueInpDecoder());
}
