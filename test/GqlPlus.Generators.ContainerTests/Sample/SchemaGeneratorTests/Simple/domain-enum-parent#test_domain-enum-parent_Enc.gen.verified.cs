//HintName: test_domain-enum-parent_Enc.gen.cs
// Generated from {CurrentDirectory}domain-enum-parent.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_parent;

internal class testDmnEnumPrntEncoder : IEncoder<ItestDmnEnumPrnt>
{
  public Structured Encode(ItestDmnEnumPrnt input)
    => input.Value?.EncodeEnum("testEnumDmnEnumPrnt") ?? Structured.Empty("testEnumDmnEnumPrnt");

  internal static testDmnEnumPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntDmnEnumPrntEncoder : IEncoder<ItestPrntDmnEnumPrnt>
{
  public Structured Encode(ItestPrntDmnEnumPrnt input)
    => input.Value?.EncodeEnum("testEnumDmnEnumPrnt") ?? Structured.Empty("testEnumDmnEnumPrnt");

  internal static testPrntDmnEnumPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumDmnEnumPrntEncoder : IEncoder<testEnumDmnEnumPrnt>
{
  public Structured Encode(testEnumDmnEnumPrnt input)
    => input.EncodeEnum("EnumDmnEnumPrnt");

  internal static testEnumDmnEnumPrntEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_domain_enum_parentEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_domain_enum_parentEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestDmnEnumPrnt>(testDmnEnumPrntEncoder.Factory)
      .AddEncoder<ItestPrntDmnEnumPrnt>(testPrntDmnEnumPrntEncoder.Factory)
      .AddEncoder<testEnumDmnEnumPrnt>(testEnumDmnEnumPrntEncoder.Factory);
}
