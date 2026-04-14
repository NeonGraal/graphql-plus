//HintName: test_field-simple+Output_Dec.gen.cs
// Generated from {CurrentDirectory}field-simple+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_simple_Output;

internal class testFieldSmplOutpDecoder
{
  public decimal Field { get; set; }
}

internal static class test_field_simple_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_field_simple_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestFieldSmplOutpObject>(r => new testFieldSmplOutpDecoder(r));
}
