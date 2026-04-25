//HintName: test_constraint-field-domain+Input_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-field-domain+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_domain_Input;

internal class testDomCnstFieldDmnInpEncoder : IEncoder<ItestDomCnstFieldDmnInp>
{
  public Structured Encode(ItestDomCnstFieldDmnInp input)
    => input.Value!.Encode();

  internal static testDomCnstFieldDmnInpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_constraint_field_domain_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_constraint_field_domain_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestDomCnstFieldDmnInp>(testDomCnstFieldDmnInpEncoder.Factory);
}
