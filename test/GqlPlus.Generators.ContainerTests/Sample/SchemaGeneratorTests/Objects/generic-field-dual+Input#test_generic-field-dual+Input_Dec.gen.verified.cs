//HintName: test_generic-field-dual+Input_Dec.gen.cs
// Generated from {CurrentDirectory}generic-field-dual+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_dual_Input;

internal class testGnrcFieldDualInpDecoder
{
  public ItestRefGnrcFieldDualInp<ItestAltGnrcFieldDualInp> Field { get; set; }
}

internal class testRefGnrcFieldDualInpDecoder<TRef>
{
}

internal class testAltGnrcFieldDualInpDecoder
{
  public decimal Alt { get; set; }
}

internal static class test_generic_field_dual_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_field_dual_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestGnrcFieldDualInpObject>(_ => new testGnrcFieldDualInpDecoder())
      .AddDecoder<ItestAltGnrcFieldDualInpObject>(_ => new testAltGnrcFieldDualInpDecoder());
}
