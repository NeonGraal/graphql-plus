//HintName: test_category-output-descr_Enc.gen.cs
// Generated from {CurrentDirectory}category-output-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_category_output_descr;

internal class testCtgrOutpDescrEncoder : IEncoder<ItestCtgrOutpDescrObject>
{
  public Structured Encode(ItestCtgrOutpDescrObject input)
    => Structured.Empty();
}

internal static class test_category_output_descrEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_category_output_descrEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestCtgrOutpDescrObject>(_ => new testCtgrOutpDescrEncoder());
}
