//HintName: test_parent-descr+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}parent-descr+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_descr_Dual;

internal class testPrntDescrDualDecoder
{

  internal static testPrntDescrDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefPrntDescrDualDecoder
{
  public decimal Parent { get; set; }

  internal static testRefPrntDescrDualDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_parent_descr_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_parent_descr_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestPrntDescrDualObject>(testPrntDescrDualDecoder.Factory)
      .AddDecoder<ItestRefPrntDescrDualObject>(testRefPrntDescrDualDecoder.Factory);
}
