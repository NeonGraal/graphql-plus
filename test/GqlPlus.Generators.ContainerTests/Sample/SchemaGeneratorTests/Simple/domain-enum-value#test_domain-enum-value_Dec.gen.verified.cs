//HintName: test_domain-enum-value_Dec.gen.cs
// Generated from {CurrentDirectory}domain-enum-value.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_value;

internal class testDmnEnumValueDecoder : IDecoder<ItestDmnEnumValue>
{
  public testEnumDmnEnumValue? Value { get; set; }

  public IMessages Decode(IValue input, out ItestDmnEnumValue? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnEnumValueDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumValueDecoder : IDecoder<testEnumDmnEnumValue?>
{
  public IMessages Decode(IValue input, out testEnumDmnEnumValue? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumDmnEnumValue value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumDmnEnumValue".AnError();
  }

  internal static testEnumDmnEnumValueDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_domain_enum_valueDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_domain_enum_valueDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDmnEnumValue>(testDmnEnumValueDecoder.Factory)
      .AddDecoder<testEnumDmnEnumValue?>(testEnumDmnEnumValueDecoder.Factory);
}
