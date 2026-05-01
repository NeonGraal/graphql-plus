//HintName: test_domain-boolean_Dec.gen.cs
// Generated from {CurrentDirectory}domain-boolean.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_boolean;

internal class testDmnBoolDecoder : IDecoder<ItestDmnBool>
{

  public IMessages Decode(IValue input, out ItestDmnBool? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnBoolDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_domain_booleanDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_domain_booleanDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDmnBool>(testDmnBoolDecoder.Factory);
}
