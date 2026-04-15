//HintName: test_domain-enum-value_Enc.gen.cs
// Generated from {CurrentDirectory}domain-enum-value.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_value;

internal class testDmnEnumValueEncoder : IEncoder<ItestDmnEnumValue>
{
  public Structured Encode(ItestDmnEnumValue input)
    => new((decimal?)input.Value);
}

internal class testEnumDmnEnumValueEncoder : IEncoder<testEnumDmnEnumValue>
{
  public Structured Encode(testEnumDmnEnumValue input)
    => new(input.ToString(), "_EnumDmnEnumValue");
}

internal static class test_domain_enum_valueEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_domain_enum_valueEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestDmnEnumValue>(_ => new testDmnEnumValueEncoder())
      .AddEncoder<testEnumDmnEnumValue>(_ => new testEnumDmnEnumValueEncoder());
}
