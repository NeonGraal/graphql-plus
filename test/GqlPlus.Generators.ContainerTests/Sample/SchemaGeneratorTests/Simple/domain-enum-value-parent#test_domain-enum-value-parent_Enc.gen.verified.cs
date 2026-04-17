//HintName: test_domain-enum-value-parent_Enc.gen.cs
// Generated from {CurrentDirectory}domain-enum-value-parent.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_value_parent;

internal class testDmnEnumValuePrntEncoder : IEncoder<ItestDmnEnumValuePrnt>
{
  public Structured Encode(ItestDmnEnumValuePrnt input)
    => new((decimal?)input.Value);

  internal static testDmnEnumValuePrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumDmnEnumValuePrntEncoder : IEncoder<testEnumDmnEnumValuePrnt>
{
  public Structured Encode(testEnumDmnEnumValuePrnt input)
    => new(input.ToString(), "_EnumDmnEnumValuePrnt");

  internal static testEnumDmnEnumValuePrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntDmnEnumValuePrntEncoder : IEncoder<testPrntDmnEnumValuePrnt>
{
  public Structured Encode(testPrntDmnEnumValuePrnt input)
    => new(input.ToString(), "_PrntDmnEnumValuePrnt");

  internal static testPrntDmnEnumValuePrntEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_domain_enum_value_parentEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_domain_enum_value_parentEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestDmnEnumValuePrnt>(testDmnEnumValuePrntEncoder.Factory)
      .AddEncoder<testEnumDmnEnumValuePrnt>(testEnumDmnEnumValuePrntEncoder.Factory)
      .AddEncoder<testPrntDmnEnumValuePrnt>(testPrntDmnEnumValuePrntEncoder.Factory);
}
