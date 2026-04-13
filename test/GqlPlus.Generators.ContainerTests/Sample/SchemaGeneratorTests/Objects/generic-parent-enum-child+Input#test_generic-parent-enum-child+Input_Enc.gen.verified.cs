//HintName: test_generic-parent-enum-child+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-child+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_child_Input;

internal class testGnrcPrntEnumChildInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntEnumChildInpObject>
{
  private readonly IEncoder<ItestFieldGnrcPrntEnumChildInpObject<testParentGnrcPrntEnumChildInp>> _itestFieldGnrcPrntEnumChildInpObject<testParentGnrcPrntEnumChildInp> = encoders.EncoderFor<ItestFieldGnrcPrntEnumChildInpObject<testParentGnrcPrntEnumChildInp>>();
  public Structured Encode(ItestGnrcPrntEnumChildInpObject input)
    => _itestFieldGnrcPrntEnumChildInpObject<testParentGnrcPrntEnumChildInp>.Encode(input);
}

internal class testFieldGnrcPrntEnumChildInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestFieldGnrcPrntEnumChildInpObject<TRef>>
{
  private readonly IEncoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public Structured Encode(ItestFieldGnrcPrntEnumChildInpObject<TRef> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _ref);
}

internal class testEnumGnrcPrntEnumChildInpEncoder : IEncoder<testEnumGnrcPrntEnumChildInp>
{
  public Structured Encode(testEnumGnrcPrntEnumChildInp input)
    => new(input.ToString(), "_EnumGnrcPrntEnumChildInp");
}

internal class testParentGnrcPrntEnumChildInpEncoder : IEncoder<testParentGnrcPrntEnumChildInp>
{
  public Structured Encode(testParentGnrcPrntEnumChildInp input)
    => new(input.ToString(), "_ParentGnrcPrntEnumChildInp");
}
