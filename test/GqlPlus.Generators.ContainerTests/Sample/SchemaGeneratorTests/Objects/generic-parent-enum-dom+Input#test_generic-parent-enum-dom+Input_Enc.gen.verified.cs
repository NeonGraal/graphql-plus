//HintName: test_generic-parent-enum-dom+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-dom+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
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

  internal static testGnrcPrntEnumDomInpEncoder Factory(IEncoderRepository r) => new(r);
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
    => input.EncodeEnum("EnumGnrcPrntEnumDomInp");

  internal static testEnumGnrcPrntEnumDomInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testDomGnrcPrntEnumDomInpEncoder : IEncoder<ItestDomGnrcPrntEnumDomInp>
{
  public Structured Encode(ItestDomGnrcPrntEnumDomInp input)
    => input.Value?.EncodeEnum("testEnumGnrcPrntEnumDomInp")!;

  internal static testDomGnrcPrntEnumDomInpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_generic_parent_enum_dom_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_generic_parent_enum_dom_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestGnrcPrntEnumDomInpObject>(testGnrcPrntEnumDomInpEncoder.Factory)
      .AddEncoder<testEnumGnrcPrntEnumDomInp>(testEnumGnrcPrntEnumDomInpEncoder.Factory)
      .AddEncoder<ItestDomGnrcPrntEnumDomInp>(testDomGnrcPrntEnumDomInpEncoder.Factory);
}
