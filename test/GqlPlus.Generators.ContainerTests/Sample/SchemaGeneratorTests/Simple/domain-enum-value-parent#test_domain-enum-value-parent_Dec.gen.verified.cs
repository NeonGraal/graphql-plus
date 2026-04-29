//HintName: test_domain-enum-value-parent_Dec.gen.cs
// Generated from {CurrentDirectory}domain-enum-value-parent.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_value_parent;

internal class testDmnEnumValuePrntDecoder
{

  internal static testDmnEnumValuePrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumValuePrntDecoder : IDecoder<testEnumDmnEnumValuePrnt?>
{
  public IMessages Decoder(IValue input, out testEnumDmnEnumValuePrnt? output)
    => input.DecodeEnum("EnumDmnEnumValuePrnt", out output);

  internal static testEnumDmnEnumValuePrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDmnEnumValuePrntDecoder : IDecoder<testPrntDmnEnumValuePrnt?>
{
  public IMessages Decoder(IValue input, out testPrntDmnEnumValuePrnt? output)
    => input.DecodeEnum("PrntDmnEnumValuePrnt", out output);

  internal static testPrntDmnEnumValuePrntDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_domain_enum_value_parentDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_domain_enum_value_parentDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDmnEnumValuePrnt>(testDmnEnumValuePrntDecoder.Factory)
      .AddDecoder<testEnumDmnEnumValuePrnt?>(testEnumDmnEnumValuePrntDecoder.Factory)
      .AddDecoder<testPrntDmnEnumValuePrnt?>(testPrntDmnEnumValuePrntDecoder.Factory);
}
