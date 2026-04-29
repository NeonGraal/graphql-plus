//HintName: test_domain-enum-parent_Dec.gen.cs
// Generated from {CurrentDirectory}domain-enum-parent.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_parent;

internal class testDmnEnumPrntDecoder
{
  public new testEnumDmnEnumPrnt? Value { get; set; }

  internal static testDmnEnumPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDmnEnumPrntDecoder
{
  public new testEnumDmnEnumPrnt? Value { get; set; }

  internal static testPrntDmnEnumPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumPrntDecoder : IDecoder<testEnumDmnEnumPrnt?>
{
  public IMessages Decoder(IValue input, out testEnumDmnEnumPrnt? output)
    => input.DecodeEnum("EnumDmnEnumPrnt", out output);

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
