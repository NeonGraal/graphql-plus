//HintName: test_category-descrs_Enc.gen.cs
// Generated from {CurrentDirectory}category-descrs.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_category_descrs;

internal class testCtgrDscrsEncoder : IEncoder<ItestCtgrDscrsObject>
{
  public Structured Encode(ItestCtgrDscrsObject input)
    => Structured.Empty();

  internal static testCtgrDscrsEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_category_descrsEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_category_descrsEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestCtgrDscrsObject>(testCtgrDscrsEncoder.Factory);
}
