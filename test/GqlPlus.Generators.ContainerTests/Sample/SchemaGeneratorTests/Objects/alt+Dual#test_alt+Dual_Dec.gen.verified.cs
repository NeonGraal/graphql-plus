//HintName: test_alt+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}alt+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_Dual;

internal class testAltDualDecoder : IDecoder<ItestAltDualObject>
{

  public IMessages Decode(IValue input, out ItestAltDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltAltDualDecoder : IDecoder<ItestAltAltDualObject>
{
  public decimal? Alt { get; set; }

  public IMessages Decode(IValue input, out ItestAltAltDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltAltDualDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_alt_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_alt_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestAltDualObject>(testAltDualDecoder.Factory)
      .AddDecoder<ItestAltAltDualObject>(testAltAltDualDecoder.Factory);
}
