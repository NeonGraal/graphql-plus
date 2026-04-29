//HintName: test_domain-enum-value_Dec.gen.cs
// Generated from {CurrentDirectory}domain-enum-value.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_value;

internal class testDmnEnumValueDecoder
{
  public new testEnumDmnEnumValue? Value { get; set; }

  internal static testDmnEnumValueDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumValueDecoder : IDecoder<testEnumDmnEnumValue?>
{
  public IMessages Decoder(IValue input, out testEnumDmnEnumValue? output)
    => input.DecodeEnum("EnumDmnEnumValue", out output);

  internal static testEnumDmnEnumValueDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_domain_enum_valueDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_domain_enum_valueDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDmnEnumValue>(testDmnEnumValueDecoder.Factory)
      .AddDecoder<testEnumDmnEnumValue?>(testEnumDmnEnumValueDecoder.Factory);
}
