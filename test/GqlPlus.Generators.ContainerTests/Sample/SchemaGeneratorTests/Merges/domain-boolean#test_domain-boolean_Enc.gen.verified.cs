//HintName: test_domain-boolean_Enc.gen.cs
// Generated from {CurrentDirectory}domain-boolean.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_boolean;

internal class testDmnBoolEncoder : IEncoder<ItestDmnBool>
{
  public Structured Encode(ItestDmnBool input)
    => new(input.Value);

  internal static testDmnBoolEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_domain_booleanEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_domain_booleanEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestDmnBool>(testDmnBoolEncoder.Factory);
}
