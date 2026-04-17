//HintName: test_domain-number_Enc.gen.cs
// Generated from {CurrentDirectory}domain-number.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_number;

internal class testDmnNmbrEncoder : IEncoder<ItestDmnNmbr>
{
  public Structured Encode(ItestDmnNmbr input)
    => new(input.Value);

  internal static testDmnNmbrEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_domain_numberEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_domain_numberEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestDmnNmbr>(testDmnNmbrEncoder.Factory);
}
