//HintName: test_parent+Input_Dec.gen.cs
// Generated from {CurrentDirectory}parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_Input;

internal class testPrntInpDecoder : IDecoder<ItestPrntInpObject>
{

  public IMessages Decode(IValue input, out ItestPrntInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefPrntInpDecoder : IDecoder<ItestRefPrntInpObject>
{
  public decimal? Parent { get; set; }

  public IMessages Decode(IValue input, out ItestRefPrntInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testRefPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_parent_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_parent_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestPrntInpObject>(testPrntInpDecoder.Factory)
      .AddDecoder<ItestRefPrntInpObject>(testRefPrntInpDecoder.Factory);
}
