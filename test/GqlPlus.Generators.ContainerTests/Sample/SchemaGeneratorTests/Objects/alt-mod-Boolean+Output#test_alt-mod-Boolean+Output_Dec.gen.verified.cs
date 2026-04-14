//HintName: test_alt-mod-Boolean+Output_Dec.gen.cs
// Generated from {CurrentDirectory}alt-mod-Boolean+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_Boolean_Output;

internal class testAltModBoolOutpDecoder
{
}

internal class testAltAltModBoolOutpDecoder
{
  public decimal Alt { get; set; }
}

internal static class test_alt_mod_Boolean_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_alt_mod_Boolean_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestAltModBoolOutpObject>(_ => new testAltModBoolOutpDecoder())
      .AddDecoder<ItestAltAltModBoolOutpObject>(r => new testAltAltModBoolOutpDecoder(r));
}
