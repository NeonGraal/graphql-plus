//HintName: test_domain-enum-exclude-parent_Dec.gen.cs
// Generated from {CurrentDirectory}domain-enum-exclude-parent.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_exclude_parent;

internal class testDmnEnumExclPrntDecoder
{

  internal static testDmnEnumExclPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumExclPrntDecoder : IDecoder<testEnumDmnEnumExclPrnt?>
{
  public IMessages Decoder(IValue input, out testEnumDmnEnumExclPrnt? output)
    => input.DecodeEnum("EnumDmnEnumExclPrnt", out output);

  internal static testEnumDmnEnumExclPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDmnEnumExclPrntDecoder : IDecoder<testPrntDmnEnumExclPrnt?>
{
  public IMessages Decoder(IValue input, out testPrntDmnEnumExclPrnt? output)
    => input.DecodeEnum("PrntDmnEnumExclPrnt", out output);

  internal static testPrntDmnEnumExclPrntDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_domain_enum_exclude_parentDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_domain_enum_exclude_parentDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDmnEnumExclPrnt>(testDmnEnumExclPrntDecoder.Factory)
      .AddDecoder<testEnumDmnEnumExclPrnt?>(testEnumDmnEnumExclPrntDecoder.Factory)
      .AddDecoder<testPrntDmnEnumExclPrnt?>(testPrntDmnEnumExclPrntDecoder.Factory);
}
