//HintName: test_generic-parent-simple-enum+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-parent-simple-enum+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_simple_enum_Input;

internal class testGnrcPrntSmplEnumInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntSmplEnumInpObject>
{
  private readonly IEncoder<ItestFieldGnrcPrntSmplEnumInpObject<testEnumGnrcPrntSmplEnumInp>> _itestFieldGnrcPrntSmplEnumInp = encoders.EncoderFor<ItestFieldGnrcPrntSmplEnumInpObject<testEnumGnrcPrntSmplEnumInp>>();
  public Structured Encode(ItestGnrcPrntSmplEnumInpObject input)
    => _itestFieldGnrcPrntSmplEnumInp.Encode(input);

  internal static testGnrcPrntSmplEnumInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFieldGnrcPrntSmplEnumInpEncoder<TRef>(
  IEncoderRepository encoders
) : IEncoder<ItestFieldGnrcPrntSmplEnumInpObject<TRef>>
{
  private readonly IEncoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public Structured Encode(ItestFieldGnrcPrntSmplEnumInpObject<TRef> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _ref);
}

internal class testEnumGnrcPrntSmplEnumInpEncoder : IEncoder<testEnumGnrcPrntSmplEnumInp>
{
  public Structured Encode(testEnumGnrcPrntSmplEnumInp input)
    => input.EncodeEnum("EnumGnrcPrntSmplEnumInp");

  internal static testEnumGnrcPrntSmplEnumInpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_generic_parent_simple_enum_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_generic_parent_simple_enum_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestGnrcPrntSmplEnumInpObject>(testGnrcPrntSmplEnumInpEncoder.Factory)
      .AddEncoder<testEnumGnrcPrntSmplEnumInp>(testEnumGnrcPrntSmplEnumInpEncoder.Factory);
}
