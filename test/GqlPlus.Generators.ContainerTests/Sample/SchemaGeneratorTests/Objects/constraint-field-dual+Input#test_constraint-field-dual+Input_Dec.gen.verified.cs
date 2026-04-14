//HintName: test_constraint-field-dual+Input_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-field-dual+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_dual_Input;

internal class testCnstFieldDualInpDecoder
{
}

internal class testRefCnstFieldDualInpDecoder<TRef>
{
  public TRef Field { get; set; }
}

internal class testPrntCnstFieldDualInpDecoder
{
}

internal class testAltCnstFieldDualInpDecoder
{
  public decimal Alt { get; set; }
}

internal static class test_constraint_field_dual_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_field_dual_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCnstFieldDualInpObject>(_ => new testCnstFieldDualInpDecoder())
      .AddDecoder<ItestPrntCnstFieldDualInpObject>(_ => new testPrntCnstFieldDualInpDecoder())
      .AddDecoder<ItestAltCnstFieldDualInpObject>(r => new testAltCnstFieldDualInpDecoder(r));
}
