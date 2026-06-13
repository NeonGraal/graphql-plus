//HintName: test_domain-enum-label_Dec.gen.cs
// Generated from {CurrentDirectory}domain-enum-label.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_label;

internal class testDmnEnumLabelDecoder : NullDecoder<ItestDmnEnumLabel>
{

  internal static testDmnEnumLabelDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumLabelDecoder : NullDecoder<testEnumDmnEnumLabel>
{
  public string dmnEnumLabel { get; set; } = default!;

  internal static testEnumDmnEnumLabelDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_domain_enum_labelDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_domain_enum_labelDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDmnEnumLabel>(testDmnEnumLabelDecoder.Factory)
      .AddDecoder<testEnumDmnEnumLabel>(testEnumDmnEnumLabelDecoder.Factory);
}
