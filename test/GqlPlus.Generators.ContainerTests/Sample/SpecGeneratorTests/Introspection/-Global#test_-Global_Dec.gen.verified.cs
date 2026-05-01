//HintName: test_-Global_Dec.gen.cs
// Generated from {CurrentDirectory}-Global.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Global;

internal class test_ResolutionDecoder : IDecoder<test_Resolution?>
{
  public IMessages Decode(IValue input, out test_Resolution? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out test_Resolution value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode test_Resolution".AnError();
  }

  internal static test_ResolutionDecoder Factory(IDecoderRepository _) => new();
}

internal class test_LocationDecoder : IDecoder<test_Location?>
{
  public IMessages Decode(IValue input, out test_Location? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out test_Location value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode test_Location".AnError();
  }

  internal static test_LocationDecoder Factory(IDecoderRepository _) => new();
}

internal static class test__GlobalDecoders
{
  internal static IDecoderRepositoryBuilder Addtest__GlobalDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<test_Resolution?>(test_ResolutionDecoder.Factory)
      .AddDecoder<test_Location?>(test_LocationDecoder.Factory);
}
