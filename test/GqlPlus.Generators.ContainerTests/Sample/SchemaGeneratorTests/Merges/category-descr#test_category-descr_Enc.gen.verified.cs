//HintName: test_category-descr_Enc.gen.cs
// Generated from {CurrentDirectory}category-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_category_descr;

internal class testCtgrDescrEncoder : IEncoder<ItestCtgrDescrObject>
{
  public Structured Encode(ItestCtgrDescrObject input)
    => Structured.Empty();
}

internal static class test_category_descrEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_category_descrEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestCtgrDescrObject>(_ => new testCtgrDescrEncoder());
}
