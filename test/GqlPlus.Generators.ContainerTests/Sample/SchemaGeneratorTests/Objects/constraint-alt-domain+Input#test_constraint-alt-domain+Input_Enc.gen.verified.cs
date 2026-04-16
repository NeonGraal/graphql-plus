//HintName: test_constraint-alt-domain+Input_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-alt-domain+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_domain_Input;

internal class testDomCnstAltDmnInpEncoder : IEncoder<ItestDomCnstAltDmnInp>
{
  public Structured Encode(ItestDomCnstAltDmnInp input)
    => new(input.Value);

  internal static testDomCnstAltDmnInpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_constraint_alt_domain_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_constraint_alt_domain_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestDomCnstAltDmnInp>(testDomCnstAltDmnInpEncoder.Factory);
}
