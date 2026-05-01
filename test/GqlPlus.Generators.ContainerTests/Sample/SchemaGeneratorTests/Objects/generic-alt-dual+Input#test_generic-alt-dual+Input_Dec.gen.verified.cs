//HintName: test_generic-alt-dual+Input_Dec.gen.cs
// Generated from {CurrentDirectory}generic-alt-dual+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_dual_Input;

internal class testGnrcAltDualInpDecoder : IDecoder<ItestGnrcAltDualInpObject>
{

  public IMessages Decode(IValue input, out ItestGnrcAltDualInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testGnrcAltDualInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefGnrcAltDualInpDecoder<TRef>
{
}

internal class testAltGnrcAltDualInpDecoder : IDecoder<ItestAltGnrcAltDualInpObject>
{
  public decimal? Alt { get; set; }

  public IMessages Decode(IValue input, out ItestAltGnrcAltDualInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltGnrcAltDualInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_generic_alt_dual_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_alt_dual_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestGnrcAltDualInpObject>(testGnrcAltDualInpDecoder.Factory)
      .AddDecoder<ItestAltGnrcAltDualInpObject>(testAltGnrcAltDualInpDecoder.Factory);
}
