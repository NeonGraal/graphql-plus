//HintName: test_alt-enum+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}alt-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_enum_Dual;

internal class testAltEnumDualEncoder : IEncoder<ItestAltEnumDualObject>
{
  public Structured Encode(ItestAltEnumDualObject input)
    => Structured.Empty();
}

internal class testEnumAltEnumDualEncoder : IEncoder<testEnumAltEnumDual>
{
  public Structured Encode(testEnumAltEnumDual input)
    => new(input.ToString(), "_EnumAltEnumDual");
}

internal static class test_alt_enum_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_alt_enum_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestAltEnumDualObject>(_ => new testAltEnumDualEncoder())
      .AddEncoder<testEnumAltEnumDual>(_ => new testEnumAltEnumDualEncoder());
}
