//HintName: test_domain-string-diff_Enc.gen.cs
// Generated from {CurrentDirectory}domain-string-diff.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_string_diff;

internal class testDmnStrDiffEncoder : IEncoder<ItestDmnStrDiff>
{
  public Structured Encode(ItestDmnStrDiff input)
    => new(input.Value);
}

internal static class test_domain_string_diffEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_domain_string_diffEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestDmnStrDiff>(_ => new testDmnStrDiffEncoder());
}
