//HintName: test_parent-field+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}parent-field+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_field_Dual;

internal class testPrntFieldDualDecoder
{
  public decimal Field { get; set; }
}

internal class testRefPrntFieldDualDecoder
{
  public decimal Parent { get; set; }
}

internal static class test_parent_field_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_parent_field_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestPrntFieldDualObject>(_ => new testPrntFieldDualDecoder())
      .AddDecoder<ItestRefPrntFieldDualObject>(_ => new testRefPrntFieldDualDecoder());
}
