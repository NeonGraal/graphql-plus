//HintName: test_domain-enum-all-descr_Dec.gen.cs
// Generated from {CurrentDirectory}domain-enum-all-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_all_descr;

internal class testDmnEnumAllDescrDecoder : IDecoder<ItestDmnEnumAllDescr>
{
  public testEnumDmnEnumAllDescr? Value { get; set; }

  public IMessages Decode(IValue input, out ItestDmnEnumAllDescr? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnEnumAllDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumAllDescrDecoder : IDecoder<testEnumDmnEnumAllDescr?>
{
  public IMessages Decode(IValue input, out testEnumDmnEnumAllDescr? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumDmnEnumAllDescr value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumDmnEnumAllDescr".AnError();
  }

  internal static testEnumDmnEnumAllDescrDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_domain_enum_all_descrDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_domain_enum_all_descrDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDmnEnumAllDescr>(testDmnEnumAllDescrDecoder.Factory)
      .AddDecoder<testEnumDmnEnumAllDescr?>(testEnumDmnEnumAllDescrDecoder.Factory);
}
