//HintName: test_constraint-enum-parent+Input_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-enum-parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_parent_Input;

internal class testCnstEnumPrntInpEncoder : IEncoder<ItestCnstEnumPrntInpObject>
{
  public Structured Encode(ItestCnstEnumPrntInpObject input)
    => Structured.Empty();
}

internal class testRefCnstEnumPrntInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstEnumPrntInpObject<TType>>
{
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestRefCnstEnumPrntInpObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _type);
}

internal class testEnumCnstEnumPrntInpEncoder : IEncoder<testEnumCnstEnumPrntInp>
{
  public Structured Encode(testEnumCnstEnumPrntInp input)
    => new(input.ToString(), "_EnumCnstEnumPrntInp");
}

internal class testParentCnstEnumPrntInpEncoder : IEncoder<testParentCnstEnumPrntInp>
{
  public Structured Encode(testParentCnstEnumPrntInp input)
    => new(input.ToString(), "_ParentCnstEnumPrntInp");
}
