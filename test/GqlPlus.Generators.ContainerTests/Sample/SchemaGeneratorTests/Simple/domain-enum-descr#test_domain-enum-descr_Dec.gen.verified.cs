//HintName: test_domain-enum-descr_Dec.gen.cs
// Generated from {CurrentDirectory}domain-enum-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_descr;

internal class testDmnEnumDescrDecoder : IDecoder<ItestDmnEnumDescr>
{
  public testEnumDmnEnumDescr? Value { get; set; }

  public IMessages Decode(IValue input, out ItestDmnEnumDescr? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnEnumDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumDescrDecoder : IDecoder<testEnumDmnEnumDescr?>
{
  public IMessages Decode(IValue input, out testEnumDmnEnumDescr? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumDmnEnumDescr value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumDmnEnumDescr".AnError();
  }

  internal static testEnumDmnEnumDescrDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_domain_enum_descrDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_domain_enum_descrDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDmnEnumDescr>(testDmnEnumDescrDecoder.Factory)
      .AddDecoder<testEnumDmnEnumDescr?>(testEnumDmnEnumDescrDecoder.Factory);
}
