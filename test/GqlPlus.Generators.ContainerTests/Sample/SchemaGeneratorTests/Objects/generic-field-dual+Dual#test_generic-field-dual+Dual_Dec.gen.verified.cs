//HintName: test_generic-field-dual+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}generic-field-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_dual_Dual;

internal class testGnrcFieldDualDualDecoder
{
  public ItestRefGnrcFieldDualDual<ItestAltGnrcFieldDualDual> Field { get; set; }
}

internal class testRefGnrcFieldDualDualDecoder<TRef>
{
}

internal class testAltGnrcFieldDualDualDecoder
{
  public decimal Alt { get; set; }
}

internal static class test_generic_field_dual_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_field_dual_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestGnrcFieldDualDualObject>(_ => new testGnrcFieldDualDualDecoder())
      .AddDecoder<ItestAltGnrcFieldDualDualObject>(_ => new testAltGnrcFieldDualDualDecoder());
}
