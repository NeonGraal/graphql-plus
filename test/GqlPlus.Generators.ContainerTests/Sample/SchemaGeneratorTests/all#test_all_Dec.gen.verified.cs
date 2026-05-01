//HintName: test_all_Dec.gen.cs
// Generated from {CurrentDirectory}all.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_all;

internal class testGuidDecoder : IDecoder<ItestGuid>
{

  public IMessages Decode(IValue input, out ItestGuid? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testGuidDecoder Factory(IDecoderRepository _) => new();
}

internal class testOneDecoder : IDecoder<testOne?>
{
  public IMessages Decode(IValue input, out testOne? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testOne value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testOne".AnError();
  }

  internal static testOneDecoder Factory(IDecoderRepository _) => new();
}

internal class testManyDecoder : IDecoder<ItestMany>
{
  public Guid? AsGuid { get; set; }
  public Number? AsNumber { get; set; }

  public IMessages Decode(IValue input, out ItestMany? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testManyDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldDecoder : IDecoder<ItestFieldObject>
{
  public ICollection<string>? Strings { get; set; }

  public IMessages Decode(IValue input, out ItestFieldObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFieldDecoder Factory(IDecoderRepository _) => new();
}

internal class testParamDecoder : IDecoder<ItestParamObject>
{
  public ItestMany? AfterId { get; set; }
  public ItestMany? BeforeId { get; set; }

  public IMessages Decode(IValue input, out ItestParamObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testParamDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_allDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_allDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestGuid>(testGuidDecoder.Factory)
      .AddDecoder<testOne?>(testOneDecoder.Factory)
      .AddDecoder<ItestMany>(testManyDecoder.Factory)
      .AddDecoder<ItestFieldObject>(testFieldDecoder.Factory)
      .AddDecoder<ItestParamObject>(testParamDecoder.Factory);
}
