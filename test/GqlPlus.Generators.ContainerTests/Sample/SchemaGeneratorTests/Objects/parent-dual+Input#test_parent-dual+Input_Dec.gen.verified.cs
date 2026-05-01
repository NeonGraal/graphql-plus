//HintName: test_parent-dual+Input_Dec.gen.cs
// Generated from {CurrentDirectory}parent-dual+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_dual_Input;

internal class testPrntDualInpDecoder : IDecoder<ItestPrntDualInpObject>
{

  public IMessages Decode(IValue input, out ItestPrntDualInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntDualInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefPrntDualInpDecoder : IDecoder<ItestRefPrntDualInpObject>
{
  public decimal? Parent { get; set; }

  public IMessages Decode(IValue input, out ItestRefPrntDualInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testRefPrntDualInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_parent_dual_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_parent_dual_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestPrntDualInpObject>(testPrntDualInpDecoder.Factory)
      .AddDecoder<ItestRefPrntDualInpObject>(testRefPrntDualInpDecoder.Factory);
}
