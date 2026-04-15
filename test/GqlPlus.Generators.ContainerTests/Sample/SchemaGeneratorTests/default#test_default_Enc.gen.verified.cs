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

  internal static testQueryEncoder Factory(IEncoderRepository _) => new();
}

internal class testMutationEncoder : IEncoder<ItestMutationObject>
{
  public Structured Encode(ItestMutationObject input)
    => Structured.Empty();

  internal static testMutationEncoder Factory(IEncoderRepository _) => new();
}

internal class testSubscriptionEncoder : IEncoder<ItestSubscriptionObject>
{
  public Structured Encode(ItestSubscriptionObject input)
    => Structured.Empty();

  internal static testSubscriptionEncoder Factory(IEncoderRepository _) => new();
}

internal class test_SchemaEncoder : IEncoder<Itest_SchemaObject>
{
  public Structured Encode(Itest_SchemaObject input)
    => Structured.Empty();

  internal static test_SchemaEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_defaultEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_defaultEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestQueryObject>(testQueryEncoder.Factory)
      .AddEncoder<ItestMutationObject>(testMutationEncoder.Factory)
      .AddEncoder<ItestSubscriptionObject>(testSubscriptionEncoder.Factory)
      .AddEncoder<Itest_SchemaObject>(test_SchemaEncoder.Factory);
}
