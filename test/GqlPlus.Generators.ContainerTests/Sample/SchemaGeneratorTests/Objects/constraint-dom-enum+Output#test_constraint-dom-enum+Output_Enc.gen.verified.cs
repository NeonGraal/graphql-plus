//HintName: test_constraint-dom-enum+Output_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-dom-enum+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_dom_enum_Output;

internal class testCnstDomEnumOutpEncoder : IEncoder<ItestCnstDomEnumOutpObject>
{
  public Structured Encode(ItestCnstDomEnumOutpObject input)
    => Structured.Empty();
}

internal class testRefCnstDomEnumOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstDomEnumOutpObject<TType>>
{
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestRefCnstDomEnumOutpObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _type);
}

internal class testEnumCnstDomEnumOutpEncoder : IEncoder<testEnumCnstDomEnumOutp>
{
  public Structured Encode(testEnumCnstDomEnumOutp input)
    => new(input.ToString(), "_EnumCnstDomEnumOutp");
}

internal class testJustCnstDomEnumOutpEncoder : IEncoder<ItestJustCnstDomEnumOutp>
{
  public Structured Encode(ItestJustCnstDomEnumOutp input)
    => new((decimal?)input.Value);
}
