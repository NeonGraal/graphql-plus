//HintName: test_union-same-parent_Dec.gen.cs
// Generated from {CurrentDirectory}union-same-parent.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_union_same_parent;

internal class testUnionSamePrntDecoder : IDecoder<ItestUnionSamePrnt>
{
  public Boolean? AsBoolean { get; set; }

  public IMessages Decode(IValue input, out ItestUnionSamePrnt? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testUnionSamePrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntUnionSamePrntDecoder : IDecoder<ItestPrntUnionSamePrnt>
{
  public String? AsString { get; set; }

  public IMessages Decode(IValue input, out ItestPrntUnionSamePrnt? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntUnionSamePrntDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_union_same_parentDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_union_same_parentDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestUnionSamePrnt>(testUnionSamePrntDecoder.Factory)
      .AddDecoder<ItestPrntUnionSamePrnt>(testPrntUnionSamePrntDecoder.Factory);
}
