//HintName: test_domain-string-diff_Dec.gen.cs
// Generated from {CurrentDirectory}domain-string-diff.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_string_diff;

internal class testDmnStrDiffDecoder : IDecoder<ItestDmnStrDiff>
{

  public IMessages Decode(IValue input, out ItestDmnStrDiff? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnStrDiffDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_domain_string_diffDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_domain_string_diffDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDmnStrDiff>(testDmnStrDiffDecoder.Factory);
}
