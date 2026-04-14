//HintName: test_alt-mod-Boolean+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}alt-mod-Boolean+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_Boolean_Dual;

internal class testAltModBoolDualDecoder
{
}

internal class testAltAltModBoolDualDecoder
{
  public decimal Alt { get; set; }
}

internal static class test_alt_mod_Boolean_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_alt_mod_Boolean_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestAltModBoolDualObject>(_ => new testAltModBoolDualDecoder())
      .AddDecoder<ItestAltAltModBoolDualObject>(r => new testAltAltModBoolDualDecoder(r));
}
