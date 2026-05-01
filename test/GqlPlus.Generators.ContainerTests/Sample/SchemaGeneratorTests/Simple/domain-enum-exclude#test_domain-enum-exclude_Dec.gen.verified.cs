//HintName: test_domain-enum-exclude_Dec.gen.cs
// Generated from {CurrentDirectory}domain-enum-exclude.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_exclude;

internal class testDmnEnumExclDecoder : IDecoder<ItestDmnEnumExcl>
{
  public testEnumDmnEnumExcl? Value { get; set; }

  public IMessages Decode(IValue input, out ItestDmnEnumExcl? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnEnumExclDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumExclDecoder : IDecoder<testEnumDmnEnumExcl?>
{
  public IMessages Decode(IValue input, out testEnumDmnEnumExcl? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumDmnEnumExcl value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumDmnEnumExcl".AnError();
  }

  internal static testEnumDmnEnumExclDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_domain_enum_excludeDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_domain_enum_excludeDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDmnEnumExcl>(testDmnEnumExclDecoder.Factory)
      .AddDecoder<testEnumDmnEnumExcl?>(testEnumDmnEnumExclDecoder.Factory);
}
