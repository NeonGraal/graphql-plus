//HintName: test_operation-domain_Enc.gen.cs
// Generated from {CurrentDirectory}operation-domain.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_operation_domain;

internal class testCatOprDmnEncoder : IEncoder<ItestCatOprDmnObject>
{
  public Structured Encode(ItestCatOprDmnObject input)
    => Structured.Empty();

  internal static testCatOprDmnEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_operation_domainEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_operation_domainEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestCatOprDmnObject>(testCatOprDmnEncoder.Factory);
}
