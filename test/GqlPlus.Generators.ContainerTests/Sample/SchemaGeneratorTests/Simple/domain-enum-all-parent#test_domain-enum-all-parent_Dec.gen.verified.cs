//HintName: test_domain-enum-all-parent_Dec.gen.cs
// Generated from {CurrentDirectory}domain-enum-all-parent.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_all_parent;

internal class testDmnEnumAllPrntDecoder : IDecoder<ItestDmnEnumAllPrnt>
{
  public testEnumDmnEnumAllPrnt? Value { get; set; }

  public IMessages Decode(IValue input, out ItestDmnEnumAllPrnt? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnEnumAllPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumAllPrntDecoder : IDecoder<testEnumDmnEnumAllPrnt?>
{
  public IMessages Decode(IValue input, out testEnumDmnEnumAllPrnt? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumDmnEnumAllPrnt value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumDmnEnumAllPrnt".AnError();
  }

  internal static testEnumDmnEnumAllPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDmnEnumAllPrntDecoder : IDecoder<testPrntDmnEnumAllPrnt?>
{
  public IMessages Decode(IValue input, out testPrntDmnEnumAllPrnt? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testPrntDmnEnumAllPrnt value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testPrntDmnEnumAllPrnt".AnError();
  }

  internal static testPrntDmnEnumAllPrntDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_domain_enum_all_parentDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_domain_enum_all_parentDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDmnEnumAllPrnt>(testDmnEnumAllPrntDecoder.Factory)
      .AddDecoder<testEnumDmnEnumAllPrnt?>(testEnumDmnEnumAllPrntDecoder.Factory)
      .AddDecoder<testPrntDmnEnumAllPrnt?>(testPrntDmnEnumAllPrntDecoder.Factory);
}
