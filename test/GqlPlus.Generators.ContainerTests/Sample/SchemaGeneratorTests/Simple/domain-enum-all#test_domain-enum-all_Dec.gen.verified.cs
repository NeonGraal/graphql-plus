//HintName: test_domain-enum-all_Dec.gen.cs
// Generated from {CurrentDirectory}domain-enum-all.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_all;

internal class testDmnEnumAllDecoder : IDecoder<ItestDmnEnumAll>
{
  public testEnumDmnEnumAll? Value { get; set; }

  public IMessages Decode(IValue input, out ItestDmnEnumAll? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnEnumAllDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumAllDecoder : IDecoder<testEnumDmnEnumAll?>
{
  public IMessages Decode(IValue input, out testEnumDmnEnumAll? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumDmnEnumAll value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumDmnEnumAll".AnError();
  }

  internal static testEnumDmnEnumAllDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_domain_enum_allDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_domain_enum_allDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDmnEnumAll>(testDmnEnumAllDecoder.Factory)
      .AddDecoder<testEnumDmnEnumAll?>(testEnumDmnEnumAllDecoder.Factory);
}
