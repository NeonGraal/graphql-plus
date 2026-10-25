//HintName: test_alt-enum+Output_Enc.gen.cs
// Generated from {CurrentDirectory}alt-enum+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_enum_Output;

internal class testAltEnumOutpEncoder : IEncoder<ItestAltEnumOutpObject>
{
  public IGqlpValue Encode(ItestAltEnumOutpObject input)
    => new GqlpUnit();

  internal static testAltEnumOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumAltEnumOutpEncoder : IEncoder<testEnumAltEnumOutp>
{
  public IGqlpValue Encode(testEnumAltEnumOutp input)
    => input.EncodeEnum("EnumAltEnumOutp");

  internal static testEnumAltEnumOutpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_alt_enum_OutputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_alt_enum_OutputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestAltEnumOutpObject>(testAltEnumOutpEncoder.Factory)
      .AddEncoder<testEnumAltEnumOutp>(testEnumAltEnumOutpEncoder.Factory);
}
