//HintName: test_generic-parent-dual-parent+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-dual-parent+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_parent_Dual;

internal class testGnrcPrntDualPrntDualDecoder : IDecoder<ItestGnrcPrntDualPrntDualObject>
{

  public IMessages Decode(IValue input, out ItestGnrcPrntDualPrntDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testGnrcPrntDualPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefGnrcPrntDualPrntDualDecoder<TRef>
{
}

internal class testAltGnrcPrntDualPrntDualDecoder : IDecoder<ItestAltGnrcPrntDualPrntDualObject>
{
  public decimal? Alt { get; set; }

  public IMessages Decode(IValue input, out ItestAltGnrcPrntDualPrntDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltGnrcPrntDualPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_generic_parent_dual_parent_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_parent_dual_parent_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestGnrcPrntDualPrntDualObject>(testGnrcPrntDualPrntDualDecoder.Factory)
      .AddDecoder<ItestAltGnrcPrntDualPrntDualObject>(testAltGnrcPrntDualPrntDualDecoder.Factory);
}
