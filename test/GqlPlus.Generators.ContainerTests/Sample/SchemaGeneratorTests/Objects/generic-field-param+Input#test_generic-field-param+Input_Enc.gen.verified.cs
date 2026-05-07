//HintName: test_generic-field-param+Input_Enc.gen.cs
// Generated from {CurrentDirectory}generic-field-param+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_param_Input;

internal class testGnrcFieldParamInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcFieldParamInpObject>
{
  private readonly IEncoder<ItestRefGnrcFieldParamInp<ItestAltGnrcFieldParamInp>> _itestRefGnrcFieldParamInp = encoders.EncoderFor<ItestRefGnrcFieldParamInp<ItestAltGnrcFieldParamInp>>();
  public Structured Encode(ItestGnrcFieldParamInpObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestRefGnrcFieldParamInp);

  internal static testGnrcFieldParamInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefGnrcFieldParamInpEncoder<TRef> : IEncoder<ItestRefGnrcFieldParamInpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcFieldParamInpObject<TRef> input)
    => Structured.Empty();
}

internal class testAltGnrcFieldParamInpEncoder : IEncoder<ItestAltGnrcFieldParamInpObject>
{
  public Structured Encode(ItestAltGnrcFieldParamInpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt.Encode());

  internal static testAltGnrcFieldParamInpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_generic_field_param_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_generic_field_param_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestGnrcFieldParamInpObject>(testGnrcFieldParamInpEncoder.Factory)
      .AddEncoder<ItestAltGnrcFieldParamInpObject>(testAltGnrcFieldParamInpEncoder.Factory);
}
