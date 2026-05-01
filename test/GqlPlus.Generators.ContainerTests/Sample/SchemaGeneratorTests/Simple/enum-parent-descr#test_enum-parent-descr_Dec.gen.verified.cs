//HintName: test_enum-parent-descr_Dec.gen.cs
// Generated from {CurrentDirectory}enum-parent-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_enum_parent_descr;

internal class testEnumPrntDescrDecoder : IDecoder<testEnumPrntDescr?>
{
  public IMessages Decode(IValue input, out testEnumPrntDescr? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumPrntDescr value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumPrntDescr".AnError();
  }

  internal static testEnumPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntEnumPrntDescrDecoder : IDecoder<testPrntEnumPrntDescr?>
{
  public IMessages Decode(IValue input, out testPrntEnumPrntDescr? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testPrntEnumPrntDescr value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testPrntEnumPrntDescr".AnError();
  }

  internal static testPrntEnumPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_enum_parent_descrDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_enum_parent_descrDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<testEnumPrntDescr?>(testEnumPrntDescrDecoder.Factory)
      .AddDecoder<testPrntEnumPrntDescr?>(testPrntEnumPrntDescrDecoder.Factory);
}
