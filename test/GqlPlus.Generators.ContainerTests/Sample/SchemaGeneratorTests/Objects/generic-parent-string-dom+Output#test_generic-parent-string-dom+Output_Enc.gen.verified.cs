//HintName: test_generic-parent-string-dom+Output_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent-string-dom+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_string_dom_Output;

internal class testGnrcPrntStrDomOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntStrDomOutpObject>
{
  private readonly IEncoder<ItestFieldGnrcPrntStrDomOutpObject<ItestDomGnrcPrntStrDomOutp>> _itestFieldGnrcPrntStrDomOutpObject<ItestDomGnrcPrntStrDomOutp> = encoders.EncoderFor<ItestFieldGnrcPrntStrDomOutpObject<ItestDomGnrcPrntStrDomOutp>>();
  public Structured Encode(ItestGnrcPrntStrDomOutpObject input)
    => _itestFieldGnrcPrntStrDomOutpObject<ItestDomGnrcPrntStrDomOutp>.Encode(input);
}

internal class testFieldGnrcPrntStrDomOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestFieldGnrcPrntStrDomOutpObject<TRef>>
{
  private readonly IEncoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public Structured Encode(ItestFieldGnrcPrntStrDomOutpObject<TRef> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _ref);
}

internal class testDomGnrcPrntStrDomOutpEncoder : IEncoder<ItestDomGnrcPrntStrDomOutp>
{
  public Structured Encode(ItestDomGnrcPrntStrDomOutp input)
    => new(input.Value);
}
