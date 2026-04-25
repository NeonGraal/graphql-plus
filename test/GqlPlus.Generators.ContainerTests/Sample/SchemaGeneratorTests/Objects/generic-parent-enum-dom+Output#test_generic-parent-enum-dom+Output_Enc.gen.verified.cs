//HintName: test_generic-parent-enum-dom+Output_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent-enum-dom+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_dom_Output;

internal class testGnrcPrntEnumDomOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntEnumDomOutpObject>
{
  private readonly IEncoder<ItestFieldGnrcPrntEnumDomOutpObject<ItestDomGnrcPrntEnumDomOutp>> _itestFieldGnrcPrntEnumDomOutp = encoders.EncoderFor<ItestFieldGnrcPrntEnumDomOutpObject<ItestDomGnrcPrntEnumDomOutp>>();
  public Structured Encode(ItestGnrcPrntEnumDomOutpObject input)
    => _itestFieldGnrcPrntEnumDomOutp.Encode(input);

  internal static testGnrcPrntEnumDomOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFieldGnrcPrntEnumDomOutpEncoder<TRef>(
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
    => input.EncodeEnum("EnumGnrcPrntEnumDomOutp");

  internal static testEnumGnrcPrntEnumDomOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testDomGnrcPrntEnumDomOutpEncoder : IEncoder<ItestDomGnrcPrntEnumDomOutp>
{
  public Structured Encode(ItestDomGnrcPrntEnumDomOutp input)
    => input.Value?.EncodeEnum("testEnumGnrcPrntEnumDomOutp") ?? Structured.Empty("testEnumGnrcPrntEnumDomOutp");

  internal static testDomGnrcPrntEnumDomOutpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_generic_parent_enum_dom_OutputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_generic_parent_enum_dom_OutputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestGnrcPrntEnumDomOutpObject>(testGnrcPrntEnumDomOutpEncoder.Factory)
      .AddEncoder<testEnumGnrcPrntEnumDomOutp>(testEnumGnrcPrntEnumDomOutpEncoder.Factory)
      .AddEncoder<ItestDomGnrcPrntEnumDomOutp>(testDomGnrcPrntEnumDomOutpEncoder.Factory);
}
