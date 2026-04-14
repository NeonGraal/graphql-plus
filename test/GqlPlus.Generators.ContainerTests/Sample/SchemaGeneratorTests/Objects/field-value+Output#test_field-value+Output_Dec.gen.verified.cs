//HintName: test_field-value+Output_Dec.gen.cs
// Generated from {CurrentDirectory}field-value+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_value_Output;

internal class testFieldValueOutpDecoder
{
  public testEnumFieldValueOutp Field { get; set; }
}

internal class testEnumFieldValueOutpDecoder
{
  public string fieldValueOutp { get; set; }
}

internal static class test_field_value_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_field_value_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestFieldValueOutpObject>(r => new testFieldValueOutpDecoder(r))
      .AddDecoder<testEnumFieldValueOutp>(_ => new testEnumFieldValueOutpDecoder());
}
