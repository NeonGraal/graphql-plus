//HintName: test_enum-descr_Dec.gen.cs
// Generated from {CurrentDirectory}enum-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_enum_descr;

internal class testEnumDescrDecoder : IDecoder<testEnumDescr?>
{
  public IMessages Decode(IValue input, out testEnumDescr? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumDescr value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumDescr".AnError();
  }

  internal static testEnumDescrDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_enum_descrDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_enum_descrDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<testEnumDescr?>(testEnumDescrDecoder.Factory);
}
