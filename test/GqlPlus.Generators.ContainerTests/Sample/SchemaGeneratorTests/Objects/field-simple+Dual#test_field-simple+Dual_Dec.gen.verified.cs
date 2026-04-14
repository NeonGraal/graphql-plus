//HintName: test_field-simple+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}field-simple+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_simple_Dual;

internal class testFieldSmplDualDecoder
{
  public decimal Field { get; set; }
}

internal static class test_field_simple_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_field_simple_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestFieldSmplDualObject>(r => new testFieldSmplDualDecoder(r));
}
