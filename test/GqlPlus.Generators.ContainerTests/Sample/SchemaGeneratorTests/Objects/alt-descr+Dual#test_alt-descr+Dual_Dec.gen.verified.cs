//HintName: test_alt-descr+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}alt-descr+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_descr_Dual;

internal class testAltDescrDualDecoder : IDecoder<ItestAltDescrDualObject>
{

  public IMessages Decode(IValue input, out ItestAltDescrDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltDescrDualDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_alt_descr_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_alt_descr_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestAltDescrDualObject>(testAltDescrDualDecoder.Factory);
}
