//HintName: test_domain-boolean-diff_Dec.gen.cs
// Generated from {CurrentDirectory}domain-boolean-diff.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_boolean_diff;

internal class testDmnBoolDiffDecoder : IDecoder<ItestDmnBoolDiff>
{

  public IMessages Decode(IValue input, out ItestDmnBoolDiff? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnBoolDiffDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_domain_boolean_diffDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_domain_boolean_diffDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDmnBoolDiff>(testDmnBoolDiffDecoder.Factory);
}
