//HintName: test_generic-field-dual+Output_Dec.gen.cs
// Generated from {CurrentDirectory}generic-field-dual+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_dual_Output;

internal class testAltGnrcFieldDualOutpDecoder
{
  public decimal Alt { get; set; }
}

internal static class test_generic_field_dual_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_field_dual_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestAltGnrcFieldDualOutpObject>(_ => new testAltGnrcFieldDualOutpDecoder());
}
