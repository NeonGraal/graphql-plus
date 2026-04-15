//HintName: test_alt-enum+Output_Enc.gen.cs
// Generated from {CurrentDirectory}alt-enum+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_enum_Output;

internal class testAltEnumOutpEncoder : IEncoder<ItestAltEnumOutpObject>
{
  public Structured Encode(ItestAltEnumOutpObject input)
    => Structured.Empty();
}

internal class testEnumAltEnumOutpEncoder : IEncoder<testEnumAltEnumOutp>
{
  public Structured Encode(testEnumAltEnumOutp input)
    => new(input.ToString(), "_EnumAltEnumOutp");
}

internal static class test_alt_enum_OutputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_alt_enum_OutputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestAltEnumOutpObject>(_ => new testAltEnumOutpEncoder())
      .AddEncoder<testEnumAltEnumOutp>(_ => new testEnumAltEnumOutpEncoder());
}
