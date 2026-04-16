//HintName: test_category-output-dict_Enc.gen.cs
// Generated from {CurrentDirectory}category-output-dict.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_category_output_dict;

internal class testCtgrOutpDictEncoder : IEncoder<ItestCtgrOutpDictObject>
{
  public Structured Encode(ItestCtgrOutpDictObject input)
    => Structured.Empty();

  internal static testCtgrOutpDictEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_category_output_dictEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_category_output_dictEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestCtgrOutpDictObject>(testCtgrOutpDictEncoder.Factory);
}
