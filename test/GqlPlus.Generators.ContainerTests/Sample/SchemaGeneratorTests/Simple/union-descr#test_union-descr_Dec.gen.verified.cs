//HintName: test_union-descr_Dec.gen.cs
// Generated from {CurrentDirectory}union-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_union_descr;

internal class testUnionDescrDecoder : IDecoder<ItestUnionDescr>
{
  public Number? AsNumber { get; set; }

  public IMessages Decode(IValue input, out ItestUnionDescr? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testUnionDescrDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_union_descrDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_union_descrDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestUnionDescr>(testUnionDescrDecoder.Factory);
}
