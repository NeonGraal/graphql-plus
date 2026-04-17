//HintName: test_category-output-optional_Enc.gen.cs
// Generated from {CurrentDirectory}category-output-optional.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_category_output_optional;

internal class testCtgrOutpOptlEncoder : IEncoder<ItestCtgrOutpOptlObject>
{
  public Structured Encode(ItestCtgrOutpOptlObject input)
    => Structured.Empty();

  internal static testCtgrOutpOptlEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_category_output_optionalEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_category_output_optionalEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestCtgrOutpOptlObject>(testCtgrOutpOptlEncoder.Factory);
}
