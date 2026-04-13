//HintName: test_constraint-enum-parent+Output_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-enum-parent+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_parent_Output;

internal class testCnstEnumPrntOutpEncoder : IEncoder<ItestCnstEnumPrntOutpObject>
{
  public Structured Encode(ItestCnstEnumPrntOutpObject input)
    => Structured.Empty();
}

internal class testRefCnstEnumPrntOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstEnumPrntOutpObject<TType>>
{
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestRefCnstEnumPrntOutpObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _type);
}

internal class testEnumCnstEnumPrntOutpEncoder : IEncoder<testEnumCnstEnumPrntOutp>
{
  public Structured Encode(testEnumCnstEnumPrntOutp input)
    => new(input.ToString(), "_EnumCnstEnumPrntOutp");
}

internal class testParentCnstEnumPrntOutpEncoder : IEncoder<testParentCnstEnumPrntOutp>
{
  public Structured Encode(testParentCnstEnumPrntOutp input)
    => new(input.ToString(), "_ParentCnstEnumPrntOutp");
}
