//HintName: test_domain-alias_Enc.gen.cs
// Generated from {CurrentDirectory}domain-alias.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_alias;

internal class testDmnAliasEncoder : IEncoder<ItestDmnAlias>
{
  public Structured Encode(ItestDmnAlias input)
    => new(input.Value);

  internal static testDmnAliasEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_domain_aliasEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_domain_aliasEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestDmnAlias>(testDmnAliasEncoder.Factory);
}
