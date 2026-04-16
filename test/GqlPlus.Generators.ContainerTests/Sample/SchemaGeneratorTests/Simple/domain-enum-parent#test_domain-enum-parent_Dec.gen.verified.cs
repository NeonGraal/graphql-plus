//HintName: test_domain-enum-parent_Dec.gen.cs
// Generated from {CurrentDirectory}domain-enum-parent.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_parent;

internal class testDmnEnumPrntDecoder
{

  internal static testDmnEnumPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDmnEnumPrntDecoder
{

  internal static testPrntDmnEnumPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumPrntDecoder
{
  public string enum_dmnEnumPrnt { get; set; }
  public string prnt_dmnEnumPrnt { get; set; }

  internal static testEnumDmnEnumPrntDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_domain_enum_parentDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_domain_enum_parentDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDmnEnumPrnt>(testDmnEnumPrntDecoder.Factory)
      .AddDecoder<ItestPrntDmnEnumPrnt>(testPrntDmnEnumPrntDecoder.Factory)
      .AddDecoder<testEnumDmnEnumPrnt>(testEnumDmnEnumPrntDecoder.Factory);
}
