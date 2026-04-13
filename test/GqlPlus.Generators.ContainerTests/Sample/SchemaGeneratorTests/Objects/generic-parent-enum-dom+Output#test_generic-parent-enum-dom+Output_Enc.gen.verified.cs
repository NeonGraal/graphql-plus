//HintName: test_generic-parent-enum-dom+Output_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-dom+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_dom_Output;

internal class testGnrcPrntEnumDomOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntEnumDomOutpObject>
{
  private readonly IEncoder<ItestFieldGnrcPrntEnumDomOutpObject<ItestDomGnrcPrntEnumDomOutp>> _itestFieldGnrcPrntEnumDomOutpObject<ItestDomGnrcPrntEnumDomOutp> = encoders.EncoderFor<ItestFieldGnrcPrntEnumDomOutpObject<ItestDomGnrcPrntEnumDomOutp>>();
  public Structured Encode(ItestGnrcPrntEnumDomOutpObject input)
    => _itestFieldGnrcPrntEnumDomOutpObject<ItestDomGnrcPrntEnumDomOutp>.Encode(input);
}

internal class testFieldGnrcPrntEnumDomOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestFieldGnrcPrntEnumDomOutpObject<TRef>>
{
  private readonly IEncoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public Structured Encode(ItestFieldGnrcPrntEnumDomOutpObject<TRef> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _ref);
}

internal class testEnumGnrcPrntEnumDomOutpEncoder : IEncoder<testEnumGnrcPrntEnumDomOutp>
{
  public Structured Encode(testEnumGnrcPrntEnumDomOutp input)
    => new(input.ToString(), "_EnumGnrcPrntEnumDomOutp");
}

internal class testDomGnrcPrntEnumDomOutpEncoder : IEncoder<ItestDomGnrcPrntEnumDomOutp>
{
  public Structured Encode(ItestDomGnrcPrntEnumDomOutp input)
    => new((decimal?)input.Value);
}
