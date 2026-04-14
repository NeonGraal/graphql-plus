//HintName: test_field-dual+Input_Dec.gen.cs
// Generated from {CurrentDirectory}field-dual+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_dual_Input;

internal class testFieldDualInpDecoder
{
  public ItestFldFieldDualInp Field { get; set; }
}

internal class testFldFieldDualInpDecoder
{
  public decimal Field { get; set; }
}

internal static class test_field_dual_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_field_dual_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestFieldDualInpObject>(r => new testFieldDualInpDecoder(r))
      .AddDecoder<ItestFldFieldDualInpObject>(r => new testFldFieldDualInpDecoder(r));
}
