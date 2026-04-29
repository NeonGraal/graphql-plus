//HintName: test_domain-enum-same_Dec.gen.cs
// Generated from {CurrentDirectory}domain-enum-same.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_same;

internal class testDmnEnumSameDecoder
{
  public new bool? Value { get; set; }

  internal static testDmnEnumSameDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_domain_enum_sameDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_domain_enum_sameDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDmnEnumSame>(testDmnEnumSameDecoder.Factory);
}
