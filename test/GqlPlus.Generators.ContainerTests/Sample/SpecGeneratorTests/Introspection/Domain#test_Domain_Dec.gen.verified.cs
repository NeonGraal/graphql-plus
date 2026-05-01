//HintName: test_Domain_Dec.gen.cs
// Generated from {CurrentDirectory}Domain.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Domain;

internal class test_DomainKindDecoder : IDecoder<test_DomainKind?>
{
  public IMessages Decode(IValue input, out test_DomainKind? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out test_DomainKind value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode test_DomainKind".AnError();
  }

  internal static test_DomainKindDecoder Factory(IDecoderRepository _) => new();
}

internal class test_BaseDomainItemDecoder : IDecoder<Itest_BaseDomainItemObject>
{
  public bool? Exclude { get; set; }

  public IMessages Decode(IValue input, out Itest_BaseDomainItemObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static test_BaseDomainItemDecoder Factory(IDecoderRepository _) => new();
}

internal class test_DomainTrueFalseDecoder : IDecoder<Itest_DomainTrueFalseObject>
{
  public bool? Value { get; set; }

  public IMessages Decode(IValue input, out Itest_DomainTrueFalseObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static test_DomainTrueFalseDecoder Factory(IDecoderRepository _) => new();
}

internal class test_DomainRangeDecoder : IDecoder<Itest_DomainRangeObject>
{
  public decimal? Lower { get; set; }
  public decimal? Upper { get; set; }

  public IMessages Decode(IValue input, out Itest_DomainRangeObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static test_DomainRangeDecoder Factory(IDecoderRepository _) => new();
}

internal class test_DomainRegexDecoder : IDecoder<Itest_DomainRegexObject>
{
  public string? Pattern { get; set; }

  public IMessages Decode(IValue input, out Itest_DomainRegexObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static test_DomainRegexDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_DomainDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_DomainDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<test_DomainKind?>(test_DomainKindDecoder.Factory)
      .AddDecoder<Itest_BaseDomainItemObject>(test_BaseDomainItemDecoder.Factory)
      .AddDecoder<Itest_DomainTrueFalseObject>(test_DomainTrueFalseDecoder.Factory)
      .AddDecoder<Itest_DomainRangeObject>(test_DomainRangeDecoder.Factory)
      .AddDecoder<Itest_DomainRegexObject>(test_DomainRegexDecoder.Factory);
}
