//HintName: test_domain-boolean-diff_Enc.gen.cs
// Generated from {CurrentDirectory}domain-boolean-diff.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_boolean_diff;

internal class testDmnBoolDiffEncoder : IEncoder<ItestDmnBoolDiff>
{
  public Structured Encode(ItestDmnBoolDiff input)
    => new(input.Value);
}

internal static class test_domain_boolean_diffEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_domain_boolean_diffEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestDmnBoolDiff>(_ => new testDmnBoolDiffEncoder());
}
