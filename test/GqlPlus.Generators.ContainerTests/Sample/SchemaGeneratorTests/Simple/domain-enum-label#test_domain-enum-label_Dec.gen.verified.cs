//HintName: test_domain-enum-label_Dec.gen.cs
// Generated from {CurrentDirectory}domain-enum-label.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_label;

internal class testDmnEnumLabelDecoder : IDecoder<ItestDmnEnumLabel>
{
  public testEnumDmnEnumLabel? Value { get; set; }

  public IMessages Decode(IValue input, out ItestDmnEnumLabel? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnEnumLabelDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumLabelDecoder : IDecoder<testEnumDmnEnumLabel?>
{
  public IMessages Decode(IValue input, out testEnumDmnEnumLabel? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumDmnEnumLabel value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumDmnEnumLabel".AnError();
  }

  internal static testEnumDmnEnumLabelDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_domain_enum_labelDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_domain_enum_labelDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDmnEnumLabel>(testDmnEnumLabelDecoder.Factory)
      .AddDecoder<testEnumDmnEnumLabel?>(testEnumDmnEnumLabelDecoder.Factory);
}
