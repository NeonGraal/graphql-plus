//HintName: test_generic-parent-string-dom+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent-string-dom+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_string_dom_Input;

internal class testGnrcPrntStrDomInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntStrDomInpObject>
{
  private readonly IEncoder<ItestFieldGnrcPrntStrDomInpObject<ItestDomGnrcPrntStrDomInp>> _itestFieldGnrcPrntStrDomInp = encoders.EncoderFor<ItestFieldGnrcPrntStrDomInpObject<ItestDomGnrcPrntStrDomInp>>();
  public Structured Encode(ItestGnrcPrntStrDomInpObject input)
    => _itestFieldGnrcPrntStrDomInp.Encode(input);

  internal static testGnrcPrntStrDomInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFieldGnrcPrntStrDomInpEncoder<TRef>(
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
    => input.Value!.Encode();

  internal static testDomGnrcPrntStrDomInpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_generic_parent_string_dom_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_generic_parent_string_dom_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestGnrcPrntStrDomInpObject>(testGnrcPrntStrDomInpEncoder.Factory)
      .AddEncoder<ItestDomGnrcPrntStrDomInp>(testDomGnrcPrntStrDomInpEncoder.Factory);
}
