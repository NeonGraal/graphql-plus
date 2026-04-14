//HintName: test_parent-descr+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}parent-descr+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_descr_Dual;

internal class testPrntDescrDualDecoder
{
}

internal class testRefPrntDescrDualDecoder
{
  public decimal Parent { get; set; }
}

internal static class test_parent_descr_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_parent_descr_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestPrntDescrDualObject>(_ => new testPrntDescrDualDecoder())
      .AddDecoder<ItestRefPrntDescrDualObject>(_ => new testRefPrntDescrDualDecoder());
}
