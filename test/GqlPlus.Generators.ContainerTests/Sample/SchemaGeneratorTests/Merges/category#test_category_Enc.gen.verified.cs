//HintName: test_category_Enc.gen.cs
// Generated from {CurrentDirectory}category.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_category;

internal class testCtgrEncoder : IEncoder<ItestCtgrObject>
{
  public Structured Encode(ItestCtgrObject input)
    => Structured.Empty();

  internal static testCtgrEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_categoryEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_categoryEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestCtgrObject>(testCtgrEncoder.Factory);
}
