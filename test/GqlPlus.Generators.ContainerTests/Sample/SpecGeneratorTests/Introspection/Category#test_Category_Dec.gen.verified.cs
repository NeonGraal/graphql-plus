//HintName: test_Category_Dec.gen.cs
// Generated from {CurrentDirectory}Category.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Category;

internal class test_ResolutionDecoder : IDecoder<test_Resolution?>
{
  public IMessages Decode(IValue input, out test_Resolution? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out test_Resolution value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode test_Resolution".AnError();
  }

  internal static test_ResolutionDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_CategoryDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_CategoryDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<test_Resolution?>(test_ResolutionDecoder.Factory);
}
