//HintName: test_Dual_Dec.gen.cs
// Generated from {CurrentDirectory}Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Dual;

internal class test_DualFieldDecoder
{
}

internal static class test_DualDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_DualDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<Itest_DualFieldObject>(_ => new test_DualFieldDecoder());
}
