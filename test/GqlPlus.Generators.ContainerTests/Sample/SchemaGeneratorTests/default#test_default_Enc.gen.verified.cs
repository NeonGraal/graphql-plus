//HintName: test_default_Enc.gen.cs
// Generated from {CurrentDirectory}default.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_default;

internal class testQueryEncoder : IEncoder<ItestQueryObject>
{
  public Structured Encode(ItestQueryObject input)
    => Structured.Empty();
}

internal class testMutationEncoder : IEncoder<ItestMutationObject>
{
  public Structured Encode(ItestMutationObject input)
    => Structured.Empty();
}

internal class testSubscriptionEncoder : IEncoder<ItestSubscriptionObject>
{
  public Structured Encode(ItestSubscriptionObject input)
    => Structured.Empty();
}

internal class test_SchemaEncoder : IEncoder<Itest_SchemaObject>
{
  public Structured Encode(Itest_SchemaObject input)
    => Structured.Empty();
}

internal static class test_defaultEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_defaultEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestQueryObject>(_ => new testQueryEncoder())
      .AddEncoder<ItestMutationObject>(_ => new testMutationEncoder())
      .AddEncoder<ItestSubscriptionObject>(_ => new testSubscriptionEncoder())
      .AddEncoder<Itest_SchemaObject>(_ => new test_SchemaEncoder());
}
