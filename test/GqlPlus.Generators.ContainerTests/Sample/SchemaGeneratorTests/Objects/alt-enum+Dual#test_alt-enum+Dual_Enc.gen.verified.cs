//HintName: test_alt-enum+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}alt-enum+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_enum_Dual;

internal class testAltEnumDualEncoder : IEncoder<ItestAltEnumDualObject>
{
  public IGqlpValue Encode(ItestAltEnumDualObject input)
    => new GqlpUnit();

  internal static testAltEnumDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumAltEnumDualEncoder : IEncoder<testEnumAltEnumDual>
{
  public IGqlpValue Encode(testEnumAltEnumDual input)
    => input.EncodeEnum("EnumAltEnumDual");

  internal static testEnumAltEnumDualEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_alt_enum_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_alt_enum_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestAltEnumDualObject>(testAltEnumDualEncoder.Factory)
      .AddEncoder<testEnumAltEnumDual>(testEnumAltEnumDualEncoder.Factory);
}
