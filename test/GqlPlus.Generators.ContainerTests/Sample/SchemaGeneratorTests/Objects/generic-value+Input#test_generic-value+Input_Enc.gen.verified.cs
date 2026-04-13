//HintName: test_generic-value+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-value+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_value_Input;

internal class testGnrcValueInpEncoder : IEncoder<ItestGnrcValueInpObject>
{
  public Structured Encode(ItestGnrcValueInpObject input)
    => Structured.Empty();
}

internal class testRefGnrcValueInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestRefGnrcValueInpObject<TType>>
{
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestRefGnrcValueInpObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _type);
}

internal class testEnumGnrcValueInpEncoder : IEncoder<testEnumGnrcValueInp>
{
  public Structured Encode(testEnumGnrcValueInp input)
    => new(input.ToString(), "_EnumGnrcValueInp");
}
