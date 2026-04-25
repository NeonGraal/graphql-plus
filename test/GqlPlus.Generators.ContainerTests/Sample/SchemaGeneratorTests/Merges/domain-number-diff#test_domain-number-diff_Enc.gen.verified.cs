//HintName: test_domain-number-diff_Enc.gen.cs
// Generated from {CurrentDirectory}domain-number-diff.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_number_diff;

internal class testDmnNmbrDiffEncoder : IEncoder<ItestDmnNmbrDiff>
{
  public Structured Encode(ItestDmnNmbrDiff input)
    => input.Value!.Encode();

  internal static testDmnNmbrDiffEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_domain_number_diffEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_domain_number_diffEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestDmnNmbrDiff>(testDmnNmbrDiffEncoder.Factory);
}
