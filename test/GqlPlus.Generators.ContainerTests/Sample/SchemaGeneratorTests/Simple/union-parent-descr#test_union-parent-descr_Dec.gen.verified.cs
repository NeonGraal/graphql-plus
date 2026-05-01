//HintName: test_union-parent-descr_Dec.gen.cs
// Generated from {CurrentDirectory}union-parent-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_union_parent_descr;

internal class testUnionPrntDescrDecoder : IDecoder<ItestUnionPrntDescr>
{
  public Number? AsNumber { get; set; }

  public IMessages Decode(IValue input, out ItestUnionPrntDescr? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testUnionPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntUnionPrntDescrDecoder : IDecoder<ItestPrntUnionPrntDescr>
{
  public Number? AsNumber { get; set; }

  public IMessages Decode(IValue input, out ItestPrntUnionPrntDescr? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntUnionPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_union_parent_descrDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_union_parent_descrDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestUnionPrntDescr>(testUnionPrntDescrDecoder.Factory)
      .AddDecoder<ItestPrntUnionPrntDescr>(testPrntUnionPrntDescrDecoder.Factory);
}
