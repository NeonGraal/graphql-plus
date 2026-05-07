//HintName: test_operation-category_Enc.gen.cs
// Generated from {CurrentDirectory}operation-category.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_operation_category;

internal class testCatOprCtgrEncoder : IEncoder<ItestCatOprCtgrObject>
{
  public Structured Encode(ItestCatOprCtgrObject input)
    => Structured.Empty();

  internal static testCatOprCtgrEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_operation_categoryEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_operation_categoryEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestCatOprCtgrObject>(testCatOprCtgrEncoder.Factory);
}
