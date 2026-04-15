//HintName: test_Base_Dec.gen.cs
// Generated from {CurrentDirectory}Base.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Base;

internal class test_ObjectKindDecoder
{
}

internal static class test_BaseDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_BaseDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<Itest_ObjectKind>(_ => new test_ObjectKindDecoder());
}
