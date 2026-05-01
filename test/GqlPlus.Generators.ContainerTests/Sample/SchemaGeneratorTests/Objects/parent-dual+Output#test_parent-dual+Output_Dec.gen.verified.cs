//HintName: test_parent-dual+Output_Dec.gen.cs
// Generated from {CurrentDirectory}parent-dual+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_dual_Output;

internal class testRefPrntDualOutpDecoder : IDecoder<ItestRefPrntDualOutpObject>
{
  public decimal? Parent { get; set; }

  public IMessages Decode(IValue input, out ItestRefPrntDualOutpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testRefPrntDualOutpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_parent_dual_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_parent_dual_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestRefPrntDualOutpObject>(testRefPrntDualOutpDecoder.Factory);
}
