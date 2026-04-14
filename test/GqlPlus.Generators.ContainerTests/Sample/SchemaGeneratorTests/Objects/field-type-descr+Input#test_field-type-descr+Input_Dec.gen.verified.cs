//HintName: test_field-type-descr+Input_Dec.gen.cs
// Generated from {CurrentDirectory}field-type-descr+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_type_descr_Input;

internal class testFieldTypeDescrInpDecoder
{
  public decimal Field { get; set; }
}

internal static class test_field_type_descr_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_field_type_descr_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestFieldTypeDescrInpObject>(r => new testFieldTypeDescrInpDecoder(r));
}
