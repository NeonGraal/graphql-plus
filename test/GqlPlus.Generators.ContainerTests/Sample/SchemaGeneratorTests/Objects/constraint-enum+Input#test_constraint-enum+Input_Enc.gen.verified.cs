//HintName: test_constraint-enum+Input_Enc.gen.cs
// Generated from {CurrentDirectory}constraint-enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_Input;

internal class testCnstEnumInpEncoder : IEncoder<ItestCnstEnumInpObject>
{
  public Structured Encode(ItestCnstEnumInpObject input)
    => Structured.Empty();
}

internal class testRefCnstEnumInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstEnumInpObject<TType>>
{
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestRefCnstEnumInpObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _type);
}

internal class testEnumCnstEnumInpEncoder : IEncoder<testEnumCnstEnumInp>
{
  public Structured Encode(testEnumCnstEnumInp input)
    => new(input.ToString(), "_EnumCnstEnumInp");
}
