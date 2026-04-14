//HintName: test_constraint-alt-dual+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-alt-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_dual_Dual;

internal class testCnstAltDualDualDecoder
{
}

internal class testRefCnstAltDualDualDecoder<TRef>
{
}

internal class testPrntCnstAltDualDualDecoder
{
}

internal class testAltCnstAltDualDualDecoder
{
  public decimal Alt { get; set; }
}

internal static class test_constraint_alt_dual_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_alt_dual_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCnstAltDualDualObject>(_ => new testCnstAltDualDualDecoder())
      .AddDecoder<ItestPrntCnstAltDualDualObject>(_ => new testPrntCnstAltDualDualDecoder())
      .AddDecoder<ItestAltCnstAltDualDualObject>(r => new testAltCnstAltDualDualDecoder(r));
}
