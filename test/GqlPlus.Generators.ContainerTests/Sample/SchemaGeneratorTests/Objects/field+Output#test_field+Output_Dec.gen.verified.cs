//HintName: test_field+Output_Dec.gen.cs
// Generated from {CurrentDirectory}field+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_Output;

internal class testFieldOutpDecoder
{
  public string Field { get; set; }
}

internal static class test_field_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_field_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestFieldOutpObject>(r => new testFieldOutpDecoder(r));
}
