//HintName: test_generic-parent-enum-dom+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-dom+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_dom_Dual;

internal class testGnrcPrntEnumDomDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntEnumDomDualObject>
{
  private readonly IEncoder<ItestFieldGnrcPrntEnumDomDualObject<ItestDomGnrcPrntEnumDomDual>> _itestFieldGnrcPrntEnumDomDualObject<ItestDomGnrcPrntEnumDomDual> = encoders.EncoderFor<ItestFieldGnrcPrntEnumDomDualObject<ItestDomGnrcPrntEnumDomDual>>();
  public Structured Encode(ItestGnrcPrntEnumDomDualObject input)
    => _itestFieldGnrcPrntEnumDomDualObject<ItestDomGnrcPrntEnumDomDual>.Encode(input);
}

internal class testFieldGnrcPrntEnumDomDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestFieldGnrcPrntEnumDomDualObject<TRef>>
{
  private readonly IEncoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public Structured Encode(ItestFieldGnrcPrntEnumDomDualObject<TRef> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _ref);
}

internal class testEnumGnrcPrntEnumDomDualEncoder : IEncoder<testEnumGnrcPrntEnumDomDual>
{
  public Structured Encode(testEnumGnrcPrntEnumDomDual input)
    => new(input.ToString(), "_EnumGnrcPrntEnumDomDual");
}

internal class testDomGnrcPrntEnumDomDualEncoder : IEncoder<ItestDomGnrcPrntEnumDomDual>
{
  public Structured Encode(ItestDomGnrcPrntEnumDomDual input)
    => new((decimal?)input.Value);
}
