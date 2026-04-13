//HintName: test_generic-parent-string-dom+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent-string-dom+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_string_dom_Input;

internal class testGnrcPrntStrDomInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntStrDomInpObject>
{
  private readonly IEncoder<ItestFieldGnrcPrntStrDomInpObject<ItestDomGnrcPrntStrDomInp>> _itestFieldGnrcPrntStrDomInpObject<ItestDomGnrcPrntStrDomInp> = encoders.EncoderFor<ItestFieldGnrcPrntStrDomInpObject<ItestDomGnrcPrntStrDomInp>>();
  public Structured Encode(ItestGnrcPrntStrDomInpObject input)
    => _itestFieldGnrcPrntStrDomInpObject<ItestDomGnrcPrntStrDomInp>.Encode(input);
}

internal class testFieldGnrcPrntStrDomInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestFieldGnrcPrntStrDomInpObject<TRef>>
{
  private readonly IEncoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public Structured Encode(ItestFieldGnrcPrntStrDomInpObject<TRef> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _ref);
}

internal class testDomGnrcPrntStrDomInpEncoder : IEncoder<ItestDomGnrcPrntStrDomInp>
{
  public Structured Encode(ItestDomGnrcPrntStrDomInp input)
    => new(input.Value);
}
