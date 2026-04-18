//HintName: test_generic-parent-dual+Input_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-dual+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_Input;

internal class testGnrcPrntDualInpDecoder
{

  internal static testGnrcPrntDualInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefGnrcPrntDualInpDecoder<TRef>
{
}

internal class testAltGnrcPrntDualInpDecoder
{
  public decimal Alt { get; set; }

  internal static testAltGnrcPrntDualInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_generic_parent_dual_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_parent_dual_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestGnrcPrntDualInpObject>(testGnrcPrntDualInpDecoder.Factory)
      .AddDecoder<ItestAltGnrcPrntDualInpObject>(testAltGnrcPrntDualInpDecoder.Factory);
}
