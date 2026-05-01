//HintName: test_generic-alt-dual+Output_Dec.gen.cs
// Generated from {CurrentDirectory}generic-alt-dual+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_dual_Output;

internal class testAltGnrcAltDualOutpDecoder : IDecoder<ItestAltGnrcAltDualOutpObject>
{
  public decimal? Alt { get; set; }

  public IMessages Decode(IValue input, out ItestAltGnrcAltDualOutpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltGnrcAltDualOutpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_generic_alt_dual_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_alt_dual_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestAltGnrcAltDualOutpObject>(testAltGnrcAltDualOutpDecoder.Factory);
}
