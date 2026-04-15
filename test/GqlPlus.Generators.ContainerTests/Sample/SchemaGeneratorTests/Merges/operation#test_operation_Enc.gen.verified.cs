//HintName: test_operation_Enc.gen.cs
// Generated from {CurrentDirectory}operation.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_operation;

internal class testOpEncoder : IEncoder<ItestOpObject>
{
  public Structured Encode(ItestOpObject input)
    => Structured.Empty();
}

internal static class test_operationEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_operationEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestOpObject>(_ => new testOpEncoder());
}
