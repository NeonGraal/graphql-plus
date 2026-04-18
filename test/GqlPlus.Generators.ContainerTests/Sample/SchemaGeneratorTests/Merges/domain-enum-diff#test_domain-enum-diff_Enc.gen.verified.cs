//HintName: test_domain-enum-diff_Enc.gen.cs
// Generated from {CurrentDirectory}domain-enum-diff.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_diff;

internal class testDmnEnumDiffEncoder : IEncoder<ItestDmnEnumDiff>
{
  public Structured Encode(ItestDmnEnumDiff input)
    => new(input.ToString(), "bool");

  internal static testDmnEnumDiffEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_domain_enum_diffEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_domain_enum_diffEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestDmnEnumDiff>(testDmnEnumDiffEncoder.Factory);
}
