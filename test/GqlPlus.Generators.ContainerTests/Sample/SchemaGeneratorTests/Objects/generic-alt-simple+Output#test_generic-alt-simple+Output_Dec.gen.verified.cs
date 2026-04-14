//HintName: test_generic-alt-simple+Output_Dec.gen.cs
// Generated from {CurrentDirectory}generic-alt-simple+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_simple_Output;

internal class testGnrcAltSmplOutpDecoder
{
}

internal class testRefGnrcAltSmplOutpDecoder<TRef>
{
}

internal static class test_generic_alt_simple_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_alt_simple_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestGnrcAltSmplOutpObject>(_ => new testGnrcAltSmplOutpDecoder());
}
