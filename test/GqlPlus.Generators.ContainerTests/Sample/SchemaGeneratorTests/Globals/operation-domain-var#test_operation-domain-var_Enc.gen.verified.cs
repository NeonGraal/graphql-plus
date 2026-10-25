//HintName: test_operation-domain-var_Enc.gen.cs
// Generated from {CurrentDirectory}operation-domain-var.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_operation_domain_var;

internal class testCatOprDmnVarEncoder : IEncoder<ItestCatOprDmnVarObject>
{
  public IGqlpValue Encode(ItestCatOprDmnVarObject input)
    => new GqlpUnit();

  internal static testCatOprDmnVarEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_operation_domain_varEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_operation_domain_varEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestCatOprDmnVarObject>(testCatOprDmnVarEncoder.Factory);
}
