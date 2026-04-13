//HintName: test_constraint-alt-domain+Input_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-alt-domain+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_domain_Input;

internal class testCnstAltDmnInpEncoder : IEncoder<ItestCnstAltDmnInpObject>
{
  public Structured Encode(ItestCnstAltDmnInpObject input)
    => Structured.Empty();
}

internal class testRefCnstAltDmnInpEncoder<TRef> : IEncoder<ItestRefCnstAltDmnInpObject<TRef>>
{
  public Structured Encode(ItestRefCnstAltDmnInpObject<TRef> input)
    => Structured.Empty();
}

internal class testDomCnstAltDmnInpEncoder : IEncoder<ItestDomCnstAltDmnInp>
{
  public Structured Encode(ItestDomCnstAltDmnInp input)
    => new(input.Value);
}
