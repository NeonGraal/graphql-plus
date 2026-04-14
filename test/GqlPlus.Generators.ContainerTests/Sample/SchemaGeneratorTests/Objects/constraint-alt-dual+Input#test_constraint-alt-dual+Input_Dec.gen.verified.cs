//HintName: test_constraint-alt-dual+Input_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-alt-dual+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_dual_Input;

internal class testCnstAltDualInpDecoder
{
}

internal class testRefCnstAltDualInpDecoder<TRef>
{
}

internal class testPrntCnstAltDualInpDecoder
{
}

internal class testAltCnstAltDualInpDecoder
{
  public decimal Alt { get; set; }
}

internal static class test_constraint_alt_dual_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_alt_dual_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCnstAltDualInpObject>(_ => new testCnstAltDualInpDecoder())
      .AddDecoder<ItestPrntCnstAltDualInpObject>(_ => new testPrntCnstAltDualInpDecoder())
      .AddDecoder<ItestAltCnstAltDualInpObject>(r => new testAltCnstAltDualInpDecoder(r));
}
