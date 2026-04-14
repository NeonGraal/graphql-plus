//HintName: test_field-type-descr+Output_Dec.gen.cs
// Generated from {CurrentDirectory}field-type-descr+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_type_descr_Output;

internal class testFieldTypeDescrOutpDecoder
{
  public decimal Field { get; set; }
}

internal static class test_field_type_descr_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_field_type_descr_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestFieldTypeDescrOutpObject>(r => new testFieldTypeDescrOutpDecoder(r));
}
