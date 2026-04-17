//HintName: test_domain-boolean-same_Enc.gen.cs
// Generated from {CurrentDirectory}domain-boolean-same.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_boolean_same;

internal class testDmnBoolSameEncoder : IEncoder<ItestDmnBoolSame>
{
  public Structured Encode(ItestDmnBoolSame input)
    => new(input.Value);

  internal static testDmnBoolSameEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_domain_boolean_sameEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_domain_boolean_sameEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestDmnBoolSame>(testDmnBoolSameEncoder.Factory);
}
