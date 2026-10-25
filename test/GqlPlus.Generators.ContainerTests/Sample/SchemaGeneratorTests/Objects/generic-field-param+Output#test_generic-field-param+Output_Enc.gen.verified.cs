//HintName: test_generic-field-param+Output_Enc.gen.cs
// Generated from {CurrentDirectory}generic-field-param+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_param_Output;

internal class testGnrcFieldParamOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcFieldParamOutpObject>
{
  private readonly Encoder<ItestRefGnrcFieldParamOutp<ItestAltGnrcFieldParamOutp>> _itestRefGnrcFieldParamOutp = encoders.EncoderFor<ItestRefGnrcFieldParamOutp<ItestAltGnrcFieldParamOutp>>();
  public IGqlpValue Encode(ItestGnrcFieldParamOutpObject input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _itestRefGnrcFieldParamOutp);

  internal static testGnrcFieldParamOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefGnrcFieldParamOutpEncoder<TRef> : IEncoder<ItestRefGnrcFieldParamOutpObject<TRef>>
{
  public IGqlpValue Encode(ItestRefGnrcFieldParamOutpObject<TRef> input)
    => new GqlpUnit();
}

internal class testAltGnrcFieldParamOutpEncoder : IEncoder<ItestAltGnrcFieldParamOutpObject>
{
  public IGqlpValue Encode(ItestAltGnrcFieldParamOutpObject input)
    => new GqlpUnit()
      .Add("alt", input.Alt.Encode());

  internal static testAltGnrcFieldParamOutpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_generic_field_param_OutputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_generic_field_param_OutputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestGnrcFieldParamOutpObject>(testGnrcFieldParamOutpEncoder.Factory)
      .AddEncoder<ItestAltGnrcFieldParamOutpObject>(testAltGnrcFieldParamOutpEncoder.Factory);
}
