//HintName: test_constraint-field-dual+Input_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-field-dual+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_dual_Input;

internal class testCnstFieldDualInpDecoder
{

  internal static testCnstFieldDualInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstFieldDualInpDecoder<TRef>
{
  public TRef Field { get; set; }
}

internal class testPrntCnstFieldDualInpDecoder
{

  internal static testPrntCnstFieldDualInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltCnstFieldDualInpDecoder
{
  public decimal Alt { get; set; }

  internal static testAltCnstFieldDualInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_constraint_field_dual_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_constraint_field_dual_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestCnstFieldDualInpObject>(testCnstFieldDualInpDecoder.Factory)
      .AddDecoder<ItestPrntCnstFieldDualInpObject>(testPrntCnstFieldDualInpDecoder.Factory)
      .AddDecoder<ItestAltCnstFieldDualInpObject>(testAltCnstFieldDualInpDecoder.Factory);
}
