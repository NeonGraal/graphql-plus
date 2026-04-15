//HintName: test_generic-value+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}generic-value+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_value_Dual;

internal class testGnrcValueDualDecoder
{
}

internal class testRefGnrcValueDualDecoder<TType>
{
  public TType Field { get; set; }
}

internal class testEnumGnrcValueDualDecoder
{
  public string gnrcValueDual { get; set; }
}

internal static class test_generic_value_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_value_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestGnrcValueDualObject>(_ => new testGnrcValueDualDecoder())
      .AddDecoder<testEnumGnrcValueDual>(_ => new testEnumGnrcValueDualDecoder());
}
