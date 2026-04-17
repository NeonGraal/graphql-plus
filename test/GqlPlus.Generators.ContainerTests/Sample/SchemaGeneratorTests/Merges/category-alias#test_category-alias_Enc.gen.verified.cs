//HintName: test_category-alias_Enc.gen.cs
// Generated from {CurrentDirectory}category-alias.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_category_alias;

internal class testCtgrAliasEncoder : IEncoder<ItestCtgrAliasObject>
{
  public Structured Encode(ItestCtgrAliasObject input)
    => Structured.Empty();

  internal static testCtgrAliasEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_category_aliasEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_category_aliasEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestCtgrAliasObject>(testCtgrAliasEncoder.Factory);
}
