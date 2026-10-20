//HintName: test_domain-enum-unique-parent_Dec.gen.cs
// Generated from {CurrentDirectory}domain-enum-unique-parent.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_unique_parent;

internal class testDmnEnumUnqPrntDecoder : NullDecoder<ItestDmnEnumUnqPrnt>
{

  internal static testDmnEnumUnqPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumUnqPrntDecoder : NullDecoder<testEnumDmnEnumUnqPrnt>
{
  public string dmnEnumUnqPrnt { get; set; } = default!;
  public string prnt_dmnEnumUnqPrnt { get; set; } = default!;
  public string dmnEnumUnqPrntPrnt { get; set; } = default!;
  public string enum_dmnEnumUnqPrnt { get; set; } = default!;
  public string dmnEnumUnqPrntValue { get; set; } = default!;

  internal static testEnumDmnEnumUnqPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDmnEnumUnqPrntDecoder : NullDecoder<testPrntDmnEnumUnqPrnt>
{
  public string dmnEnumUnqPrnt { get; set; } = default!;
  public string prnt_dmnEnumUnqPrnt { get; set; } = default!;
  public string dmnEnumUnqPrntPrnt { get; set; } = default!;

  internal static testPrntDmnEnumUnqPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testDupDmnEnumUnqPrntDecoder : NullDecoder<testDupDmnEnumUnqPrnt>
{
  public string dmnEnumUnqPrnt { get; set; } = default!;
  public string dup_dmnEnumUnqPrnt { get; set; } = default!;
  public string dmnEnumUnqPrntDup { get; set; } = default!;

  internal static testDupDmnEnumUnqPrntDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_domain_enum_unique_parentDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_domain_enum_unique_parentDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDmnEnumUnqPrnt>(testDmnEnumUnqPrntDecoder.Factory)
      .AddDecoder<testEnumDmnEnumUnqPrnt>(testEnumDmnEnumUnqPrntDecoder.Factory)
      .AddDecoder<testPrntDmnEnumUnqPrnt>(testPrntDmnEnumUnqPrntDecoder.Factory)
      .AddDecoder<testDupDmnEnumUnqPrnt>(testDupDmnEnumUnqPrntDecoder.Factory);
}
