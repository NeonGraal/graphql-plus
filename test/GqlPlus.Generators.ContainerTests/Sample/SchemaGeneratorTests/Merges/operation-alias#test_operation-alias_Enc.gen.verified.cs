//HintName: test_operation-alias_Enc.gen.cs
// Generated from {CurrentDirectory}operation-alias.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_operation_alias;

internal class testOpEncoder : IEncoder<ItestOpObject>
{
  public Structured Encode(ItestOpObject input)
    => Structured.Empty();

  internal static testOpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_operation_aliasEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_operation_aliasEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestOpObject>(testOpEncoder.Factory);
}
