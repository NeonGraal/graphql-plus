//HintName: test_enum-diff_Dec.gen.cs
// Generated from {CurrentDirectory}enum-diff.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_enum_diff;

internal class testEnumDiffDecoder : IDecoder<testEnumDiff?>
{
  public IMessages Decoder(IValue input, out testEnumDiff? output)
    => input.DecodeEnum("EnumDiff", out output);

  internal static testEnumDiffDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_enum_diffDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_enum_diffDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<testEnumDiff?>(testEnumDiffDecoder.Factory);
}
