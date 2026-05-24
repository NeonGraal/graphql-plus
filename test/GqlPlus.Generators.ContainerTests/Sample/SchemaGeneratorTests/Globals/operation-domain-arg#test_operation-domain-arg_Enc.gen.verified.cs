//HintName: test_operation-domain-arg_Enc.gen.cs
// Generated from {CurrentDirectory}operation-domain-arg.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_operation_domain_arg;

internal class testCatOprDmnArgEncoder : IEncoder<ItestCatOprDmnArgObject>
{
  public Structured Encode(ItestCatOprDmnArgObject input)
    => Structured.Empty();

  internal static testCatOprDmnArgEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_operation_domain_argEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_operation_domain_argEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestCatOprDmnArgObject>(testCatOprDmnArgEncoder.Factory);
}
