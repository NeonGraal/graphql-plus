//HintName: test_Category_Dec.gen.cs
// Generated from {CurrentDirectory}Category.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Category;

internal class test_ResolutionDecoder
{
  public string Parallel { get; set; }
  public string Sequential { get; set; }
  public string Single { get; set; }

  internal static test_ResolutionDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_CategoryDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_CategoryDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<test_Resolution>(test_ResolutionDecoder.Factory);
}
