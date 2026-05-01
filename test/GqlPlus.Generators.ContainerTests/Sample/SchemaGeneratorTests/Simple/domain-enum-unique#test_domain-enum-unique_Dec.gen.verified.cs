//HintName: test_domain-enum-unique_Dec.gen.cs
// Generated from {CurrentDirectory}domain-enum-unique.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_unique;

internal class testDmnEnumUnqDecoder : IDecoder<ItestDmnEnumUnq>
{

  public IMessages Decode(IValue input, out ItestDmnEnumUnq? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnEnumUnqDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumUnqDecoder : IDecoder<testEnumDmnEnumUnq?>
{
  public IMessages Decode(IValue input, out testEnumDmnEnumUnq? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumDmnEnumUnq value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumDmnEnumUnq".AnError();
  }

  internal static testEnumDmnEnumUnqDecoder Factory(IDecoderRepository _) => new();
}

internal class testDupDmnEnumUnqDecoder : IDecoder<testDupDmnEnumUnq?>
{
  public IMessages Decode(IValue input, out testDupDmnEnumUnq? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testDupDmnEnumUnq value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testDupDmnEnumUnq".AnError();
  }

  internal static testDupDmnEnumUnqDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_domain_enum_uniqueDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_domain_enum_uniqueDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDmnEnumUnq>(testDmnEnumUnqDecoder.Factory)
      .AddDecoder<testEnumDmnEnumUnq?>(testEnumDmnEnumUnqDecoder.Factory)
      .AddDecoder<testDupDmnEnumUnq?>(testDupDmnEnumUnqDecoder.Factory);
}
