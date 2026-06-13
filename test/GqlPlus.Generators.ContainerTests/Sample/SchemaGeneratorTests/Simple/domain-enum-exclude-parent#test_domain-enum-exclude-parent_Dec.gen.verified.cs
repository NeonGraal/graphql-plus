//HintName: test_domain-enum-exclude-parent_Dec.gen.cs
// Generated from {CurrentDirectory}domain-enum-exclude-parent.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_exclude_parent;

internal class testDmnEnumExclPrntDecoder : NullDecoder<ItestDmnEnumExclPrnt>
{

  internal static testDmnEnumExclPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumExclPrntDecoder : NullDecoder<testEnumDmnEnumExclPrnt>
{
  public string prnt_dmnEnumExclPrnt { get; set; } = default!;
  public string dmnEnumExclPrntPrnt { get; set; } = default!;
  public string dmnEnumExclPrnt { get; set; } = default!;
  public string dmnEnumExclPrntValue { get; set; } = default!;

  internal static testEnumDmnEnumExclPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDmnEnumExclPrntDecoder : NullDecoder<testPrntDmnEnumExclPrnt>
{
  public string prnt_dmnEnumExclPrnt { get; set; } = default!;
  public string dmnEnumExclPrntPrnt { get; set; } = default!;

  internal static testPrntDmnEnumExclPrntDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_domain_enum_exclude_parentDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_domain_enum_exclude_parentDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDmnEnumExclPrnt>(testDmnEnumExclPrntDecoder.Factory)
      .AddDecoder<testEnumDmnEnumExclPrnt>(testEnumDmnEnumExclPrntDecoder.Factory)
      .AddDecoder<testPrntDmnEnumExclPrnt>(testPrntDmnEnumExclPrntDecoder.Factory);
}
