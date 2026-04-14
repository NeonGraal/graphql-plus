//HintName: test_default_Dec.gen.cs
// Generated from {CurrentDirectory}default.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_default;

internal class testQueryDecoder
{
}

internal class testMutationDecoder
{
}

internal class testSubscriptionDecoder
{
}

internal class test_SchemaDecoder
{
}

internal static class test_defaultDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_defaultDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestQueryObject>(_ => new testQueryDecoder())
      .AddDecoder<ItestMutationObject>(_ => new testMutationDecoder())
      .AddDecoder<ItestSubscriptionObject>(_ => new testSubscriptionDecoder())
      .AddDecoder<Itest_SchemaObject>(_ => new test_SchemaDecoder());
}
