//HintName: test_alt-dual+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}alt-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_dual_Dual;

internal class testAltDualDualDecoder : IDecoder<ItestAltDualDualObject>
{

  public IMessages Decode(IValue input, out ItestAltDualDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltDualDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjDualAltDualDualDecoder : IDecoder<ItestObjDualAltDualDualObject>
{
  public decimal? Alt { get; set; }

  public IMessages Decode(IValue input, out ItestObjDualAltDualDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testObjDualAltDualDualDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_alt_dual_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_alt_dual_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestAltDualDualObject>(testAltDualDualDecoder.Factory)
      .AddDecoder<ItestObjDualAltDualDualObject>(testObjDualAltDualDualDecoder.Factory);
}
