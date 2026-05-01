//HintName: test_domain-enum-parent_Dec.gen.cs
// Generated from {CurrentDirectory}domain-enum-parent.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_parent;

internal class testDmnEnumPrntDecoder : IDecoder<ItestDmnEnumPrnt>
{
  public testEnumDmnEnumPrnt? Value { get; set; }

  public IMessages Decode(IValue input, out ItestDmnEnumPrnt? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnEnumPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDmnEnumPrntDecoder : IDecoder<ItestPrntDmnEnumPrnt>
{
  public testEnumDmnEnumPrnt? Value { get; set; }

  public IMessages Decode(IValue input, out ItestPrntDmnEnumPrnt? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntDmnEnumPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumPrntDecoder : IDecoder<testEnumDmnEnumPrnt?>
{
  public IMessages Decode(IValue input, out testEnumDmnEnumPrnt? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumDmnEnumPrnt value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumDmnEnumPrnt".AnError();
  }

  internal static testEnumDmnEnumPrntDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_domain_enum_parentDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_domain_enum_parentDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDmnEnumPrnt>(testDmnEnumPrntDecoder.Factory)
      .AddDecoder<ItestPrntDmnEnumPrnt>(testPrntDmnEnumPrntDecoder.Factory)
      .AddDecoder<testEnumDmnEnumPrnt?>(testEnumDmnEnumPrntDecoder.Factory);
}
