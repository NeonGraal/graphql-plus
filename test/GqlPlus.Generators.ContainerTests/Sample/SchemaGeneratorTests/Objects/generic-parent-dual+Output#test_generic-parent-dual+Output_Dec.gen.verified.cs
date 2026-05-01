//HintName: test_generic-parent-dual+Output_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-dual+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_dual_Output;

internal class testAltGnrcPrntDualOutpDecoder : IDecoder<ItestAltGnrcPrntDualOutpObject>
{
  public decimal? Alt { get; set; }

  public IMessages Decode(IValue input, out ItestAltGnrcPrntDualOutpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltGnrcPrntDualOutpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_generic_parent_dual_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_parent_dual_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestAltGnrcPrntDualOutpObject>(testAltGnrcPrntDualOutpDecoder.Factory);
}
