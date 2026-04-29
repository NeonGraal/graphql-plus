//HintName: test_Category_Dec.gen.cs
// Generated from {CurrentDirectory}Category.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Category;

internal class test_ResolutionDecoder : IDecoder<test_Resolution?>
{
  public IMessages Decoder(IValue input, out test_Resolution? output)
    => input.DecodeEnum("_Resolution", out output);

  internal static test_ResolutionDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_CategoryDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_CategoryDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<test_Resolution?>(test_ResolutionDecoder.Factory);
}
