//HintName: test_-Simple_Dec.gen.cs
// Generated from {CurrentDirectory}-Simple.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Simple;

internal class test_DomainKindDecoder : NullDecoder<test_DomainKind>
{
  public string Boolean { get; set; } = default!;
  public string Enum { get; set; } = default!;
  public string Number { get; set; } = default!;
  public string String { get; set; } = default!;

  internal static test_DomainKindDecoder Factory(IDecoderRepository _) => new();
}

internal class test_BaseDomainItemDecoder : NullDecoder<Itest_BaseDomainItemObject>
{
  public bool Exclude { get; set; } = default!;

  internal static test_BaseDomainItemDecoder Factory(IDecoderRepository _) => new();
}

internal class test_DomainTrueFalseDecoder : NullDecoder<Itest_DomainTrueFalseObject>
{
  public bool Value { get; set; } = default!;

  internal static test_DomainTrueFalseDecoder Factory(IDecoderRepository _) => new();
}

internal class test_DomainRangeDecoder : NullDecoder<Itest_DomainRangeObject>
{
  public decimal? Lower { get; set; } = default!;
  public decimal? Upper { get; set; } = default!;

  internal static test_DomainRangeDecoder Factory(IDecoderRepository _) => new();
}

internal class test_DomainRegexDecoder : NullDecoder<Itest_DomainRegexObject>
{
  public string Pattern { get; set; } = default!;

  internal static test_DomainRegexDecoder Factory(IDecoderRepository _) => new();
}

internal class test_EnumLabelDecoder : NullDecoder<Itest_EnumLabelObject>
{
  public Itest_Name EnumType { get; set; } = default!;

  internal static test_EnumLabelDecoder Factory(IDecoderRepository _) => new();
}

internal static class test__SimpleDecoders
{
  internal static IDecoderRepositoryBuilder Addtest__SimpleDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<test_DomainKind>(test_DomainKindDecoder.Factory)
      .AddDecoder<Itest_BaseDomainItemObject>(test_BaseDomainItemDecoder.Factory)
      .AddDecoder<Itest_DomainTrueFalseObject>(test_DomainTrueFalseDecoder.Factory)
      .AddDecoder<Itest_DomainRangeObject>(test_DomainRangeDecoder.Factory)
      .AddDecoder<Itest_DomainRegexObject>(test_DomainRegexDecoder.Factory)
      .AddDecoder<Itest_EnumLabelObject>(test_EnumLabelDecoder.Factory);
}
