//HintName: test_domain-enum-value_Enc.gen.cs
// Generated from {CurrentDirectory}domain-enum-value.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_value;

internal class testDmnEnumValueEncoder : IEncoder<ItestDmnEnumValue>
{
  public Structured Encode(ItestDmnEnumValue input)
    => input.Value?.EncodeEnum("testEnumDmnEnumValue") ?? Structured.Empty("testEnumDmnEnumValue");

  internal static testDmnEnumValueEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumDmnEnumValueEncoder : IEncoder<testEnumDmnEnumValue>
{
  public Structured Encode(testEnumDmnEnumValue input)
    => input.EncodeEnum("EnumDmnEnumValue");

  internal static testEnumDmnEnumValueEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_domain_enum_valueEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_domain_enum_valueEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestDmnEnumValue>(testDmnEnumValueEncoder.Factory)
      .AddEncoder<testEnumDmnEnumValue>(testEnumDmnEnumValueEncoder.Factory);
}
