//HintName: test_generic-alt-dual+Input_Dec.gen.cs
// Generated from {CurrentDirectory}generic-alt-dual+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_dual_Input;

internal class testGnrcAltDualInpDecoder
{
}

internal class testRefGnrcAltDualInpDecoder<TRef>
{
}

internal class testAltGnrcAltDualInpDecoder
{
  public decimal Alt { get; set; }
}

internal static class test_generic_alt_dual_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_alt_dual_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestGnrcAltDualInpObject>(_ => new testGnrcAltDualInpDecoder())
      .AddDecoder<ItestAltGnrcAltDualInpObject>(_ => new testAltGnrcAltDualInpDecoder());
}
