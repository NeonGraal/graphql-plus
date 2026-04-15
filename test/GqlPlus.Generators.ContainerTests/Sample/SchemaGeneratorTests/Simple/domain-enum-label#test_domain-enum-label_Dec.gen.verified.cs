//HintName: test_domain-enum-label_Dec.gen.cs
// Generated from {CurrentDirectory}domain-enum-label.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_label;

internal class testDmnEnumLabelDecoder
{
}

internal class testEnumDmnEnumLabelDecoder
{
  public string dmnEnumLabel { get; set; }
}

internal static class test_domain_enum_labelDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_domain_enum_labelDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDmnEnumLabel>(_ => new testDmnEnumLabelDecoder())
      .AddDecoder<testEnumDmnEnumLabel>(_ => new testEnumDmnEnumLabelDecoder());
}
