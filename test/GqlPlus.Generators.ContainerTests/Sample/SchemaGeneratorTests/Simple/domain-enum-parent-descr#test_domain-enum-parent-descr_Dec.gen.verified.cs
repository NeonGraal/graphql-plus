//HintName: test_domain-enum-parent-descr_Dec.gen.cs
// Generated from {CurrentDirectory}domain-enum-parent-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_parent_descr;

internal class testDmnEnumPrntDescrDecoder
{

  internal static testDmnEnumPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDmnEnumPrntDescrDecoder
{

  internal static testPrntDmnEnumPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumPrntDescrDecoder
{
  public string enum_dmnEnumPrntDescr { get; set; }
  public string prnt_dmnEnumPrntDescr { get; set; }

  internal static testEnumDmnEnumPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_domain_enum_parent_descrDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_domain_enum_parent_descrDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDmnEnumPrntDescr>(testDmnEnumPrntDescrDecoder.Factory)
      .AddDecoder<ItestPrntDmnEnumPrntDescr>(testPrntDmnEnumPrntDescrDecoder.Factory)
      .AddDecoder<testEnumDmnEnumPrntDescr>(testEnumDmnEnumPrntDescrDecoder.Factory);
}
