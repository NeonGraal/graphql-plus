//HintName: test_domain-enum-value-parent_Dec.gen.cs
// Generated from {CurrentDirectory}domain-enum-value-parent.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_value_parent;

internal class testDmnEnumValuePrntDecoder : IDecoder<ItestDmnEnumValuePrnt>
{
  public testEnumDmnEnumValuePrnt? Value { get; set; }

  public IMessages Decode(IValue input, out ItestDmnEnumValuePrnt? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnEnumValuePrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumValuePrntDecoder : IDecoder<testEnumDmnEnumValuePrnt?>
{
  public IMessages Decode(IValue input, out testEnumDmnEnumValuePrnt? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumDmnEnumValuePrnt value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumDmnEnumValuePrnt".AnError();
  }

  internal static testEnumDmnEnumValuePrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDmnEnumValuePrntDecoder : IDecoder<testPrntDmnEnumValuePrnt?>
{
  public IMessages Decode(IValue input, out testPrntDmnEnumValuePrnt? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testPrntDmnEnumValuePrnt value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testPrntDmnEnumValuePrnt".AnError();
  }

  internal static testPrntDmnEnumValuePrntDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_domain_enum_value_parentDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_domain_enum_value_parentDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDmnEnumValuePrnt>(testDmnEnumValuePrntDecoder.Factory)
      .AddDecoder<testEnumDmnEnumValuePrnt?>(testEnumDmnEnumValuePrntDecoder.Factory)
      .AddDecoder<testPrntDmnEnumValuePrnt?>(testPrntDmnEnumValuePrntDecoder.Factory);
}
