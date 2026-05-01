//HintName: test_domain-enum-diff_Dec.gen.cs
// Generated from {CurrentDirectory}domain-enum-diff.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_diff;

internal class testDmnEnumDiffDecoder : IDecoder<ItestDmnEnumDiff>
{
  public bool? Value { get; set; }

  public IMessages Decode(IValue input, out ItestDmnEnumDiff? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnEnumDiffDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_domain_enum_diffDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_domain_enum_diffDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestDmnEnumDiff>(testDmnEnumDiffDecoder.Factory);
}
