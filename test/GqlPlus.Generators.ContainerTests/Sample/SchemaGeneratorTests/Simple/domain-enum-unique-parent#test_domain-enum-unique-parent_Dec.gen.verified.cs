//HintName: test_domain-enum-unique-parent_Dec.gen.cs
// Generated from {CurrentDirectory}domain-enum-unique-parent.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_unique_parent;

internal class testDmnEnumUnqPrntDecoder : IDecoder<ItestDmnEnumUnqPrnt>
{

  public IMessages Decode(IValue input, out ItestDmnEnumUnqPrnt? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnEnumUnqPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumUnqPrntDecoder : IDecoder<testEnumDmnEnumUnqPrnt?>
{
  public IMessages Decode(IValue input, out testEnumDmnEnumUnqPrnt? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumDmnEnumUnqPrnt value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumDmnEnumUnqPrnt".AnError();
  }

  internal static testEnumDmnEnumUnqPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDmnEnumUnqPrntDecoder : IDecoder<testPrntDmnEnumUnqPrnt?>
{
  public IMessages Decode(IValue input, out testPrntDmnEnumUnqPrnt? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testPrntDmnEnumUnqPrnt value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testPrntDmnEnumUnqPrnt".AnError();
  }

  internal static testPrntDmnEnumUnqPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testDupDmnEnumUnqPrntDecoder : IDecoder<testDupDmnEnumUnqPrnt?>
{
  public IMessages Decode(IValue input, out testDupDmnEnumUnqPrnt? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testDupDmnEnumUnqPrnt value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testDupDmnEnumUnqPrnt".AnError();
  }

  internal static testDupDmnEnumUnqPrntDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_domain_enum_unique_parentDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_domain_enum_unique_parentDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDmnEnumUnqPrnt>(testDmnEnumUnqPrntDecoder.Factory)
      .AddDecoder<testEnumDmnEnumUnqPrnt?>(testEnumDmnEnumUnqPrntDecoder.Factory)
      .AddDecoder<testPrntDmnEnumUnqPrnt?>(testPrntDmnEnumUnqPrntDecoder.Factory)
      .AddDecoder<testDupDmnEnumUnqPrnt?>(testDupDmnEnumUnqPrntDecoder.Factory);
}
