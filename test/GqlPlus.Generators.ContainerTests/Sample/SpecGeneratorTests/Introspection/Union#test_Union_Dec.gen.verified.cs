//HintName: test_Union_Dec.gen.cs
// Generated from {CurrentDirectory}Union.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Union;

internal class test_UnionRefDecoder
{
}

internal class test_UnionMemberDecoder
{
  public Itest_Name Union { get; set; }
}

internal static class test_UnionDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_UnionDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<Itest_UnionRefObject>(_ => new test_UnionRefDecoder())
      .AddDecoder<Itest_UnionMemberObject>(r => new test_UnionMemberDecoder(r));
}
