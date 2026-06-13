//HintName: test_constraint-alt-domain+Input_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-alt-domain+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_domain_Input;

internal class testCnstAltDmnInpEncoder : IEncoder<ItestCnstAltDmnInpObject>
{
  public Structured Encode(ItestCnstAltDmnInpObject input)
    => Structured.Empty();

  internal static testCnstAltDmnInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefCnstAltDmnInpEncoder<TRef> : IEncoder<ItestRefCnstAltDmnInpObject<TRef>>
{
  public Structured Encode(ItestRefCnstAltDmnInpObject<TRef> input)
    => Structured.Empty();
}

internal class testDomCnstAltDmnInpEncoder : IEncoder<ItestDomCnstAltDmnInp>
{
  public Structured Encode(ItestDomCnstAltDmnInp input)
    => input.Value!.Encode();

  internal static testDomCnstAltDmnInpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_constraint_alt_domain_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_constraint_alt_domain_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestCnstAltDmnInpObject>(testCnstAltDmnInpEncoder.Factory)
      .AddEncoder<ItestDomCnstAltDmnInp>(testDomCnstAltDmnInpEncoder.Factory);
}
