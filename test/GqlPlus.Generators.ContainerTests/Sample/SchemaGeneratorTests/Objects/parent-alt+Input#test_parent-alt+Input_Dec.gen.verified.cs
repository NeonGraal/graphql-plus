//HintName: test_parent-alt+Input_Dec.gen.cs
// Generated from {CurrentDirectory}parent-alt+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_alt_Input;

internal class testPrntAltInpDecoder : IDecoder<ItestPrntAltInpObject>
{

  public IMessages Decode(IValue input, out ItestPrntAltInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntAltInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefPrntAltInpDecoder : IDecoder<ItestRefPrntAltInpObject>
{
  public decimal? Parent { get; set; }

  public IMessages Decode(IValue input, out ItestRefPrntAltInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testRefPrntAltInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_parent_alt_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_parent_alt_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestPrntAltInpObject>(testPrntAltInpDecoder.Factory)
      .AddDecoder<ItestRefPrntAltInpObject>(testRefPrntAltInpDecoder.Factory);
}
