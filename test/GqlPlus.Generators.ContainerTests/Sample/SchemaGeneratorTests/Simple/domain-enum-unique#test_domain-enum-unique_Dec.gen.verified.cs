//HintName: test_domain-enum-unique_Dec.gen.cs
// Generated from {CurrentDirectory}domain-enum-unique.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_unique;

internal class testDmnEnumUnqDecoder
{

  internal static testDmnEnumUnqDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumUnqDecoder : IDecoder<testEnumDmnEnumUnq?>
{
  public IMessages Decoder(IValue input, out testEnumDmnEnumUnq? output)
    => input.DecodeEnum("EnumDmnEnumUnq", out output);

  internal static testEnumDmnEnumUnqDecoder Factory(IDecoderRepository _) => new();
}

internal class testDupDmnEnumUnqDecoder : IDecoder<testDupDmnEnumUnq?>
{
  public IMessages Decoder(IValue input, out testDupDmnEnumUnq? output)
    => input.DecodeEnum("DupDmnEnumUnq", out output);

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
