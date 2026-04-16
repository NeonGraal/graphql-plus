//HintName: test_category-output_Enc.gen.cs
// Generated from {CurrentDirectory}category-output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_category_output;

internal class testCtgrOutpEncoder : IEncoder<ItestCtgrOutpObject>
{
  public Structured Encode(ItestCtgrOutpObject input)
    => Structured.Empty();

  internal static testCtgrOutpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_category_outputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_category_outputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestCtgrOutpObject>(testCtgrOutpEncoder.Factory);
}
