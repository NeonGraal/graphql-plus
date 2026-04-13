//HintName: test_generic-parent-enum-parent+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_parent_Input;

internal class testGnrcPrntEnumPrntInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntEnumPrntInpObject>
{
  private readonly IEncoder<ItestFieldGnrcPrntEnumPrntInpObject<testEnumGnrcPrntEnumPrntInp>> _itestFieldGnrcPrntEnumPrntInpObject<testEnumGnrcPrntEnumPrntInp> = encoders.EncoderFor<ItestFieldGnrcPrntEnumPrntInpObject<testEnumGnrcPrntEnumPrntInp>>();
  public Structured Encode(ItestGnrcPrntEnumPrntInpObject input)
    => _itestFieldGnrcPrntEnumPrntInpObject<testEnumGnrcPrntEnumPrntInp>.Encode(input);
}

internal class testFieldGnrcPrntEnumPrntInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestFieldGnrcPrntEnumPrntInpObject<TRef>>
{
  private readonly IEncoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public Structured Encode(ItestFieldGnrcPrntEnumPrntInpObject<TRef> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _ref);
}

internal class testEnumGnrcPrntEnumPrntInpEncoder : IEncoder<testEnumGnrcPrntEnumPrntInp>
{
  public Structured Encode(testEnumGnrcPrntEnumPrntInp input)
    => new(input.ToString(), "_EnumGnrcPrntEnumPrntInp");
}

internal class testParentGnrcPrntEnumPrntInpEncoder : IEncoder<testParentGnrcPrntEnumPrntInp>
{
  public Structured Encode(testParentGnrcPrntEnumPrntInp input)
    => new(input.ToString(), "_ParentGnrcPrntEnumPrntInp");
}
