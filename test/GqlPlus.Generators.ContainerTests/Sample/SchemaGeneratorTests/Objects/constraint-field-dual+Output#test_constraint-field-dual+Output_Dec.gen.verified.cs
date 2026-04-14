//HintName: test_constraint-field-dual+Output_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-field-dual+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_dual_Output;

internal class testCnstFieldDualOutpDecoder
{
}

internal class testRefCnstFieldDualOutpDecoder<TRef>
{
  public TRef Field { get; set; }
}

internal class testPrntCnstFieldDualOutpDecoder
{
}

internal class testAltCnstFieldDualOutpDecoder
{
  public decimal Alt { get; set; }
}

internal static class test_constraint_field_dual_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_field_dual_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCnstFieldDualOutpObject>(_ => new testCnstFieldDualOutpDecoder())
      .AddDecoder<ItestPrntCnstFieldDualOutpObject>(_ => new testPrntCnstFieldDualOutpDecoder())
      .AddDecoder<ItestAltCnstFieldDualOutpObject>(r => new testAltCnstFieldDualOutpDecoder(r));
}
