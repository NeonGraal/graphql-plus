//HintName: test_constraint-alt-domain+Output_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-alt-domain+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_domain_Output;

internal class testCnstAltDmnOutpEncoder : IEncoder<ItestCnstAltDmnOutpObject>
{
  public Structured Encode(ItestCnstAltDmnOutpObject input)
    => Structured.Empty();
}

internal class testRefCnstAltDmnOutpEncoder : IEncoder<ItestRefCnstAltDmnOutpObject<TRef>>
{
  public Structured Encode(ItestRefCnstAltDmnOutpObject<TRef> input)
    => Structured.Empty();
}

internal class testDomCnstAltDmnOutpEncoder : IEncoder<ItestDomCnstAltDmnOutp>
{
  public Structured Encode(ItestDomCnstAltDmnOutp input)
    => new(input.Value);
}
