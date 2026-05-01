//HintName: test_domain-number-descr_Dec.gen.cs
// Generated from {CurrentDirectory}domain-number-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_number_descr;

internal class testDmnNmbrDescrDecoder : IDecoder<ItestDmnNmbrDescr>
{

  public IMessages Decode(IValue input, out ItestDmnNmbrDescr? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnNmbrDescrDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_domain_number_descrDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_domain_number_descrDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDmnNmbrDescr>(testDmnNmbrDescrDecoder.Factory);
}
