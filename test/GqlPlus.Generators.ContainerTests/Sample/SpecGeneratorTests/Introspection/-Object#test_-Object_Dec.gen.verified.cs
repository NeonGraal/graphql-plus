//HintName: test_-Object_Dec.gen.cs
// Generated from {CurrentDirectory}-Object.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Object;

internal class test_ObjectKindDecoder
{
}

internal static class test__ObjectDecoders
{
  internal static IDecoderRepositoryBuilder Addtest__ObjectDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<Itest_ObjectKind>(_ => new test_ObjectKindDecoder());
}
