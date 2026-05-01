//HintName: test_domain-enum-parent-descr_Dec.gen.cs
// Generated from {CurrentDirectory}domain-enum-parent-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_parent_descr;

internal class testDmnEnumPrntDescrDecoder : IDecoder<ItestDmnEnumPrntDescr>
{
  public testEnumDmnEnumPrntDescr? Value { get; set; }

  public IMessages Decode(IValue input, out ItestDmnEnumPrntDescr? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnEnumPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDmnEnumPrntDescrDecoder : IDecoder<ItestPrntDmnEnumPrntDescr>
{
  public testEnumDmnEnumPrntDescr? Value { get; set; }

  public IMessages Decode(IValue input, out ItestPrntDmnEnumPrntDescr? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntDmnEnumPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumPrntDescrDecoder : IDecoder<testEnumDmnEnumPrntDescr?>
{
  public IMessages Decode(IValue input, out testEnumDmnEnumPrntDescr? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumDmnEnumPrntDescr value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumDmnEnumPrntDescr".AnError();
  }

  internal static testEnumDmnEnumPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_domain_enum_parent_descrDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_domain_enum_parent_descrDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDmnEnumPrntDescr>(testDmnEnumPrntDescrDecoder.Factory)
      .AddDecoder<ItestPrntDmnEnumPrntDescr>(testPrntDmnEnumPrntDescrDecoder.Factory)
      .AddDecoder<testEnumDmnEnumPrntDescr?>(testEnumDmnEnumPrntDescrDecoder.Factory);
}
