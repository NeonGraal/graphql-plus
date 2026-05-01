//HintName: test_domain-string-parent-descr_Dec.gen.cs
// Generated from {CurrentDirectory}domain-string-parent-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_string_parent_descr;

internal class testDmnStrPrntDescrDecoder : IDecoder<ItestDmnStrPrntDescr>
{

  public IMessages Decode(IValue input, out ItestDmnStrPrntDescr? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnStrPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDmnStrPrntDescrDecoder : IDecoder<ItestPrntDmnStrPrntDescr>
{

  public IMessages Decode(IValue input, out ItestPrntDmnStrPrntDescr? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntDmnStrPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_domain_string_parent_descrDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_domain_string_parent_descrDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDmnStrPrntDescr>(testDmnStrPrntDescrDecoder.Factory)
      .AddDecoder<ItestPrntDmnStrPrntDescr>(testPrntDmnStrPrntDescrDecoder.Factory);
}
