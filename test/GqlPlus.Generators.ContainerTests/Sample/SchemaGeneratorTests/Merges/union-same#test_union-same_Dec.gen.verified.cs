//HintName: test_union-same_Dec.gen.cs
// Generated from {CurrentDirectory}union-same.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_union_same;

internal class testUnionSameDecoder : IDecoder<ItestUnionSame>
{
  public Boolean? AsBoolean { get; set; }

  public IMessages Decode(IValue input, out ItestUnionSame? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testUnionSameDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_union_sameDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_union_sameDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestUnionSame>(testUnionSameDecoder.Factory);
}
