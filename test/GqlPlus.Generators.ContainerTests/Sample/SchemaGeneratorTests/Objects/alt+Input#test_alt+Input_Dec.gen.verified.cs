//HintName: test_alt+Input_Dec.gen.cs
// Generated from {CurrentDirectory}alt+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_Input;

internal class testAltInpDecoder : IDecoder<ItestAltInpObject>
{

  public IMessages Decode(IValue input, out ItestAltInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltAltInpDecoder : IDecoder<ItestAltAltInpObject>
{
  public decimal? Alt { get; set; }

  public IMessages Decode(IValue input, out ItestAltAltInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltAltInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_alt_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_alt_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestAltInpObject>(testAltInpDecoder.Factory)
      .AddDecoder<ItestAltAltInpObject>(testAltAltInpDecoder.Factory);
}
