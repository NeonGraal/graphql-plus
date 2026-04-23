//HintName: test_domain-string_Enc.gen.cs
// Generated from {CurrentDirectory}domain-string.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_string;

internal class testDmnStrEncoder : IEncoder<ItestDmnStr>
{
  public Structured Encode(ItestDmnStr input)
    => input.Value!.Encode();

  internal static testDmnStrEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_domain_stringEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_domain_stringEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestDmnStr>(testDmnStrEncoder.Factory);
}
