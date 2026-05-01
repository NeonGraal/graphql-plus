//HintName: test_domain-number-parent-descr_Dec.gen.cs
// Generated from {CurrentDirectory}domain-number-parent-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_number_parent_descr;

internal class testDmnNmbrPrntDescrDecoder : IDecoder<ItestDmnNmbrPrntDescr>
{

  public IMessages Decode(IValue input, out ItestDmnNmbrPrntDescr? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnNmbrPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDmnNmbrPrntDescrDecoder : IDecoder<ItestPrntDmnNmbrPrntDescr>
{

  public IMessages Decode(IValue input, out ItestPrntDmnNmbrPrntDescr? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntDmnNmbrPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_domain_number_parent_descrDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_domain_number_parent_descrDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDmnNmbrPrntDescr>(testDmnNmbrPrntDescrDecoder.Factory)
      .AddDecoder<ItestPrntDmnNmbrPrntDescr>(testPrntDmnNmbrPrntDescrDecoder.Factory);
}
