//HintName: test_generic-parent-dual-parent+Input_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-dual-parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_parent_Input;

internal class testGnrcPrntDualPrntInpDecoder : IDecoder<ItestGnrcPrntDualPrntInpObject>
{

  public IMessages Decode(IValue input, out ItestGnrcPrntDualPrntInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testGnrcPrntDualPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefGnrcPrntDualPrntInpDecoder<TRef>
{
}

internal class testAltGnrcPrntDualPrntInpDecoder : IDecoder<ItestAltGnrcPrntDualPrntInpObject>
{
  public decimal? Alt { get; set; }

  public IMessages Decode(IValue input, out ItestAltGnrcPrntDualPrntInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltGnrcPrntDualPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_generic_parent_dual_parent_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_parent_dual_parent_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestGnrcPrntDualPrntInpObject>(testGnrcPrntDualPrntInpDecoder.Factory)
      .AddDecoder<ItestAltGnrcPrntDualPrntInpObject>(testAltGnrcPrntDualPrntInpDecoder.Factory);
}
