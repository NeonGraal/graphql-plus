//HintName: test_generic-field-param+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}generic-field-param+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_field_param_Dual;

internal class testGnrcFieldParamDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcFieldParamDualObject>
{
  private readonly Encoder<ItestRefGnrcFieldParamDual<ItestAltGnrcFieldParamDual>> _itestRefGnrcFieldParamDual = encoders.EncoderFor<ItestRefGnrcFieldParamDual<ItestAltGnrcFieldParamDual>>();
  public IGqlpValue Encode(ItestGnrcFieldParamDualObject input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _itestRefGnrcFieldParamDual);

  internal static testGnrcFieldParamDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefGnrcFieldParamDualEncoder<TRef> : IEncoder<ItestRefGnrcFieldParamDualObject<TRef>>
{
  public IGqlpValue Encode(ItestRefGnrcFieldParamDualObject<TRef> input)
    => new GqlpUnit();
}

internal class testAltGnrcFieldParamDualEncoder : IEncoder<ItestAltGnrcFieldParamDualObject>
{
  public IGqlpValue Encode(ItestAltGnrcFieldParamDualObject input)
    => new GqlpUnit()
      .Add("alt", input.Alt.Encode());

  internal static testAltGnrcFieldParamDualEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_generic_field_param_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_generic_field_param_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestGnrcFieldParamDualObject>(testGnrcFieldParamDualEncoder.Factory)
      .AddEncoder<ItestAltGnrcFieldParamDualObject>(testAltGnrcFieldParamDualEncoder.Factory);
}
