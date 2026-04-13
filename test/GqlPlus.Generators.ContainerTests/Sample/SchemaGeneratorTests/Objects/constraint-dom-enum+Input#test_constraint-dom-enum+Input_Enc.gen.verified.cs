//HintName: test_constraint-dom-enum+Input_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-dom-enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_dom_enum_Input;

internal class testCnstDomEnumInpEncoder : IEncoder<ItestCnstDomEnumInpObject>
{
  public Structured Encode(ItestCnstDomEnumInpObject input)
    => Structured.Empty();
}

internal class testRefCnstDomEnumInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstDomEnumInpObject<TType>>
{
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestRefCnstDomEnumInpObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _type);
}

internal class testEnumCnstDomEnumInpEncoder : IEncoder<testEnumCnstDomEnumInp>
{
  public Structured Encode(testEnumCnstDomEnumInp input)
    => new(input.ToString(), "_EnumCnstDomEnumInp");
}

internal class testJustCnstDomEnumInpEncoder : IEncoder<ItestJustCnstDomEnumInp>
{
  public Structured Encode(ItestJustCnstDomEnumInp input)
    => new((decimal?)input.Value);
}
