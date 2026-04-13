//HintName: test_generic-parent-enum-dom+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-dom+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_dom_Input;

internal class testGnrcPrntEnumDomInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntEnumDomInpObject>
{
  private readonly IEncoder<ItestFieldGnrcPrntEnumDomInpObject<ItestDomGnrcPrntEnumDomInp>> _itestFieldGnrcPrntEnumDomInp = encoders.EncoderFor<ItestFieldGnrcPrntEnumDomInpObject<ItestDomGnrcPrntEnumDomInp>>();
  public Structured Encode(ItestGnrcPrntEnumDomInpObject input)
    => _itestFieldGnrcPrntEnumDomInp.Encode(input);
}

internal class testFieldGnrcPrntEnumDomInpEncoder<TRef>(
  IEncoderRepository encoders
) : IEncoder<ItestFieldGnrcPrntEnumDomInpObject<TRef>>
{
  private readonly IEncoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public Structured Encode(ItestFieldGnrcPrntEnumDomInpObject<TRef> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _ref);
}

internal class testEnumGnrcPrntEnumDomInpEncoder : IEncoder<testEnumGnrcPrntEnumDomInp>
{
  public Structured Encode(testEnumGnrcPrntEnumDomInp input)
    => new(input.ToString(), "_EnumGnrcPrntEnumDomInp");
}

internal class testDomGnrcPrntEnumDomInpEncoder : IEncoder<ItestDomGnrcPrntEnumDomInp>
{
  public Structured Encode(ItestDomGnrcPrntEnumDomInp input)
    => new((decimal?)input.Value);
}
