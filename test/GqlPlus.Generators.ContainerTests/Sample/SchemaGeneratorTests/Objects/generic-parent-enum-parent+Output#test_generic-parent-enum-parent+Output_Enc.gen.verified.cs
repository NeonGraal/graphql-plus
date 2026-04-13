//HintName: test_generic-parent-enum-parent+Output_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-parent+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_parent_Output;

internal class testGnrcPrntEnumPrntOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntEnumPrntOutpObject>
{
  private readonly IEncoder<ItestFieldGnrcPrntEnumPrntOutpObject<testEnumGnrcPrntEnumPrntOutp>> _itestFieldGnrcPrntEnumPrntOutpObject<testEnumGnrcPrntEnumPrntOutp> = encoders.EncoderFor<ItestFieldGnrcPrntEnumPrntOutpObject<testEnumGnrcPrntEnumPrntOutp>>();
  public Structured Encode(ItestGnrcPrntEnumPrntOutpObject input)
    => _itestFieldGnrcPrntEnumPrntOutpObject<testEnumGnrcPrntEnumPrntOutp>.Encode(input);
}

internal class testFieldGnrcPrntEnumPrntOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestFieldGnrcPrntEnumPrntOutpObject<TRef>>
{
  private readonly IEncoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public Structured Encode(ItestFieldGnrcPrntEnumPrntOutpObject<TRef> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _ref);
}

internal class testEnumGnrcPrntEnumPrntOutpEncoder : IEncoder<testEnumGnrcPrntEnumPrntOutp>
{
  public Structured Encode(testEnumGnrcPrntEnumPrntOutp input)
    => new(input.ToString(), "_EnumGnrcPrntEnumPrntOutp");
}

internal class testParentGnrcPrntEnumPrntOutpEncoder : IEncoder<testParentGnrcPrntEnumPrntOutp>
{
  public Structured Encode(testParentGnrcPrntEnumPrntOutp input)
    => new(input.ToString(), "_ParentGnrcPrntEnumPrntOutp");
}
