//HintName: test_parent-field+Input_Dec.gen.cs
// Generated from {CurrentDirectory}parent-field+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_field_Input;

internal class testPrntFieldInpDecoder : IDecoder<ItestPrntFieldInpObject>
{
  public decimal? Field { get; set; }

  public IMessages Decode(IValue input, out ItestPrntFieldInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntFieldInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefPrntFieldInpDecoder : IDecoder<ItestRefPrntFieldInpObject>
{
  public decimal? Parent { get; set; }

  public IMessages Decode(IValue input, out ItestRefPrntFieldInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testRefPrntFieldInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_parent_field_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_parent_field_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestPrntFieldInpObject>(testPrntFieldInpDecoder.Factory)
      .AddDecoder<ItestRefPrntFieldInpObject>(testRefPrntFieldInpDecoder.Factory);
}
