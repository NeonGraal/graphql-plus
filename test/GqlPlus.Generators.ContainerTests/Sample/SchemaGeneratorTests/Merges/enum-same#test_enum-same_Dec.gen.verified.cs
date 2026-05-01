//HintName: test_enum-same_Dec.gen.cs
// Generated from {CurrentDirectory}enum-same.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_enum_same;

internal class testEnumSameDecoder : IDecoder<testEnumSame?>
{
  public IMessages Decode(IValue input, out testEnumSame? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumSame value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumSame".AnError();
  }

  internal static testEnumSameDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_enum_sameDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_enum_sameDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<testEnumSame?>(testEnumSameDecoder.Factory);
}
