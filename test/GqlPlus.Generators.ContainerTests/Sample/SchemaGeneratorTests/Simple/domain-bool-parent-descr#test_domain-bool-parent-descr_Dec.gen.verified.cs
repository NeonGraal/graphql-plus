//HintName: test_domain-bool-parent-descr_Dec.gen.cs
// Generated from {CurrentDirectory}domain-bool-parent-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_bool_parent_descr;

internal class testDmnBoolPrntDescrDecoder : IDecoder<ItestDmnBoolPrntDescr>
{

  public IMessages Decode(IValue input, out ItestDmnBoolPrntDescr? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnBoolPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDmnBoolPrntDescrDecoder : IDecoder<ItestPrntDmnBoolPrntDescr>
{

  public IMessages Decode(IValue input, out ItestPrntDmnBoolPrntDescr? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntDmnBoolPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_domain_bool_parent_descrDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_domain_bool_parent_descrDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDmnBoolPrntDescr>(testDmnBoolPrntDescrDecoder.Factory)
      .AddDecoder<ItestPrntDmnBoolPrntDescr>(testPrntDmnBoolPrntDescrDecoder.Factory);
}
