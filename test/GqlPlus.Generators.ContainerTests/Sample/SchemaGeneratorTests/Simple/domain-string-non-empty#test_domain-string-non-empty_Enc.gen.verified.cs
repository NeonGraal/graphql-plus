//HintName: test_domain-string-non-empty_Enc.gen.cs
// Generated from {CurrentDirectory}domain-string-non-empty.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_string_non_empty;

internal class testDmnStrNonEmptyEncoder : IEncoder<ItestDmnStrNonEmpty>
{
  public Structured Encode(ItestDmnStrNonEmpty input)
    => input.Value!.Encode();

  internal static testDmnStrNonEmptyEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_domain_string_non_emptyEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_domain_string_non_emptyEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestDmnStrNonEmpty>(testDmnStrNonEmptyEncoder.Factory);
}
