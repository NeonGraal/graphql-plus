//HintName: test_domain-enum-all-parent_Enc.gen.cs
// Generated from {CurrentDirectory}domain-enum-all-parent.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_all_parent;

internal class testDmnEnumAllPrntEncoder : IEncoder<ItestDmnEnumAllPrnt>
{
  public Structured Encode(ItestDmnEnumAllPrnt input)
    => input.Value?.EncodeEnum("testEnumDmnEnumAllPrnt") ?? Structured.Empty("testEnumDmnEnumAllPrnt");

  internal static testDmnEnumAllPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumDmnEnumAllPrntEncoder : IEncoder<testEnumDmnEnumAllPrnt>
{
  public Structured Encode(testEnumDmnEnumAllPrnt input)
    => input.EncodeEnum("EnumDmnEnumAllPrnt");

  internal static testEnumDmnEnumAllPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntDmnEnumAllPrntEncoder : IEncoder<testPrntDmnEnumAllPrnt>
{
  public Structured Encode(testPrntDmnEnumAllPrnt input)
    => input.EncodeEnum("PrntDmnEnumAllPrnt");

  internal static testPrntDmnEnumAllPrntEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_domain_enum_all_parentEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_domain_enum_all_parentEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestDmnEnumAllPrnt>(testDmnEnumAllPrntEncoder.Factory)
      .AddEncoder<testEnumDmnEnumAllPrnt>(testEnumDmnEnumAllPrntEncoder.Factory)
      .AddEncoder<testPrntDmnEnumAllPrnt>(testPrntDmnEnumAllPrntEncoder.Factory);
}
