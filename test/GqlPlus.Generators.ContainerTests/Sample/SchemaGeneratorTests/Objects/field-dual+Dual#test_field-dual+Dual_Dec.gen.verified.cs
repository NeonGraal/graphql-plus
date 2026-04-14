//HintName: test_field-dual+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}field-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_dual_Dual;

internal class testFieldDualDualDecoder
{
  public ItestFldFieldDualDual Field { get; set; }
}

internal class testFldFieldDualDualDecoder
{
  public decimal Field { get; set; }
}

internal static class test_field_dual_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_field_dual_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestFieldDualDualObject>(_ => new testFieldDualDualDecoder())
      .AddDecoder<ItestFldFieldDualDualObject>(_ => new testFldFieldDualDualDecoder());
}
