//HintName: test_parent+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}parent+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_Dual;

internal class testPrntDualDecoder : IDecoder<ItestPrntDualObject>
{

  public IMessages Decode(IValue input, out ItestPrntDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefPrntDualDecoder : IDecoder<ItestRefPrntDualObject>
{
  public decimal? Parent { get; set; }

  public IMessages Decode(IValue input, out ItestRefPrntDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testRefPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_parent_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_parent_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestPrntDualObject>(testPrntDualDecoder.Factory)
      .AddDecoder<ItestRefPrntDualObject>(testRefPrntDualDecoder.Factory);
}
