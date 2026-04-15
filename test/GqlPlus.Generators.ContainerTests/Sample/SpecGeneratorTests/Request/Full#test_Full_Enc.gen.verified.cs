//HintName: test_Full_Enc.gen.cs
// Generated from {CurrentDirectory}Full.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Full;

internal class test_IdentifierEncoder : IEncoder<Itest_Identifier>
{
  public Structured Encode(Itest_Identifier input)
    => new(input.Value);
}

internal static class test_FullEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_FullEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<Itest_Identifier>(_ => new test_IdentifierEncoder());
}
