//HintName: test_domain-enum-label_Enc.gen.cs
// Generated from {CurrentDirectory}domain-enum-label.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_label;

internal class testDmnEnumLabelEncoder : IEncoder<ItestDmnEnumLabel>
{
  public Structured Encode(ItestDmnEnumLabel input)
    => new((decimal?)input.Value);
}

internal class testEnumDmnEnumLabelEncoder : IEncoder<testEnumDmnEnumLabel>
{
  public Structured Encode(testEnumDmnEnumLabel input)
    => new(input.ToString(), "_EnumDmnEnumLabel");
}

internal static class test_domain_enum_labelEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_domain_enum_labelEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestDmnEnumLabel>(_ => new testDmnEnumLabelEncoder())
      .AddEncoder<testEnumDmnEnumLabel>(_ => new testEnumDmnEnumLabelEncoder());
}
