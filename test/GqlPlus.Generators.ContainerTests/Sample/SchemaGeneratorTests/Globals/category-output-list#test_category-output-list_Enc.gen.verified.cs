//HintName: test_category-output-list_Enc.gen.cs
// Generated from {CurrentDirectory}category-output-list.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_category_output_list;

internal class testCtgrOutpListEncoder : IEncoder<ItestCtgrOutpListObject>
{
  public Structured Encode(ItestCtgrOutpListObject input)
    => Structured.Empty();

  internal static testCtgrOutpListEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_category_output_listEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_category_output_listEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestCtgrOutpListObject>(testCtgrOutpListEncoder.Factory);
}
