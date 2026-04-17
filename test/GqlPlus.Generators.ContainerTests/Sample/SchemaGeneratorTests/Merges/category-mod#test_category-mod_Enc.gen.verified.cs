//HintName: test_category-mod_Enc.gen.cs
// Generated from {CurrentDirectory}category-mod.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_category_mod;

internal class testCtgrModEncoder : IEncoder<ItestCtgrModObject>
{
  public Structured Encode(ItestCtgrModObject input)
    => Structured.Empty();

  internal static testCtgrModEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_category_modEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_category_modEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestCtgrModObject>(testCtgrModEncoder.Factory);
}
