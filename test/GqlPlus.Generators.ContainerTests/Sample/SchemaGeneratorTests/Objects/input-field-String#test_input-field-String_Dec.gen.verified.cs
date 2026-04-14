//HintName: test_input-field-String_Dec.gen.cs
// Generated from {CurrentDirectory}input-field-String.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_input_field_String;

internal class testInpFieldStrDecoder
{
  public string Field { get; set; }
}

internal static class test_input_field_StringDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_input_field_StringDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestInpFieldStrObject>(r => new testInpFieldStrDecoder(r));
}
