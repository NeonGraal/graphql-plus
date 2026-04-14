//HintName: test_generic-parent-dual-parent+Input_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-dual-parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_parent_Input;

internal class testGnrcPrntDualPrntInpDecoder
{
}

internal class testRefGnrcPrntDualPrntInpDecoder<TRef>
{
}

internal class testAltGnrcPrntDualPrntInpDecoder
{
  public decimal Alt { get; set; }
}

internal static class test_generic_parent_dual_parent_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_parent_dual_parent_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestGnrcPrntDualPrntInpObject>(_ => new testGnrcPrntDualPrntInpDecoder())
      .AddDecoder<ItestAltGnrcPrntDualPrntInpObject>(r => new testAltGnrcPrntDualPrntInpDecoder(r));
}
