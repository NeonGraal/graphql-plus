//HintName: test_field-value-descr+Input_Dec.gen.cs
// Generated from {CurrentDirectory}field-value-descr+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_value_descr_Input;

internal class testFieldValueDescrInpDecoder
{
  public testEnumFieldValueDescrInp Field { get; set; }
}

internal class testEnumFieldValueDescrInpDecoder
{
  public string fieldValueDescrInp { get; set; }
}

internal static class test_field_value_descr_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_field_value_descr_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestFieldValueDescrInpObject>(_ => new testFieldValueDescrInpDecoder())
      .AddDecoder<testEnumFieldValueDescrInp>(_ => new testEnumFieldValueDescrInpDecoder());
}
