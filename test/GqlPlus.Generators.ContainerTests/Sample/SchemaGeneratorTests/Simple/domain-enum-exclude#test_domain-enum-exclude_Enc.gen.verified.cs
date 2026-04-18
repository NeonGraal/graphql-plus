//HintName: test_domain-enum-exclude_Enc.gen.cs
// Generated from {CurrentDirectory}domain-enum-exclude.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_exclude;

internal class testDmnEnumExclEncoder : IEncoder<ItestDmnEnumExcl>
{
  public Structured Encode(ItestDmnEnumExcl input)
    => new(input.ToString(), "testEnumDmnEnumExcl");

  internal static testDmnEnumExclEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumDmnEnumExclEncoder : IEncoder<testEnumDmnEnumExcl>
{
  public Structured Encode(testEnumDmnEnumExcl input)
    => new(input.ToString(), "_EnumDmnEnumExcl");

  internal static testEnumDmnEnumExclEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_domain_enum_excludeEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_domain_enum_excludeEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestDmnEnumExcl>(testDmnEnumExclEncoder.Factory)
      .AddEncoder<testEnumDmnEnumExcl>(testEnumDmnEnumExclEncoder.Factory);
}
