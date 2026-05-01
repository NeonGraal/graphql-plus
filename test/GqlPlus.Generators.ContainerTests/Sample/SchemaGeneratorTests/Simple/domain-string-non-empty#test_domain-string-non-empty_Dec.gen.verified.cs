//HintName: test_domain-string-non-empty_Dec.gen.cs
// Generated from {CurrentDirectory}domain-string-non-empty.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_string_non_empty;

internal class testDmnStrNonEmptyDecoder : IDecoder<ItestDmnStrNonEmpty>
{

  public IMessages Decode(IValue input, out ItestDmnStrNonEmpty? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnStrNonEmptyDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_domain_string_non_emptyDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_domain_string_non_emptyDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDmnStrNonEmpty>(testDmnStrNonEmptyDecoder.Factory);
}
