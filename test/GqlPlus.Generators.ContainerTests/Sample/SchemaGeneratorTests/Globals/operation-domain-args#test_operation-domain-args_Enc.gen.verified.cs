//HintName: test_operation-domain-args_Enc.gen.cs
// Generated from {CurrentDirectory}operation-domain-args.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_operation_domain_args;

internal class testCatOprDmnArgsEncoder : IEncoder<ItestCatOprDmnArgsObject>
{
  public Structured Encode(ItestCatOprDmnArgsObject input)
    => Structured.Empty();

  internal static testCatOprDmnArgsEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_operation_domain_argsEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_operation_domain_argsEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestCatOprDmnArgsObject>(testCatOprDmnArgsEncoder.Factory);
}
