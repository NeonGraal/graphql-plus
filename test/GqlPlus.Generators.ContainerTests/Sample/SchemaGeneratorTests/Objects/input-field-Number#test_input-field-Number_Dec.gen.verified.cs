//HintName: test_input-field-Number_Dec.gen.cs
// Generated from {CurrentDirectory}input-field-Number.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_input_field_Number;

internal class testInpFieldNmbrDecoder
{
  public decimal Field { get; set; }
}

internal static class test_input_field_NumberDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_input_field_NumberDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestInpFieldNmbrObject>(_ => new testInpFieldNmbrDecoder());
}
