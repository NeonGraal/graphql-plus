//HintName: test_field-descr+Output_Dec.gen.cs
// Generated from {CurrentDirectory}field-descr+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_descr_Output;

internal class testFieldDescrOutpDecoder
{
  public string Field { get; set; }
}

internal static class test_field_descr_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_field_descr_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestFieldDescrOutpObject>(r => new testFieldDescrOutpDecoder(r));
}
