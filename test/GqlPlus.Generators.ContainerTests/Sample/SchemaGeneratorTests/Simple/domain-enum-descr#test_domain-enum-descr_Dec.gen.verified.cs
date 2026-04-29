//HintName: test_domain-enum-descr_Dec.gen.cs
// Generated from {CurrentDirectory}domain-enum-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_descr;

internal class testDmnEnumDescrDecoder
{
  public new testEnumDmnEnumDescr? Value { get; set; }

  internal static testDmnEnumDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumDescrDecoder : IDecoder<testEnumDmnEnumDescr?>
{
  public IMessages Decoder(IValue input, out testEnumDmnEnumDescr? output)
    => input.DecodeEnum("EnumDmnEnumDescr", out output);

  internal static testEnumDmnEnumDescrDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_domain_enum_descrDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_domain_enum_descrDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDmnEnumDescr>(testDmnEnumDescrDecoder.Factory)
      .AddDecoder<testEnumDmnEnumDescr?>(testEnumDmnEnumDescrDecoder.Factory);
}
