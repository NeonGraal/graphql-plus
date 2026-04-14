//HintName: test_input-field-null_Dec.gen.cs
// Generated from {CurrentDirectory}input-field-null.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_input_field_null;

internal class testInpFieldNullDecoder
{
  public ItestFldInpFieldNull? Field { get; set; }
}

internal class testFldInpFieldNullDecoder
{
}

internal static class test_input_field_nullDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_input_field_nullDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestInpFieldNullObject>(r => new testInpFieldNullDecoder(r))
      .AddDecoder<ItestFldInpFieldNullObject>(_ => new testFldInpFieldNullDecoder());
}
