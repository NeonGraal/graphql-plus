//HintName: test_domain-enum-unique-parent_Dec.gen.cs
// Generated from {CurrentDirectory}domain-enum-unique-parent.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_unique_parent;

internal class testDmnEnumUnqPrntDecoder
{

  internal static testDmnEnumUnqPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumUnqPrntDecoder : IDecoder<testEnumDmnEnumUnqPrnt?>
{
  public IMessages Decoder(IValue input, out testEnumDmnEnumUnqPrnt? output)
    => input.DecodeEnum("EnumDmnEnumUnqPrnt", out output);

  internal static testEnumDmnEnumUnqPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDmnEnumUnqPrntDecoder : IDecoder<testPrntDmnEnumUnqPrnt?>
{
  public IMessages Decoder(IValue input, out testPrntDmnEnumUnqPrnt? output)
    => input.DecodeEnum("PrntDmnEnumUnqPrnt", out output);

  internal static testPrntDmnEnumUnqPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testDupDmnEnumUnqPrntDecoder : IDecoder<testDupDmnEnumUnqPrnt?>
{
  public IMessages Decoder(IValue input, out testDupDmnEnumUnqPrnt? output)
    => input.DecodeEnum("DupDmnEnumUnqPrnt", out output);

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
