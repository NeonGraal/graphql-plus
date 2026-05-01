//HintName: test_generic-parent-param+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}generic-parent-param+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_Dual;

internal class testGnrcPrntParamDualDecoder : IDecoder<ItestGnrcPrntParamDualObject>
{

  public IMessages Decode(IValue input, out ItestGnrcPrntParamDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testGnrcPrntParamDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefGnrcPrntParamDualDecoder<TRef>
{
}

internal class testAltGnrcPrntParamDualDecoder : IDecoder<ItestAltGnrcPrntParamDualObject>
{
  public decimal? Alt { get; set; }

  public IMessages Decode(IValue input, out ItestAltGnrcPrntParamDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltGnrcPrntParamDualDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_generic_parent_param_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_parent_param_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestGnrcPrntParamDualObject>(testGnrcPrntParamDualDecoder.Factory)
      .AddDecoder<ItestAltGnrcPrntParamDualObject>(testAltGnrcPrntParamDualDecoder.Factory);
}
