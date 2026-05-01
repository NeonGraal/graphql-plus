//HintName: test_parent-descr+Input_Dec.gen.cs
// Generated from {CurrentDirectory}parent-descr+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_descr_Input;

internal class testPrntDescrInpDecoder : IDecoder<ItestPrntDescrInpObject>
{

  public IMessages Decode(IValue input, out ItestPrntDescrInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntDescrInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefPrntDescrInpDecoder : IDecoder<ItestRefPrntDescrInpObject>
{
  public decimal? Parent { get; set; }

  public IMessages Decode(IValue input, out ItestRefPrntDescrInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testRefPrntDescrInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_parent_descr_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_parent_descr_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestPrntDescrInpObject>(testPrntDescrInpDecoder.Factory)
      .AddDecoder<ItestRefPrntDescrInpObject>(testRefPrntDescrInpDecoder.Factory);
}
