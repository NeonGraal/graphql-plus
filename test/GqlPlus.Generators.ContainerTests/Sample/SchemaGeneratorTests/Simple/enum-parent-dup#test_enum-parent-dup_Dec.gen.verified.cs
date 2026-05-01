//HintName: test_enum-parent-dup_Dec.gen.cs
// Generated from {CurrentDirectory}enum-parent-dup.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_enum_parent_dup;

internal class testEnumPrntDupDecoder : IDecoder<testEnumPrntDup?>
{
  public IMessages Decode(IValue input, out testEnumPrntDup? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumPrntDup value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumPrntDup".AnError();
  }

  internal static testEnumPrntDupDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntEnumPrntDupDecoder : IDecoder<testPrntEnumPrntDup?>
{
  public IMessages Decode(IValue input, out testPrntEnumPrntDup? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testPrntEnumPrntDup value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testPrntEnumPrntDup".AnError();
  }

  internal static testPrntEnumPrntDupDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_enum_parent_dupDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_enum_parent_dupDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<testEnumPrntDup?>(testEnumPrntDupDecoder.Factory)
      .AddDecoder<testPrntEnumPrntDup?>(testPrntEnumPrntDupDecoder.Factory);
}
