//HintName: test_alt-enum+Input_Dec.gen.cs
// Generated from {CurrentDirectory}alt-enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_enum_Input;

internal class testAltEnumInpDecoder
{

  internal static testAltEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumAltEnumInpDecoder
{
  public string altEnumInp { get; set; }

  internal static testEnumAltEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_alt_enum_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_alt_enum_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestAltEnumInpObject>(testAltEnumInpDecoder.Factory)
      .AddDecoder<testEnumAltEnumInp>(testEnumAltEnumInpDecoder.Factory);
}
