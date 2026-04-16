//HintName: test_alt-enum+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}alt-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_enum_Dual;

internal class testAltEnumDualDecoder
{

  internal static testAltEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumAltEnumDualDecoder
{
  public string altEnumDual { get; set; }

  internal static testEnumAltEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_alt_enum_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_alt_enum_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestAltEnumDualObject>(testAltEnumDualDecoder.Factory)
      .AddDecoder<testEnumAltEnumDual>(testEnumAltEnumDualDecoder.Factory);
}
